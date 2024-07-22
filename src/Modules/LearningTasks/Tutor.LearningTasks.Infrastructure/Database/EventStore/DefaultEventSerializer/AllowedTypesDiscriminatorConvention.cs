using Dahomey.Json;
using Dahomey.Json.Serialization.Conventions;
using System.Collections.Immutable;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Tutor.LearningTasks.Infrastructure.Database.EventStore.DefaultEventSerializer;

/// <summary>
/// Implements a Dahomey.Json discriminator policy, where the discriminator value is defined 
/// through a dictionary of discriminators for allowed types. 
/// For usage see: <see href="https://github.com/dahomey-technologies/Dahomey.Json#polymorphism"/>
/// </summary>
public class AllowedTypesDiscriminatorConvention<T> : IDiscriminatorConvention where T : notnull
{
    private readonly JsonSerializerOptions _options;
    private readonly ReadOnlyMemory<byte> _memberName;
    private readonly Dictionary<T, Type> _typesByDiscriminator = new();
    private readonly Dictionary<Type, T> _discriminatorsByType = new();
    private readonly JsonConverter<T> _jsonConverter;

    public ReadOnlySpan<byte> MemberName => _memberName.Span;

    public AllowedTypesDiscriminatorConvention(JsonSerializerOptions options, IImmutableDictionary<Type, T> allowedTypes)
        : this(options, allowedTypes, "$type")
    {
    }

    public AllowedTypesDiscriminatorConvention(JsonSerializerOptions options, IImmutableDictionary<Type, T> allowedTypes, string memberName)
    {
        _options = options;
        _memberName = Encoding.UTF8.GetBytes(memberName);
        _jsonConverter = options.GetConverter<T>();
        foreach (var (type, discriminator) in allowedTypes)
        {                
            _typesByDiscriminator.Add(discriminator, type);
            _discriminatorsByType.Add(type, discriminator);
            /*
             * Adding a (type, discriminator) pair to these dictionaries allows the convention to actually read and write
             * discriminators for that type, which shouldn't be enabled until TryRegisterType for that type is called. However, 
             * in a situation where:
             * 1. A hierarchy contains concrete class B, and its concrete superclass class A,
             * 2. Both instances of class A and class B need to be (de)serialized with discriminators,
             * 3. The Dahomey.Json DiscriminatorConventionRegistry.RegisterType method is called for class B first, and then for class A,
             * The current implementation of DiscriminatorConventionRegistry will not invoke the IDiscriminatorConvention.TryRegisterType
             * method for class A. This means that (de)serialization of instances of class A will fail.
             * 
             * This issue was circumvented in AllowedTypesDiscriminatorConvention by moving all necessary work for setting up types and
             * discriminators from the TryRegisterType method to the constructor. 
             * Usage of AllowedTypesDiscriminatorConvention doesn't change because of this, and DiscriminatorConventionRegistry.RegisterType
             * should still be called for all types that need to be supported. 
             */
        }
    }

    public bool TryRegisterType(Type type)
    {
        return _discriminatorsByType.ContainsKey(type);
    }

    public Type ReadDiscriminator(ref Utf8JsonReader reader)
    {
        T discriminator = _jsonConverter.Read(ref reader, typeof(T), _options);

        if (discriminator == null)
        {
            throw new JsonException("Null discriminator");
        }

        if (!_typesByDiscriminator.TryGetValue(discriminator, out Type type))
        {
            throw new JsonException($"Unknown type discriminator: {discriminator}");
        }
        return type;
    }

    public void WriteDiscriminator(Utf8JsonWriter writer, Type actualType)
    {
        if (!_discriminatorsByType.TryGetValue(actualType, out T discriminator))
        {
            throw new JsonException($"Unknown discriminator for type: {actualType}");
        }

        _jsonConverter.Write(writer, discriminator, _options);
    }
}
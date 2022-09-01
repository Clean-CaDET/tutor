using Dahomey.Json;
using Dahomey.Json.Serialization.Conventions;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Tutor.Infrastructure.Database.EventStore.DefaultEventSerializer
{
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
            foreach(var (type, discriminator) in allowedTypes)
            {
                _typesByDiscriminator.Add(discriminator, type);
                _discriminatorsByType.Add(type, discriminator);
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
                throw new JsonException($"Null discriminator");
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
}

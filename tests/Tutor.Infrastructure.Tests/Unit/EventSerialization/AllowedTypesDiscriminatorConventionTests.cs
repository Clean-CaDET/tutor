using Dahomey.Json;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.Json;
using Tutor.Infrastructure.Database.EventStore.DefaultEventSerializer;
using Tutor.Infrastructure.Tests.TestData;
using Xunit;

namespace Tutor.Infrastructure.Tests.Unit.EventSerialization
{
    public class AllowedTypesDiscriminatorConventionTests
    {
        [Theory]
        [MemberData(nameof(TypeRegistrationData))]
        public void Only_registers_allowed_types(Type typeToRegister, bool expected, IImmutableDictionary<Type, string> allowedTypes)
        {
            var convention = new AllowedTypesDiscriminatorConvention<string>(new JsonSerializerOptions(), allowedTypes);

            var result = convention.TryRegisterType(typeToRegister);

            result.ShouldBe(expected);
        }

        [Theory]
        [MemberData(nameof(SerializationData))]
        public void Serializes_and_deserializes_registered_types(object original, JsonSerializerOptions options)
        {
            var serialized = JsonSerializer.Serialize(original, SerializationTestClasses.AbstractRoot(), options);
            var deserialized = JsonSerializer.Deserialize(serialized, SerializationTestClasses.AbstractRoot(), options);

            deserialized.ShouldNotBeNull();
            deserialized.ShouldBeOfType(original.GetType());
            foreach (var property in original.GetType().GetProperties())
            {
                property.GetValue(deserialized).ShouldBe(property.GetValue(original));
            }
        }

        public static IEnumerable<object[]> TypeRegistrationData()
        {
            var testClasses = SerializationTestClasses.ConcreteWithDiscriminators();
            var testData = new List<object[]>()
            {
                new object[] { SerializationTestClasses.AbstractRoot(), false, testClasses },
                new object[] { typeof(string), false, testClasses },
                new object[] { typeof(Exception), false, testClasses }
            };

            foreach (Type testClass in testClasses.Keys)
            {
                testData.Add(new object[] { testClass, true, testClasses });
                testData.Add(new object[] { testClass, false, SerializationTestClasses.ConcreteWithDiscriminatorsWithout(testClass) });
            }

            return testData;
        }

        public static IEnumerable<object[]> SerializationData()
        {
            var testClasses = SerializationTestClasses.ConcreteWithDiscriminators();
            var options = new JsonSerializerOptions();
            options.SetupExtensions();
            var registry = options.GetDiscriminatorConventionRegistry();
            registry.ClearConventions();
            registry.RegisterConvention(new AllowedTypesDiscriminatorConvention<string>(options, testClasses));
            foreach (Type type in testClasses.Keys)
            {
                registry.RegisterType(type);
            }

            return SerializationTestClasses.ObjectsOfConcrete().Select(o => new[] { o, options });
        }
    }
}

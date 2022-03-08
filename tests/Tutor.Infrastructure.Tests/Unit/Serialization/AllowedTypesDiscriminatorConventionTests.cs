using Dahomey.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Tutor.Infrastructure.Serialization;
using Shouldly;
using Xunit;

namespace Tutor.Infrastructure.Tests.Unit.Serialization
{
    public class AllowedTypesDiscriminatorConventionTests
    {
        [Theory]
        [InlineData(typeof(ClassA), false)]
        [InlineData(typeof(ClassB), false)]
        [InlineData(typeof(ClassC), true)]
        [InlineData(typeof(ClassD), true)]
        [InlineData(typeof(ClassE), true)]
        [InlineData(typeof(ArgumentException), false)]
        public void Only_registers_allowed_types(Type typeToRegister, bool expected)
        {
            var convention = new AllowedTypesDiscriminatorConvention<string>(new JsonSerializerOptions(), allowedTypes);

            var result = convention.TryRegisterType(typeToRegister);

            result.ShouldBe(expected);
        }

        [Theory]
        [MemberData(nameof(ExampleObjects))]
        public void Serializes_and_deserializes_registered_types(ClassA original)
        {
            var serialized = JsonSerializer.Serialize(original, options);
            var deserialized = JsonSerializer.Deserialize<ClassA>(serialized, options);

            deserialized.ShouldNotBeNull();
            deserialized.ShouldBeOfType(original.GetType());
            foreach (var property in original.GetType().GetProperties())
            {
                property.GetValue(deserialized).ShouldBe(property.GetValue(original));
            }
        }

        public static IEnumerable<object[]> ExampleObjects() => new List<object[]>
        {
            new object[]
            {
                new ClassC() { FieldA = 2, FieldC = 3 }
            },
            new object[]
            {
                new ClassD() { FieldA = 2, FieldDE = 3 }
            },
            new object[]
            {
                new ClassE() { FieldA = 2, FieldDE = 3 }
            }
        };

        public AllowedTypesDiscriminatorConventionTests()
        {
            options = new JsonSerializerOptions();
            options.SetupExtensions();
            var registry = options.GetDiscriminatorConventionRegistry();
            registry.ClearConventions();
            registry.RegisterConvention(new AllowedTypesDiscriminatorConvention<string>(options, allowedTypes));
            foreach (Type type in allowedTypes.Keys)
            {
                registry.RegisterType(type);
            }
        }

        private JsonSerializerOptions options;
        private IDictionary<Type, string> allowedTypes = new Dictionary<Type, string>()
            {
                { typeof(ClassC), "classC" },
                { typeof(ClassD), "classD" },
                { typeof(ClassE), "classE" }
            };

        public abstract class ClassA
        {
            public int FieldA { get; set; }
        }

        public class ClassB : ClassA
        {
            public int FieldB { get; set; }
        }

        public class ClassC : ClassA
        {
            public int FieldC { get; set; }
        }

        public class ClassD : ClassB
        {
            public int FieldDE { get; set; }
        }

        public class ClassE : ClassB
        {
            public int FieldDE { get; set; }
        }
    }
}

using Dahomey.Json.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Tutor.Infrastructure.Tests.TestData
{
    public static class SerializationTestClasses
    {
        public static Type AbstractRoot() => typeof(ClassBase);

        public static IImmutableDictionary<Type, string> ConcreteWithDiscriminators() => new Dictionary<Type, string>()
        {
            { typeof(ClassB), "classB" },
            { typeof(ClassC), "classC"},
            { typeof(ClassD), "classD"},
            { typeof(ClassE), "classE"}
        }.ToImmutableDictionary();

        public static IImmutableDictionary<Type, string> ConcreteWithDiscriminatorsWithout(Type exclude)
        {
            var classes = ConcreteWithDiscriminators();
            if (classes.ContainsKey(exclude))
                classes = classes.Remove(exclude);
            return classes;
        }

        public static IEnumerable<object> ObjectsOfConcrete() => new List<object>()
        {
            new ClassB() { FieldA = 2, FieldB = 3 },
            new ClassC() { FieldA = 2, FieldC = 3 },
            new ClassD() { FieldA = 2, FieldDE = 3 },
            new ClassE() { FieldA = 2, FieldDE = 3 }
        };

        private abstract class ClassBase
        {
            internal int FieldA { get; set; }
        }

        private class ClassB : ClassBase
        {
            internal int FieldB { get; set; }
        }

        private sealed class ClassC : ClassBase
        {
            internal int FieldC { get; set; }
        }

        private sealed class ClassD : ClassB
        {
            internal int FieldDE { get; set; }
        }

        private sealed class ClassE : ClassB
        {
            internal int FieldDE { get; set; }
        }
    }
}

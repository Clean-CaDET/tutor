using System;
using System.Collections.Generic;

namespace Tutor.Infrastructure.Tests.TestData
{
    public static class SerializationTestClasses
    {
        public static Type AbstractRoot() => typeof(ClassA);

        public static IDictionary<Type, string> ConcreteWithDiscriminators() => new Dictionary<Type, string>()
        {
            { typeof(ClassB), "classB" },
            { typeof(ClassC), "classC"},
            { typeof(ClassD), "classD"},
            { typeof(ClassE), "classE"}
        };

        public static IDictionary<Type, string> ConcreteWithDiscriminatorsWithout(Type exclude)
        {
            var classes = ConcreteWithDiscriminators();
            if (classes.ContainsKey(exclude))
                classes.Remove(exclude);
            return classes;
        }

        public static IEnumerable<object> ObjectsOfConcrete() => new List<object>()
        {
            new ClassB() { FieldA = 2, FieldB = 3 },
            new ClassC() { FieldA = 2, FieldC = 3 },
            new ClassD() { FieldA = 2, FieldDE = 3 },
            new ClassE() { FieldA = 2, FieldDE = 3 }
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

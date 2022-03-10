namespace Tutor.Infrastructure.Tests.TestData
{
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

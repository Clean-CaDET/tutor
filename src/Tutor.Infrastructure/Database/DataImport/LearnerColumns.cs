namespace Tutor.Infrastructure.Database.DataImport
{
    public class LearnerColumns
    {
        public int Id { get; internal set; }
        public string StudentIndex { get; internal set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; internal set; }
        public string Salt { get; internal set; }
    }
}

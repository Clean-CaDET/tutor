namespace Tutor.Infrastructure.Database.DataImport.Domain.DomainExcelModel
{
    public class KCColumns
    {
        public int Id { get; internal set; }
        public string Code { get; internal set; }
        public string Name { get; internal set; }
        public string Description { get; internal set; }
        public int ExpectedDurationInMinutes { get; internal set; }
        public int UnitId { get; internal set; }
        public int ParentId { get; internal set; }
    }
}

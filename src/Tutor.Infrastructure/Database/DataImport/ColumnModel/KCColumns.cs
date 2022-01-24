namespace Tutor.Infrastructure.Database.DataImport.ColumnModel
{
    internal class KCColumns
    {
        public int Id { get; internal set; }
        public string Code { get; internal set; }
        public string Name { get; internal set; }
        public string Description { get; internal set; }
        public int UnitId { get; internal set; }
        public int ParentId { get; internal set; }
    }
}

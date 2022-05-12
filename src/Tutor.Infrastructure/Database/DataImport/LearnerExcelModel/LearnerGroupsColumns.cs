using System.Collections.Generic;

namespace Tutor.Infrastructure.Database.DataImport.LearnerExcelModel
{
    public class LearnerGroupsColumns
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public List<UserLearnerColumns> Learners { get; set; }
    }
}

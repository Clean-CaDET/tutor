using System.ComponentModel.DataAnnotations;

namespace Tutor.Web.Controllers.Learners
{
    public class LearnerDto
    {
        public int Id { get; set; }

        [RegularExpression("[A-Za-z]{2,3}-[0-9]{1,3}-[0-9]{4}")]
        public string Index { get; set; }
        
        public string Name { get; set; }
        
        public string Surname { get; set; }
    }
}
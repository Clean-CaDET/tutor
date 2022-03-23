using System.Collections.Generic;

namespace Naming.Domain
{
    /// <summary>
    /// ID izazova je dostupan na web prikazu.
    /// ** Nemoj da modifikuješ naziv namespace-a, Run klase i zaglavlja metoda ove klase. **
    /// 1. Identifikuj i preimenuj sve nejasne nazive tako da koriste domensku terminologiju.
    /// 2. Instrukcije "c.Status.Equals("enrolled") || c.Status.Equals("current")" možemo izdvojiti u zasebnu metodu
    ///     čiji naziv objašnjava značenje ove logike. Napravi ovakvu funkciju i dodeli joj domenski značajan naziv.
    /// </summary>
    public class CourseService
    {
        private const int Max = 6;
        public void Add(Course nc, Student s)
        {
            int i = 0;
            //Counts number of active courses
            foreach (var c in s.Courses)
            {
                if (c.Status.Equals("enrolled") || c.Status.Equals("current")) i++;
            }
            if (i < Max) //Check course limit
            {
                s.Courses.Add(nc);
            }
        }
    }

    public class Course
    {
        public string Status { get; set; }
    }

    public class Student
    {
        public List<Course> Courses { get; set; } = new List<Course>();
    }

    #region Run
    public class Run
    {
        private readonly Student _student = new Student();
        private readonly CourseService _service = new CourseService();

        public Run()
        {
            _service.Add(new Course { Status = "enrolled" }, _student);
            _service.Add(new Course { Status = "current" }, _student);
            _service.Add(new Course { Status = "enrolled" }, _student);
            _service.Add(new Course { Status = "current" }, _student);
            _service.Add(new Course { Status = "current" }, _student);
        }

        public void AddCourse()
        {
            _service.Add(new Course { Status = "enrolled" }, _student);
        }

        public int Count()
        {
            return _student.Courses.Count;
        }
    }
    #endregion
}
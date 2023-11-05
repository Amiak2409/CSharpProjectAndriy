namespace Zadanie2;

public class zadanie2A
{
    public class Student
    {
        private string _name;
        private int _studentId;
    
        public Student(string nameStudent, int IdStudent)
        {
            _name = nameStudent;
            _studentId = IdStudent;
        }
        
        public string GetName()
        {
            return _name;
        }
    
        public int GetStudentId()
        {
            return _studentId;
        }
    }
    
    public class Course
    {
        private string _name;
        private List<Student> _students;
        
    
        public Course(string name)
        {
            _name = name;
            _students = new List<Student>();
        }
    
        public List<Student> GetStudents()
        {
            return _students;
        }
        public void AddStudent(Student stud)
        {
            _students.Add(stud);
        }
    
        public void RemoveStudent(Student stud)
        {
            _students.Remove(stud);
        }
    }
}
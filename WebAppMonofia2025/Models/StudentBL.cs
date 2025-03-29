namespace WebAppMonofia2025.Models
{
    public class StudentBL
    {
        List<Student> Students;
        public StudentBL()
        {
            Students = new List<Student>()
            {
                new(){Id=1,Name="Ahmed",Address="Alex" ,ImageURL="m.png"},
                new(){Id=2,Name="Mohamed",Address="Alex" ,ImageURL="m.png"},
                new(){Id=3,Name="Asma",Address="Alex" ,ImageURL="2.jpg"},
                new(){Id=4,Name="Sara",Address="Alex" ,ImageURL="2.jpg"}
            };

        }

        public List<Student> GetAll()
        {
            return Students;
        }

        public Student GetByID(int id)
        {
            return Students.FirstOrDefault(s => s.Id == id);
        }
    }
}

namespace WebAppMonofia2025.Repository
{
    public class DepartmentRepository:IDepartmentRepository
    {
        ITIContext context;
       
        public string ID { get; set; }

        public DepartmentRepository(ITIContext _Context)
        {
            context = _Context;//new ITIContext();
            ID = Guid.NewGuid().ToString();//unique id
        }

        //CRUD (Create - REad - Update -Delete)
        public List<Department> GetAll()
        {
            return context.Department.ToList();
        }

        public Department GetByID(int id)
        {
            return context.Department.FirstOrDefault(d => d.Id == id);
        }

        public void Add(Department obj)
        {
            context.Department.Add(obj);
        }

        public void Update(Department obj) {
            context.Update(obj);
        }

        public void Delete(int id)
        {
            Department dept = GetByID(id);
            context.Department.Remove(dept);
        }

        public int Save()
        {
            return  context.SaveChanges();
        }
    }
}

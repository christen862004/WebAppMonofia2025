namespace WebAppMonofia2025.Repository
{
    public class EmployeeRepository:IEmployeeRepository
    {
        ITIContext context;
        public EmployeeRepository(ITIContext _Context)
        {
            context = _Context;
        }

        //CRUD (Create - REad - Update -Delete)
        public List<Employee> GetAll()
        {
            return context.Employee.ToList();
        }

        public Employee GetByID(int id)
        {
            return context.Employee.FirstOrDefault(e =>e.Id == id);
        }

        public void Add(Employee obj)
        {
            context.Employee.Add(obj);
        }

        public void Update(Employee obj)
        {
            context.Update(obj);
        }

        public void Delete(int id)
        {
            Employee Emp = GetByID(id);
            context.Employee.Remove(Emp);
        }

        public int Save()
        {
            return context.SaveChanges();
        }
    }
}

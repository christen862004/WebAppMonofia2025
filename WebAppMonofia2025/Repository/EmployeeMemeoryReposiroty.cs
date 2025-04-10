
namespace WebAppMonofia2025.Repository
{
    public class EmployeeMemeoryReposiroty : IEmployeeRepository
    {
        public void Add(Employee obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAll()
        {
            return new List<Employee>
            {
                new Employee(){Id=1,Name="Ahemd"},
                new Employee(){Id=2,Name="Mohamed"},
            };
        }

        public List<Employee> GetByDeptId(int deptID)
        {
            throw new NotImplementedException();
        }

        public Employee GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public int Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Employee obj)
        {
            throw new NotImplementedException();
        }
    }
}

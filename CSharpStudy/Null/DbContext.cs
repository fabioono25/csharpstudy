namespace CSharpStudy.Null
{
    public class DbContext
    {
        public Employee Find(int id){
            return null;
        }
    }

    public class Employee{
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public interface IEmployeeRepository{
        //Employee GetById(int id);
        Option<Employee> GetById(int id);
    }

    //o resultado esperado é uma instancia de Employee...
    //contudo, pode ser null
    //para mitigar esse problema, a proposta é criar um container indicando o resultado "sem resultado"
    public class EmployeeRepository : IEmployeeRepository
    {
        //public Employee GetById(int id) => new DbContext().Find(id);

        public Option<Employee> GetById(int id)
        {
            throw new System.NotImplementedException();
        }
    }

    public struct Option<T>{
        
    }
}
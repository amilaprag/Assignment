namespace Assignment.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }

        public List<Employee> Employee { get; set; }
    }
}
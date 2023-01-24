using TAKSCODE5.Models.Base;

namespace TAKSCODE5.Models
{
    public class Pozition:BaseId
    {
        public string Name { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}

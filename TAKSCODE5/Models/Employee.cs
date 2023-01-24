using TAKSCODE5.Models.Base;

namespace TAKSCODE5.Models
{
    public class Employee:BaseId
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Pozition { get; set; }
        public string Description { get; set; }
        public string Instagram { get; set; }
        public string Twitter { get; set; }
        public string Facebook { get; set; }
        public string LinkEdin { get; set; }
    }
}

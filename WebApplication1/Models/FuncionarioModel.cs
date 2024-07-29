using System.ComponentModel.DataAnnotations;
using WebApplication1.Enums;

namespace WebApplication1.Models
{
    public class FuncionarioModel
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string lastName { get; set;}
        public DepartmentEnum department { get; set; }
        public bool active { get; set; }
        public TurnEnums turn { get; set; }
        public DateTime creationDate { get; set; } = DateTime.Now.ToLocalTime();
        public DateTime changeDate { get; set; } = DateTime.Now.ToLocalTime();
    }
}

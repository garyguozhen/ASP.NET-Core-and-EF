using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chapter4_LeaveManagementSystem.Web.Data
{
    public class LeaveType
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName ="nvarchar(150)")]
        public string? Name { get; set; }
        public int NumberofDays { get; set; }
    }
}

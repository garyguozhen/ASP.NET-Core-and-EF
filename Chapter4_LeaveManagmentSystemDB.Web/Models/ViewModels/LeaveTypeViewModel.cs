using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Chapter4_LeaveManagmentSystemDB.Web.Models.ViewModels
{
    public class LeaveTypeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public int Days { get; set; }
    }
    public class LeaveTypeCreateView
    {
        [Required]
        [Length(4,150,ErrorMessage ="Name必填")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [Range(1,90)]
        public int Days { get; set; }
    }
}

using Chapter4_LeaveManagmentSystemDB.Web.Models.ViewModels;

namespace Chapter4_LeaveManagmentSystemDB.Web.Services
{
    public interface ILeaveTypeServices
    {
        Task Create(LeaveTypeCreateView createView);
        Task Edit(LeaveTypeViewModel viewModel);
        Task<T> Get<T>(int id) where T : class;
        Task<List<LeaveTypeViewModel>> GetLeaveTypesAsync();
        Task Remove(int id);
        bool LeaveTypeExists(int id);
    }
}
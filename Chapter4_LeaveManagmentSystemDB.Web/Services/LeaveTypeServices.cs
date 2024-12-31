using AutoMapper;
using Chapter4_LeaveManagementSystem.Web.Data;
using Chapter4_LeaveManagmentSystemDB.Web.Data;
using Chapter4_LeaveManagmentSystemDB.Web.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Chapter4_LeaveManagmentSystemDB.Web.Services
{
    public class LeaveTypeServices : ILeaveTypeServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public LeaveTypeServices(ApplicationDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<List<LeaveTypeViewModel>> GetLeaveTypesAsync()
        {
            var data = await _context.LeaveTypes.ToListAsync();
            var viewData = _mapper.Map<List<LeaveTypeViewModel>>(data);
            return viewData;
        }
        public async Task<T> Get<T>(int id) where T : class
        {
            var data = await _context.LeaveTypes.FirstOrDefaultAsync(x => x.Id == id);
            if (data == null)
            {
                return null;
            }

            var viewData = _mapper.Map<T>(data);
            return viewData;
        }
        public async Task Create(LeaveTypeCreateView createView)
        {
            var leaveType = _mapper.Map<LeaveType>(createView);
            _context.LeaveTypes.Add(leaveType);
            await _context.SaveChangesAsync();
        }
        public async Task Edit(LeaveTypeViewModel viewModel)
        {
            var leaveType = _mapper.Map<LeaveType>(viewModel);
            _context.Update(leaveType);
            await _context.SaveChangesAsync();
        }
        public async Task Remove(int id)
        {
            var data = await _context.LeaveTypes.FirstOrDefaultAsync(x => x.Id == id);
            if (data != null)
            {
                _context.Remove(data);
                await _context.SaveChangesAsync();
            }
        }
        public bool LeaveTypeExists(int id)
        {
            return _context.LeaveTypes.Any(e => e.Id == id);
        }
    }
}

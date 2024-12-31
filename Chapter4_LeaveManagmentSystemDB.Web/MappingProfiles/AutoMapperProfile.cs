using AutoMapper;
using Chapter4_LeaveManagementSystem.Web.Data;
using Chapter4_LeaveManagmentSystemDB.Web.Models.ViewModels;

namespace Chapter4_LeaveManagmentSystemDB.Web.MappingProfiles
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile() { 
            CreateMap<LeaveType,LeaveTypeViewModel>()
                .ForMember(dest=>dest.Days,opt=>opt.MapFrom(src=>src.NumberofDays));
            CreateMap< LeaveTypeCreateView,LeaveType>()
                .ForMember(dest=>dest.NumberofDays,opt=>opt.MapFrom(src=>src.Days)); 
            CreateMap<LeaveTypeViewModel, LeaveType>()
                .ForMember(dest => dest.NumberofDays, opt => opt.MapFrom(src => src.Days));
        }
    }
}

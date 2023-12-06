using AutoMapper;
using BackendEss.Dtos.Project;
using BackendEss.Dtos.Tasks;
using BackendEss.Dtos.User;
using BackendEss.Model;

namespace BackendEss
{
    public class AutoMapperProfile :Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AddTaskDTO, Tasks>();
            CreateMap<AppUsers, GetUserDTO>();
            CreateMap<AppUsers, UserTaskDTO>()
                .ForMember(dest => dest.UserID, opt => opt.MapFrom(src => src.UserID))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Tasks, opt => opt.MapFrom(src => src.Tasks));

            CreateMap<Tasks, TaskDTO>()
                .ForMember(dest => dest.TaskID, opt => opt.MapFrom(src => src.TaskID))
                .ForMember(dest => dest.TaskName, opt => opt.MapFrom(src => src.TaskName))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.JiraID, opt => opt.MapFrom(src => src.JiraID))
                .ForMember(dest => dest.JiraLink, opt => opt.MapFrom(src => src.JiraLink))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.TaskStartTime))
                .ForMember(dest => dest.HoursSpent, opt => opt.MapFrom(src => src.HoursSpent))
                .ForMember(dest => dest.Project, opt => opt.MapFrom(src => src.Project));

            CreateMap<Project, ProjectDTO>()
                .ForMember(dest => dest.ProjectID, opt => opt.MapFrom(src => src.ProjectID))
                .ForMember(dest => dest.ProjectName, opt => opt.MapFrom(src => src.ProjectName));
        }
    }
}

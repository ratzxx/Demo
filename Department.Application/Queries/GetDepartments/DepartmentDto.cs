using AutoMapper;
using Department.Application.Common.Mappings;

namespace Department.Application.Queries.GetDepartments
{
    public class DepartmentDto : IMapFrom<Domain.Entities.Department>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Department, DepartmentDto>();
        }
    }
}

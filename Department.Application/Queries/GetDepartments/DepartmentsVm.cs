using System.Collections.Generic;

namespace Department.Application.Queries.GetDepartments
{
    public class DepartmentsVm
    {
        public IList<DepartmentDto> Departments { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace User.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public int DepartmentId { get; set; }
    }
}

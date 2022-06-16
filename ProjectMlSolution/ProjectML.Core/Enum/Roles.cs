using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectML.Core.Enum
{
    public enum Roles
    {
        [Display(Name = "System")]
        System,
        [Display(Name = "Администратор")]
        Admin,
        [Display(Name = "Учитель")]
        Teacher,
        [Display(Name = "Студент")]
        Student
    }
}

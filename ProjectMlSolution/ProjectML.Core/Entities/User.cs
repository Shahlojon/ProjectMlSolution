using Microsoft.AspNetCore.Identity;
using ProjectML.Core.Enum;
using ProjectML.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectML.Core.Models
{
    public class User:IdentityUser<int>
    {
        public string FIO { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        //[Column(TypeName = "Enum")]
        public Roles Role { get; set; }
        //public int GroupId { get; set; }

        public virtual Group Group { get; set; }
    }
}

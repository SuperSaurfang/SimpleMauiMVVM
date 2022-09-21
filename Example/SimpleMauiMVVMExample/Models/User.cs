using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMauiMVVMExample.Models
{
    public enum Gender
    {
        Male,
        Female,
        Other,
    }
    public class User
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public Gender Gender { get; set; }
    }
}

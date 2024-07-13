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
        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public Gender Gender { get; set; }
    }
}

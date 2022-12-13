using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsDisabled { get; set; }
        public int NumberOfFiles { get; set; }
        public long  SumOfFilesSize { get; set; }
        public virtual List<File> Files { get; set; } 
        public virtual UserLimit UserLimit { get; set; }
    }
}

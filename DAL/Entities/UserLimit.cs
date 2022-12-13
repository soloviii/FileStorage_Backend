using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities
{
    public class UserLimit 
    {
        public Guid Id { get; set; }
        public int? MaxFilesNumber { get; set; }
        public long? MaxFileSize { get; set; }
        public long? MaxStorageSize { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}

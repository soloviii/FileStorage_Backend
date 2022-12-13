using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class UserLimitModel
    {
        public Guid Id { get; set; }
        public int? MaxFilesNumber { get; set; }
        public long? MaxFileSize { get; set; }
        public long? MaxStorageSize { get; set; }
        public string UserId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class FileModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public long Size { get; set; }
        public Guid UserId { get; set; }
    }
}

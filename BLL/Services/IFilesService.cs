using BLL.Models;
using System;
using System.Collections.Generic;

namespace BLL.Services
{
    public interface IFilesService
    {
        void UploadFiles(FileModel[] fileModels);
        void RemoveFiles(Guid id);  
        FileModel GetFile(Guid id);
        List<FileModel> GetAllFiles(Guid id);
    }
}
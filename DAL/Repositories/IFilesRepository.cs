using DAL.Entities;
using System;
using System.Collections.Generic;

namespace DAL.Repositories
{
    public interface IFilesRepository
    {
        void CreateFiles(File[] files);
        List<File> GetFiles(Guid id);
        File GetFileById(Guid id);
        bool RemoveFiles(Guid id);
    }
}
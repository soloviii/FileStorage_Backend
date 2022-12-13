using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    public class FilesRepository : IFilesRepository
    {
        private readonly ApplicationDbContext _dbcontext;
        public FilesRepository(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public void CreateFiles(File[] files)
        {
            _dbcontext.Files.AddRange(files);
        }

        public bool RemoveFiles(Guid id)
        {
            var fileToDelete = _dbcontext.Files.Find(id);
            if (fileToDelete == null) return false;

            _dbcontext.Files.Remove(fileToDelete);
            return true;
        }

        public File GetFileById(Guid id)
        {
            return _dbcontext.Files.Find(id);
        }

        public List<File> GetFiles(Guid id)
        {
            return _dbcontext.Files.Where(file => file.UserId == id.ToString()).ToList();
        }
    }
}

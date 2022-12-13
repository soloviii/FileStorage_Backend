using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private FilesRepository _filesRepository;
        private UserLimitRepository _userLimitRepository; 
        private ApplicationDbContext _dbcontext;
        public UnitOfWork(ApplicationDbContext dbcontext) 
        {
            _dbcontext = dbcontext;
        }
        public IFilesRepository FilesRepository 
        {
            get
            {
                if (_filesRepository == null)
                {
                    _filesRepository = new FilesRepository(_dbcontext);
                }
                return _filesRepository;
            }
        }

        public IUserLimitRepository UserLimitRepository
        {
            get
            {
                if (_userLimitRepository == null)
                {
                    _userLimitRepository = new UserLimitRepository(_dbcontext);
                }
                return _userLimitRepository; 
            }
        }

        public void SaveChanges()
        {
            _dbcontext.SaveChanges();
        }
    }
}

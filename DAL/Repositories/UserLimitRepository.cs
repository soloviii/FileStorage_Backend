using DAL.Entities;
using System;
using System.Linq;

namespace DAL.Repositories
{
    public class UserLimitRepository : IUserLimitRepository
    {
        private readonly ApplicationDbContext _dbcontext;
        public UserLimitRepository(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public UserLimit GetLimitByUserId(Guid? userId)
        {
            var isNull = userId?.ToString();
            var limits = _dbcontext.UserLimit.Where(limit => limit.UserId == isNull).FirstOrDefault();
            if (limits is null)
                return _dbcontext.UserLimit.Where(limit => limit.UserId == null).FirstOrDefault();
            return limits;
        }

        public void CreateOrUpdateUserLimit(UserLimit userLimit)
        {
            var exist = _dbcontext.UserLimit
                                   .Where(limit => limit.UserId == userLimit.UserId)
                                   .FirstOrDefault();
            if (exist is null)
            {
                if (userLimit.UserId == "")
                    userLimit.UserId = null;
                _dbcontext.UserLimit.Add(userLimit);
            }
            else
            {
                userLimit.Id = exist.Id;
                _dbcontext.Entry(exist).CurrentValues.SetValues(userLimit);
            }
        }

        public bool RemoveUserLimit(Guid userId)
        {
            var exist = _dbcontext.UserLimit
                                   .Where(limit => limit.UserId == userId.ToString())
                                   .FirstOrDefault();
            if (exist is null)
                return false;
            _dbcontext.UserLimit.Remove(exist);
            return true;
        }
    }
}

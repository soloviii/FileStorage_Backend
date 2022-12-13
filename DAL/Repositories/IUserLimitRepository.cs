using DAL.Entities;
using System;

namespace DAL.Repositories
{
    public interface IUserLimitRepository
    { 
        UserLimit GetLimitByUserId(Guid? userId);
        void CreateOrUpdateUserLimit(UserLimit userLimit);
        bool RemoveUserLimit(Guid userId);
    }
}
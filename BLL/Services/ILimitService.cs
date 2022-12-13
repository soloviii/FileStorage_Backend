using BLL.Models;
using DAL.Entities;
using System;

namespace BLL.Services
{
    public interface ILimitService
    {
        void CreateOrUpdateLimitForUser(UserLimit userLimit);
        UserLimitModel GetLimits(Guid? userId);
        bool RemoveLimit(Guid userId);
    }
}
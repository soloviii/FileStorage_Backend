using AutoMapper;
using BLL.Models;
using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class LimitService : ILimitService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public LimitService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public void CreateOrUpdateLimitForUser(UserLimit userLimit)  
        {
            _unitOfWork.UserLimitRepository.CreateOrUpdateUserLimit(userLimit); 
            _unitOfWork.SaveChanges();
        }
        public UserLimitModel GetLimits(Guid? userId)   
        {
            var unmappedFile =  _unitOfWork.UserLimitRepository.GetLimitByUserId(userId);
            var mappedFile = _mapper.Map<UserLimit, UserLimitModel>(unmappedFile);
            return mappedFile;
        }
        public bool RemoveLimit(Guid userId) 
        {
            var isRemove = _unitOfWork.UserLimitRepository.RemoveUserLimit(userId);
            _unitOfWork.SaveChanges();
            return isRemove;
        }
    }
}

using AutoMapper;
using BLL.Models;
using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Services
{
    public class FilesService : IFilesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public FilesService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<FileModel> GetAllFiles(Guid id)
        {
            var unmappedFiles = _unitOfWork.FilesRepository.GetFiles(id);
            var mappedFiles = _mapper.Map<List<File>, List<FileModel>>(unmappedFiles);
            return mappedFiles;
        }

        public FileModel GetFile(Guid id)
        {
            var unmappedFile = _unitOfWork.FilesRepository.GetFileById(id);
            var mappedFile = _mapper.Map<File, FileModel>(unmappedFile);
            return mappedFile;
        }

        public void UploadFiles(FileModel[] fileModels)
        {
            var mappedFile = _mapper.Map<FileModel[], File[]>(fileModels);
            _unitOfWork.FilesRepository.CreateFiles(mappedFile);
            _unitOfWork.SaveChanges();
        }

        public void RemoveFiles(Guid id) 
        {
            if (!_unitOfWork.FilesRepository.RemoveFiles(id))
                throw new KeyNotFoundException($"Файл з таким ідентифікатором доступу ({id}) не існує");
            _unitOfWork.SaveChanges();
        }
    }
}

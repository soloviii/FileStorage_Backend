using BLL.Models;
using BLL.Services;
using DAL.Configuration;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FileStorage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFilesService _filesService;
        private readonly UserManager<User> _userManager;
        private readonly ILimitService _limitService;
        public FileController(IFilesService filesService, UserManager<User> userManager,
            ILimitService limitService)
        {
            _filesService = filesService;
            _userManager = userManager;
            _limitService = limitService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetFiles()
        {
            var user = await _userManager.GetUserAsync(User);
            var allFiles = _filesService.GetAllFiles(Guid.Parse(user.Id));
            return Ok(allFiles);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetFile(Guid id)
        {
            var file = _filesService.GetFile(id);
            if (file is null)
                return NotFound();
            return Ok(file);
        }

        [Authorize]
        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> Upload([FromForm] IFormFileCollection files)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user.IsDisabled)
                return BadRequest(new { message = $"Користувач `{user.FirstName}` у чорному списку(" });
            try
            {
                var folderName = Path.Combine("Resources", "Files", user.Id.ToString());
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (!System.IO.Directory.Exists(pathToSave))
                    System.IO.Directory.CreateDirectory(pathToSave);

                var userLimits = _limitService.GetLimits(Guid.Parse(user.Id));
                var numberOfFiles = files.Count;
                if (userLimits.MaxFilesNumber < user.NumberOfFiles + numberOfFiles)
                    return BadRequest("Вибачте, ви перевищили ліміт на кількість файлів (" +
                        $"поточна кількість - '{user.NumberOfFiles + numberOfFiles}' > максимальна - '{userLimits.MaxFilesNumber}')");
                user.NumberOfFiles += numberOfFiles;
                long sizeOfFiles = 0;
                if (numberOfFiles > 0)
                {
                    string fullPath = "";
                    foreach (var file in files)
                    {
                        if (userLimits.MaxFileSize < file.Length)
                            return BadRequest("Вибачте, ви перевищили ліміт на максимальний розмір файлу (" +
                                $"Файл - `{file.FileName}` має поточний розмір - '{file.Length}' > максимальний - '{userLimits.MaxFileSize}')");
                        var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                        fullPath = Path.Combine(pathToSave, fileName);
                        sizeOfFiles += file.Length;
                        if (System.IO.File.Exists(fullPath))
                        {
                            return BadRequest($"Файл {fileName} з таким ім'ям вже існує");
                        }
                    }
                    if (userLimits.MaxStorageSize < user.SumOfFilesSize + sizeOfFiles)
                        return BadRequest("Вибачте, ви перевищили ліміт на максимальний розмір сховища (" +
                            $"поточний розмір - '{user.SumOfFilesSize + sizeOfFiles}' > максимальний - '{userLimits.MaxStorageSize}')");
                    user.SumOfFilesSize += sizeOfFiles;
                    var allFileModels = new List<FileModel>();
                    foreach (var file in files)
                    {
                        var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                        fullPath = Path.Combine(pathToSave, fileName);
                        var dbPath = Path.Combine(folderName, fileName);

                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }

                        allFileModels.Add(
                            new FileModel
                            {
                                Name = fileName,
                                Size = file.Length,
                                Path = dbPath,
                                UserId = Guid.Parse(user.Id)
                            });
                    }
                    _filesService.UploadFiles(allFileModels.ToArray());
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [Authorize]
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            var user = await _userManager.GetUserAsync(User);
            var file = _filesService.GetFile(id);
            if (file is null)
                return NotFound();
            if (file.UserId != Guid.Parse(user.Id) &&
                await _userManager.IsInRoleAsync(user, Constants.REGISTEREDUSER))
                return BadRequest($"Цей файл не належить цьому користувачеві - {user.FirstName}");
            var folderName = Path.Combine("Resources", "Files", file.UserId.ToString());
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            var currentUser = await _userManager.FindByIdAsync(file.UserId.ToString());
            var fullPath = Path.Combine(pathToSave, file.Name);
            if (!System.IO.File.Exists(fullPath))
                return BadRequest($"Файл з таким іменем - {file.Name} вже видалено");
            FileInfo info = new FileInfo(fullPath);
            currentUser.SumOfFilesSize -= info.Length;
            currentUser.NumberOfFiles -= 1;
            _filesService.RemoveFiles(id);
            System.IO.File.Delete(fullPath);
            return Ok(); 
        }

        [HttpGet, DisableRequestSizeLimit]
        [Route("download/{id}")]
        public IActionResult Download(Guid id)
        {
            var fileName = _filesService.GetFile(id).Name;
            var userId = _filesService.GetFile(id).UserId;
            var folderName = Path.Combine("Resources", "Files", userId.ToString());
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            var fullPath = Path.Combine(pathToSave, fileName);
            var fileContent = new FileStream(fullPath, FileMode.Open);
            return File(fileContent, GetContentType(fullPath));
        }

        private string GetContentType(string path)
        {
            var provider = new FileExtensionContentTypeProvider();

            if (!provider.TryGetContentType(path, out string contentType))
            {
                contentType = "application/octet-stream";
            }

            return contentType;
        }
    }
}

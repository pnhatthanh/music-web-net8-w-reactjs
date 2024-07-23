using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;

namespace MusicApi.Helper.Helpers
{
    public class FileHelper
    {
        //Upload file in sql server
       // private readonly SqlConnection _connection;
        private readonly Cloudinary cloudinary;
        private readonly ILogger<FileHelper> _logger;
        public FileHelper(Cloudinary cloud, ILogger<FileHelper> logger)
        {
            cloudinary = cloud;
            _logger = logger;
            //_connection = new SqlConnection("Server=ADMIN;Database=MusicFile;Trusted_Connection=True;TrustServerCertificate=True");
        }

        //Using Cloudinary
        public async Task<string> UploadFileImage(IFormFile fileImage)
        {
            if (fileImage.Length == 0)
            {
                throw new ArgumentException("File image cannot empty");
            }
            if (fileImage.Length > 10 * 1024 * 1024)
            {
                throw new ArgumentException("File is too large. Maximum allowed size is 10Mb");
            }
            var validExtension = new[] { ".png", ".jpg" };
            var fileExtension = Path.GetExtension(fileImage.FileName).ToLowerInvariant();
            if (!Array.Exists(validExtension, extention => extention == fileExtension))
            {
                throw new ArgumentException("Invalid file extension. Only .png, .jpg are allowed");
            }
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(Guid.NewGuid().ToString() + fileExtension
                                           ,fileImage.OpenReadStream()),
                Folder="Images"
            };
            var uploadResult = await cloudinary.UploadAsync(uploadParams);
            return uploadResult.SecureUrl.ToString();
        }
        public async Task<string> UploadFileAudio(IFormFile fileAudio)
        {
            if (fileAudio.Length == 0)
            {
                throw new ArgumentException("File image cannot empty");
            }
            if (fileAudio.Length > 20 * 1024 * 1024)
            {
                throw new ArgumentException("File is too large. Maximum allowed size is 20Mb");
            }
            var validExtension = new[] { ".mp3", ".wav" };
            var fileExtension = Path.GetExtension(fileAudio.FileName).ToLowerInvariant();
            if (!Array.Exists(validExtension, extention => extention == fileExtension))
            {
                throw new ArgumentException("Invalid file extension. Only .mp3, .wav are allowed");
            }
            var uploadParams = new RawUploadParams
            {
                File = new FileDescription(Guid.NewGuid().ToString() + fileExtension
                                           , fileAudio.OpenReadStream()),
                Folder = "Audios"
            };
            var uploadResult = await cloudinary.UploadAsync(uploadParams);
            _logger.LogInformation(uploadResult.PublicId);
            return uploadResult.SecureUrl.ToString();
        }
        public async Task DeleteImageFile(string fileName)
        {
            var uri = new Uri(fileName);
            var segments = uri.Segments;
            var publicId = Path.Combine(segments[^2], Path.GetFileNameWithoutExtension(segments[^1]));
            var deleteParams = new DeletionParams(publicId);
            await cloudinary.DestroyAsync(deleteParams);
        }
        public async Task DeleteAudioFile(string fileName)
        {
            var uri = new Uri(fileName);
            var segments = uri.Segments;
            var publicId = Path.Combine(segments[^2], segments[^1]);
            var deleteParams = new DeletionParams(publicId)
            {
                ResourceType=ResourceType.Raw
            };
            await cloudinary.DestroyAsync(deleteParams);
        }



        //Using Sql Server lỏ :))
        //public async Task<string> UploadFileImage(IFormFile file)
        //{
        //    if (file.Length == 0)
        //    {
        //        throw new ArgumentException("File image cannot empty");
        //    }
        //    //Check size < 10MB
        //    if (file.Length > 10 * 1024 * 1024)
        //    {
        //        throw new ArgumentException("File is too large. Maximum allowed size is 2Mb");
        //    }
        //    //Check extension
        //    var validExtension = new[] { ".png", ".jpg" };
        //    var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();
        //    if (!Array.Exists(validExtension, extention => extention == fileExtension))
        //    {
        //        throw new ArgumentException("Invalid file extension. Only .png, .jpg are allowed");
        //    }
        //    var fileName = Guid.NewGuid().ToString() + fileExtension;
        //    await _connection.OpenAsync();
        //    var command = new SqlCommand("INSERT INTO Images(NameImage, FileImage) " +
        //        "VALUES (@FileName, @MusicFile)", _connection);
        //    command.Parameters.AddWithValue("@FileName", fileName);
        //    command.Parameters.AddWithValue("@MusicFile", await ConvertToByteArrayAsync(file));
        //    try
        //    {
        //        await command.ExecuteNonQueryAsync();
        //    }
        //    catch (Exception)
        //    {
        //        _connection.Close();
        //        throw;
        //    }
        //    _connection.Close();
        //    return fileName;
        //}
        //public async Task<byte[]> GetFileImage(string fileName)
        //{

        //    SqlCommand command = new SqlCommand("SELECT FileImage FROM Images WHERE NameImage = @FileName", _connection);
        //    command.Parameters.AddWithValue("@FileName", fileName);
        //    try
        //    {
        //        await _connection.OpenAsync();
        //        var reader = await command.ExecuteReaderAsync();
        //        if (!await reader.ReadAsync())
        //        {
        //            throw new Exception("Not found");
        //        }
        //        var result = (byte[])reader["FileImage"];
        //        _connection.Close();
        //        return result;
        //    }
        //    catch (Exception)
        //    {
        //        _connection?.Close();
        //        throw;
        //    }
        //}
        //public async Task DeleteImageFile(string fileName)
        //{
        //    await _connection.OpenAsync();
        //    SqlCommand command = new SqlCommand("DELETE FROM Images WHERE NameImage=@FileName", _connection);
        //    command.Parameters.AddWithValue("@FileName", fileName);
        //    try
        //    {
        //        await command.ExecuteNonQueryAsync();
        //        _connection.Close();
        //    }
        //    catch (Exception)
        //    {
        //        _connection.Close();
        //        throw;
        //    }
        //}
        //public async Task<string> UploadFileAudio(IFormFile fileAudio)
        //{
        //    //Check file empty
        //    if (fileAudio.Length == 0)
        //    {
        //        throw new ArgumentException("File audio cannot empty");
        //    }
        //    //Check size file <20MB
        //    if (fileAudio.Length > 20 * 1024 * 1024)
        //    {
        //        throw new ArgumentException("File is too large. Maximum allowed size is 20Mb");
        //    }
        //    //Check extension 
        //    var validExtension = new[] { ".mp3", ".wav" };
        //    var fileExtension = Path.GetExtension(fileAudio.FileName).ToLowerInvariant();
        //    if (!Array.Exists(validExtension, extention => extention == fileExtension))
        //    {
        //        throw new ArgumentException("Invalid file extension. Only .mp3, .wav are allowed");
        //    }
        //    var fileName = Guid.NewGuid().ToString() + fileExtension;
        //    await _connection.OpenAsync();
        //    SqlCommand command = new SqlCommand("INSERT INTO Audios(NameAudio, FileAudio)" +
        //        "VALUES(@NameFile,@FileAudio)", _connection);
        //    command.Parameters.AddWithValue("@NameFile", fileName);
        //    command.Parameters.AddWithValue("@FileAudio",await ConvertToByteArrayAsync(fileAudio));
        //    try
        //    {
        //        await command.ExecuteNonQueryAsync();
        //    }catch(Exception)
        //    {
        //        _connection.Close();
        //        throw;
        //    }
        //    _connection.Close();
        //    return fileName;
        //}
        //public async Task<byte[]> GetFileAudio(string fileName)
        //{
        //    if (fileName == null)
        //    {
        //        throw new Exception("File audio not found");
        //    }
        //    await _connection.OpenAsync();
        //    SqlCommand command = new SqlCommand("SELECT FileAudio FROM Audios WHERE NameAudio=@NameFile", _connection);
        //    command.Parameters.AddWithValue("@NameFile", fileName);
        //    try
        //    {
        //        var reader = await command.ExecuteReaderAsync();
        //        if (!await reader.ReadAsync())
        //        {
        //            throw new Exception("Not found");
        //        }
        //        var result = (byte[])reader["FileAudio"];
        //        _connection.Close();
        //        return result;
        //    }
        //    catch (Exception)
        //    {
        //        _connection.Close();
        //        throw;
        //    }
        //}
        //public async Task DeleteAudioFile(string fileName)
        //{
        //    await _connection.OpenAsync();
        //    SqlCommand command = new SqlCommand("DELETE FROM Audios WHERE NameAudio=@FileName", _connection);
        //    command.Parameters.AddWithValue("@FileName", fileName);
        //    try
        //    {
        //        await command.ExecuteNonQueryAsync();
        //        _connection.Close();
        //    }
        //    catch (Exception)
        //    {
        //        _connection.Close();
        //        throw;
        //    }
        //}
        //private async Task<byte[]> ConvertToByteArrayAsync(IFormFile file)
        //{
        //    using (var memoryStream = new MemoryStream())
        //    {
        //        await file.CopyToAsync(memoryStream);
        //        return memoryStream.ToArray();
        //    }
        //}
    }
}

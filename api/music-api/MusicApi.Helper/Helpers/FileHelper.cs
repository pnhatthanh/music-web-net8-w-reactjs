using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;

namespace MusicApi.Helper.Helpers
{
    public class FileHelper
    {
        //Upload file in sql server
        private readonly SqlConnection _connection;
        public FileHelper()
        {
            _connection = new SqlConnection("Server=ADMIN;Database=MusicFile;Trusted_Connection=True;TrustServerCertificate=True");
        }
        public async Task<string> UploadFileImage(IFormFile file)
        {
            if (file.Length == 0)
            {
                throw new ArgumentException("File image cannot empty");
            }
            //Check size < 2MB
            if (file.Length > 2 * 1024 * 1024)
            {
                throw new ArgumentException("File is too large. Maximum allowed size is 2Mb");
            }
            //Check extension
            var validExtension = new[] { ".png", ".jpg" };
            var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (!Array.Exists(validExtension, extention => extention == fileExtension))
            {
                throw new ArgumentException("Invalid file extension. Only .png, .jpg are allowed");
            }
            var fileName = Guid.NewGuid().ToString() + fileExtension;
            await _connection.OpenAsync();
            var command = new SqlCommand("INSERT INTO Images(NameImage, FileImage) " +
                "VALUES (@FileName, @MusicFile)", _connection);
            command.Parameters.AddWithValue("@FileName", fileName);
            command.Parameters.AddWithValue("@MusicFile", await ConvertToByteArrayAsync(file));
            try
            {
                await command.ExecuteNonQueryAsync();
            }
            catch (Exception)
            {
                _connection.Close();
                throw;
            }
            _connection.Close();
            return fileName;
        }

        public async Task<byte[]> GetFileImage(string fileName)
        {
            
            SqlCommand command = new SqlCommand("SELECT FileImage FROM Images WHERE NameImage = @FileName", _connection);
            command.Parameters.AddWithValue("@FileName", fileName);
            try
            {
                await _connection.OpenAsync();
                var reader = await command.ExecuteReaderAsync();
                if (await reader.ReadAsync() == true)
                {
                    return (byte[])reader["FileImage"];
                }
                else
                {
                    throw new Exception("Not found");
                }
            }catch(Exception)
            {
                _connection?.Close();
                throw;
            }
        }

        private async Task<byte[]> ConvertToByteArrayAsync(IFormFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }
        }



        //Upload file in directory

        //public async Task<string> UploadFileImage(IFormFile fileImage)
        //{
        //    //Check file empty
        //    if(fileImage.Length == 0)
        //    {
        //        throw new ArgumentException("File image cannot empty");
        //    }
        //    //Check size < 2MB
        //    if(fileImage.Length > 2*1024*1024)
        //    {
        //        throw new ArgumentException("File is too large. Maximum allowed size is 2Mb");
        //    }

        //    //Check extension
        //    var validExtension = new[] { ".png", ".jpg" };
        //    var fileExtension=Path.GetExtension(fileImage.FileName).ToLowerInvariant();
        //    if (!Array.Exists(validExtension, extention => extention == fileExtension))
        //    {
        //        throw new ArgumentException("Invalid file extension. Only .png, .jpg are allowed");
        //    }

        //    //Change file name and add to folder image
        //    var uploadFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "upload\\image");
        //    if(!Directory.Exists(uploadFolderPath))
        //    {
        //        Directory.CreateDirectory(uploadFolderPath);
        //    }
        //    var fileName=Guid.NewGuid().ToString()+fileExtension;
        //    var filePath=Path.Combine(uploadFolderPath, fileName);
        //    using (var stream= new FileStream(filePath, FileMode.Create))
        //    {
        //        await fileImage.CopyToAsync(stream);
        //    }
        //    return fileName;
        //}

        public async Task<string> UploadFileAudio(IFormFile fileAudio)
        {
            //Check file empty
            if (fileAudio.Length == 0)
            {
                throw new ArgumentException("File image cannot empty");
            }

            //Check size file <20MB
            if (fileAudio.Length > 20 * 1024 * 1024)
            {
                throw new ArgumentException("File is too large. Maximum allowed size is 20Mb");
            }

            //Check extension 
            var validExtension = new[] { ".mp3", ".wav" };
            var fileExtension = Path.GetExtension(fileAudio.FileName).ToLowerInvariant();
            if (!Array.Exists(validExtension, extention => extention == fileExtension))
            {
                throw new ArgumentException("Invalid file extension. Only .mp3, .wav are allowed");
            }

            //Change file name and add to folder audio
            var uploadFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "upload\\audio");
            if (!Directory.Exists(uploadFolderPath))
            {
                Directory.CreateDirectory(uploadFolderPath);
            }
            var fileName = Guid.NewGuid().ToString() + fileExtension;
            var filePath = Path.Combine(uploadFolderPath, fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await fileAudio.CopyToAsync(stream);
            }
            return fileName;
        }

        //public async Task<byte[]> GetFileImage(string fileName)
        //{
        //    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "upload\\image", fileName);
        //    return await File.ReadAllBytesAsync(filePath);
        //}
        public async Task<byte[]> GetFileAudio(string fileName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "upload\\audio", fileName);
            return await File.ReadAllBytesAsync(filePath);
        }

        public void DeleteImageFile(string fileName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "upload\\image", fileName);
            File.Delete(filePath);
        }

        public void DeleteAudioFile(string fileName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "upload\\audio", fileName);
            File.Delete(filePath);
        }
    }
}

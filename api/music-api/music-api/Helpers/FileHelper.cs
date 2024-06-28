namespace music_api.Helpers
{
    public class FileHelper
    {
        private readonly IWebHostEnvironment _environment;
        public FileHelper(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public async Task<string> UploadFileImage(IFormFile fileImage)
        {
            //Check file empty
            if(fileImage.Length == 0)
            {
                throw new ArgumentException("File image cannot empty");
            }
            //Check size < 2MB
            if(fileImage.Length > 2*1024*1024)
            {
                throw new ArgumentException("File is too large. Maximum allowed size is 2Mb");
            }

            //Check extension
            var validExtension = new[] { ".png", ".jpg" };
            var fileExtension=Path.GetExtension(fileImage.FileName).ToLowerInvariant();
            if (!Array.Exists(validExtension, extention => extention == fileExtension))
            {
                throw new ArgumentException("Invalid file extension. Only .png, .jpg are allowed");
            }

            //Change file name and add to folder image
            var uploadFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "upload\\image");
            if(!Directory.Exists(uploadFolderPath))
            {
                Directory.CreateDirectory(uploadFolderPath);
            }
            var fileName=Guid.NewGuid().ToString()+fileExtension;
            var filePath=Path.Combine(uploadFolderPath, fileName);
            using (var stream= new FileStream(filePath, FileMode.Create))
            {
                await fileImage.CopyToAsync(stream);
            }
            return filePath;
        }

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
            var uploadFolderPath = Path.Combine(_environment.WebRootPath, "upload\\audio");
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

        public async Task<byte[]> GetFileImage(string fileName)
        {
            var filePath = Path.Combine(_environment.WebRootPath, "upload\\image", fileName);
            return await File.ReadAllBytesAsync(filePath);
        }
        public async Task<byte[]> GetFileAudio(string fileName)
        {
            var filePath = Path.Combine(_environment.WebRootPath, "upload\\audio", fileName);
            return await File.ReadAllBytesAsync(filePath);
        }

        public void DeleteImageFile(string fileName)
        {
            var filePath = Path.Combine(_environment.WebRootPath, "upload\\image", fileName);
            File.Delete(filePath);
        }

        public void DeleteAudioFile(string fileName)
        {
            var filePath = Path.Combine(_environment.WebRootPath, "upload\\audio", fileName);
            File.Delete(filePath);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace City.api.Controllers
{
    [Route("api/Files")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        FileExtensionContentTypeProvider _fileExtensionContentTypeProvider1;

        public FilesController(FileExtensionContentTypeProvider fileExtensionContentTypeProvider1)
        {
            _fileExtensionContentTypeProvider1 = fileExtensionContentTypeProvider1;
        }

        [HttpGet("{fileId}")]
        public ActionResult GetFile(string fileId)
        {
            
            string FileToPath = "milf.mp4";
            if(!System.IO.File.Exists(FileToPath)) 
            {
                return NotFound();
            }

            var bytes = System.IO.File.ReadAllBytes(FileToPath);

            if (_fileExtensionContentTypeProvider1.TryGetContentType(FileToPath, out var contentType))
            {
                contentType = "application/octet-stream";
            }

           
            return File(bytes, contentType,Path.GetFileName(FileToPath));
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly FileExtensionContentTypeProvider _FileExtensionContentTypeProvider;
        
        public FileController (FileExtensionContentTypeProvider fileExtensionContentTypeProvider) 
        {
            _FileExtensionContentTypeProvider = fileExtensionContentTypeProvider;
           
        }

        [HttpGet("{fileid}")]
        public ActionResult GetFile(int fileid)
        {
            var filepath = "netfullstack.pdf";

            if(!System.IO.File.Exists(filepath))
            {
                return NotFound();
            }

            if(_FileExtensionContentTypeProvider.TryGetContentType(filepath, out var contentType))
            {
                contentType = "application/octet-stream";
            }

            var bytes = System.IO.File.ReadAllBytes(filepath);
            return File(bytes, contentType, Path.GetFileName(filepath));
        }
    }
}

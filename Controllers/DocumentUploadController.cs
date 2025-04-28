using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TscLoanManagement.TSCDB.Application.DTOs;
using TscLoanManagement.TSCDB.Application.Interfaces;

namespace TscLoanManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentUploadController : ControllerBase
    {
        private readonly IDocumentUploadService _documentService;

        public DocumentUploadController(IDocumentUploadService documentService)
        {
            _documentService = documentService;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadDocument([FromForm] DocumentUploadDto dto, IFormFile file)
        {
            // Save file to disk or blob and set path
            var filePath = await SaveFileAsync(file);
            dto.FilePath = filePath;

            var result = await _documentService.UploadDocumentAsync(dto);
            return Ok(result);
        }

        private async Task<string> SaveFileAsync(IFormFile file)
        {
            // Save file logic (disk or cloud storage)
            var folderPath = Path.Combine("wwwroot", "uploads");
            Directory.CreateDirectory(folderPath);
            var fileName = $"{Guid.NewGuid()}_{file.FileName}";
            var fullPath = Path.Combine(folderPath, fileName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return $"/uploads/{fileName}";
        }

        // GET: api/DocumentUpload/view/{id}
        [HttpGet("view/{id}")]
        public async Task<IActionResult> ViewDocument(int id)
        {
            var document = await _documentService.GetByIdAsync(id);
            if (document == null || string.IsNullOrEmpty(document.FilePath))
                return NotFound("Document not found");

            var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", document.FilePath.TrimStart('/'));
            if (!System.IO.File.Exists(fullPath))
                return NotFound("File not found on disk");

            var fileUrl = $"{Request.Scheme}://{Request.Host}/uploads/{Path.GetFileName(document.FilePath)}";
            return Ok(new { Url = fileUrl });
        }

        // GET: api/DocumentUpload/download/{id}
        [HttpGet("download/{id}")]
        public async Task<IActionResult> DownloadDocument(int id)
        {
            var document = await _documentService.GetByIdAsync(id);
            if (document == null || string.IsNullOrEmpty(document.FilePath))
                return NotFound("Document not found");

            var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", document.FilePath.TrimStart('/'));
            if (!System.IO.File.Exists(fullPath))
                return NotFound("File not found on disk");

            var memory = new MemoryStream();
            using (var stream = new FileStream(fullPath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;

            var contentType = "application/octet-stream"; // You can also detect by file extension
            return File(memory, contentType, Path.GetFileName(fullPath));
        }

        [HttpGet("by-dealer/{dealerId}")]
        public async Task<IActionResult> GetDocumentsByDealer(int dealerId)
        {
            var documents = await _documentService.GetByDealerIdAsync(dealerId);
            return Ok(documents);
        }

        [HttpPost("upload-multiple")]
        public async Task<IActionResult> UploadMultipleDocuments([FromForm] List<IFormFile> files, [FromForm] List<string> documentTypes, [FromForm] int dealerId)
        {
            if (files == null || files.Count == 0)
                return BadRequest("No files uploaded.");

            if (files.Count != documentTypes.Count)
                return BadRequest("Mismatch between files and document types.");

            var uploadedDocuments = new List<DocumentUploadDto>();

            for (int i = 0; i < files.Count; i++)
            {
                var file = files[i];
                var documentType = documentTypes[i];

                var filePath = await SaveFileAsync(file);

                var dto = new DocumentUploadDto
                {
                    DealerId = dealerId,
                    DocumentType = documentType,
                    FilePath = filePath,
                    //UploadedOn = DateTime.UtcNow
                };

                var result = await _documentService.UploadDocumentAsync(dto);
                uploadedDocuments.Add(result);
            }

            return Ok(uploadedDocuments);
        }



    }
}

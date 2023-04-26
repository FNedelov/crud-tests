using System.Text.Json;

namespace CRUD.Common.DTOs
{
    public record ErrorDetailsDto
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public string? ExceptionType { get; set; }
        public string? InnerException { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
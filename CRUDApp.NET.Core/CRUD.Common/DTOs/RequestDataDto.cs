using Microsoft.Extensions.Primitives;

namespace CRUD.Common.DTOs
{
    public record RequestDataDto
    {
        public string? RequestPath { get; set; }
        public string? RequestInitiator { get; set; }
        public string? AccessToken { get; set; }
        public string? Description { get; set; }
    }
}
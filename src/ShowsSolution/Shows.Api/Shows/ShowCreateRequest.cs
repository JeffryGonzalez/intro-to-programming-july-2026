using System.ComponentModel.DataAnnotations;

namespace Shows.Api.Shows;

public record ShowCreateRequest
{
    // this is a "property" - sort of like a get_ set_ pair in java.
    [MinLength(3), MaxLength(50)]
    public required string Title { get; set; }
}

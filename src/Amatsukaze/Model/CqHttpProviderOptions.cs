using System.ComponentModel.DataAnnotations;

namespace Amatsukaze.Model;

public sealed record class CqHttpProviderOptions
{
    public Uri? BaseUri { get; set; }
    public bool UseApiEndPoint { get; set; }
    public bool UseEventEndPoint { get; set; }
    public string? AccessToken { get; set; }
    public int BufferSize { get; set; }
    [Required]
    public CqHttpUser? Account { get; set; }
}

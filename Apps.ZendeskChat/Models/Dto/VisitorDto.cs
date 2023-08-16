using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.ZendeskChat.Models.Dto;

public class VisitorDto
{
    [JsonProperty("banned")]
    [Display("Is banned")]
    public bool Banned { get; set; }

    [JsonProperty("created")]
    [Display("Created time")]
    public DateTime Created { get; set; }

    [JsonProperty("email")]
    [Display("Email")]
    public string Email { get; set; }

    [JsonProperty("external_id")]
    [Display("External ID")]
    public string? ExternalId { get; set; }

    [JsonProperty("id")]
    [Display("ID")]
    public string Id { get; set; }

    [JsonProperty("name")]
    [Display("Name")]
    public string Name { get; set; }

    [JsonProperty("notes")]
    [Display("Notes")]
    public string Notes { get; set; }

    [JsonProperty("phone")]
    [Display("Phone")]
    public string Phone { get; set; }
}
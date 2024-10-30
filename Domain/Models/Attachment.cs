namespace Domain.Models;

public class Attachment: BaseEntity
{
    public string Type { get; set; } = String.Empty;
    public int FormId { get; set; }
    public Form Form { get; set; } //navigation property
    //anexo
}
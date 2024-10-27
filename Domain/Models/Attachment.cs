namespace Domain.Models;

public class Attachment
{
    public int Id { get; set; }
    public string Type { get; set; } = String.Empty;
    public int FormId { get; set; }
    public Form Form { get; set; } //navigation property
    //anexo
}
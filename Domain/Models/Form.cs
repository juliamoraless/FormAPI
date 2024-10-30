namespace Domain.Models;

public class Form : BaseEntity
{
    public string Name { get; set; } = "";
    public string Cpf { get; set; } = "";
    public DateTime BirthDate { get; set; }
    public List<Attachment> Attachments { get; set; }
}
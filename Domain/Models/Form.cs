namespace Domain.Models;

public class Form
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Cpf { get; set; } = "";
    public DateTime DataNascimento { get; set; }
    public List<Attachment> Attachments { get; set; }
}
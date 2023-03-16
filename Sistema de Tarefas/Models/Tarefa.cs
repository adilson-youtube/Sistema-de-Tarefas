using Sistema_de_Tarefas.Enums;

namespace Sistema_de_Tarefas.Models
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Descricao { get; set; }
        public StatusTarefa? Status { get; set; }
        public int? UsuarioId { get; set; }

        public virtual Usuario? Usuario { get; set; }
    }
}

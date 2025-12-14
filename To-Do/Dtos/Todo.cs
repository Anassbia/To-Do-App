using To_Do.Enums;

namespace To_Do.Dtos
{
    public class Todo
    {
        public string Libelle { get; set; }

        public string Description { get; set; }

        public DateTime DateLimite { get; set; }

        public Statuts Statut { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}

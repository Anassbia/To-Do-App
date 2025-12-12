using To_Do.Enums;

namespace To_Do.ViewModels
{
    public class TodoAddVM
    {
        public string Libelle { get; set; }
        public string Description { get; set; }
        public DateTime DateLimite { get; set; }

        public Statuts Statut { get; set; }
    }
}

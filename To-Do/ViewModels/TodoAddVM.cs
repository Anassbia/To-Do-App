using System.ComponentModel.DataAnnotations;
using To_Do.Enums;

namespace To_Do.ViewModels
{
    public class TodoAddVM
    {
        [Required(ErrorMessage ="Libelle est obligatoire")]
        public string Libelle { get; set; }
        
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateLimite { get; set; }
        [Required]
        public Statuts Statut { get; set; }
    }
}

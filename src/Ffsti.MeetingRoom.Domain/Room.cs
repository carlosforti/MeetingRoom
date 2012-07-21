using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ffsti.MeetingRoom.Domain.Interfaces;

namespace Ffsti.MeetingRoom.Domain
{
    public class Room: IBaseClass
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo deve ter entre {1} e {2} caracteres", MinimumLength = 3)]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        public int Capacity { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        [Display(Name = "Tem Projetor")]
        public bool HasProjector { get; set; }

        [Display(Name = "Cor para exibição no mapa de agendamento")]
        public string Color { get; set; }

        public virtual ICollection<Meeting> Reservations { get; set; }
    }
}
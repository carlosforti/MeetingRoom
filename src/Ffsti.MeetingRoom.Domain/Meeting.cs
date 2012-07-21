using System;
using System.ComponentModel.DataAnnotations;
using Ffsti.MeetingRoom.Domain.Interfaces;

namespace Ffsti.MeetingRoom.Domain
{
    public class Meeting : IBaseClass
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        [Display(Name = "Contato")]
        public int ContactId { get; set; }
        public virtual Contact Contact { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        public int RoomId { get; set; }
        public Room Room { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        [Display(Name = "Início")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:g}", ApplyFormatInEditMode = true)]
        public DateTime Start { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        [Display(Name = "Término")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:g}", ApplyFormatInEditMode = true)]
        public DateTime Finish { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        [Display(Name = "Participantes")]
        public int Participants { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        [StringLength(4096, ErrorMessage = "O tamanho máximo para o campo é de {1} caracteres")]
        [Display(Name = "Assunto")]
        public string Subject { get; set; }
    }
}
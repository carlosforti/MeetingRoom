using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ffsti.MeetingRoom.Domain.Interfaces;

namespace Ffsti.MeetingRoom.Domain
{
    public class Contact : IBaseClass
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        [Display(Name = "Tipo de contato")]
        public int ContactTypeId { get; set; }
        public virtual ContactType ContactType { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        [StringLength(100, ErrorMessage = "O tamanho máximo para o campo é de {1} caracteres")]
        [Display(Name = "Primeiro nome")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo deve ter entre {1} e {2} caracteres", MinimumLength = 3)]
        [Display(Name = "Sobrenome")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        [StringLength(100, ErrorMessage = "O tamanho máximo para o campo é de {1} caracteres")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        [StringLength(13, ErrorMessage = "O tamanho máximo para o campo é de {1} caracteres")]
        [Display(Name = "Telefone")]
        public string Phone { get; set; }

        [StringLength(5, ErrorMessage = "O tamanho máximo para o campo é de {1} caracteres")]
        [Display(Name = "Ramal")]
        public string Extension { get; set; }

        [Display(Name = "Informações Extras")]
        [StringLength(4096, ErrorMessage = "O tamanho máximo para o campo é de {1} caracteres")]
        public string InformacoesExtras { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        [StringLength(100, ErrorMessage = "O tamanho máximo para o campo é de {1} caracteres")]
        public string Empresa { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        [StringLength(100, ErrorMessage = "O tamanho máximo para o campo é de {1} caracteres")]
        public string Site { get; set; }

        public virtual ICollection<Meeting> Reservations { get; set; }
    }
}
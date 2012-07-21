using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ffsti.MeetingRoom.Domain.Interfaces;

namespace Ffsti.MeetingRoom.Domain
{
    public class ContactType : IBaseClass
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo deve ter entre {1} e {2} caracteres", MinimumLength = 3)]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; }

        public ContactType() { }

        public ContactType(string name)
        {
            this.Name = name;
        }
    }
}
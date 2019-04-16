using System.ComponentModel.DataAnnotations;

namespace GSoft.AbpZeroTemplate.Persons
{
    public class CreatePersonInput
    {
        [Required]
        [MaxLength(32)]
        public string Name { get; set; }

        [Required]
        [MaxLength(32)]
        public string Surname { get; set; }

        [EmailAddress]
        [MaxLength(255)]
        public string EmailAddress { get; set; }
    }

}

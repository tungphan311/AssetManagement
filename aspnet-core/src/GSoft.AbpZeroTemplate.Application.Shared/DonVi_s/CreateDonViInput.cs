using System.ComponentModel.DataAnnotations;

namespace GSoft.AbpZeroTemplate.DonVi_s
{
    public class CreateDonViInput
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

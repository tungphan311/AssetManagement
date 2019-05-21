using System.ComponentModel.DataAnnotations;

namespace GSoft.AbpZeroTemplate.DonVi_s
{
    public class CreateDonViInput
    {
        [Required]
        [MaxLength(255)]
        public string TenDonVi { get; set; }

        public int DonViChinhId { get; set; }

        public string DiaChi { get; set; }
    }

}
using System.ComponentModel.DataAnnotations;

namespace Web.API.Model
{
    public class PointofInterestofUpdateDto
    {
        [Required(ErrorMessage = "Please provide Name information . ")]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(200)]

        public string Description { get; set; } = string.Empty;
    }
}

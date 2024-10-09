using System.ComponentModel.DataAnnotations;

namespace ProyectoACSyDBAR.DTOs
{
    public class CreateProductDTO
    {

        [Required]
        public string Name { get; set; }


        public string Description { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required]
        public string Category { get; set; }
    }
}

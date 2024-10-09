using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace ProyectoACSyDBAR.DTOs
{
    public class UpdateProductoDTO
        {
            public string Id { get; set; }
            
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


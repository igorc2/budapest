using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Budapest.API.Entities
{
    public class PointOfInterest
    {
        [Key] //Não é necessário, pq segundo a conveção ele já pega esse valor
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [ForeignKey("CityId")] //Não é necessário, pq segundo a conveção ele já pega esse valor
        public City City { get; set; }

        public int CityId { get; set;  }

    }
}

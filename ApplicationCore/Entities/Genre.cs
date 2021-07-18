using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;    
using System.ComponentModel.DataAnnotations.Schema;    
    
namespace ApplicationCore.Entities
{
    
    public class Genre
    {

        public int ID { get; set; }

  
        public string Name { get; set; }

        public ICollection<MovieGenre> movieGenres { get; set; }
    }
    // To change entity/table 2 options, DataAnnotations, Fluent API
}

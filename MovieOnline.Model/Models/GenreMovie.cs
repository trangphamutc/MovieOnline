using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieOnline.Model.Models
{
    [Table("GenreMovies")]
    public class GenreMovie
    {

        [Key]
        [Column(Order=1)]
        public int MovieId { set; get; }
        [Key]
        [Column(Order = 2)]
        public int GenreId { set; get; }

    }
}

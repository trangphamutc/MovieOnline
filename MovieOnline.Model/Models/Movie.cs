using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieOnline.Model.Models
{
    [Table("Movies")]
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }

        [MaxLength(500)]
        [Column(TypeName ="nvarchar")]
        public string NameVietNamese { set; get; }

        [Column(TypeName = "nvarchar")]
        public string Description { set; get; }

        [MaxLength(500)]
        [Column(TypeName = "nvarchar")]
        public string NameOriginal { set; get; }
       
        public virtual IEnumerable<GenreMovie> GenreMovies { set; get; }


}
}

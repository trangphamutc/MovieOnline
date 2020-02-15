using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieOnline.Web.Models
{
    public class MovieViewModel
    {
   
        public int Id { set; get; }

        public string NameVietNamese { set; get; }

        public string NameOriginal { set; get; }

        public string Description { set; get; }

        public DateTime CreatedDate { set; get; }


        public bool Status { get; set; }
    }
}
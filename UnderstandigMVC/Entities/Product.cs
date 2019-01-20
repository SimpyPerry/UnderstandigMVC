using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UnderstandigMVC.Entities
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string ArtistId { get; set; }
        public DateTime ArtistDeath { get; set; }
        public DateTime ArtistBirth { get; set; }
        //Her binder vi identity det Product
        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcMovie.Models
{
    /// <summary>
    /// PM:Enable-Migrations -ContextTypeName MvcMovie.Models.MovieDbContext
    /// PM:add-migration Initial
    /// PM:update-database
    /// step1:Enalbe migrations to generate configuration file
    /// step2:Add migration with name of Initial
    /// step3:Update database and execute seeding method
    /// After add a property to Movice object, use add migration command to update database
    /// PM:add-migration Rating(1)
    /// PM:update-database(2)
    /// </summary>
    public class Movie
    {
        public int ID { get; set; }
        [StringLength(60, MinimumLength =3)]
        public string Title { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [StringLength(5)]
        public string Rating { get; set; }
        [Display(Name ="Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}", ApplyFormatInEditMode =true)]
        public DateTime ReleaseDate { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [Required]
        [StringLength(30)]
        public string Genre { get; set; }
        [Range(1,100)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
    }

    public class MovieDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
    }
}
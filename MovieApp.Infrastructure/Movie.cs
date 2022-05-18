using System;

namespace MovieApp.Infrastructure
{
    public class Movie
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public string Rated { get; set; }
        public DateTime ReleasedDate { get; set; }
        public string Runtime { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Writer { get; set; }
        public string Actors { get; set; }
        public string Plot { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }
        public string Awards { get; set; }
        public string Poster { get; set; }
        public int? Metascore { get; set; }
        public decimal? ImdbRating { get; set; }
        public int? ImdbVotes { get; set; }
        public string ImdbID { get; set; }
        public string Type { get; set; }
        public bool Response { get; set; }
        public string[] Images { get; set; }
    }
}

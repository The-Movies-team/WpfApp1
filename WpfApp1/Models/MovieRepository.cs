namespace WpfApp1.Models
{
    public class MovieRepository
    {
        private List<Movie> currentMovies;

        public MovieRepository()
        {

            Id = idCount++;
        }

        public override string ToString()
        {
            return $"{Id}";
        }
    }
}

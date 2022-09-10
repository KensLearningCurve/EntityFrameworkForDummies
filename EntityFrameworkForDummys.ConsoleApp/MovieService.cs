using EntityFrameworkForDummys.ConsoleApp.Objects;

namespace EntityFrameworkForDummys.ConsoleApp
{
    internal class MovieService
    {
        private readonly List<Movie> _movies = new()
        {
            new Movie{ Id = 1, Rating = 10, Title = "Shrek"},
            new Movie{ Id = 2, Rating = 2, Title = "The Green Latern"},
            new Movie{ Id = 3, Rating = 7, Title = "The Matrix"},
            new Movie{ Id = 4, Rating = 4, Title = "Inception"},
            new Movie{ Id = 5, Rating = 8, Title = "The Avengers"},
        };

        public IEnumerable<Movie> GetAll()
        {
            return _movies.OrderBy(x => x.Title);
        }

        public Movie? Get(int id)
        {
            return _movies?.SingleOrDefault(x => x.Id == id);
        }

        public void Insert(Movie movie)
        {
            if (string.IsNullOrEmpty(movie.Title))
                throw new Exception("Title is required.");

            movie.Id = _movies.Max(x => x.Id) + 1;
            _movies.Add(movie);
        }

        public void Delete(int id)
        {
            Movie? toDelete = Get(id);

            if (toDelete != null)
                _movies.Remove(toDelete);
        }
    }
}

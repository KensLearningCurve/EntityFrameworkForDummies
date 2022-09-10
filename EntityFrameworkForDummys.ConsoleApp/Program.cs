using EntityFrameworkForDummys.ConsoleApp;
using EntityFrameworkForDummys.ConsoleApp.Objects;

MovieService movieService = new();
int? action = 0;
do
{
    if (action == 0)
        MainMenu();
    else if (action == 1)
        ShowMovies();
    else if (action == 2)
        CreateMovie();

    Console.WriteLine("");



} while (true);

void MainMenu()
{
    Console.Clear();

    Console.WriteLine($"1. Show all movies");
    Console.WriteLine($"2. Create a new movie");
    Console.WriteLine($"3. Exit");

    char choice = Console.ReadKey().KeyChar;

    if (char.IsDigit(choice))
    {
        int? choosenItem = int.Parse(choice.ToString());

        switch (choosenItem)
        {
            case 1:
                action = 1;
                break;
            case 2:
                action = 2;
                break;
            case 3:
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Thank you and goodbye!");
                Console.WriteLine("");
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("This is not a validate choice");
                Console.WriteLine("");
                break;

        }
    }
}

void ShowMovies()
{

    Console.Clear();

    foreach (Movie movie in movieService.GetAll())
    {
        Console.WriteLine($"{movie.Id}. {movie.Title}");
    }


    Console.WriteLine($"B. Back");

    char choice = Console.ReadKey().KeyChar;

    if (char.IsDigit(choice))
    {
        MovieDetails(int.Parse(choice.ToString()));
    }
    else if (choice.ToString().ToLower() == "b")
    {
        action = 0;
    }
}

void MovieDetails(int id)
{
    Console.Clear();

    Movie? movie = movieService.Get(id);

    Console.WriteLine(movie?.Title);
    Console.WriteLine($"The rating of this movie is {movie?.Rating}");
    Console.WriteLine("");
    Console.WriteLine("Press any key to return");

    Console.ReadKey();
    action = 1;
}

void CreateMovie()
{
    Console.Clear();
    Console.WriteLine("Enter a title of a movie: ");
    string? title = Console.ReadLine();

    if (string.IsNullOrEmpty(title))
        title = "Unknown movie";

    Console.WriteLine("What rating would you give this movie? (1-10)");
    int? rating = int.Parse(Console.ReadLine());

    movieService.Insert(new() { Rating = rating ?? 0, Title = title });

    Console.WriteLine("Movie has been created. Press any key to return.");
    Console.ReadKey();
    action = 0;
}
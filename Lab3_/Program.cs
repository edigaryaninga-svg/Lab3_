using System;

namespace Lab3
{
    public enum MovieGenre
    {
        Action = 1,
        Comedy,
        Drama,
        Horror,
        SciFi
    }

    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public MovieGenre Genre { get; set; }
        public int Views { get; set; }
        public int Likes { get; set; }

        public Movie(int id, string title, int year, MovieGenre genre, int views, int likes)
        {
            Id = id;
            Title = title;
            Year = year;
            Genre = genre;
            Views = views;
            Likes = likes;
        }

        public double GetRating()
        {
            if (Views == 0) return 0.0;
            return Math.Sqrt(Math.Pow(Likes, 2) / (double)Views);
        }

        public override string ToString()
        {
            string formattedYear = $"({Year})";
            string genreString = Genre.ToString();
            double rating = GetRating();

            return $"{Id,4} {Title,-15} {formattedYear,-8} {genreString,-12} {rating,8:F3}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.Write("Enter number of movies: ");
            if (!int.TryParse(Console.ReadLine(), out int count)) return;

            Movie[] movies = new Movie[count];

            Console.WriteLine("\nEnter format: Id, Title, Year, Genre(1-5), Views, Likes (separated by space or comma)");
            Console.WriteLine("Example: 1 Inception 2010 5 10000 8500\n");

            for (int i = 0; i < count; i++)
            {
                Console.Write($"Movie {i + 1}: ");
                string input = Console.ReadLine();
                string[] parts = input.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                int id = int.Parse(parts[0]);
                string title = parts[1];
                int year = int.Parse(parts[2]);
                MovieGenre genre = (MovieGenre)int.Parse(parts[3]);
                int views = int.Parse(parts[4]);
                int likes = int.Parse(parts[5]);

                movies[i] = new Movie(id, title, year, genre, views, likes);
            }

            Console.WriteLine("\n--- Movies List ---");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(movies[i].ToString());
            }

            Console.ReadKey();
        }
    }
}

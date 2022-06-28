using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SimpleMovieApp
{
    class Program
    {
        static String[] movies = new String[5];
        static int counter = 0;
        static string path = @"d://Movies List";
        static void Main(String[] args)
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Simple Movie App");
                Console.WriteLine("1 Add movie");
                Console.WriteLine("2 clear movie");
                Console.WriteLine("3 Display movie");
                Console.WriteLine("4 Display Previous movies(option can be used only when you clear exit the program)");
                Console.WriteLine("5 Exit");
                Console.WriteLine("Enter your choice");
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        AddMovies(movies);
                        break;
                    case 2:
                        counter = 0;
                        Array.Clear(movies, 0, movies.Length);
                        break;
                    case 3:
                        DisplayMovie(movies);
                        break;
                    case 4:
                        PreviousDisplayMovie();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }         
        }

        private static void DisplayMovie(string[] movie)
        {

            if (movie.Length != 0){
                for (int i = 0; i < movie.Length; i++)
                {
                    if (movie[i] != null)
                    {
                        Console.WriteLine("Movie  " + (i+1) + " : " + movie[i]);
                    }
                    else 
                        break;
                }
            }
            else
            {
                Console.WriteLine("No movie Present ");
            }
        }
        private static void PreviousDisplayMovie()
        {
            FileStream stream = new FileStream(path, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            String[] movies = (String[])formatter.Deserialize(stream);
            Array.Copy(movies, 0, Program.movies, 0, movies.Length);

            if (movies.Length != 0)
            {
                for (int i = 0; i < movies.Length; i++)
                {
                    if (movies[i] != null)
                    {
                        Console.WriteLine("Movie  " + (i+1) + " : " + movies[i]);
                    }
                    else break;
                }
                return;
            }
            else if (movies.Length == 0)
            {
                Console.WriteLine("No movie Present ");
                return;
            }
            stream.Close();
        }

        private static void AddMovies(string[] movie)
        {
            if (counter < 5)
            {
                Console.WriteLine("Enter movie name");
                movie[counter] = Console.ReadLine();
                counter++;
                FileStream stream = new FileStream(path, FileMode.OpenOrCreate);
                BinaryFormatter formater = new BinaryFormatter();
                formater.Serialize(stream, movie);
                stream.Close();
            }
            else
            {
                Console.WriteLine("Sorry Overflow");
            }
        }
    }
}
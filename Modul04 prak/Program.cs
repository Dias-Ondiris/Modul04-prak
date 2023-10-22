using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Modul04_prak
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student[] students = new Student[10];

            students[0] = new Student { FullName = "Dias O.J.", Group = "intership", Grades = new[] { 5, 4, 5, 5, 5 } };
            students[1] = new Student { FullName = "Oljas A.B.", Group = "intership", Grades = new[] { 3, 4, 4, 5, 5 } };
            students[2] = new Student { FullName = "Almas A.B.", Group = "web", Grades = new[] { 3, 5, 4, 5, 5 } };
            students[3] = new Student { FullName = "Ertargun A.B.", Group = "intership", Grades = new[] { 5, 4, 4, 5, 5 } };
            students[4] = new Student { FullName = "Aimurat A.B.", Group = "intership", Grades = new[] { 3, 4, 4, 3, 5 } };
            students[5] = new Student { FullName = "Islam A.B.", Group = "intership", Grades = new[] { 5, 4, 3, 5, 5 } };
            students[6] = new Student { FullName = "Madiyar A.B.", Group = "web", Grades = new[] { 4, 4, 4, 4, 4 } };
            students[7] = new Student { FullName = "Bala A.B.", Group = "intership", Grades = new[] { 4, 4, 4, 5, 5 } };
            students[8] = new Student { FullName = "Jala A.B.", Group = "web", Grades = new[] { 4, 5, 4, 5, 5 } };
            students[9] = new Student { FullName = "Sala A.B.", Group = "intership", Grades = new[] { 3, 4, 4, 3, 5 } };
            var orderStudents = students.OrderBy(g => g.AverageGrade).ToArray();
            foreach (var student in orderStudents)
            {
                if (student.HasOnlyHighGrades)
                {
                    Console.WriteLine($"{student.FullName} ({student.Group})");
                }
            }


            List<Animal> animals = new List<Animal>
            {
                new Carnivore { Id = "1", Name = "Lion" },
                new Carnivore { Id = "2", Name = "Leopard" },
                new Omnivore { Id = "3", Name = "Bear" },
                new Herbivore { Id = "4", Name = "Horse " },
                new Herbivore { Id = "5", Name = "Cow " },
            };
            var orderAnimals = animals.OrderByDescending(a => a.NeedFood().Amount).ThenBy(a => a.Name).ToList();
            foreach (var animal in orderAnimals)
            {
                Console.WriteLine(animal);
            }
            Console.WriteLine("\nПервые 5 имен:");
            foreach (var animal in orderAnimals.Take(5))
            {
                Console.WriteLine(animal.Name);
            }
            Console.WriteLine("\nПоследние 3 идентификатора:");
            foreach (var animal in orderAnimals.Skip(Math.Max(0, orderAnimals.Count() - 3)))
            {
                Console.WriteLine(animal.Id);
            }
            File.WriteAllLines("animals.txt", orderAnimals.Select(a => a.ToString()));
            Console.WriteLine("\nЧтение из файла:");
            try
            {
                foreach (var line in File.ReadAllLines("animals.txt"))
                {
                    Console.WriteLine(line);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при чтении файла");
            }



            var library = new HomeLibrary();
            library.AddBook(new Book { Title = "War and Peace", Author = "Leo Tolstoy", PublicationDate =new DateTime(1869,10,17)  });
            library.AddBook(new Book { Title = "Sherlock Holmes", Author = "Arthur Conan Doyle", PublicationDate = new DateTime(1854, 9, 27) });
            library.AddBook(new Book { Title = "Way Abai 1", Author = "Mukhtar Auezov", PublicationDate = new DateTime(1942, 11, 14)  });
            library.AddBook(new Book { Title = "Way Abai 2", Author = "Mukhtar Auezov", PublicationDate = new DateTime(1947, 11, 14)  });
            var orwellBooks = library.FindByAuthor("Mukhtar Auezov");
            Console.WriteLine("Books by Mukhtar Auezov:");
            foreach (var book in orwellBooks)
            {
                Console.WriteLine(book.Title);
            }
            var searchedBook = library.FindByTitle("War and Peace");
            if (searchedBook != null)
            {
                Console.WriteLine($"\nFound book by title 'War and Peace': {searchedBook.Author}, {searchedBook.PublicationYear}");
            }
            else
            {
                Console.WriteLine("\nBook not found.");
            }

            library.RemoveBookByTitle("War and Peace");

            Console.WriteLine("\nAll books in the library:");
            foreach (var book in library.GetAllBooks())
            {
                Console.WriteLine($"{book.Title} by {book.Author}, {book.PublicationYear}");
            }
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
namespace DemoLINQ;
class Program
{
    static void Main()
    {
        bool continueLoop = true;

        while (continueLoop)
        {

            while (continueLoop)
            {
                Menu();
                continueLoop = HandleUserSelection();
            }
        }
    }
    static void Menu()
    {
        Console.WriteLine("Select an exercise to run (1-7):");
        Console.WriteLine("1. Exercise #1: Select even numbers from an array");
        Console.WriteLine("2. Exercise #2: Select positive numbers less than 12");
        Console.WriteLine("3. Exercise #3: Select animal names with length >= 5");
        Console.WriteLine("4. Exercise #4: Take top 5 largest numbers");
        Console.WriteLine("5. Exercise #5: Order pets by age");
        Console.WriteLine("6. Exercise #6: Select pets whose names start with 'S'");
        Console.WriteLine("7. Quit");
        Console.Write("Enter your choice: ");
    }
    static bool HandleUserSelection()
    {
        string input = Console.ReadLine();
        int option;
        bool validInput = int.TryParse(input, out option);

        if (validInput)
        {
            switch (option)
            {
                case 1:
                    LinqExercise1();
                    break;
                case 2:
                    LinqExercise2();
                    break;
                case 3:
                    LinqExercise3();
                    break;
                case 4:
                    LinqExercise4();
                    break;
                case 5:
                    LinqExercise5();
                    break;
                case 6:
                    LinqExercise6();
                    break;
                case 7:
                    Console.WriteLine("Exiting...");
                    return false; 
                default:
                    Console.WriteLine("Invalid option. Please select a number between 1 and 7.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number between 1 and 7.");
        }

        return true; 
    }
    

    // Exercise #1: Select even numbers from an array
    static void LinqExercise1()
    {
        int[] n1 = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        var nQuery = from tmp in n1
                     where (tmp % 2) == 0
                     select tmp;

        Console.Write("Even numbers: ");
        foreach (var num in nQuery)
        {
            Console.Write(num + ", ");
        }
        Console.WriteLine();
    }

    // Exercise #2: Select positive numbers less than 12
    static void LinqExercise2()
    {
        int[] n1 = { 1, 3, -2, -4, -7, -3, -8, 12, 19, 6, 9, 10, 14 };
        var nQuery = from tmp in n1
                     where tmp > 0 && tmp < 12
                     select tmp;

        Console.Write("Positive numbers less than 12: ");
        foreach (var num in nQuery)
        {
            Console.Write(num + ", ");
        }
        Console.WriteLine();
    }

    // Exercise #3: Select animal names with length >= 5
    static void LinqExercise3()
    {
        List<string> animals = new List<string> { "zebra", "elephant", "cat", "dog", "rhino", "bat" };
        var selectedAnimals = animals.Where(s => s.Length >= 5).Select(x => x.ToUpper());

        Console.Write("Animals with length >= 5 (in uppercase): ");
        foreach (var animal in selectedAnimals)
        {
            Console.Write(animal+", ");
        }
        Console.WriteLine();
    }

    // Exercise #4: Take top 5 largest numbers
    static void LinqExercise4()
    {
        List<int> numbers = new List<int> { 6, 0, 999, 11, 443, 6, 1, 24, 54 };
        var top5 = numbers.OrderByDescending(x => x).Take(5);

        Console.Write("Top 5 largest numbers: ");
        foreach (var num in top5)
        {
            Console.Write(num + ", ");
        }
        Console.WriteLine();
    }

    // Exercise #5: Order pets by age
    class Pet
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    static void LinqExercise5()
    {

    Pet[] pets =
    {
            new Pet { Name = "Barley", Age = 8 },
            new Pet { Name = "Boots", Age = 4 },
            new Pet { Name = "Whiskers", Age = 1 }
        };

    var query = pets.OrderBy(pet => pet.Age);

    Console.Write("Pets ordered by age: ");
        foreach (var pet in query)
        {
            Console.Write($"Name: {pet.Name}, Age: {pet.Age}");
        }
        Console.WriteLine();
    }

    // Exercise #6: Select pets whose names start with 'S'
    class PetOwner
    {
        public string Name { get; set; }
        public List<string> Pets { get; set; }
    }
    static void LinqExercise6()
    {
        PetOwner[] petOwners =
        {
                    new PetOwner { Name = "Higa", Pets = new List<string> { "Scruffy", "Sam" } },
                    new PetOwner { Name = "Ashkenazi", Pets = new List<string> { "Walker", "Sugar" } },
                    new PetOwner { Name = "Price", Pets = new List<string> { "Scratches", "Diesel" } },
                    new PetOwner { Name = "Hines", Pets = new List<string> { "Dusty" } }
                };

        var query = petOwners
            .SelectMany(petOwner => petOwner.Pets, (petOwner, petName) => new { petOwner, petName })
            .Where(ownerAndPet => ownerAndPet.petName.StartsWith("S"))
            .Select(ownerAndPet => new
            {
                Owner = ownerAndPet.petOwner.Name,
                Pet = ownerAndPet.petName
            });

        foreach (var result in query)
        {
            Console.Write($"Owner: {result.Owner}, Pet: {result.Pet}");
        }
        Console.WriteLine();
    }
}

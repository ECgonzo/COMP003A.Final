/*
 * Author: Ethen Gonzalez
 * Course: COMP003A
 * Purpose: Dating App - New User Profile Final Project
 */

namespace COMP003A.Final
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // User Input Section
            string firstName, lastName, gender;
            int birthYear;

            Console.WriteLine("Welcome to the Dating App New User Profile Intake Form!");
            Console.WriteLine("Please enter the following information:");

            // Accept and validate first name
            do
            {
                Console.Write("First Name: ");
                firstName = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(firstName) || ContainsNumberOrSpecialChar(firstName));

            // Accept and validate last name
            do
            {
                Console.Write("Last Name: ");
                lastName = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(lastName) || ContainsNumberOrSpecialChar(lastName));

            // Accept and validate birth year
            do
            {
                Console.Write("Birth Year: ");
                if (!int.TryParse(Console.ReadLine(), out birthYear) || birthYear < 1900 || birthYear > DateTime.Now.Year)
                {
                    Console.WriteLine("Invalid input. Please enter a valid birth year.");
                }
            } while (birthYear < 1900 || birthYear > DateTime.Now.Year);

            // Accept and validate gender
            do
            {
                Console.Write("Gender (M/F/O): ");
                gender = Console.ReadLine().ToUpper();
            } while (gender != "M" && gender != "F" && gender != "O");

            // Questionnaire Section
            List<string> questions = new List<string>
        {
            "What is your favorite hobby?",
            "What is your dream travel destination?",
            "What is your favorite movie?",
            "What do you like to do on weekends?",
            "What is your favorite meal?",
            "What is your favorite music genre?",
            "What qualities do you value in a partner?",
            "What is your idea of a perfect date?",
            "What are your career goals?",
            "What do you value most in life?"
        };

            List<string> questionnaire = new List<string>();

            Console.WriteLine("\nPlease answer the following questions:");
            for (int i = 0; i < questions.Count; i++)
            {
                Console.Write($"{questions[i]}: ");
                string response = Console.ReadLine();
                questionnaire.Add(response);
            }

            // Profile Summary Section
            Console.WriteLine("\nProfile Summary:");
            Console.WriteLine($"Name: {firstName} {lastName}");
            Console.WriteLine($"Age: {DateTime.Now.Year - birthYear}");
            Console.WriteLine($"Gender: {GetFullGenderDescription(gender)}");

            Console.WriteLine("\nQuestionnaire Responses:");
            for (int i = 0; i < questionnaire.Count; i++)
            {
                Console.WriteLine($"Question {i + 1}: {questions[i]}");
                Console.WriteLine($"Response {i + 1}: {questionnaire[i]}");
            }
        }

        // Exception Handeling
        static bool ContainsNumberOrSpecialChar(string input)
        {
            foreach (char c in input)
            {
                if (char.IsNumber(c) || char.IsSymbol(c) || char.IsPunctuation(c))
                    return true;
            }
            return false;
        }

        // Full Gender Description
        static string GetFullGenderDescription(string gender)
        {
            switch (gender)
            {
                case "M":
                    return "Male";
                case "F":
                    return "Female";
                case "O":
                    return "Other";
                default:
                    return "Unknown";
            }
        }
    }
}
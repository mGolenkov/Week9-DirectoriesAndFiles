using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DirectoriesAndFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string rootDirectory = @"C:\Users\TECH TOOL V110\samples";
            Console.WriteLine("Enter directory name: ");
            string newDirectory = Console.ReadLine();
            Console.WriteLine("Enter file name: ");
            string fileName = Console.ReadLine();

            if (Directory.Exists($"{rootDirectory}\\{newDirectory}") && File.Exists($"{rootDirectory}\\{newDirectory}\\{fileName}"))
            {
                Console.WriteLine($"Directory and File exist.");
            }
            else
            {
                Directory.CreateDirectory($"{rootDirectory}\\{newDirectory}");
                File.Create($"{rootDirectory}\\{newDirectory}\\{fileName}").Close();
            }

            //string fileLocation = $@"C:\User\Laptop\samples\{newDirectory}";
            //string userFileName = $@"C:\User\Laptop\samples\{newDirectory}\\{fileName};"

            string[] arrayFromFile = File.ReadAllLines($"{rootDirectory}\\{newDirectory}\\{fileName}");
            List<string> myWishList = arrayFromFile.ToList<string>();

            bool loopActive = true;

            while (loopActive)
            {
                Console.WriteLine("Would you like to add a wish? Y/N: ");
                char userInput = Convert.ToChar(Console.ReadLine().ToLower());

                if (userInput == 'y')
                {
                    Console.WriteLine("Enter your wish: ");
                    string userWish = Console.ReadLine();
                    myWishList.Add(userWish);
                }
                else
                {
                    loopActive = false;
                    Console.WriteLine("Take care!");
                }

                Console.Clear();

                foreach (string wish in myWishList)
                {
                    Console.WriteLine($"Your wish: {wish}.");
                }

                File.WriteAllLines($"{rootDirectory}\\{newDirectory}\\{fileName}", myWishList);
            }
        }
    }
}

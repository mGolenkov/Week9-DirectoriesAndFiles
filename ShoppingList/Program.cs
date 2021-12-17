﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MyWishListFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileLocation = @"C:\Users\TECH TOOL V110\samples\Shopping";
            string fileName = @"\\myWishList.txt";

            string[] arrayFromFile = File.ReadAllLines($"{fileLocation}{fileName}");
            List<string> myWishList = arrayFromFile.ToList<string>();

            bool loopActive = true;

            while (loopActive)
            {
                Console.WriteLine("Would you like to add a wish? Y/N: ");
                char userInput = Convert.ToChar(Console.ReadLine().ToLower());

                if (userInput == 'y')
                {
                    Console.WriteLine("Enter your wich: ");
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

                File.WriteAllLines($"{fileLocation}{fileName}", myWishList);
            }
        }
    }
}


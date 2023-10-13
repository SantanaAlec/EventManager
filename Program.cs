﻿// Copyright (c) <YOUR_NAME_HERE> <mewmewby2@gmail.com>. Licensed under the MIT Licence.
// See the LICENSE file in the repository root for full license text.

namespace EventManager
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            if (OperatingSystem.IsWindows())
            {
            }

            // Back up the cwd
            string cwd = Environment.CurrentDirectory;

            foreach (string arg in args)
            {
                string[] split = arg.Split('=');

                string key = split[0];
                string val = split.Length > 1 ? split[1] : string.Empty;

                switch (key)
                {
                    case "--hello":
                        Console.WriteLine("Hi!");
                        break;
                }
            }

            Console.WriteLine("Hello, World!");
        }
    }
}
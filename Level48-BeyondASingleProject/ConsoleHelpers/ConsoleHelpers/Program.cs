using Helpers;
using System;

int number = ConsoleHelpers.AskForNumber("Pick a number between 0 and 10.", 0, 10);
Console.WriteLine($"You picked {number}.");
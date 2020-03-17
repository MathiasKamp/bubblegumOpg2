using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace bubblegumMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            // her oprettes et ny gui objekt
            Gui gui = new Gui();
            // her oprettes et nyt dispenser objekt
            Dispenser dispenser = new Dispenser();
            // kalder min renderMenu() metode
            gui.RenderMenu();
            // kalder min FillDisepenser() metode som fylder min liste med Bubblegum Objekter
            dispenser.FillDispenser();
            bool start = false;
            
            
            while (!start)
            {
                // venter på userinput 
                int userInput = int.Parse(Console.ReadLine());
                // variable til at gemme hvor mange Bubblegum objekter der er i listen
                int count = dispenser.CountBubblegum();
                switch (userInput)
                {
                    // hvis brugeren har trykket 1
                    case 1:
                        // så trækkes et random Bubblegum Objekt fra listen
                        Bubblegum gum = dispenser.DrawRandomGum();
                        // navnet på objektet bliver udskrevet
                        Console.WriteLine($"You´ve got a gum of: {gum.Name} and the color is: {gum.Color}");
                        // tjekker på om der er flere Bubblegum objekter tilbage i listen
                        if (count == 0)
                        {
                            Console.WriteLine("there is no more gum in the machine please fill it up by pressing 4");
                        }
                        Thread.Sleep(2000);
                        Console.Clear();
                        gui.RenderMenu();
                        break;
                        // hvis brugeren har trykket 2
                    case 2:
                        // udskriver hvor mange Bubblegum objekter der er tilbage i listen
                        Console.WriteLine("bubblegum left in the machine: "+count);
                        Thread.Sleep(2000);
                        Console.Clear();
                        gui.RenderMenu();
                        break;
                        // hvis brugeren har trykket 3
                    case 3:
                        // tjekker om listen er tom
                        if (count == 0)
                        {
                            // fylder 55 Bubblegum objekter op
                            dispenser.FillDispenser();
                            Thread.Sleep(2000);
                            Console.Clear();
                            gui.RenderMenu();
                        }
                        else
                        {
                            // ellers så er listen ikke tom
                            Console.WriteLine("you can only fill the machine if its empty. there is: "+count +" left");
                            Thread.Sleep(2000);
                            Console.Clear();
                            gui.RenderMenu();
                        }
                        break;

                    case 4:
                        start = true;
                        break;

                        default:
                            Console.WriteLine("please enter a number between 1 - 4 ");
                            break;
                }

            }
        }
    }
}

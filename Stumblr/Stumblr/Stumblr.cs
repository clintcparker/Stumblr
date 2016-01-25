using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Stumblr
{
    public class Stumblr
    {
        private string _Name;
        private int _Health = 10;
        private int _BlocksFromHome = 10;
        private const string YouLookGood = "You're looking good!";
        private const string YouLookBad = "You're not looking so good";
        private const string FarFromHome = "You're a long way from home!";
        private const string AlmostThere = "Keep going. You're almost there!";
        private const int MaxAttempts = 10;


        public void StartAdventure()
        {
            //Startup, we need a name
            while (String.IsNullOrWhiteSpace(_Name))
            {
                Console.WriteLine("Please enter your name:");
                _Name = Console.ReadLine();
            }

            PrintNameByLetter();

            //Main loop
            for (var i=0;i<MaxAttempts;i++)
            {
                Console.WriteLine("You're {0} blocks from home", _BlocksFromHome);
                MentionDistance();
                MentionHealth();

                DoSomething();
                if (_BlocksFromHome == 0 || _Health == 0)
                {
                    break;
                }
            }
            
            //Success
            if (_BlocksFromHome == 0)
            {
                Console.WriteLine("You did it!");
                //return;
            }

            //Failure
            if (_Health <= 0)
            {
                Console.WriteLine("You're in no shape to be going anywhere.");
            }

            do
            {
                Console.WriteLine("Press Q to quit");
            }
            while (!Q_Entered());
        }

        private bool Q_Entered()
        {
            var readLine = Console.ReadLine();
            return readLine != null && readLine.Equals("q", StringComparison.InvariantCultureIgnoreCase);
        }

        private void PrintNameByLetter()
        {
            foreach (var letter in _Name)
            {
                Console.WriteLine(letter);
            }
        }

        private void MentionHealth()
        {
            string healthComment;
            if (_Health >= 10)
            {
                healthComment = YouLookGood;
            }
            else
            {
                healthComment = YouLookBad;
            }
            Console.WriteLine(healthComment);
        }

        private void MentionDistance()
        {
            var distanceComment = _BlocksFromHome >= 10 ? FarFromHome : AlmostThere;
            Console.WriteLine(distanceComment);
        }


        private void DoSomething()
        {
            int selection = 0;
            var isValid = false;

            while (!isValid)
            {
                Console.WriteLine("Please enter an integer");
                isValid = Int32.TryParse(Console.ReadLine(), out selection);
            };

            decider(selection);

        }


        private void decider(int selection)
        {
            if (selection % 2 == 0)
            {
                SomethingBadHappens(selection);
            }
            else
            {
                SomethingGoodHappens(selection);
            }
        }

        private void SomethingBadHappens(int selection)
        {
            var weirdnessFactor = selection % 3;
            switch (weirdnessFactor)
            {
                case 0:
                    _BlocksFromHome++;
                    Console.WriteLine("Ran from scary squirrel");
                    break;
                case 1:
                    _BlocksFromHome++;
                    _Health--;
                    Console.WriteLine("Ran from scary squirrel...and tripped");
                    break;
                default:
                    _BlocksFromHome++;
                    _Health--;
                    _Health--;
                    Console.WriteLine("Ran from scary squirrel...and tripped...and got attacked");
                    break;
            }
        }

        private void SomethingGoodHappens(int selection)
        {
            var weirdnessFactor = selection % 4;
            switch (weirdnessFactor)
            {
                case 0:
                    _BlocksFromHome--;
                    Console.WriteLine("One block down.");
                    break;
                case 1:
                    _BlocksFromHome--;
                    _Health--;
                    Console.WriteLine("Cartwheeled an entire block...room is now spinning");
                    break;
                case 2:
                    _BlocksFromHome--;
                    _BlocksFromHome--;
                    _Health++;
                    Console.WriteLine("Found skateboard...made it 2 whole blocks!");
                    break;
                default:
                    _BlocksFromHome = 0;
                    _Health++;
                    Console.WriteLine("Free Uber and a Gatorade!");
                    break;
            }
        }



    }


}

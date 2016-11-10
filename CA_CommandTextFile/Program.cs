using FinchAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_CommandTextFile
{
    public enum FinchCommand
    {
        DONE,
        MOVEFORWARD,
        MOVEBACKWARD,
        STOPMOTORS,
        DELAY,
        TURNRIGHT,
        TURNLEFT,
        LEDON,
        LEDOFF
    }

    class Program
    {
        static int numberOfCommands;
        static int delayDuration;
        static int motorSpeed;
        static int LEDBrightness;
        static Finch myFinch = new Finch();
        static FinchCommand[] commands;

        static void Main(string[] args)
        {
            DisplayOpeningScreen();

            DisplayMenu();

            DisplayClosingScreen();
        }

        //
        // menu
        //
        static void DisplayMenu()
        {
            int menuChoice;
            bool quit = false;

            while (!quit)
            {
                //
                // display header
                //
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Main Menu");
                Console.WriteLine();

                Console.WriteLine("1) Initialize Finch");
                Console.WriteLine("2) Set Command Parameters");
                Console.WriteLine("3) Get Commands");
                Console.WriteLine("4) Display Commands");
                Console.WriteLine("5) Execute Commands");
                Console.WriteLine("6) Terminate Finch");
                Console.WriteLine("7) Exit");
                Console.WriteLine();
                Console.Write("Enter the menu number of your chocie:");
                menuChoice = int.Parse(Console.ReadLine());

                switch (menuChoice)
                {
                    case 1:
                        DisplayInitializeFinch();
                        break;

                    case 2:
                        DisplayGetCommandParameters();
                        break;
                    case 3:
                        DisplayGetFinchCommands();
                        break;
                    case 4:
                        DisplayCommands();
                        break;
                    case 5:
                        ExecuteCommands();
                        break;
                    case 6:
                        DisplayTerminateFinch();
                        break;

                    case 7:
                        quit = true;
                        break;

                    default:
                        Console.WriteLine("That is not a valid response.");
                        break;
                }
            }
        }

        //
        // opening screen
        //
        static void DisplayOpeningScreen()
        {
            //
            // display opening screen
            //
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Welcome to Our Application");
            Console.WriteLine();
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        //
        // closing screen
        //
        static void DisplayClosingScreen()
        {
            //
            // display closing screen
            //
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Thank you for using our application");
            Console.WriteLine();
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        //
        // continue prompt
        //
        static void DisplayContinuePrompt()
        {
            //
            // display continue prompt
            //
            Console.WriteLine();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        static void DisplayInitializeFinch()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Initialize Finch");
            Console.WriteLine();
            Console.WriteLine();

            myFinch.connect();

            Console.WriteLine("Finch Initialized!");

            DisplayContinuePrompt();
        }

        static void DisplayTerminateFinch()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Terminate Finch");
            Console.WriteLine();
            Console.WriteLine();

            myFinch.connect();

            Console.WriteLine("Finch Terminated!");

            DisplayContinuePrompt();
        }

        static void DisplayGetCommandParameters()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Setup Command Parameters");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Instructions!!!");

            DisplayContinuePrompt();

            DisplayGetNumberOfFinchCommands();
            DisplayGetDelayDuration();
            DisplayGetMotorSpeed();
            DisplayGetLEDBrightness();

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Setup Command Parameters");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine($"Number of Finch Commands: {numberOfCommands}");
            Console.WriteLine($"Command Duration: {delayDuration}");
            Console.WriteLine($"Motor Speed: {motorSpeed}");
            Console.WriteLine($"LED Brightness: {LEDBrightness}");

            DisplayContinuePrompt();
        }

        static void DisplayGetNumberOfFinchCommands()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Finch Commands");
            Console.WriteLine();
            Console.WriteLine();

            Console.Write("Enter the number of commands:");
            numberOfCommands = int.Parse(Console.ReadLine());

            //
            // instantiate
            //
            commands = new FinchCommand[numberOfCommands];

            DisplayContinuePrompt();
        }

        static void DisplayGetDelayDuration()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Delay Duration");
            Console.WriteLine();
            Console.WriteLine();

            Console.Write("Enter the number of seconds for each command:");
            delayDuration = int.Parse(Console.ReadLine()) * 1000;

            DisplayContinuePrompt();
        }

        static void DisplayGetMotorSpeed()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Motor Speed");
            Console.WriteLine();
            Console.WriteLine();

            Console.Write("Enter the speed for the motor (0-255):");
            motorSpeed = int.Parse(Console.ReadLine());

            DisplayContinuePrompt();
        }

        static void DisplayGetLEDBrightness()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("LED Brightness");
            Console.WriteLine();
            Console.WriteLine();

            Console.Write("Enter the brightness for the LED (0-255):");
            LEDBrightness = int.Parse(Console.ReadLine());

            DisplayContinuePrompt();
        }

        static void DisplayGetFinchCommands()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Enter Finch Commands");
            Console.WriteLine();
            Console.WriteLine();

            string userResponse;
            FinchCommand finchCommandChoice;

            for (int index = 0; index < numberOfCommands; index++)
            {
                Console.Write($"Enter command {index + 1}: ");
                userResponse = Console.ReadLine().ToUpper();
                Enum.TryParse<FinchCommand>(userResponse, out finchCommandChoice);

                commands[index] = finchCommandChoice;
            }


            DisplayContinuePrompt();
        }

        static void DisplayCommands()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("List of Commands");
            Console.WriteLine();
            Console.WriteLine();

            foreach (FinchCommand command in commands)
            {
                Console.WriteLine(command);
            }

            DisplayContinuePrompt();
        }

        static void ExecuteCommands()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Execute Commands");
            Console.WriteLine();
            Console.WriteLine();

            DisplayContinuePrompt();

            foreach (FinchCommand command in commands)
            {
                switch (command)
                {
                    case FinchCommand.DONE:
                        break;
                    case FinchCommand.MOVEFORWARD:
                        Console.WriteLine("Now moving forward.");
                        myFinch.setMotors(motorSpeed, motorSpeed);                       
                        break;
                    case FinchCommand.MOVEBACKWARD:
                        Console.WriteLine("Now moving backward.");
                        myFinch.setMotors(-motorSpeed, -motorSpeed);
                        break;
                    case FinchCommand.STOPMOTORS:
                        myFinch.setMotors(0, 0);
                        break;
                    case FinchCommand.DELAY:
                        myFinch.wait(delayDuration);
                        break;
                    case FinchCommand.TURNRIGHT:
                        myFinch.setMotors(motorSpeed, -motorSpeed);
                        break;
                    case FinchCommand.TURNLEFT:
                        myFinch.setMotors(-motorSpeed, motorSpeed);
                        break;
                    case FinchCommand.LEDON:
                        myFinch.setLED(LEDBrightness, LEDBrightness, LEDBrightness);
                        break;
                    case FinchCommand.LEDOFF:
                        myFinch.setLED(0, 0, 0);
                        break;
                    default:
                        break;
                }
            }

            DisplayContinuePrompt();
        }

    }
}

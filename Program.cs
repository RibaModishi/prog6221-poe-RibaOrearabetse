using System;

namespace CybersecurityAwarenessBot
{
    /// <summary>
    /// Main program class - coordinates the application flow
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize services
            var renderer = new ConsoleRenderer();
            var audioService = new AudioService();

            // Show header
            renderer.DisplayAsciiArt();

            // Play welcome audio
            audioService.PlayWelcomeAudio();

            // Get user name with validation
            string userName = GetUserName(renderer);

            // Initialize knowledge base with user's name
            var knowledge = new KnowledgeBase(userName);

            // Initialize input processor with dependencies
            var inputProcessor = new InputProcessor(knowledge, renderer, audioService, userName);

            // Start main conversation loop
            RunConversationLoop(renderer, inputProcessor);
        }

        /// <summary>
        /// Gets and validates the user's name
        /// </summary>
        /// <returns>Validated user name</returns>
        static string GetUserName(ConsoleRenderer renderer)
        {
            string userName;
            do
            {
                renderer.DisplayColoredMessage("Please enter your name: ", ConsoleColor.Magenta);
                userName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(userName))
                {
                    renderer.DisplayColoredMessage("Name cannot be empty. Please try again.", ConsoleColor.Red);
                }
            } while (string.IsNullOrWhiteSpace(userName));

            renderer.DisplayColoredMessage($"\nHello, {userName}! I'm your Cybersecurity Awareness Assistant.", ConsoleColor.Green);
            Console.WriteLine($"Current South African cyber threats you should know about:");
            Console.WriteLine("- Fake SARS eFiling notifications\n- Banking app SIM swap scams\n- 'Hi Mum' WhatsApp scams\n");

            return userName;
        }

        /// <summary>
        /// Runs the main conversation loop until user exits
        /// </summary>
        static void RunConversationLoop(ConsoleRenderer renderer, InputProcessor processor)
        {
            renderer.DisplayHelpMenu();

            // Continue conversation until user requests to exit
            while (true)
            {
                renderer.DisplayColoredMessage("\nWhat would you like to talk about? (type 'help' for options): ", ConsoleColor.Yellow);
                string input = Console.ReadLine();

                if (processor.ProcessInput(input))
                {
                    break; // Exit if ProcessInput returns true
                }
            }
        }
    }
}
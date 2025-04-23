namespace CybersecurityAwarenessBot
{
    /// <summary>
    /// Handles all user input processing and response generation
    /// </summary>
    public class InputProcessor
    {
        private readonly KnowledgeBase _knowledge;
        private readonly ConsoleRenderer _renderer;
        private readonly AudioService _audioService;
        private readonly string _userName;

        public InputProcessor(KnowledgeBase knowledge, ConsoleRenderer renderer, AudioService audioService, string userName)
        {
            _knowledge = knowledge;
            _renderer = renderer;
            _audioService = audioService;
            _userName = userName;
        }

        /// <summary>
        /// Processes user input and generates appropriate responses
        /// </summary>
        /// <param name="input">User's input text</param>
        /// <returns>True if user requested to exit, False otherwise</returns>
        public bool ProcessInput(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                _renderer.DisplayColoredMessage("I didn't catch that. Please type something.", ConsoleColor.Red);
                return false;
            }

            // Check for exit commands first
            if (IsExitCommand(input)) return true;

            // Check for help command
            if (input.Equals("help", StringComparison.OrdinalIgnoreCase))
            {
                _renderer.DisplayHelpMenu();
                return false;
            }

            // Check for cybersecurity topics list request
            if (input.Equals("cybersecurity", StringComparison.OrdinalIgnoreCase))
            {
                _renderer.DisplayCybersecurityTopics(_knowledge.Topics);
                return false;
            }

            // Check if input matches any cybersecurity topic
            if (_knowledge.Topics.TryGetValue(input, out string topicInfo))
            {
                _renderer.DisplayColoredMessage($"\n{topicInfo}", ConsoleColor.Cyan);
                return false;
            }

            // Check if input matches any small talk phrase
            if (_knowledge.SmallTalk.TryGetValue(input, out string response))
            {
                _renderer.DisplayColoredMessage($"\n{response}", ConsoleColor.Green);
                return false;
            }

            // Input didn't match anything - show default response
            _renderer.DisplayColoredMessage($"\nI'm not sure I understand, {_userName}. Try asking about cybersecurity topics or type 'help' for options.", ConsoleColor.Red);
            return false;
        }

        /// <summary>
        /// Checks if the user input is an exit command
        /// </summary>
        private bool IsExitCommand(string input)
        {
            if (input.Equals("exit", StringComparison.OrdinalIgnoreCase) ||
                input.Equals("quit", StringComparison.OrdinalIgnoreCase))
            {
                _renderer.DisplayExitMessage(_userName);
                _audioService.PlayNotificationSound();
                return true;
            }
            return false;
        }
    }
}
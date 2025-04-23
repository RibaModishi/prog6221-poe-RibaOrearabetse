using System.Collections.Generic;

namespace CybersecurityAwarenessBot
{
    /// <summary>
    /// Contains all the bot's knowledge - responses to topics and small talk
    /// </summary>
    public class KnowledgeBase
    {
        public Dictionary<string, string> Topics { get; private set; }
        public Dictionary<string, string> SmallTalk { get; private set; }

        /// <summary>
        /// Initializes all response data
        /// </summary>
        /// <param name="userName">Current user's name for personalization</param>
        public KnowledgeBase(string userName)
        {
            InitializeTopics(userName);
            InitializeSmallTalk(userName);
        }

        /// <summary>
        /// Sets up all cybersecurity topics with their explanations
        /// </summary>
        private void InitializeTopics(string userName)
        {
            Topics = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                {"phishing", "Phishing:\nCybercriminals send fake emails or messages pretending to be from reputable organizations to trick you into revealing personal information. In South Africa, common phishing scams target banking customers with fake 'security alerts'."},
                {"password safety", "Password Safety:\nUse strong, unique passwords for each account (minimum 12 characters with mix of letters, numbers, and symbols). Consider using a password manager. Never share your passwords or write them down."},
                {"safe browsing", "Safe Browsing:\nAlways check for 'https://' and the padlock icon in your browser. Avoid clicking suspicious links. In South Africa, be especially careful with .co.za domains that look similar to legitimate sites."},
                {"social engineering", "Social Engineering:\nScammers manipulate people into giving up confidential information. Common in South Africa are 'Hi Mum' scams where criminals pretend to be family members needing money urgently."},
                {"vishing", "Vishing:\nVoice phishing scams conducted over the phone. In South Africa, criminals often pretend to be from banks, SARS, or service providers to get your personal details."},
                {"malware", "Malware:\nMalicious software designed to harm your device or steal data. Common in SA through pirated software downloads. Only install apps from official app stores."},
                {"public wifi", "Public WiFi Risks:\nAvoid accessing sensitive accounts on public WiFi. If necessary, use a VPN. Many South African malls and cafes have insecure networks."}
            };
        }

        /// <summary>
        /// Sets up all casual conversation responses
        /// </summary>
        private void InitializeSmallTalk(string userName)
        {
            SmallTalk = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                {"hello", $"Hello {userName}! How can I help you with cybersecurity today?"},
                {"hi", $"Hi there {userName}! Ready to learn about staying safe online?"},
                {"how are you", $"I'm doing great {userName}, thanks for asking! I'm always ready to discuss cybersecurity."},
                {"what's up", $"Not much {userName}, just here to help you stay safe in the digital world!"},
                {"what can you do", $"I can teach you about {string.Join(", ", Topics.Keys)}. Just ask about any of these topics or type 'cybersecurity' to see all options."},
                {"purpose", $"My purpose is to help South African citizens like you, {userName}, understand and protect against common cyber threats through education and awareness."},
                {"thanks", $"You're welcome {userName}! Stay vigilant against cyber threats."},
                {"thank you", $"My pleasure {userName}! Remember to always verify requests for personal information."}
            };
        }
    }
}
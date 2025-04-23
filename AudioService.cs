using System;
using System.IO;
using NAudio.Wave;
using System.Threading;
using System.Media; // Required for SystemSounds

namespace CybersecurityAwarenessBot
{
    public class AudioService : IDisposable
    {
        private WaveOutEvent _waveOut;
        private AudioFileReader _audioFile;
        private bool _isDisposed;

        public void PlayWelcomeAudio()
        {
            try
            {
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "greetings_welcome_chatbot.mp3");

                if (File.Exists(filePath))
                {
                    StopPlayback();

                    _audioFile = new AudioFileReader(filePath);
                    _waveOut = new WaveOutEvent();
                    _waveOut.Init(_audioFile);
                    _waveOut.Play();

                    // Wait for playback to complete
                    while (_waveOut.PlaybackState == PlaybackState.Playing)
                    {
                        Thread.Sleep(100);
                    }
                }
                else
                {
                    Console.WriteLine("Audio file not found: greetings_welcome_chatbot.mp3");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Audio playback error: {ex.Message}");
                Dispose();
            }
        }

        public void PlayNotificationSound()
        {
            try
            {
                Console.Beep(); // Works in most Windows environments
            }
            catch
            {
                // Silent fail if even console beep doesn't work
            }
        }

        public void StopPlayback()
        {
            _waveOut?.Stop();
            _audioFile?.Dispose();
            _audioFile = null;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    StopPlayback();
                    _waveOut?.Dispose();
                }
                _isDisposed = true;
            }
        }

        ~AudioService()
        {
            Dispose(false);
        }
    }
}
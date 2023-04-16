using System;
namespace CipherServices.Services
{
    public class Encrypter : IEncrypter
    {
        private static readonly char[] alphabet = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

        public string Encrypt(string message)
        {
            char[] encryptedMessage = new char[message.Length];

            for (int i = 0; i < message.Length; i++)
            {
                char letter = message[i];
                int letterPosition = Array.IndexOf(alphabet, letter);
                int newLetterPosition = (letterPosition + 3) % alphabet.Length;
                encryptedMessage[i] = alphabet[newLetterPosition];
            }

            return new string(encryptedMessage);
        }
    }
}
using System;
namespace CipherServices.Services
{
    public class Decrypter : IDecrypter
    {
        private static readonly char[] alphabet = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

        public string Decrypt(string message)
        {
            char[] decryptedMessage = new char[message.Length];

            for (int i = 0; i < message.Length; i++)
            {
                char letter = message[i];
                int letterPosition = Array.IndexOf(alphabet, letter);
                int newLetterPosition;
                if (letterPosition <= 2)
                    newLetterPosition = alphabet.Length - (3 - letterPosition);
                else
                    newLetterPosition = (letterPosition - 3) % alphabet.Length;
                decryptedMessage[i] = alphabet[newLetterPosition];
            }

            return new string(decryptedMessage);
        }
    }
}
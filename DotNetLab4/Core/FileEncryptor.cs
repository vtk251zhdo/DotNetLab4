using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetLab4_FileEncryptor.Core
{
    public class FileEncryptor
    {
        public void EncryptFile(string inputPath, string outputPath, string key,
                               IProgress<int> progress = null)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentException("Ключ не може бути порожнім", nameof(key));

            if (!File.Exists(inputPath))
                throw new FileNotFoundException("Вхідний файл не знайдено", inputPath);

            byte[] keyBytes = System.Text.Encoding.UTF8.GetBytes(key);
            long totalBytes = new FileInfo(inputPath).Length;
            long processedBytes = 0;

            const int bufferSize = 4096;
            byte[] buffer = new byte[bufferSize];

            using (FileStream input = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
            using (FileStream output = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
            {
                int read;
                int keyIndex = 0;

                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    for (int i = 0; i < read; i++)
                    {
                        buffer[i] = (byte)(buffer[i] ^ keyBytes[keyIndex]);
                        keyIndex++;
                        if (keyIndex >= keyBytes.Length)
                            keyIndex = 0;
                    }

                    output.Write(buffer, 0, read);

                    processedBytes += read;
                    int percent = (int)(processedBytes * 100 / totalBytes);
                    progress?.Report(percent);
                }
            }
        }
    }
}

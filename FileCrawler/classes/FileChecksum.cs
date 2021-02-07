using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace FileCrawler.classes
{
    class FileChecksum
    {

        public static string GetChecksum(string filePath)
        {
            using (var stream = new BufferedStream(File.OpenRead(filePath), 1200000))
            //using (FileStream stream = File.OpenRead(file))
            {
                SHA256Managed sha = new SHA256Managed();
                byte[] checksum = sha.ComputeHash(stream);
                return BitConverter.ToString(checksum).Replace("-", String.Empty);
            }
        }
    }
}




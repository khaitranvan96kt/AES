using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AESWork
{
    class Encrypt
    {
        public void Start(string filename_in,string filename_out,string password, int length)
        {
            CryptoStream cs;
            using (FileStream fout = new FileStream(filename_out, FileMode.Create))
            {
                using (Aes aesAlg = Aes.Create())
                {
                    UnicodeEncoding UE = new UnicodeEncoding();
                    byte[] key = UE.GetBytes(password);
                    Console.WriteLine(UE.GetString(key));
                    //aesAlg.BlockSize = length;
                     cs = new CryptoStream(fout,
                      aesAlg.CreateEncryptor(key, key),
                      CryptoStreamMode.Write);
                    using(FileStream fin = new FileStream(filename_in, FileMode.Open, FileAccess.Read))
                    {
                        int data;
                        while ((data = fin.ReadByte()) != -1)
                        {
                            cs.WriteByte((byte)data);
                        }
                           
                    }
                }
            }
            
            
        }
    }
}

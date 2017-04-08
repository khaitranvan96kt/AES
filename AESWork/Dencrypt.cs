using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AESWork
{
    class Dencrypt
    {
        public void Start(string filename_in, string filename_out, string pass, int length)
        {
            CryptoStream cs;
            using (FileStream fIn = new FileStream(filename_in, FileMode.Open, FileAccess.Read))
            {
                using (Aes aesAlg = Aes.Create())
                {
                    UnicodeEncoding UE = new UnicodeEncoding();
                    aesAlg.Key = UE.GetBytes(pass);
                    aesAlg.IV = UE.GetBytes(pass);
                   // aesAlg.BlockSize = length;
                    cs = new CryptoStream(fIn,
                     aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV),
                     CryptoStreamMode.Read);
                    using(FileStream fout = new FileStream(filename_out, FileMode.Create, FileAccess.Write))
                    {
                        
                        try
                        {
                            while (true)
                            {
                                fout.WriteByte((byte)cs.ReadByte());
                            }
                        }
                        catch { }
                        

                    }
                }
            }
          //  Console.WriteLine(cs);
        }
    }
}

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
        public void Start(string filename_in, string filename_out, string pass,int length)
        {
            CryptoStream cs;

            using (FileStream fIn = new FileStream(filename_in, FileMode.Open, FileAccess.Read))
            {
                using (Aes aesAlg = Aes.Create())
                {
                    //aesAlg.KeySize = length;
                    byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(pass, saltBytes);
                    if (aesAlg != null)
                    {
                        aesAlg.KeySize = length;
                        aesAlg.Key = pdb.GetBytes(aesAlg.KeySize/8);
                        aesAlg.IV = pdb.GetBytes(16);
                        cs = new CryptoStream(fIn,
                            aesAlg.CreateDecryptor(),
                            CryptoStreamMode.Read);
                        using (FileStream fout = new FileStream(filename_out, FileMode.Create, FileAccess.Write))
                        {

                            try
                            {
                                while (true)
                                {
                                    fout.WriteByte((byte)cs.ReadByte());
                                }
                            }
                            catch
                            {
                                // ignored
                            }
                        }
                    }
                    
                }
            }
          //  Console.WriteLine(cs);
        }
    }
}

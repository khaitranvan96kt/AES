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
        public void Start(string filename_in,string filename_out,string password,int length)
        {
            CryptoStream cs;
            using (FileStream fout = new FileStream(filename_out, FileMode.Create))
            {
                using (Aes aesAlg = Aes.Create())
                {
                    byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
                    UnicodeEncoding UE = new UnicodeEncoding();
                    byte[] key = UE.GetBytes(password);
                    byte[] iv = new byte[key.Length];
                    Console.WriteLine(UE.GetString(key));
                    //aesAlg.BlockSize = length;
                    if (aesAlg != null)
                    {
                        aesAlg.KeySize = length;
                        Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(password, saltBytes);
                        aesAlg.Key = pdb.GetBytes(aesAlg.KeySize /8);
                        aesAlg.IV = pdb.GetBytes(16);
                       Console.WriteLine("\nIV:");
                        foreach (var variable in aesAlg.IV)
                        {
                            Console.Write(variable);
                        }
                        Console.WriteLine("\nKey:");
                        foreach (var variable in aesAlg.Key)
                        {
                            Console.Write(variable);
                        }
                        Console.Write("\n");
                        cs = new CryptoStream(fout, aesAlg.CreateEncryptor(), CryptoStreamMode.Write);
                        using (FileStream fin = new FileStream(filename_in, FileMode.Open, FileAccess.Read))
                        {
                            int data;
                            while ((data = fin.ReadByte()) != -1)
                            {
                                cs.WriteByte((byte)data);
                            }

                        }
                    }
                    else
                    {
                        Console.WriteLine("AESALG == Null");
                    }
                       
                }
            }
            
            
        }
    }
}

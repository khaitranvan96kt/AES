using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AESWork
{
    
    class Controler
    {
        Encrypt en = new Encrypt();
        Dencrypt de = new Dencrypt();
        Animation ani = new Animation();

        [STAThread]
        public void Start()
        {
           // Thread t1 = new Thread(ani.Turn);
            Console.WriteLine("MA HOA vs GIA MA FILE AES");
            Console.WriteLine("1: Ma hoa");
            Console.WriteLine("2: Gia ma");
            Console.Write("\nNhap: ");
            int input_value = int.Parse(Console.ReadLine());
            switch (input_value)
            {
                case 1:
                    Console.WriteLine("Chon file can ma hoa");
                    string filename_input = OpenDialog();
                    Console.WriteLine("Nhap password: ");
                    string pass = Console.ReadLine();
                    Console.WriteLine("Nhap data_length: ");
                    Console.WriteLine("\t128");
                    Console.WriteLine("\t192");
                    Console.WriteLine("\t256");
                    int length = int.Parse(Console.ReadLine());
                    if (length != 128 && length != 192 && length != 256)
                    {
                        Console.WriteLine("Gia tri nhap khong duoc chap nhan!");
                        break;
                    }
                    Console.WriteLine("Chon noi luu file da ma hoa");
                    string filename_output = SaveDialog();
                    Console.WriteLine("Loading ....");
                   // t1.Start();
                    en.Start(filename_input, filename_output, pass, length);
                   
                    break;
                case 2:
                    Console.WriteLine("Chon file can giai ma");
                    string filename_inputt = OpenDialog();
                    Console.WriteLine("Nhap password: ");
                    string passs = Console.ReadLine();
                    Console.WriteLine("Nhap data_length: ");
                    Console.WriteLine("\t128");
                    Console.WriteLine("\t192");
                    Console.WriteLine("\t256");
                    int lengthh = int.Parse(Console.ReadLine());
                    if (lengthh != 128 && lengthh != 192 && lengthh != 256)
                    {
                        Console.WriteLine("Gia tri nhap khong duoc chap nhan!");
                        break;
                    }
                    Console.WriteLine("Chon noi luu file giai ma");
                    string filename_outputt = SaveDialog();
                    de.Start(filename_inputt, filename_outputt, passs, lengthh);
                    break;
                default:
                    Console.WriteLine("Khong dung chuc nang");
                    break;
            }
        }

         
        private string OpenDialog()
        {
            string path = null;
            OpenFileDialog OpenDialog = new OpenFileDialog();
            OpenDialog.Filter = "All Files (*.*)|*.*";
            OpenDialog.FilterIndex = 1;        
            if (OpenDialog.ShowDialog() == DialogResult.OK)
            {
                path = OpenDialog.InitialDirectory + OpenDialog.FileName;
                Console.WriteLine(path);
            }
            return path;
        }
        private string SaveDialog()
        {
            string path = null;
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "All Files (*.*)|*.*";
            saveDialog.FilterIndex = 1;
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                path = saveDialog.InitialDirectory + saveDialog.FileName;
            }
            return path;
               
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Day01TextFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int NUM = 3;
            const string strFile = "data.txt";
            string strName;
            string strLine = "";
            StreamWriter sw = null;
            Console.WriteLine("Please enter your name.");
            strName = Console.ReadLine();
            try
            {
                using (sw = new StreamWriter(strFile))
                {
                    sw.WriteLine("==========================");
                    for (int i = 0; i < NUM; i++)
                    {
                        sw.WriteLine(strName);
                    }
                }

                using (StreamReader sr = new StreamReader(strFile))
                {
                    while ((strLine = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(strLine);
                    }
                }
            }

            catch (SystemException e)
            {
                Console.WriteLine(e.Message);
            }

            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            finally
            {
                if(sw != null)  
                    sw.Close();
                Console.ReadKey();
            }

            
        }
    }
}

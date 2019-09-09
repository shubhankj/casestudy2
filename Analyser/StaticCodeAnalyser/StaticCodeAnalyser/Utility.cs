//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Text.RegularExpressions;
//using System.Threading.Tasks;

//namespace StaticCodeAnalyzer
//{
//    public class Utility
//    {

//        internal static int WriteFileToCSV(string file1, string myfile)
//        {

//            if (File.Exists(file1))
//            {

//                string[] lines = File.ReadAllLines(file1);
//                FileStream f = new FileStream(myfile, FileMode.OpenOrCreate);
//                StreamWriter s = new StreamWriter(f);
//                f.Seek(f.Length, SeekOrigin.Begin);

//                for (int i = 0; i < lines.Length; i++)
//                {
//                    StringBuilder line = new StringBuilder(lines[i]);
//                    line.Replace(',', '.');
//                    Regex regex = new Regex(":\\d+ .+:");
//                    StringBuilder modifiedLine = new StringBuilder(regex.Replace(line.ToString(), ","));
//                    Regex regex1 = new Regex(@":(?!\\)");
//                    StringBuilder modifiedLine1 = new StringBuilder(regex1.Replace(modifiedLine.ToString(), ","));
//                    s.WriteLine(modifiedLine1);

//                }

//                s.Close();
//                f.Close();

//                return 0;

//            }
//            else
//                return 1;


//            //string textLine = "";
//            //if(System.IO.File.Exists(file1)==true)
//            //{
//            //    System.IO.StreamReader objReader;
//            //    objReader = new System.IO.StreamReader(file1);

//            //    do
//            //    {
//            //        textLine = textLine + objReader.ReadLine() + "\r\n";

//            //    } while (objReader.Peek() != -1);
//            //    objReader.Close();


//            //FileStream fs = new FileStream(myfile, FileMode.OpenOrCreate, FileAccess.ReadWrite);
//            //StreamReader sr = new StreamReader(fs);
//            //string content = File.ReadAllText(file);
//            //StringBuilder contents = new StringBuilder(content);

//            //File.AppendAllText(myfile, content);

//        }



//    }
//}

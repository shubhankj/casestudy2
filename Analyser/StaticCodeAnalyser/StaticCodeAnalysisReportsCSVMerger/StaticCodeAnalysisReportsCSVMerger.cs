using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IStaticCodeAnalysisToolParserLib;
using PMDReportParserLib;

namespace StaticCodeAnalysisReportsCSVMergerLib
{
    public class StaticCodeAnalysisReportsCSVMerger
    {
        public void WriteReportsToCSV(Dictionary<IStaticCodeAnalysisToolParser, string> reports, string outfile)
        {
            IStaticCodeAnalysisToolParser parser;
            for (int i=0; i<reports.Count; i++)
            {
                string[] lines = File.ReadAllLines(reports.ElementAt(i).Value);
                parser = reports.ElementAt(i).Key;
                lines = parser.ParseReportToCSV(lines);

                FileStream f = new FileStream(outfile, FileMode.OpenOrCreate);
                StreamWriter s = new StreamWriter(f);
                f.Seek(f.Length, SeekOrigin.Begin);

                foreach (string line in lines)
                {
                    s.WriteLine(line);
                }

                s.Close();
                f.Close();
            }
        }
    }
}

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
        public bool WriteReportsToCSV(IStaticCodeAnalysisToolParser parser, string report, string outfile)
        {
            if (!File.Exists(report))
                return false;
            string[] lines = File.ReadAllLines(report);
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

            return true;
        }
    }
}

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
        public void WriteReportsToCSV(Queue<string> reports, string outfile)
        {
            IStaticCodeAnalysisToolParser parser;
            while (reports.Count > 0)
            {
                string[] lines = File.ReadAllLines(reports.Dequeue());
                parser = new PMDReportParser();
                lines = parser.ParseReportToCSV(lines);

            }
        }
    }
}

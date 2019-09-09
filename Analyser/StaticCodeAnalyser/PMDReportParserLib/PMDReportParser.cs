using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IStaticCodeAnalysisToolParserLib;
using System.IO;
using System.Text.RegularExpressions;

namespace PMDReportParserLib
{
    public class PMDReportParser : IStaticCodeAnalysisToolParser
    {
        public string[] ParseReportToCSV(string[] lines)
        {
            for (int i = 0; i < lines.Length; i++)
            {
                StringBuilder line = new StringBuilder(lines[i]);
                line.Replace(',', ';');
                Regex regex = new Regex(":\\d+ .+:");
                StringBuilder modifiedLine = new StringBuilder(regex.Replace(line.ToString(), ","));
                Regex regex1 = new Regex(@":(?!\\)");
                modifiedLine = new StringBuilder(regex1.Replace(modifiedLine.ToString(), ","));

                lines[i] = modifiedLine.ToString();
            }

            return lines;
        }
    }
}

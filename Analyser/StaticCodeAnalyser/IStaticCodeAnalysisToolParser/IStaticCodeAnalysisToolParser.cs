using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IStaticCodeAnalysisToolParserLib
{
    public interface IStaticCodeAnalysisToolParser
    {
        string[] ParseReportToCSV(string[] lines);
    }
}

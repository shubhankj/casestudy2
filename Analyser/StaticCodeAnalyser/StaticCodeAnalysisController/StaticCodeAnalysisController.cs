using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StaticCodeAnalysisToolContractLib;
using StaticCodeAnalysisReportsCSVMergerLib;
using IStaticCodeAnalysisToolParserLib;

namespace StaticCodeAnalysisControllerLib
{
    public class StaticCodeAnalysisController
    {
        public string AnalyseUsingTool(IStaticCodeAnalysisTool tool, string codeDirectoryPath)
        {
            return tool.Analyse(codeDirectoryPath);
        }

        public void Merge(IStaticCodeAnalysisToolParser parser, string report, string outfile)
        {
                StaticCodeAnalysisReportsCSVMerger merger = new StaticCodeAnalysisReportsCSVMerger();
                merger.WriteReportsToCSV(parser, report, outfile);
        }
    }
}

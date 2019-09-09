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
        private Dictionary<IStaticCodeAnalysisToolParser, string> reportsQueue;

        public StaticCodeAnalysisController()
        {
            reportsQueue = new Dictionary<IStaticCodeAnalysisToolParser, string>();
        }
        public int AnalyseUsingTool(IStaticCodeAnalysisTool tool, string batFilePath, string codeDirectoryPath, string reportFilePath)
        {
            reportsQueue.Add(tool.GetParserObject(),reportFilePath);       //  Changes Required
            return tool.Analyse(batFilePath, codeDirectoryPath, reportFilePath);
        }

        public void Merge(string outfile)
        {
            if (reportsQueue.Count > 0)
            {
                StaticCodeAnalysisReportsCSVMerger merger = new StaticCodeAnalysisReportsCSVMerger();
                merger.WriteReportsToCSV(reportsQueue, outfile);
            }
        }

        //public int MergeReports(string[] reports, string outfile)
        //{
        //    int status1 = 1, status2 = 1;
        //    try
        //    {
        //        System.IO.File.WriteAllText(outfile, string.Empty);
        //        status1 = Utility.WriteFileToCSV(file1, outfile);

        //        status2 = Utility.WriteFileToCSV(file2, outfile);

        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //        Console.WriteLine("Cannot merge reports");
        //        return 1;
        //    }
        //    if (status1 == 0 && status2 == 0)
        //        return 0;
        //    else
        //        return 1;
        //}
    }
}

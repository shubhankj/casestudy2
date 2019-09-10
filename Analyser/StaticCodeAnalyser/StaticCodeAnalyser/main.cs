using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StaticCodeAnalysisControllerLib;
using StaticCodeAnalysisPMDToolLib;
using StaticCodeAnalysisSchedulerLib;

namespace StaticCodeAnalyzer
{
    public class main
    {
        public static int Main(string[] args)
        {
            Directory.SetCurrentDirectory(@"..\..\..\..\");
            string sampleCodeDirectory = @"feereport";
            string outputFile = @"FinalReport.csv";

            //StaticCodeAnalysisController controller = new StaticCodeAnalysisController();
            //controller.AnalyseUsingTool(pMDTool, pMDBatFile, sampleCodeDirectory);
            //controller.Merge(outputFile);         DO THIS USING SCHEDULER

            StaticCodeAnalysisScheduler scheduler = new StaticCodeAnalysisScheduler();
            scheduler.RunAnalysisWithAllTools(sampleCodeDirectory, outputFile);

            //scheduler.RunAnalysisWithPMD(sampleCodeDirectory, outputFile);

            return 0;
        }

    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StaticCodeAnalysisSchedulerLib;

namespace StaticCodeAnalysisClientLib
{
    public class StaticCodeAnalysisClient
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
            if (scheduler.RunAnalysisWithAllTools(sampleCodeDirectory, outputFile))
                return 0;

            //scheduler.RunAnalysisWithPMD(sampleCodeDirectory, outputFile);

            return -1;
        }

    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StaticCodeAnalysisSchedulerLib;

namespace StaticCodeAnalysisClientLib
{
    public static class StaticCodeAnalysisClient
    {
        public static int Main(string[] args)
        {
            Directory.SetCurrentDirectory(@"..\..\..\..\");
            string sampleCodeDirectory = @"feereport";
            string outputFile = @"FinalReport.csv";

            StaticCodeAnalysisScheduler scheduler = new StaticCodeAnalysisScheduler();
            if (scheduler.RunAnalysisWithAllTools(sampleCodeDirectory, outputFile))
                return 0;

            return -1;
        }

    }
}

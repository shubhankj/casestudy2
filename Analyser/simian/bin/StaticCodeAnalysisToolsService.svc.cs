using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using StaticCodeAnalysisSchedulerLib;

namespace StaticCodeAnalysisToolsWebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PMDToolService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select PMDToolService.svc or PMDToolService.svc.cs at the Solution Explorer and start debugging.
    public class StaticCodeAnalysisToolsService : IStaticCodeAnalysisToolsService
    {
        public bool RunAllTools(string sampleCodeDirectory, string finalReportPath)
        {
            Directory.SetCurrentDirectory(@"C:\Users\320052125\casestudy2\Analyser");        //Set this path to the project folder
            StaticCodeAnalysisScheduler scheduler = new StaticCodeAnalysisScheduler();
            return scheduler.RunAnalysisWithAllTools(sampleCodeDirectory, finalReportPath);
        }

        public bool RunPMDTool(string sampleCodeDirectory, string finalReportPath)
        {
            Directory.SetCurrentDirectory(@"C:\Users\320052125\casestudy2\Analyser");        //Set this path to the project folder
            StaticCodeAnalysisScheduler scheduler = new StaticCodeAnalysisScheduler();
            return scheduler.RunAnalysisWithPMD(sampleCodeDirectory, finalReportPath);

        }


        //public string RunPMDTool()
        //{
        //    string pMDToolRuleset = @"C:\Users\320052125\casestudy2\Analyser\pmd-bin-6.16.0\bin\rulesets\java\quickstart.xml";
        //    string pMDBatFile = @"C:\Users\320052125\casestudy2\Analyser\pmd-bin-6.16.0\bin\pmd.bat";
        //    string sampleCodeDirectory = @"C:\Users\320052125\casestudy2\Analyser\feereport";
        //    string pmDReport = @"C:\Users\320052125\casestudy2\Analyser\PMDReport.txt";

        //    StaticCodeAnalysisPMDTool pMDTool = new StaticCodeAnalysisPMDTool();

        //    StaticCodeAnalysisController controller = new StaticCodeAnalysisController();
        //    controller.AnalyseUsingTool(pMDTool, sampleCodeDirectory);

        //    return pmDReport;
        //}
    }
}

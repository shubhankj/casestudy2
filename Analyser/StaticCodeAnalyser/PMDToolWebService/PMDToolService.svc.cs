using StaticCodeAnalysisControllerLib;
using StaticCodeAnalysisPMDToolLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PMDToolWebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PMDToolService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select PMDToolService.svc or PMDToolService.svc.cs at the Solution Explorer and start debugging.
    public class PMDToolService : IPMDToolService
    {
        public bool RunPMDTool(string batFilePath, string sampleCodeDirectory, string finalReportPath)
        {

            return false;
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

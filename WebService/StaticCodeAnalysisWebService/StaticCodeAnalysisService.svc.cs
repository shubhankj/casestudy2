using StaticCodeAnalysisControllerLib;
using StaticCodeAnalysisPMDToolLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using StaticCodeAnalysisWebService.PMDToolWebService;

namespace StaticCodeAnalysisWebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "StaticCodeAnalysisService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select StaticCodeAnalysisService.svc or StaticCodeAnalysisService.svc.cs at the Solution Explorer and start debugging.
    public class StaticCodeAnalysisService : IStaticCodeAnalysisService
    {
        
        int NoOfErrors;
        string filename = @"C:\Users\320052125\casestudy2\WebService\Errors.txt";
        public string AnalyseCode(string threshold)
        {
            string reportFilePath;

            var remoteAddress = new System.ServiceModel.EndpointAddress(@"http://localhost:58107/PMDToolService.svc");

            using (var productService = new PMDToolServiceClient(new System.ServiceModel.BasicHttpBinding(), remoteAddress))
            {
                //set timeout
                productService.Endpoint.Binding.SendTimeout = new TimeSpan(0, 0, 0, 10);

                //call web service method            
                reportFilePath = productService.RunPMDTool();
            }

            //PMDToolServiceClient pMDToolService = new PMDToolServiceClient();
            //string reportFilePath = pMDToolService.RunPMDTool();
            NoOfErrors = File.ReadLines(reportFilePath).Count();

            var file = File.Open(filename, FileMode.OpenOrCreate);
            using (StreamWriter sw = new StreamWriter(file))
            {
                file.Seek(file.Length, SeekOrigin.Begin);
                sw.WriteLine(NoOfErrors);

                if (NoOfErrors > Convert.ToInt32(threshold))
                    return "no";

                return "yes";
            }
        }

        public string AnalyseCodeAuto()
        {
            string pMDToolRuleset = @"C:\Users\320052125\casestudy2\Analyser\pmd-bin-6.16.0\bin\rulesets\java\quickstart.xml";
            string pMDBatFile = @"C:\Users\320052125\casestudy2\Analyser\pmd-bin-6.16.0\bin\pmd.bat";
            string sampleCodeDirectory = @"C:\Users\320052125\casestudy2\Analyser\feereport";
            string pmDReport = @"C:\Users\320052125\casestudy2\Analyser\PMDReport.txt";

            StaticCodeAnalysisPMDTool pMDTool = new StaticCodeAnalysisPMDTool(pMDToolRuleset);

            StaticCodeAnalysisController controller = new StaticCodeAnalysisController();
            controller.AnalyseUsingTool(pMDTool, pMDBatFile, sampleCodeDirectory, pmDReport);

            int lastLine = Convert.ToInt32(File.ReadLines(filename).Last());

            var file = File.Open(filename, FileMode.OpenOrCreate);
            using (StreamWriter sw = new StreamWriter(file))
            {
                file.Seek(file.Length, SeekOrigin.Begin);
                sw.WriteLine(NoOfErrors);
                if (NoOfErrors <= lastLine)
                    return "Yes";
                return "No";    //  NOT IMPLEMENTED
            }
        }
    }
}

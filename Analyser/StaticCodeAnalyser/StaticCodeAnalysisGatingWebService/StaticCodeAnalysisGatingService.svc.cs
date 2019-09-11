
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using StaticCodeAnalysisToolsWebService;

namespace StaticCodeAnalysisGatingWebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "StaticCodeAnalysisService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select StaticCodeAnalysisService.svc or StaticCodeAnalysisService.svc.cs at the Solution Explorer and start debugging.
    public class StaticCodeAnalysisGatingService : IStaticCodeAnalysisGatingService
    {
        private string _noOfErrorsFilePath = @"C:\Users\320052125\casestudy2\Analyser\Errors.txt";

        public string GateErrors(string threshold, string sampleCodeDirectory, string finalReportPath)
        {
            throw new NotImplementedException();
        }

        public string GateErrorsRelatively(string sampleCodeDirectory, string finalReportPath)
        {
            throw new NotImplementedException();
        }

        public string GateErrorsUsingPMDTool(string threshold, string sampleCodeDirectory, string finalReportPath)
        {
            StaticCodeAnalysisToolsService ToolsService = new StaticCodeAnalysisToolsService();
            bool status = ToolsService.RunPMDTool(sampleCodeDirectory, finalReportPath);
            if (status)
            {
                int NoOfErrors = File.ReadLines(finalReportPath).Count();
                var file = File.Open(_noOfErrorsFilePath, FileMode.OpenOrCreate);
                using (StreamWriter sw = new StreamWriter(file))
                {
                    file.Seek(file.Length, SeekOrigin.Begin);
                    sw.WriteLine(NoOfErrors);

                    if (NoOfErrors > Convert.ToInt32(threshold))
                        return "no";

                    return "yes";
                }
            }
            return "error";
        }

        public string GateErrorsUsingPMDToolRelatively(string sampleCodeDirectory, string finalReportPath)
        {
            StaticCodeAnalysisToolsService ToolsService = new StaticCodeAnalysisToolsService();
            bool status = ToolsService.RunPMDTool(sampleCodeDirectory, finalReportPath);
            if (status)
            {
                int NoOfErrors = File.ReadLines(finalReportPath).Count();
                int lastLine = Convert.ToInt32(File.ReadLines(_noOfErrorsFilePath).Last());
                var file = File.Open(_noOfErrorsFilePath, FileMode.OpenOrCreate);
                using (StreamWriter sw = new StreamWriter(file))
                {
                    file.Seek(file.Length, SeekOrigin.Begin);
                    sw.WriteLine(NoOfErrors);

                    if (NoOfErrors > Convert.ToInt32(lastLine))
                        return "no";

                    return "yes";
                }
            }
            return "error";
        }
        
    }
}

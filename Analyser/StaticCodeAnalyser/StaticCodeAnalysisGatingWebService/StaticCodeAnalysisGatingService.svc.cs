
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
        private string _noOfErrorsFilePath = @"C:\Users\320052123\casestudy2\Analyser\Errors.txt";  // set this path to the project directory
        private StaticCodeAnalysisToolsService _toolsService;

        public StaticCodeAnalysisGatingService()
        {
            _toolsService = new StaticCodeAnalysisToolsService();
        }

        public string GateErrors(string threshold, string sampleCodeDirectory, string finalReportPath)
        {
            bool status = _toolsService.RunAllTools(sampleCodeDirectory, finalReportPath);
            if (status)
            {
                return CompareNoOfErrors(int.Parse(threshold), finalReportPath);
            }
            return "error";
        }
        
        public string GateErrorsRelatively(string sampleCodeDirectory, string finalReportPath)
        {
            int lastLine = 0;
            if (File.Exists(_noOfErrorsFilePath) && File.ReadLines(_noOfErrorsFilePath).Count() > 0)
                lastLine = Convert.ToInt32(File.ReadLines(_noOfErrorsFilePath).Last());
            
            bool status = _toolsService.RunAllTools(sampleCodeDirectory, finalReportPath);
            if (status)
            {
                return CompareNoOfErrors(lastLine, finalReportPath);
            }
            return "error";
        }

        public string GateErrorsUsingPMDTool(string threshold, string sampleCodeDirectory, string finalReportPath)
        {
            bool status = _toolsService.RunPMDTool(sampleCodeDirectory, finalReportPath);
            if (status)
            {
                return CompareNoOfErrors(int.Parse(threshold), finalReportPath);
            }
            return "error";
        }

        public string GateErrorsUsingPMDToolRelatively(string sampleCodeDirectory, string finalReportPath)
        {
            int lastLine = 0;
            if (File.Exists(_noOfErrorsFilePath) && File.ReadLines(_noOfErrorsFilePath).Count() > 0)
                lastLine = Convert.ToInt32(File.ReadLines(_noOfErrorsFilePath).Last());

            bool status = _toolsService.RunPMDTool(sampleCodeDirectory, finalReportPath);
            if (status)
            {
                return CompareNoOfErrors(lastLine, finalReportPath);
            }
            return "error";
        }

        private string CompareNoOfErrors(int threshold, string finalReportPath)
        {
            int NoOfErrors = File.ReadLines(finalReportPath).Count();
            var file = File.Open(_noOfErrorsFilePath, FileMode.OpenOrCreate);
            using (StreamWriter sw = new StreamWriter(file))
            {
                file.Seek(file.Length, SeekOrigin.Begin);
                sw.WriteLine(NoOfErrors);
                if (NoOfErrors > threshold)
                    return "Static Code Analysis Gating Failed!";
                return "Static Code Analysis Gating Passed Successfully!";
            }
        }

    }
}

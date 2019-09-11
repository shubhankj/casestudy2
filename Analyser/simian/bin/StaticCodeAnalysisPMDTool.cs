using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StaticCodeAnalysisToolContractLib;
using IStaticCodeAnalysisToolParserLib;
using PMDReportParserLib;
using System.IO;

namespace StaticCodeAnalysisPMDToolLib
{
    public class StaticCodeAnalysisPMDTool : IStaticCodeAnalysisTool
    {
        private string _rulesetFilePath = @"pmd-bin-6.16.0\bin\rulesets\java\quickstart.xml";   //
        private string _batFilePath = @"pmd-bin-6.16.0\bin\pmd.bat";
        private string _reportFilePath = @"PMDReport.txt";

        public string Analyse(string codeDirectoryPath)
        {
            if (!Directory.Exists(codeDirectoryPath))
                return string.Empty;

            string command = _batFilePath + " -d " + codeDirectoryPath + @" -f text -R " + _rulesetFilePath + " -r " + _reportFilePath ;

            try
            {
                Process cmd = new Process();
                cmd.StartInfo.FileName = "cmd.exe";
                cmd.StartInfo.RedirectStandardInput = true;
                cmd.StartInfo.RedirectStandardOutput = true;
                cmd.StartInfo.CreateNoWindow = true;
                cmd.StartInfo.UseShellExecute = false;
                cmd.Start();

                cmd.StandardInput.WriteLine(command);
                cmd.StandardInput.Flush();
                cmd.StandardInput.Close();
                cmd.WaitForExit();
                return _reportFilePath;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return string.Empty;
            }
        }
    }
}

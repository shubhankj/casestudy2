using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StaticCodeAnalysisToolContractLib;
using IStaticCodeAnalysisToolParserLib;
using PMDReportParserLib;

namespace StaticCodeAnalysisPMDToolLib
{
    public class StaticCodeAnalysisPMDTool : IStaticCodeAnalysisTool
    {
        private string _rulesetFilePath;// = @"..\..\pmd-bin-6.16.0\bin\rulesets\java\quickstart.xml";

        public StaticCodeAnalysisPMDTool(string rulesetFilePath)
        {
            _rulesetFilePath = rulesetFilePath;
        }

        public IStaticCodeAnalysisToolParser GetParserObject()
        {
            return new PMDReportParser();
        }

        public int Analyse(string batFilePath, string codeDirectoryPath, string reportFilePath)
        {
            string command = batFilePath + " -d " + codeDirectoryPath + @" -f text -R " + _rulesetFilePath + " -r " + reportFilePath ;

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
                
                return cmd.ExitCode;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StaticCodeAnalysisControllerLib;
using StaticCodeAnalysisToolContractLib;
using IStaticCodeAnalysisToolParserLib;
using StaticCodeAnalysisPMDToolLib;
using PMDReportParserLib;
using System.IO;

namespace StaticCodeAnalysisSchedulerLib
{
    public class StaticCodeAnalysisScheduler
    {
        private Dictionary<IStaticCodeAnalysisTool, IStaticCodeAnalysisToolParser> _toolToParserMap;
        private StaticCodeAnalysisPMDTool _pMDTool;
        private StaticCodeAnalysisPMDReportParser _pMDReportParser;

        public StaticCodeAnalysisScheduler()
        {
            _pMDTool = new StaticCodeAnalysisPMDTool();
            _pMDReportParser = new StaticCodeAnalysisPMDReportParser();
            _toolToParserMap = new Dictionary<IStaticCodeAnalysisTool, IStaticCodeAnalysisToolParser>();
            _toolToParserMap.Add(_pMDTool, _pMDReportParser);
        }

        public bool RunAnalysisWithAllTools(string codeDirectoryPath, string outReportFilePath)
        {
            StaticCodeAnalysisController controller = new StaticCodeAnalysisController();
            File.Delete(outReportFilePath);
            bool status = true;
            for(int i=0; i<_toolToParserMap.Count; i++)
            {
                string tempReportPath = controller.AnalyseUsingTool(_toolToParserMap.ElementAt(i).Key, codeDirectoryPath);

                status &= controller.Merge(_toolToParserMap.ElementAt(i).Value, tempReportPath, outReportFilePath);
            }
            return status;
        }

        public bool RunAnalysisWithPMD(string codeDirectoryPath, string outReportFilePath)
        {
            IStaticCodeAnalysisTool tool = _pMDTool;
            StaticCodeAnalysisController controller = new StaticCodeAnalysisController();
            File.Delete(outReportFilePath);

            string tempReportPath = controller.AnalyseUsingTool(tool, codeDirectoryPath);

            return controller.Merge(_toolToParserMap[tool], tempReportPath, outReportFilePath);
        }
    }
}
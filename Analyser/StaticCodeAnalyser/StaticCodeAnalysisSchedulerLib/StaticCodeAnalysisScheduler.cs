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
        private PMDReportParser _pMDReportParser;

        public StaticCodeAnalysisScheduler()
        {
            _pMDTool = new StaticCodeAnalysisPMDTool();
            _pMDReportParser = new PMDReportParser();
            _toolToParserMap = new Dictionary<IStaticCodeAnalysisTool, IStaticCodeAnalysisToolParser>();
            _toolToParserMap.Add(_pMDTool, _pMDReportParser);
        }

        public void RunAnalysisWithAllTools(string codeDirectoryPath, string outReportFilePath)
        {
            StaticCodeAnalysisController controller = new StaticCodeAnalysisController();
            File.Delete(outReportFilePath);

            for(int i=0; i<_toolToParserMap.Count; i++)
            {
                string tempReportPath = controller.AnalyseUsingTool(_toolToParserMap.ElementAt(i).Key, codeDirectoryPath);

                controller.Merge(_toolToParserMap.ElementAt(i).Value, tempReportPath, outReportFilePath);
            }
        }

        public void RunAnalysisWithPMD(string codeDirectoryPath, string outReportFilePath)
        {
            IStaticCodeAnalysisTool tool = _pMDTool;
            StaticCodeAnalysisController controller = new StaticCodeAnalysisController();
            File.Delete(outReportFilePath);

            string tempReportPath = controller.AnalyseUsingTool(tool, codeDirectoryPath);

            controller.Merge(_toolToParserMap[tool], tempReportPath, outReportFilePath);
        }
    }
}
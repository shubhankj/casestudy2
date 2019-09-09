using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IStaticCodeAnalysisToolParserLib;

namespace StaticCodeAnalysisToolContractLib
{
    public interface IStaticCodeAnalysisTool
    {
        int Analyse(string batFilePath, string codeDirectoryPath, string reportFilePath);
        IStaticCodeAnalysisToolParser GetParserObject();
    }
}

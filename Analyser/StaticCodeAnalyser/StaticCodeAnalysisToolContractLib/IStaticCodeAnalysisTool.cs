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
        string Analyse(string codeDirectoryPath);
    }
}

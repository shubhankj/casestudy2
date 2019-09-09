using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StaticCodeAnalysisControllerLib;
using StaticCodeAnalysisPMDToolLib;

namespace StaticCodeAnalyzer
{
    public class main
    {
        public static int Main(string[] args)
        {
            Directory.SetCurrentDirectory(@"..\..\..\..\");
            string pMDToolRuleset = @"pmd-bin-6.16.0\bin\rulesets\java\quickstart.xml";
            string pMDBatFile = @"pmd-bin-6.16.0\bin\pmd.bat";
            string sampleCodeDirectory = @"feereport";
            string pmDReport = @"PMDReport.txt";
            string outputFile = @"FinalReport.csv";

            StaticCodeAnalysisPMDTool pMDTool = new StaticCodeAnalysisPMDTool(pMDToolRuleset);

            StaticCodeAnalysisController controller = new StaticCodeAnalysisController();
            controller.AnalyseUsingTool(pMDTool, pMDBatFile, sampleCodeDirectory, pmDReport);
            controller.Merge(outputFile);

            return 0;

            //int PMDStatus = StaticCodeAnalyzer.Tool(@"(C:\Users\320052123\C++CaseStudy\casestudy1\pmd-bin-6.16.0\bin\pmd.bat -d ..\..\feereport -f text -R C:\Users\320052123\C++CaseStudy\casestudy1\pmd-bin-6.16.0\bin\rulesets\java\quickstart.xml -r C:\Users\320052123\C++CaseStudy\casestudy1\PMDReport.txt)");

            //int SpotBugsStatus = StaticCodeAnalyzer.Tool(@"(C:\Users\320052123\C++CaseStudy\casestudy1\spotbugs-3.1.12\bin\spotbugs.bat -textui -maxHeap 1500 -nested:false -output C:\Users\320052123\C++CaseStudy\casestudy1\SpotBugsReport.emacs -effort:max -low -sortByClass -emacs sourcepath C:\Users\320052123\C++CaseStudy\casestudy1\feereport)");

            //int MergeStatus = StaticCodeAnalyzer.MergeReports(@"C:\Users\320052123\C++CaseStudy\casestudy1\SpotBugsReport.emacs", @"C:\Users\320052123\C++CaseStudy\casestudy1\PMDReport.txt", @"C:\Users\320052123\C++CaseStudy\casestudy1\FinalReport.csv");

            //if (PMDStatus == 0 && SpotBugsStatus == 0 && MergeStatus == 0)
            //    return 0;
            //else return 1;
        }

    }
}

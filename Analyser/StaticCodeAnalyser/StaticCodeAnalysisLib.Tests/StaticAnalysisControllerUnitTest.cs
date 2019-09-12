using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StaticCodeAnalysisToolContractLib;
using StaticCodeAnalysisControllerLib;
using IStaticCodeAnalysisToolParserLib;
using StaticCodeAnalysisReportsCSVMergerLib;

namespace StaticCodeAnalysisLib.Tests
{
    [TestClass]
    public class StaticAnalysisControllerUnitTest
    {
        [TestMethod]
        public void Given_Valid_Arguments_When_AnalyseUsingTool_Is_Invoked_Then_ReportFilePath_Is_Asserted()
        {
            StaticCodeAnalysisController obj = new StaticCodeAnalysisController();
            string codeDirectoryPath = @"C:\Users\320052123\casestudy2\Analyser\feereport";
            string expectedValue = @"C:\Users\320052123\casestudy2\Analyser\PMDReport.txt";
            Moq.Mock<IStaticCodeAnalysisTool> _mockWrapper = new Moq.Mock<IStaticCodeAnalysisTool>();
            _mockWrapper.Setup(x => x.Analyse(codeDirectoryPath)).Returns(expectedValue);

            string actualValue = obj.AnalyseUsingTool(_mockWrapper.Object, codeDirectoryPath);
            Assert.AreEqual(expectedValue,actualValue);
        }

        [TestMethod]
        public void Given_Valid_Arguments_When_Merge_Is_Invoked_Then_True_Is_Asserted()
        {
            StaticCodeAnalysisController obj = new StaticCodeAnalysisController();
            Moq.Mock<IStaticCodeAnalysisToolParser> _mockWrapper = new Moq.Mock<IStaticCodeAnalysisToolParser>();            

            string reportFilePath = @"C:\Users\320052123\casestudy2\Analyser\PMDReport.txt";
            string outfileFath = @"C:\Users\320052123\casestudy2\Analyser\FinalReport.csv";

            bool actualValue = obj.Merge(_mockWrapper.Object, reportFilePath, outfileFath);
            Assert.AreEqual(true, actualValue);
        }
    }
}

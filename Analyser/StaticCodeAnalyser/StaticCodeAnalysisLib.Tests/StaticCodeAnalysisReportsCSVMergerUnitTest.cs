using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StaticCodeAnalysisReportsCSVMergerLib;
using PMDReportParserLib;
using IStaticCodeAnalysisToolParserLib;
using System.IO;

namespace StaticCodeAnalysisLib.Tests
{
    [TestClass]
    public class StaticCodeAnalysisReportsCSVMergerUnitTest
    {
        [TestMethod]
        public void Given_Valid_Argument_When_WriteReportsToCSV_Invoked_Then_True_Asserted()
        {            
            StaticCodeAnalysisReportsCSVMerger obj = new StaticCodeAnalysisReportsCSVMerger();
                      
            string[] a1 = new string[] { };
            string[] a2 = new string[] { };

            string reportFilePath = @"C:\Users\320052123\casestudy2\Analyser\PMDReport.txt";
            string outfileFath = @"C:\Users\320052123\casestudy2\Analyser\FinalReport.txt";
            Moq.Mock<IStaticCodeAnalysisToolParser> _mockWrapper = new Moq.Mock<IStaticCodeAnalysisToolParser>();
            _mockWrapper.Setup(x => x.ParseReportToCSV(a1)).Returns(a2);

            bool actualValue = obj.WriteReportsToCSV(_mockWrapper.Object, reportFilePath, outfileFath);
            
            Assert.AreEqual(true, actualValue);

        }

        [TestMethod]        
        public void Given_Invalid_ReportFilePath_When_WriteReportsToCSV_Invoked_Then_False_Asserted()
        {
            StaticCodeAnalysisReportsCSVMerger obj = new StaticCodeAnalysisReportsCSVMerger();

            string[] a1 = new string[] { };
            string[] a2 = new string[] { };

            Moq.Mock<IStaticCodeAnalysisToolParser> _mockWrapper = new Moq.Mock<IStaticCodeAnalysisToolParser>();
            _mockWrapper.Setup(x => x.ParseReportToCSV(a1)).Returns(a2);

            string reportFilePath = @"C:\Users\casestudy\Analyser\PMDReport.txt";
            string outfileFath = @"C:\Users\320052123\casestudy2\Analyser\FinalReport.txt";

            bool actualValue = obj.WriteReportsToCSV(_mockWrapper.Object, reportFilePath, outfileFath);

            Assert.AreEqual(false, actualValue);

        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void Given_Valid_Arguments_With_Already_Open_ReportFilePath_When_WriteReportsToCSV_Invoked_Then_Exception_Asserted()
        {
            StaticCodeAnalysisReportsCSVMerger obj = new StaticCodeAnalysisReportsCSVMerger();

            string[] a1 = new string[] { };
            string[] a2 = new string[] { };

            Moq.Mock<IStaticCodeAnalysisToolParser> _mockWrapper = new Moq.Mock<IStaticCodeAnalysisToolParser>();
            _mockWrapper.Setup(x => x.ParseReportToCSV(a1)).Returns(a2);

            string reportFilePath = @"C:\Users\320052123\casestudy2\Analyser\PMDReport.txt";
            string outfileFath = @"C:\Users\320052123\casestudy2\Analyser\FinalReport.txt";

            using (var fileStream = new FileStream(@"c:\file.txt", FileMode.Open, FileAccess.Read))
            {
                // read from file
            }
            bool actualValue = obj.WriteReportsToCSV(_mockWrapper.Object, reportFilePath, outfileFath);

        }


    }
}

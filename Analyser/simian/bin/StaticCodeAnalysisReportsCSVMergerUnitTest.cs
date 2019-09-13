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
            Directory.SetCurrentDirectory(@"C:\Users\320052125\casestudy2\Analyser");
            StaticCodeAnalysisReportsCSVMerger obj = new StaticCodeAnalysisReportsCSVMerger();
                      
            string[] a1 = new string[] { };
            string[] a2 = new string[] { };

            string reportFilePath = @"PMDReport.txt";
            string outfileFath = @"FinalReport.txt";
            Moq.Mock<IStaticCodeAnalysisToolParser> _mockWrapper = new Moq.Mock<IStaticCodeAnalysisToolParser>();
            _mockWrapper.Setup(x => x.ParseReportToCSV(a1)).Returns(a2);

            bool actualValue = obj.WriteReportsToCSV(_mockWrapper.Object, reportFilePath, outfileFath);
            
            Assert.AreEqual(true, actualValue);

        }

        [TestMethod]        
        public void Given_Invalid_ReportFilePath_When_WriteReportsToCSV_Invoked_Then_False_Asserted()
        {
            Directory.SetCurrentDirectory(@"C:\Users\320052125\casestudy2\Analyser");
            StaticCodeAnalysisReportsCSVMerger obj = new StaticCodeAnalysisReportsCSVMerger();

            string[] a1 = new string[] { };
            string[] a2 = new string[] { };

            Moq.Mock<IStaticCodeAnalysisToolParser> _mockWrapper = new Moq.Mock<IStaticCodeAnalysisToolParser>();
            _mockWrapper.Setup(x => x.ParseReportToCSV(a1)).Returns(a2);

            string reportFilePath = @"notexists";
            string outfileFath = @"FinalReport.csv";

            bool actualValue = obj.WriteReportsToCSV(_mockWrapper.Object, reportFilePath, outfileFath);

            Assert.AreEqual(false, actualValue);

        }

        [TestMethod]
        [ExpectedException(typeof(IOException))]
        public void Given_Valid_Arguments_With_Already_Open_ReportFilePath_When_WriteReportsToCSV_Invoked_Then_Exception_Asserted()
        {
            Directory.SetCurrentDirectory(@"C:\Users\320052125\casestudy2\Analyser");
            StaticCodeAnalysisReportsCSVMerger obj = new StaticCodeAnalysisReportsCSVMerger();

            string[] s1 = new string[] { };
            string[] s2 = new string[] { };

            Moq.Mock<IStaticCodeAnalysisToolParser> _mockWrapper = new Moq.Mock<IStaticCodeAnalysisToolParser>();
            _mockWrapper.Setup(x => x.ParseReportToCSV(s1)).Returns(s2);

            string reportFilePath = @"PMDReport.txt";
            string outfileFath = @"FinalReport.csv";

            using (var fileStream = new FileStream(@"PMDReport.txt", FileMode.Open))
            {
                obj.WriteReportsToCSV(_mockWrapper.Object, reportFilePath, outfileFath);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StaticCodeAnalysisSchedulerLib;

namespace StaticCodeAnalysisLib.Tests
{
    [TestClass]
    public class StaticCodeAnalysisSchedulerUnitTest
    {
        [TestMethod]
        public void Given_Valid_Arguments_When_RunAnalysisWithPMD_Invoked_Then_True_Asserted()
        {
            Directory.SetCurrentDirectory(@"C:\Users\320052123\casestudy2\Analyser");
            string codeDirectoryPath = @"feereport";
            string outReportFilePath = @"FinalReport.csv";
            StaticCodeAnalysisScheduler scheduler = new StaticCodeAnalysisScheduler();

            Assert.AreEqual(true, scheduler.RunAnalysisWithPMD(codeDirectoryPath, outReportFilePath));
        }

        [TestMethod]
        public void Given_Valid_Arguments_When_RunAnalysisWithAllTools_Invoked_Then_True_Asserted()
        {
            Directory.SetCurrentDirectory(@"C:\Users\320052123\casestudy2\Analyser");
            string codeDirectoryPath = @"feereport";
            string outReportFilePath = @"FinalReport.csv";
            StaticCodeAnalysisScheduler scheduler = new StaticCodeAnalysisScheduler();

            Assert.AreEqual(true, scheduler.RunAnalysisWithAllTools(codeDirectoryPath, outReportFilePath));
        }
    }
}

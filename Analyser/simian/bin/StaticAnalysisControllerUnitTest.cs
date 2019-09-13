﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StaticCodeAnalysisToolContractLib;
using StaticCodeAnalysisControllerLib;
using IStaticCodeAnalysisToolParserLib;
using StaticCodeAnalysisReportsCSVMergerLib;
using System.IO;

namespace StaticCodeAnalysisLib.Tests
{
    [TestClass]
    public class StaticAnalysisControllerUnitTest
    {
        [TestMethod]
        public void Given_Valid_Arguments_When_AnalyseUsingTool_Is_Invoked_Then_ReportFilePath_Is_Asserted()
        {
            Directory.SetCurrentDirectory(@"C:\Users\320052125\casestudy2\Analyser");

            StaticCodeAnalysisController obj = new StaticCodeAnalysisController();
            string codeDirectoryPath = @"feereport";
            string expectedValue = @"PMDReport.csv";
            Moq.Mock<IStaticCodeAnalysisTool> _mockWrapper = new Moq.Mock<IStaticCodeAnalysisTool>();
            _mockWrapper.Setup(x => x.Analyse(codeDirectoryPath)).Returns(expectedValue);

            string actualValue = obj.AnalyseUsingTool(_mockWrapper.Object, codeDirectoryPath);
            Assert.AreEqual(expectedValue,actualValue);
        }

        [TestMethod]
        public void Given_Valid_Arguments_When_Merge_Is_Invoked_Then_True_Is_Asserted()
        {
            Directory.SetCurrentDirectory(@"C:\Users\320052125\casestudy2\Analyser");

            StaticCodeAnalysisController obj = new StaticCodeAnalysisController();
            Moq.Mock<IStaticCodeAnalysisToolParser> _mockWrapper = new Moq.Mock<IStaticCodeAnalysisToolParser>();            

            string reportFilePath = @"PMDReport.txt";
            string outfileFath = @"FinalReport.csv";

            bool actualValue = obj.Merge(_mockWrapper.Object, reportFilePath, outfileFath);
            Assert.AreEqual(true, actualValue);
        }
    }
}
using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StaticCodeAnalysisPMDToolLib;

namespace StaticCodeAnalysisLib.Tests
{
    [TestClass]
    public class StaticCodeAnalysisPMDToolUnitTest
    {
        [TestMethod]
        public void Given_Valid_Argument_When_Analyse_Invoked_Then_Valid_Result_Asserted()
        {
            Directory.SetCurrentDirectory(@"C:\Users\320052125\casestudy2\Analyser");
            StaticCodeAnalysisPMDTool obj = new StaticCodeAnalysisPMDTool();

            Assert.AreEqual("PMDReport.txt", obj.Analyse("feereport"));
        }

        [TestMethod]
        public void Given_Invalid_Argument_When_Analyse_Invoked_Then_Empty_String_Asserted()
        {
            Directory.SetCurrentDirectory(@"C:\Users\320052125\casestudy2\Analyser");

            StaticCodeAnalysisPMDTool obj = new StaticCodeAnalysisPMDTool();
            Assert.AreEqual("", obj.Analyse("notexists"));

        }
    }
}

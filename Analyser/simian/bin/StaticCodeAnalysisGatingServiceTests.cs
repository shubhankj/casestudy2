using System;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StaticCodeAnalysisGatingServiceLib.Tests
{
    [TestClass]
    public class StaticCodeAnalysisGatingServiceTests
    {
        [TestMethod]
        public void Given_Valid_Parameters_When_GateErrorsUsingPMDTool_Is_Invoked_Then_Passed_Successfully_Asserted()
        {
            var client = new WebClient();
            var content = client.DownloadString("http://localhost:52307/StaticCodeAnalysisGatingService.svc/GateErrorsUsingPMD/150/feereport/FinalReport.csv");

            Assert.AreEqual("{\"GateErrorsUsingPMDToolResult\":\"Static Code Analysis Gating Passed Successfully!\"}", content);
            client.Dispose();
        }

        [TestMethod]
        public void Given_Valid_Parameters_When_GateErrorsUsingPMDToolRelatively_Is_Invoked_Then_Passed_Successfully_Asserted()
        {
            var client = new WebClient();
            var content = client.DownloadString("http://localhost:52307/StaticCodeAnalysisGatingService.svc/GateErrorsUsingPMDRelatively/feereport/FinalReport.csv");

            Assert.AreEqual("{\"GateErrorsUsingPMDToolRelativelyResult\":\"Static Code Analysis Gating Passed Successfully!\"}", content);
            client.Dispose();
        }

        [TestMethod]
        public void Given_Valid_Parameters_When_GateErrors_Is_Invoked_Then_Passed_Successfully_Asserted()
        {
            var client = new WebClient();
            var content = client.DownloadString("http://localhost:52307/StaticCodeAnalysisGatingService.svc/GateErrors/150/feereport/FinalReport.csv");

            Assert.AreEqual("{\"GateErrorsResult\":\"Static Code Analysis Gating Passed Successfully!\"}", content);
            client.Dispose();
        }

        [TestMethod]
        public void Given_Valid_Parameters_When_GateErrorsRelatively_Is_Invoked_Then_Passed_Successfully_Asserted()
        {
            var client = new WebClient();
            var content = client.DownloadString("http://localhost:52307/StaticCodeAnalysisGatingService.svc/GateErrorsRelatively/feereport/FinalReport.csv");

            Assert.AreEqual("{\"GateErrorsRelativelyResult\":\"Static Code Analysis Gating Passed Successfully!\"}", content);
            client.Dispose();
        }
    }
}

using System;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StaticCodeAnalysisWebServicesLib.Tests
{
    [TestClass]
    public class StaticCodeAnalysisToolsServiceUnitTest
    {
        [TestMethod]
        public void Given_Valid_Parameters_When_RunAllTools_Is_Invoked_Then_True_Asserted()
        {
            var client = new WebClient();
            var content = client.DownloadString("http://localhost:52333/StaticCodeAnalysisToolsService.svc/RunAllTools/feereport/FinalReport.csv");

            Assert.AreEqual("{\"RunAllToolsResult\":true}", content);
            client.Dispose();
        }

        [TestMethod]
        public void Given_Valid_Parameters_When_RunPMDTool_Is_Invoked_Then_True_Asserted
()
        {
            var client = new WebClient();
            var content = client.DownloadString("http://localhost:52333/StaticCodeAnalysisToolsService.svc/RunPMDTool/feereport/FinalReport.csv");

            Assert.AreEqual("{\"RunPMDToolResult\":true}", content);
            client.Dispose();
        }



    }
}

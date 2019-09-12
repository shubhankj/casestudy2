using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMDReportParserLib;

namespace StaticCodeAnalysisLib.Tests
{
    [TestClass]
    public class PMDReportParserUnitTest
    {
        [TestMethod]
        public void Given_Valid_Argument_When_ParseReportToCSV_Invoked_Then_Valid_Result_Asserted()
        {
            PMDReportParser obj = new PMDReportParser();
            string[] input = {@"C:\Users\320052125\casestudy2\Analyser\feereport\src\AccountantDao.java:26: Ensure that resources like this ResultSet object are closed after use", @"C:\Users\320052125\casestudy2\Analyser\feereport\src\AccountantDao.java:26: Always check the return of one of the navigation method (next,previous,first,last) of a ResultSet." };

            string[] expectedStringOutput = {@"C:\Users\320052125\casestudy2\Analyser\feereport\src\AccountantDao.java,26, Ensure that resources like this ResultSet object are closed after use", @"C:\Users\320052125\casestudy2\Analyser\feereport\src\AccountantDao.java,26, Always check the return of one of the navigation method (next;previous;first;last) of a ResultSet." };

            string[] actualStringOutput = obj.ParseReportToCSV(input);
            
            CollectionAssert.AreEqual(expectedStringOutput, actualStringOutput);
        }

        [TestMethod]
        public void Given_Invalid_Argument_When_ParseReportToCSV_Invoked_Then_Empty_String__Array_Asserted()
        {
            PMDReportParser obj = new PMDReportParser();
            string[] input = new string[] { };
            string[] expectedStringOutput= new string[] { };
            string[] actualStringOutput = obj.ParseReportToCSV(input);
            CollectionAssert.AreEqual(expectedStringOutput, actualStringOutput);
        }
    }
}

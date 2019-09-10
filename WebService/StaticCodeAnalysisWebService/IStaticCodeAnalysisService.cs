using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace StaticCodeAnalysisWebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IStaticCodeAnalysisService" in both code and config file together.
    [ServiceContract]
    public interface IStaticCodeAnalysisService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/AnalyseCodeUsingPMD/Absolute/{threshold}/{batFilePath}/{sampleCodeDirectory}/{finalReportPath}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        string AnalyseCodeUsingPMDTool(string threshold, string batFilePath, string sampleCodeDirectory, string finalReportPath);

        //[OperationContract]
        //[WebInvoke(Method = "GET", UriTemplate = "/AnalyseCode/Absolute/{threshold}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        //string AnalyseCode(string threshold);

        //[OperationContract]
        //[WebInvoke(Method = "GET", UriTemplate = "/AnalyseCode/Relative", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        //string AnalyseCodeAuto();
    }
}

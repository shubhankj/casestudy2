using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace StaticCodeAnalysisGatingWebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IStaticCodeAnalysisService" in both code and config file together.
    [ServiceContract]
    public interface IStaticCodeAnalysisGatingService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GateErrorsUsingPMD/{threshold}/{sampleCodeDirectory}/{finalReportPath}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        string GateErrorsUsingPMDTool(string threshold, string sampleCodeDirectory, string finalReportPath);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GateErrorsUsingPMDRelatively/{sampleCodeDirectory}/{finalReportPath}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        string GateErrorsUsingPMDToolRelatively(string sampleCodeDirectory, string finalReportPath);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GateErrors/{threshold}/{sampleCodeDirectory}/{finalReportPath}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        string GateErrors(string threshold, string sampleCodeDirectory, string finalReportPath);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GateErrorsRelatively/{sampleCodeDirectory}/{finalReportPath}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        string GateErrorsRelatively(string sampleCodeDirectory, string finalReportPath);
    }
}

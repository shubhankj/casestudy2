using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace StaticCodeAnalysisToolsWebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPMDToolService" in both code and config file together.
    [ServiceContract]
    public interface IStaticCodeAnalysisToolsService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/RunPMDTool/{sampleCodeDirectory}/{finalReportPath}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool RunPMDTool(string sampleCodeDirectory, string finalReportPath);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/RunAllTools/{sampleCodeDirectory}/{finalReportPath}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool RunAllTools(string sampleCodeDirectory, string finalReportPath);

        //[OperationContract]
        //[WebInvoke(Method = "GET", UriTemplate = "/RunPMDTool", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        //string RunPMDTool();
    }
}

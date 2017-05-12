using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfOnlineRestfulAjaxWalkThrough
{
    [ServiceContract]
    public interface IEmployeeService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/GetAllEmployee/")]
        List<Employee> GetAllEmployee();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetEmployeeDetails/{EmpId}", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        Employee GetEmployeeDetails(string EmpId);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/AddNewEmployee", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        bool AddNewEmployee(Employee emp);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/TestEmployeeAdd/", BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool TestEmployeeAdd(string emp);

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json)]
        void UpdateEmployee(Employee contact);

        [OperationContract]
        [WebInvoke(Method = "DELETE", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "DeleteEmployee/{EmpId}")]
        void DeleteEmployee(string EmpId);
    }
}
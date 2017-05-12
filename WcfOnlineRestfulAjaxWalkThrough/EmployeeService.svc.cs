using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Xml.Linq;

namespace WcfOnlineRestfulAjaxWalkThrough
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EmployeeService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EmployeeService.svc or EmployeeService.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class EmployeeService : IEmployeeService
    {
        public List<Employee> GetAllEmployee()
        {
            List<Employee> empList = new List<Employee>();

		  XElement xelement = XElement.Load(@"C:\Users\Abhilash\Desktop\Training\.NET Developer\C# Code\WcfOnlineRestfulAjaxWalkThrough\WcfOnlineRestfulAjaxWalkThrough\EmployeeData.xml");
            IEnumerable <XElement> employees = xelement.Elements();
            foreach(var employee in employees)
            {
                Console.WriteLine(employee.Element("Name").Value);
                empList.Add(new Employee
                    {
                        EmployeeId = employee.Element("EmployeeID").Value,
                        Name = employee.Element("Name").Value,
                        JoiningDate = employee.Element("JoiningDate").Value,
                        CompanyName = employee.Element("CompanyName").Value,
                        Address = employee.Element("Address").Value
                    });
            }
            return empList;
        }

        public Employee GetEmployeeDetails(string EmpId)
        {
            Employee emp = new Employee();

            try
            {
		    XDocument doc = XDocument.Load(@"C:\Users\Abhilash\Desktop\Training\.NET Developer\C# Code\WcfOnlineRestfulAjaxWalkThrough\WcfOnlineRestfulAjaxWalkThrough\EmployeeData.xml");

                IEnumerable<XElement> employee = (from result in doc.Descendants("DocumentElement").Descendants("Employees")
                                                  where result.Element("EmployeeID").Value == EmpId.ToString()
                                                  select result);

                emp.EmployeeId = employee.ElementAt(0).Element("EmployeeID").Value;
                emp.Name = employee.ElementAt(0).Element("Name").Value;
                emp.JoiningDate = employee.ElementAt(0).Element("JoiningDate").Value;
                emp.CompanyName = employee.ElementAt(0).Element("CompanyName").Value;
                emp.Address = employee.ElementAt(0).Element("Address").Value;
            }
            catch (Exception ex)
            {
                throw new FaultException<string>
                (ex.Message);
            }
            return emp;
        }

        public bool AddNewEmployee(Employee emp)
        {
            try
            {
		    XDocument doc = XDocument.Load(@"C:\Users\Abhilash\Desktop\Training\.NET Developer\C# Code\WcfOnlineRestfulAjaxWalkThrough\WcfOnlineRestfulAjaxWalkThrough\EmployeeData.xml");

                doc.Element("DocumentElement").Add(
                    new XElement("Employees",
                    new XElement("EmployeeID", emp.EmployeeId),
                    new XElement("Name", emp.Name),
                    new XElement("JoiningDate", emp.JoiningDate),
                    new XElement("CompanyName", emp.CompanyName),
                    new XElement("Address", emp.Address))
                    );
                doc.Save(@"C:\Users\Abhilash\Desktop\Training\.NET Developer\C# Code\WcfOnlineRestfulAjaxWalkThrough\WcfOnlineRestfulAjaxWalkThrough\EmployeeDataInsert.xml");
            }
            catch (Exception ex)
            {
                throw new FaultException<string>
                (ex.Message);
            }
            return true;
        }

        public void UpdateEmployee(Employee employee)
        {
            try
            {
		    XDocument doc = XDocument.Load(@"C:\Users\Abhilash\Desktop\Training\.NET Developer\C# Code\WcfOnlineRestfulAjaxWalkThrough\WcfOnlineRestfulAjaxWalkThrough\EmployeeData.xml");
                var element = doc
                    .Element("DocumentElement");
                if (element != null)
                {
                    var target = element
                        .Elements("Employees")
                        .Single(e =>
                        {
                            var xElement = e.Element("EmployeeID");
                            return xElement != null && xElement.Value == employee.EmployeeId;
                        });

                    target.Element("Name").Value = employee.Name;
                    target.Element("JoiningDate").Value = employee.JoiningDate;
                    target.Element("CompanyName").Value = employee.CompanyName;
                    target.Element("Address").Value = employee.Address;
                }

                doc.Save(@"C:\Users\Li_Qi_000\Documents\Visual Studio 2013\Projects\WcfOnlineRestfulAjaxWalkThrough\EmployeeData.xml");
            }
            catch (Exception ex)
            {
                throw new FaultException<string>
                (ex.Message);
            }
        }

        public void DeleteEmployee(string EmpId)
        {
            try
            {
		    XDocument doc = XDocument.Load(@"C:\Users\Abhilash\Desktop\Training\.NET Developer\C# Code\WcfOnlineRestfulAjaxWalkThrough\WcfOnlineRestfulAjaxWalkThrough\EmployeeData.xml");
                foreach (var result in doc.Descendants("DocumentElement").Descendants("Employees"))
                {
                    if (result.Element("EmployeeID").Value == EmpId.ToString())
                    {
                        result.Remove();//now we don't need to make it IEnumerable????
                        break;
                    }
                }
                doc.Save(@"");
            }
            catch (Exception ex)
            {
                throw new FaultException<string>
                (ex.Message);
            }
        }


        public bool TestEmployeeAdd(string emp)
        {
            return true;
        }
    }
}

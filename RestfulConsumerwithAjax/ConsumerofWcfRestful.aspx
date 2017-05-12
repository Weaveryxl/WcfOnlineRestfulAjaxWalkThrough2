<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsumerofWcfRestful.aspx.cs" Inherits="RestfulConsumerwithAjax.ConsumerofWcfRestful" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%--<script type="text/javascript" src="http://code.jquery.com/jquery-1.8.2.js"></script>--%>
    <script src="Scripts/jquery-1.9.1.js"></script>
    <%--<link href="Content/bootstrap.css" rel="stylesheet" />--%>
     <script type="text/javascript">

        $(function () {
            //$(function(){}) is the same as $(document).ready(function(){}); Just in case the function runs before the document is ready.
            $('#tbDetails').hide();
            
            $('#btnGetAllEmployee').click(function () {
                $.ajax({
                    type: "GET",
                    url: "http://localhost:49571/EmployeeService.svc/GetAllEmployee",
                    contentType: 'application/json',
                    dataType: 'jsonp',
                    success: function (data) {//Seems that "data" is the data given back from the server.
                        $.each(data, function (key, value) {
                            var jsonData = JSON.stringify(value);
                            var objData = $.parseJSON(jsonData);
                            
                            var EmployeeID = objData.EmployeeID;
                            var Name = objData.Name;
                            var JoiningDate = objData.JoiningDate;
                            var CompanyName = objData.CompanyName;
                            var Address = objData.Address;
                            $('<tr><td>' + EmployeeID + '</td><td>' + Name + '</td><td>'
                                + JoiningDate + '</td><td>' + CompanyName + '</td><td>'
                                + Address + '</td></tr>').appendTo('#tbDetails');
                        });
                        $('#tbDetails').show();
                    },
                    error: function (xhr) {
                        //alert('error occured');
                        alert(xhr.responseText);
                    }
                });
            });

            $('#btnGetEmpDetail').click(function () {
                var Emp_ID = $("#txtEmpID").val();
                //It seems that the ajax function doesn't execute.
                $.ajax({
                    type: "GET",
                    url: "http://localhost:49571/EmployeeService.svc/GetEmployeeDetails/"+Emp_ID.toString(),
                    contentType: 'application/json',
                    dataType: 'jsonp',
                    //data: JSON.stringify({ "EmpId": Emp_ID }),//the parameter can't be passed into the service method.
                  //  data: '{"EmpId":"'+ Emp_ID + '"}',
                    success: function (data) {
                        var jsonData = JSON.stringify(data);
                        var objData = $.parseJSON(jsonData);
                        var EmployeeID = objData.EmployeeID;
                        var Name = objData.Name;
                        var JoiningDate = objData.JoiningDate;
                        var CompanyName = objData.CompanyName;
                        var Address = objData.Address;

                        $('<tr><td>' + EmployeeID + '</td><td>' + Name + '</td><td>' + JoiningDate + '</td><td>' + CompanyName + '</td><td>' + Address + '</td></tr>').appendTo('#tbDetails');
                        $('#tbDetails').show();
                    },
                    error: function (xhr) {
                        alert(xhr.responseText);
                        
                    }
                });
            });

            $('#btnAddNewEmployee').click(function () {
                var emp =  {
                    "EmployeeID": $("#txtAddEmpID").val(),
                    "Name": $("#txtAddEmpName").val(),
                    "JoiningDate": $("#txtAddEmpJoining").val(),
                    "CompanyName": $("#txtAddEmpCompany").val(),
                    "Address": $("#txtAddEmpAddress").val()
                };

                
                var testStringify = JSON.stringify({
                    "EmployeeID": $("#txtAddEmpID").val(),
                    "Name": $("#txtAddEmpName").val(),
                    "JoiningDate": $("#txtAddEmpJoining").val(),
                    "CompanyName": $("#txtAddEmpCompany").val(),
                    "Address": $("#txtAddEmpAddress").val()
                });

                alert(testStringify);
   
                $.ajax({
                    type: "POST",
                    url: "http://localhost:49571/EmployeeService.svc/AddNewEmployee",
                    data: JSON.stringify({
                        "EmployeeID": $("#txtAddEmpID").val(),
                        "Name": $("#txtAddEmpName").val(),
                        "JoiningDate": $("#txtAddEmpJoining").val(),
                        "CompanyName": $("#txtAddEmpCompany").val(),
                        "Address": $("#txtAddEmpAddress").val()
                    }),
                    contentType: "application/json",
                    dataType: "jsonp",
                    processData: true,
                    success: function (data) {
                        alert("success…" + data);
                    },
                    error: function (xhr) {
                        alert('hello');
                        alert(xhr);
                    }
                });


            });

            $('#btnUpdateEmployee').click(function () {

                var EmployeeData = {
                    "EmployeeID": $("#txtAddEmpID").val(),
                    "Name": $("#txtAddEmpName").val(),
                    "JoiningDate": $("#txtAddEmpJoining").val(),
                    "CompanyName": $("#txtAddEmpCompany").val(),
                    "Address": $("#txtAddEmpAddress").val()
                };
                $.ajax({
                    type: "PUT",
                    url: "http://localhost:49571/EmployeeService.svc/UpdateEmployee",
                    data: JSON.stringify(EmployeeData),
                    contentType: "application/json; charset=utf-8",
                    dataType: "jsonp",
                    processData: true,
                    success: function (data, status, jqXHR) {
                        alert("Employee Updated Successfully.");
                    },
                    error: function (xhr) {
                        alert(xhr.responseText);
                    }
                });

            });

            $('#btnDeleteEmployee').click(function () {

                var Emp_ID = $("#txtEmpID").val();
                $.ajax({
                    type: "DELETE",
                    url: "http://localhost:49571/EmployeeService.svc/DeleteEmployee",
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify(Emp_ID),
                    dataType: "jsonp",
                    success: function (data, status, jqXHR) {
                        alert("Employee Data deleted successfully.");
                    },

                    error: function (jqXHR, status) {
                        alert("Error occured in Delete Process");
                    }
                });

            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <table cellpadding="5" cellspacing="5" style="border: solid 5px red;" width="98%" align="center">
            <tr>
                <td style="background-color: green; color: yellow; height: 30px; font-size: 16pt; font-family: Georgia; text-align: center;" colspan="2">Consume REST WCF using jQuery</td>
            </tr>
            <tr>
                <td style="vertical-align: top;">
                    <table cellpadding="5" cellspacing="5" class="table-bordered" style="border: solid 2px Green; width: 90%; text-align: center;">
                    <%--<table class="table-bordered">--%>
                        <tr>
                            <td><b>Employee ID:</b></td>
                            <td style="text-align: left;">
                                <input type="text" id="txtEmpID" />
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td style="text-align: left;">
                                <input type="button" id="btnGetEmpDetail" value="Get Employee Detail" /></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td style="text-align: left;">
                                <input type="button" id="btnGetAllEmployee" value="Get All Employee" /></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td style="text-align: left;">
                                <input type="button" id="btnDeleteEmployee" value="Delete Employee" /></td>
                        </tr>
                    </table>
                </td>

                <td style="vertical-align: top; width: 55%; text-align: center;">
                    <table cellpadding="2" cellspacing="4" style="border: solid 2px Green;" width="90%" align="center">
                        <tr>
                            <td>Employee ID #    
                     
                            </td>
                            <td style="text-align: left;">
                                <input type="text" id="txtAddEmpID" /></td>
                        </tr>
                        <tr>
                            <td>Employee Name #                        
                            </td>
                            <td style="text-align: left;">
                                <input type="text" id="txtAddEmpName" /></td>
                        </tr>
                        <tr>
                            <td>Joining Date #                      
                            </td>
                            <td style="text-align: left;">
                                <input type="text" id="txtAddEmpJoining" /></td>
                        </tr>
                        <tr>
                            <td>Company Name #                      
                            </td>
                            <td style="text-align: left;">
                                <input type="text" id="txtAddEmpCompany" /></td>
                        </tr>
                        <tr>
                            <td>Address #                       
                            </td>
                            <td style="text-align: left;">
                                <input type="text" id="txtAddEmpAddress" /></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <input type="button" id="btnAddNewEmployee" value="Add New Employee" />
                                <input type="button" id="btnUpdateEmployee" value="Update Employee" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td height="30px"></td>
            </tr>
            <tr>
                <td colspan="2">
                    <table id="tbDetails" cellpadding="5" cellspacing="5" style="border: solid 5px red;">
                        <thead style="background-color: skyblue; color: White; font-weight: bold">
                            <tr style="border: solid 1px #000000">
                                <td width="15%">Employee ID</td>
                                <td width="15%">Name</td>
                                <td width="15%">Joining Date</td>
                                <td>Company Name</td>
                                <td>Address</td>
                            </tr>
                        </thead>
                        <tbody>
                        </tbody>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>

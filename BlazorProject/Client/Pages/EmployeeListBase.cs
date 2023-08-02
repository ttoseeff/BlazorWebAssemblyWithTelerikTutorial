using BlazorProject.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;

namespace BlazorProject.Client.Pages
{
    public class EmployeeListBase : ComponentBase
    {
        protected string message { get; set; }
        protected string FirstNameText { get; set; }
        protected Employee Employee { get; set; }

        protected List<Department> DepartmentList { get; set; } = new List<Department>();
        protected string DepartmentIdText { get; private set; }

        protected EmployeeListBase()
        {
            message = "Hi Toseef";
        }

        protected override void OnInitialized()
        {
            Employee = new Employee
            {
                EmployeeId = 1,
                FirstName = "John",
                LastName = "Hastings",
                Email = "john@pragimtech.com",
                DateOfBrith = new DateTime(1980, 10, 5),
                Gender = Gender.Male,
                Department = new Department { DepartmentId = 1, DepartmentName = "IT" },
                PhotoPath = "images/john.png",
                DepartmentId = 1
            };

            DepartmentList = new List<Department>()
            {
                new Department
                {
                    DepartmentId = 1,
                    DepartmentName = "IT"
                },
                new Department
                {
                    DepartmentId = 2,
                    DepartmentName = "CS"
                },
                new Department
                {
                    DepartmentId = 3,
                    DepartmentName = "SE"
                },
                new Department
                {
                    DepartmentId = 4,
                    DepartmentName = "CE"
                }
            };
        }

        protected void FormSubmitCallback()
        {

        }

        protected void TextboxEventHandler(string value)
        {
            FirstNameText = value.ToString();
            Employee.FirstName = value.ToString();
        }

        protected bool SetTextboxAccess()
        {
            return true;
        }

        protected void DepartmentChangeEvent(int value)
        {
            DepartmentIdText = value.ToString();
            Employee.DepartmentId = value;
        }
    }
}

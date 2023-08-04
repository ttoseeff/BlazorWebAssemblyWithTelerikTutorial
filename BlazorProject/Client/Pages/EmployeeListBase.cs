using BlazorProject.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.Blazor;

namespace BlazorProject.Client.Pages
{
    public class EmployeeListBase : ComponentBase
    {
        protected StringFilterOperator StringFilterOperator { get; set; }
        protected string message { get; set; }
        protected string FirstNameText { get; set; }
        protected Employee Employee { get; set; }

        protected List<Department> DepartmentList { get; set; } = new List<Department>();
        protected string DepartmentIdText { get; private set; }
        public List<int> SelectedDepartments { get; set; } = new List<int>();

        protected List<Subscriptions> SubscriptionsList { get; set; }
        protected bool CheckAll
        {
            get
            {
                return SubscriptionsList.All(x => x.Selected);
            }
            set
            {
                SubscriptionsList.ForEach(x => x.Selected = value);
            }
        }

        protected bool CheckAllIndescriminate
        {
            get
            {
                return !CheckAll && SubscriptionsList.Any(x=> x.Selected);
            }
        }

        protected EmployeeListBase()
        {
            message = "Hi Toseef";
        }

        protected override void OnInitialized()
        {
            LoadSubsriptions();
            StringFilterOperator = StringFilterOperator.Contains;
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

        public void LoadSubsriptions()
        {
            SubscriptionsList = new List<Subscriptions>() {
                new Subscriptions()
                {
                    Id= 1,
                    SubscriptionName = "Gold",
                    Selected = false
                },
                new Subscriptions()
                {
                    Id= 2,
                    SubscriptionName = "Silver",
                    Selected = false
                },
                new Subscriptions()
                {
                    Id= 3,
                    SubscriptionName = "Bronze",
                    Selected = false
                },
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

        protected void DepartmentACChangeEvent(object value)
        {
            DepartmentIdText = value.ToString();
            Employee.DepartmentId = DepartmentList.FirstOrDefault(x => x.DepartmentName == DepartmentIdText).DepartmentId;
        }
        protected void MultiSelectDepartmentChangeEvent(List<int> value)
        {
            SelectedDepartments = value;
        }
    }
}

using BlazorProject.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Text.Json;
using Newtonsoft.Json;

namespace BlazorProject.Client.Services
{
    
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient httpClient;
        private readonly JsonSerializerOptions _options;

        public EmployeeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            try
            {
                //IEnumerable<Employee> employees = await httpClient.GetFromJsonAsync<IEnumerable<Employee>>("api/employees");
                var response = await httpClient.GetAsync("api/employees");
                var content = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    throw new ApplicationException(content);
                }
                var emp = JsonConvert.DeserializeObject<List<Employee>>(content);
                
                return emp;
                //var list = employees.ToList();
                //return employees;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Task<Employee> AddEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEmployee(int employeeId)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetEmployee(int employeeId)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetEmployeeByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Employee>> Search(string name, Gender? gender)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
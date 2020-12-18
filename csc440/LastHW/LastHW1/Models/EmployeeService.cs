using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastHW1.Models
{
    public class EmployeeService
    {
        //list created to hold information of employee(s)
        private static List<Employee> ObjEmployeeList;
        //employee for display
        public EmployeeService()
        {
            ObjEmployeeList = new List<Employee>()
            {
                new Employee{ Id=222, Name="Tyler"}
                
            };
        }
        //method to display all employees
        public List<Employee> GetAll()
        {
            return ObjEmployeeList;
        }
        //a method to be able to add an employee to the list
        public bool Add(Employee objNewEmployee)
        {
            ObjEmployeeList.Add(objNewEmployee);
            return true;
        }
        //method to update emplyee info
        public bool Update(Employee objEmployeeToUpdate)
        {
            bool IsUpdated = false;
            for(int index = 0; index < ObjEmployeeList.Count; index++)
            {
                if(ObjEmployeeList[index].Id == objEmployeeToUpdate.Id)
                {
                    ObjEmployeeList[index].Name = objEmployeeToUpdate.Name;
                    IsUpdated = true;
                    break;
                }
            }
            return IsUpdated;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2S.Training.Entities
{
    class Employee
    {
        private int employeeId;

        private string employeeName;

        private double salary;

        private int spvrId;

        public int EmployeeId
        {
            get { return employeeId; }
            set { employeeId = value; }
        }

        public string EmployeeName
        {
            get { return employeeName; }
            set { employeeName = value; }
        }

        public double Salary
        {
            get { return salary; }
            set { salary = value; }
        }
        public int SpvrId
        {
            get { return spvrId; }
            set { spvrId = value; }
        }

        public Employee()
        {

        }

        public Employee(int employeeId, string employeeName, double salary, int spvrId)
        {
            this.employeeId = employeeId;
            this.employeeName = employeeName;
            this.salary = salary;
            this.spvrId = spvrId;
        }
    }
}

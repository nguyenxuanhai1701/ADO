using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADO.MODEL
{
    public class Employee
    {
        public int EMP_ID { get; set; }
        public string EMP_NAME { get; set; }
        public string EMP_GENDER { get; set; }
        public string EMP_SALARY { get; set; }

        public Employee() { }

        public Employee(int id, string name, string gender, string salary)
        {
            this.EMP_ID = id;
            this.EMP_NAME = name;
            this.EMP_GENDER = gender;
            this.EMP_SALARY = salary;
        }
    }
}
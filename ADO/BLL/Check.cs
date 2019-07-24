using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ADO.MODEL;

namespace ADO.BLL
{
    public class Check
    {
        public bool checkValue(Employee emp,string action)
        {
            foreach (char c in emp.EMP_NAME.Trim())
            {
                if (!char.IsLetter(c))
                    return false;
            }

            if (emp.EMP_GENDER != "Male" && emp.EMP_GENDER != "Female")
            {
                emp.EMP_GENDER = "";
            }

            foreach(char c in emp.EMP_SALARY.Trim())
            {
                if (!char.IsDigit(c))
                    return false;
            }

            if (action=="Insert")
            {
                if (emp.EMP_NAME == "" || (emp.EMP_GENDER != "Male" && emp.EMP_GENDER != "Female") || emp.EMP_SALARY == "")
                    return false;
            }
            if (action == "Search")
                return true;
            return true;
        }
    }
}
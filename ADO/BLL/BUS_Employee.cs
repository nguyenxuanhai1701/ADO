using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ADO.DAL;
using System.Data;
using ADO.MODEL;

namespace ADO.BLL
{
    public class BUS_Employee
    {
        /// <summary>
        /// SQL SERVER
        /// </summary>
        public DataTable getEmployee(Employee emp)
        {
            return DAL_Employee.getEmployee(emp);
        }

        public int insertEmployee(Employee emp)
        {
            return DAL_Employee.insertEmployee(emp);
        }




        /// <summary>
        /// ORACLE
        /// </summary>
        public DataTable getEmployeeORCL(Employee emp)
        {
            return DAL_Employee.getEmployeeORCL(emp);
        }

        public int insertEmployeeORCL(Employee emp, ref string strReturnCode, ref string strReturnMess)
        {
            return DAL_Employee.insertEmployeeORCL(emp, ref strReturnCode, ref strReturnMess);
        }
        public int deleteEmployeeORCL(Employee emp, ref string strReturnCode, ref string strReturnMess)
        {
            return DAL_Employee.deleteEmployeeORCL(emp, ref strReturnCode, ref strReturnMess);
        }
        public int updateEmployeeORCL(Employee emp, ref string strReturnCode, ref string strReturnMess)
        {
            return DAL_Employee.updateEmployeeORCL(emp, ref strReturnCode, ref strReturnMess);
        }
    }
}
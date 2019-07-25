using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Oracle.DataAccess.Client;
using System.Data;
using ADO.MODEL;
using System.Configuration;

namespace ADO.DAL
{
    public class DAL_Employee
    {
        /// <summary>
        /// SQL SERVER
        /// </summary>
        private static SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLSERVER"].ConnectionString);
        public static int insertEmployee(Employee emp)
        {
            int i = 1;
            SqlCommand cmd = new SqlCommand("spEMPLOYEE_i", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@NAME", emp.EMP_NAME));
            cmd.Parameters.Add(new SqlParameter("@GENDER", emp.EMP_GENDER));
            cmd.Parameters.Add(new SqlParameter("@SALARY", emp.EMP_SALARY));
            conn.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                i = 0;
                throw (ex);
            }
            conn.Close();
            return i;
        }
        public static DataTable getEmployee(Employee emp)
        {
            conn.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("spEMPLOYEE_get", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@NAME", emp.EMP_NAME));
            cmd.Parameters.Add(new SqlParameter("@GENDER", emp.EMP_GENDER));
            cmd.Parameters.Add(new SqlParameter("@SALARY", emp.EMP_SALARY));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            conn.Close();
            return dt;
        }




        /// <summary>
        /// Oracle
        /// </summary>
        private static OracleConnection connORCL = new OracleConnection(ConfigurationManager.ConnectionStrings["ORACLE"].ConnectionString);
        public static DataTable getEmployeeORCL(Employee emp)
        {
            connORCL.Open();
            DataTable dt = new DataTable();
            OracleCommand cmd = new OracleCommand("spEMPLOYEE_GET", connORCL);
            OracleParameter[] parra = new OracleParameter[4];
            parra[0] = new OracleParameter("pEMP_NAME", OracleDbType.NVarchar2, 255)
            {
                Direction = ParameterDirection.Input,
                Value = emp.EMP_NAME
            };
            parra[1] = new OracleParameter("pEMP_GENDER", OracleDbType.NVarchar2, 255)
            {
                Direction = ParameterDirection.Input,
                Value = emp.EMP_GENDER
            };
            parra[2] = new OracleParameter("pEMP_SALARY", OracleDbType.NVarchar2,20)
            {
                Direction = ParameterDirection.Input,
                Value = emp.EMP_SALARY
            };
            parra[3] = new OracleParameter("c", OracleDbType.RefCursor)
            {
                Direction = ParameterDirection.Output,
                Value = DBNull.Value
            };
            for (int i=0;i<4;i++)
            {
                cmd.Parameters.Add(parra[i]);
            }
            cmd.CommandType = CommandType.StoredProcedure;
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(dt);
            connORCL.Close();
            return dt;
        }
        public static int insertEmployeeORCL(Employee emp, ref string strReturnCode, ref string strReturnMess)
        {
            int i = 1;
            connORCL.Open();
            OracleCommand cmd = new OracleCommand("spEMPLOYEE_i", connORCL)
            {
                CommandType = CommandType.StoredProcedure
            };
            OracleParameter[] parra = new OracleParameter[5];
            parra[0] = new OracleParameter("pEMP_NAME", OracleDbType.NVarchar2, 255)
            {
                Direction = ParameterDirection.Input,
                Value = emp.EMP_NAME
            };
            parra[1] = new OracleParameter("pEMP_GENDER", OracleDbType.NVarchar2, 255)
            {
                Direction = ParameterDirection.Input,
                Value = emp.EMP_GENDER
            };
            parra[2] = new OracleParameter("pEMP_SALARY", OracleDbType.Int32)
            {
                Direction = ParameterDirection.Input,
                Value = Int32.Parse(emp.EMP_SALARY)
            };
            parra[3] = new OracleParameter("preturncode", OracleDbType.Int64)
            {
                Direction = ParameterDirection.Output,
                Value = DBNull.Value
            };
            parra[4] = new OracleParameter("preturnmess", OracleDbType.NVarchar2, 255)
            {
                Direction = ParameterDirection.Output,
                Value = DBNull.Value
            };
            for (int j=0;j<5;j++)
            {
                cmd.Parameters.Add(parra[j]);
            }
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                i = 0;
                throw (ex);
            }
            finally
            {
                connORCL.Close();
            }
            strReturnCode = parra[3].Value.ToString();
            strReturnMess = parra[4].Value.ToString();
            return i;
        }
        public static int deleteEmployeeORCL(Employee emp, ref string strReturnCode, ref string strReturnMess)
        {
            int result = 1;
            connORCL.Open();
            OracleCommand cmd = new OracleCommand("spEmployee_d", connORCL);
            cmd.CommandType = CommandType.StoredProcedure;
            OracleParameter[] parra = new OracleParameter[3];
            parra[0] = new OracleParameter("pEMP_ID", OracleDbType.Int64);
            parra[0].Direction = ParameterDirection.Input;
            parra[0].Value = emp.EMP_ID;
            parra[1] = new OracleParameter("preturncode", OracleDbType.Int64);
            parra[1].Direction = ParameterDirection.Output;
            parra[1].Value = DBNull.Value;
            parra[2] = new OracleParameter("preturnmess", OracleDbType.NVarchar2, 255);
            parra[2].Direction = ParameterDirection.Output;
            parra[2].Value = DBNull.Value;
            foreach(OracleParameter p in parra)
            {
                cmd.Parameters.Add(p);
            }
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                result = 0;
                throw (ex);
            }
            connORCL.Close();
            strReturnCode = parra[1].Value.ToString();
            strReturnMess = parra[2].Value.ToString();
            return result;
        }
        public static int updateEmployeeORCL(Employee emp, ref string strReturnCode, ref string strReturnMess)
        {
            int result = 1;
            connORCL.Open();
            OracleCommand cmd = new OracleCommand("spEmployee_u", connORCL);
            cmd.CommandType = CommandType.StoredProcedure;
            OracleParameter[] parra = new OracleParameter[6];
            parra[0] = new OracleParameter("pEMP_ID", OracleDbType.Int64)
            {
                Direction = ParameterDirection.Input,
                Value = emp.EMP_ID
            };
            parra[1] = new OracleParameter("pEMP_NAME", OracleDbType.NVarchar2, 255)
            {
                Direction = ParameterDirection.Input,
                Value = emp.EMP_NAME
            };
            parra[2] = new OracleParameter("pEMP_GENDER", OracleDbType.NVarchar2, 255)
            {
                Direction = ParameterDirection.Input,
                Value = emp.EMP_GENDER
            };
            parra[3] = new OracleParameter("pEMP_SALARY", OracleDbType.Int32)
            {
                Direction = ParameterDirection.Input,
                Value = Int32.Parse(emp.EMP_SALARY)
            };
            parra[4] = new OracleParameter("preturncode", OracleDbType.Int64)
            {
                Direction = ParameterDirection.Output,
                Value = DBNull.Value
            };
            parra[5] = new OracleParameter("preturnmess", OracleDbType.NVarchar2, 255)
            {
                Direction = ParameterDirection.Output,
                Value = DBNull.Value
            };
            foreach (OracleParameter p in parra)
            {
                cmd.Parameters.Add(p);
            }
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                result = 0;
                throw (ex);
            }
            connORCL.Close();
            strReturnCode = parra[1].Value.ToString();
            strReturnMess = parra[2].Value.ToString();
            return result;
        }
    }
}
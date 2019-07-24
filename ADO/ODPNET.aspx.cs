using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ADO.MODEL;
using ADO.BLL;
using ADO.DAL;

namespace ADO
{
    public partial class ODPNET : System.Web.UI.Page
    {
        BUS_Employee busE = new BUS_Employee();
        Check chk = new Check();
        public DataTable employeeDT = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                loadEmployee();
            }
        }

        protected void loadEmployee()
        {
            Employee emp = new Employee(0, txtEmpNM.Text, txtGender.Text, txtSalary.Text);
            if(!chk.checkValue(emp,"Search"))
            {
                Mess.Text = "Invalid value";
                return;
            }
            dtg.DataSource = busE.getEmployeeORCL(emp);
            dtg.DataBind();
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            string strReturnCode = "";
            string strReturnMess = "";
            int result;
            Employee emp = new Employee(0, txtEmpNM.Text.Trim(), txtGender.Text.Trim(), txtSalary.Text.Trim());
            if (!chk.checkValue(emp, "Insert"))
            {
                Mess.Text = "Invalid value";
                return;
            }
            result = busE.insertEmployeeORCL(emp, ref strReturnCode, ref strReturnMess);
            if (result == 0)
            {
                Mess.Text = strReturnMess;
            }
            else
            {
                Mess.Text = "Insert succeeded";
                loadEmployee();
            }
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            loadEmployee();
        }

        public void Reset()
        {
            txtEmpNM.Text = "";
            txtSalary.Text = "";
            Mess.Text = "";
            txtGender.Text = "Choose gender";
            loadEmployee();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
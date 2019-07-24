using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using ADO.DAL;
using ADO.MODEL;
using ADO.BLL;

namespace ADO
{
    public partial class ADONET : System.Web.UI.Page
    {
        BUS_Employee busE = new BUS_Employee();
        Check chk = new Check();
        public DataTable employeeDT = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                loadEmployee();
            }
        }

        protected void loadEmployee()
        {
            Employee emp = new Employee(0, txtEmpNM.Text.Trim(), txtGender.Text.Trim(), txtSalary.Text.Trim());
            if (!chk.checkValue(emp, "Search"))
            {
                Mess.Text = "Invalid value";
                return;
            }
            dtg.DataSource = busE.getEmployee(emp);
            dtg.DataBind();
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            int result;
            Employee emp = new Employee(0, txtEmpNM.Text, txtGender.Text, txtSalary.Text);
            if (!chk.checkValue(emp, "Insert"))
            {
                Mess.Text = "Invalid value";
                return;
            }
            result = busE.insertEmployee(emp);
            if (result == 0)
            {
                Mess.Text = "Insert failed";
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
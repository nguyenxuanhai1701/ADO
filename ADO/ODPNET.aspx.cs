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
                Session["action"] = "Insert";
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
            Employee emp = new Employee(int.Parse(Session["EMP_ID"].ToString()), txtEmpNM.Text.Trim(), txtGender.Text.Trim(), txtSalary.Text.Trim());
            if (!chk.checkValue(emp, "Insert"))
            {
                Mess.Text = "Invalid value";
                return;
            }
            if(Session["action"].ToString()=="Insert")
            {
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
            else if(Session["action"].ToString()=="Update")
            {
                result = busE.updateEmployeeORCL(emp, ref strReturnCode, ref strReturnMess);
                if (result == 0)
                {
                    Mess.Text = strReturnMess;
                }
                else
                {
                    Mess.Text = "Update succeeded";
                    loadEmployee();
                }
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
            
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
            loadEmployee();
        }

        protected void dtg_EditCommand(object source, DataGridCommandEventArgs e)
        {
            Reset();
            Session["EMP_ID"] = e.Item.Cells[1].Text;
            Session["action"] = "Update";
            btnSubmit.Text = "Update";
            Mess.Text = e.Item.Cells[1].Text;
            txtEmpNM.Text = e.Item.Cells[2].Text;
            txtGender.Text = e.Item.Cells[3].Text;
            txtSalary.Text = e.Item.Cells[4].Text;
        }

        protected void dtg_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            string strReturnCode = "";
            string strReturnMess = "";
            int result = 0;
            Employee emp = new Employee();
            emp.EMP_ID = int.Parse(e.Item.Cells[1].Text);
            result = busE.deleteEmployeeORCL(emp, ref strReturnCode, ref strReturnMess);
            if (result == 0)
            {
                Mess.Text = strReturnMess;
            }
            else
            {
                Mess.Text = "Delete succeeded";
                loadEmployee();
            }
        }
    }
}
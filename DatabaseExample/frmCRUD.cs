using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseExample
{
    public partial class frmCRUD : Form
    {
        public frmCRUD()
        {
            InitializeComponent();
        }

        //for read
        public void labasData()
        {
            Database db = new Database();
            dGridView.DataSource = db.selectCmd("Select * from tableInfo");
        }

        private void frmCRUD_Load(object sender, EventArgs e)
        {
            try
            {
                Database DB = new Database();
                lblConnection.ForeColor = Color.Green;
                //continue read
                labasData();
            }
            catch
            {
                lblConnection.ForeColor = Color.Red;
            }
            

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sql = "Insert into tableInfo Values ('"+ tbID.Text +"'," +
                "'" + tbName.Text + "'," +
                "'"+ tbContact.Text +"'," +
                "'"+ cbProgram.Text +"'," +
                "'"+ tbMail.Text +"')";

            Database db = new Database();

            if(db.cudCMD(sql) >0)
            {
                MessageBox.Show("Record Has Been Saved");
            }
            else
            {
                MessageBox.Show("An Error Has Been Occured");
            }
        }

        private void dGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dGridView.Rows[index];
            tbID.Text = selectedRow.Cells[0].Value.ToString();
            tbName.Text = selectedRow.Cells[1].Value.ToString();
            cbProgram.Text = selectedRow.Cells[2].Value.ToString();
            tbContact.Text = selectedRow.Cells[3].Value.ToString();
            tbMail.Text = selectedRow.Cells[4].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string sql = "Update tableInfo set Name ='" + tbName.Text +
                "', Program='" + cbProgram.Text +
                "', Contact='" + tbContact.Text +
                "', Email='" + tbMail.Text + 
                "' Where IDNo = '"+tbID.Text+ "'";

            Database db = new Database();

            if (db.cudCMD(sql) > 0)
            {
                labasData();
                MessageBox.Show("Record Has Been Changed");
            }
            else
            {
                MessageBox.Show("An Error Has Been Occured");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string sql = "Delete from tableInfo Where IDNo ='" + tbID.Text + "'";
            /* "'" + tbName.Text + "'," +
             "'"+ tbContact.Text +"'," +
             "'"+ cbProgram.Text +"'," +
             "'"+ tbMail.Text +"')";*/

            Database db = new Database();

            if (db.cudCMD(sql) > 0)
            {
                labasData();
                MessageBox.Show("Record Has Been Changed");
            }
            else
            {
                MessageBox.Show("An Error Has Been Occured");
            }
        }
    }
}

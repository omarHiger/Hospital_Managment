using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Patients_Info.Data;

namespace Patients_Info
{
    public partial class Search : Form
    {
        public Search()
        {
            InitializeComponent();
        }

        private void Search_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'patientSet.Patient' table. You can move, or remove it, as needed.
            this.patientTableAdapter.Fill(this.patientSet.Patient);

        }

        private void btn_Id_Click(object sender, EventArgs e)
        {
            if(txt_Id.Text!="")
            dgv_Search.DataSource = DBHandler.exeQuery("select * from Patient where Pa_id=" + txt_Id.Text);
            else
                dgv_Search.DataSource = DBHandler.exeQuery("select * from Patient");
        }

        private void btn_Name_Click(object sender, EventArgs e)
        {
            if(txt_Name.Text != "")
            dgv_Search.DataSource = DBHandler.exeQuery(string.Format("select * from Patient where First_Name like'{0}%' " , txt_Name.Text));
            else
                dgv_Search.DataSource = DBHandler.exeQuery("select * from Patient");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Are you sure you want to go back ...", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (d == DialogResult.OK)
            {
                this.Close();
                Patient_Details f = new Patient_Details();
                f.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            txt_Id.Visible = true;
            btn_Id.Visible = true;

            label2.Visible = false;
            txt_Name.Visible = false;
            btn_Name.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            txt_Id.Visible = false;
            btn_Id.Visible = false;

            label2.Visible = true;
            txt_Name.Visible = true;
            btn_Name.Visible = true;
        }
    }
}

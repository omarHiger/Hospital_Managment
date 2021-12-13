using Patients_Info.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Patients_Info
{
    public partial class Insert : Form
    {
        public Insert()
        {
            InitializeComponent();
        }

        private void btn_Post_Click(object sender, EventArgs e)
        {
            if (txt_FName.Text == "" || txt_MName.Text == "" || txt_LName.Text == "")
            {
                MessageBox.Show("Please Enter the Full Name at least", "Warining", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult s = MessageBox.Show("Are you sure ", "Warrning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (s == DialogResult.OK)
                {
                    string sql = string.Format("insert into Patient values ('{0}','{1}','{2}','{3}','{4}','{5}') ",
                                      txt_FName.Text, txt_MName.Text, txt_LName.Text, txt_Phone.Text, txt_Loc.Text, txt_Blood.Text);
                    DBHandler.exeChanges(sql);
                    this.Close();
                    Patient_Details f = new Patient_Details();
                    f.Show();
                }
            }
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Close();
            Patient_Details f = new Patient_Details();
            f.Show();
        }
    }
}

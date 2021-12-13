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
    public partial class Update : Form
    {
        public Update()
        {
            InitializeComponent();
        }

        private void btn_UP_Back_Click(object sender, EventArgs e)
        {
            this.Close();
            Patient_Details f = new Patient_Details();
            f.Show();
        }
       
        public void Add(string fn, string mn, string ln, string phone, string loc , string id)
        {
            txt_UP_FName.Text = fn;
            txt_UP_MName.Text = mn;
            txt_UP_LName.Text = ln;
            txt_UP_Phone.Text = phone;
            txt_UP_Loc.Text = loc;
            lbl_ID.Text = id;
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
           DialogResult s= MessageBox.Show("Are you sure you want to make changes","Make changes",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if (s == DialogResult.OK)
            {

                if (txt_UP_FName.Text == "" || txt_UP_MName.Text == "" || txt_UP_LName.Text == "")
                {
                    MessageBox.Show("Please Enter the Full Name at least");
                }
                else
                {
                    int i = DBHandler.exeChanges(string.Format("update Patient set First_Name='{0}', Middle_Name='{1}', Last_Name='{2}', Phone_Number='{3}', Location='{4}',Blood_Type= '{6}'where Pa_id={5}",
                      txt_UP_FName.Text, txt_UP_MName.Text, txt_UP_LName.Text, txt_UP_Phone.Text, txt_UP_Loc.Text, lbl_ID.Text,txt_UP_Blood.Text));
                    this.Close();
                    Patient_Details f = new Patient_Details();
                    f.Show();

                }
            }
        }

        private void Update_Load(object sender, EventArgs e)
        {

        }
    }
}

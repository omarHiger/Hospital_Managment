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
using System.Configuration;
using Patients_Info.Data;
using System.IO;

namespace Patients_Info
{
    public partial class Patient_Details : Form
    {
        public Patient_Details()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'patientSet1.Patient' table. You can move, or remove it, as needed.
            this.patientTableAdapter.Fill(this.patientSet1.Patient);

            dataGridView1.DataSource = DBHandler.exeQuery("select * from Patient");

        }

        private void btn_insert_Click(object sender, EventArgs e)
        {

            Insert ins = new Insert();

            this.Hide();

            ins.Show();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            int i = 0;
            try
            {
                if (dataGridView1.Rows.Count == 0)
                    MessageBox.Show("There is no thing to delete it","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                else
                {
                    i = DBHandler.exeChanges("delete from Patient where Pa_Id = " + dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                    dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
                    MessageBox.Show("deleted sucessfully","Delete",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Please select rwo to delete it","Warining", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch
            {}

            //int i = 0;
            //try
            //{
            //    if (dataGridView1.CurrentRow != null && dataGridView1.Rows.Count > 1)
            //    {
            //        i = DBHandler.exeChanges("delete from Patient where Pa_Id = " + dataGridView1.CurrentRow.Cells[0].Value.ToString());
            //        dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
            //        if(i==-1)
            //            MessageBox.Show("There is a wrong with database please check the connection and try again");
            //        MessageBox.Show("delete succefuly");
            //    }
            //    else if (dataGridView1.Rows.Count == 1)
            //        MessageBox.Show("Cannot deleted");
            //    else
            //    {
            //        MessageBox.Show("please selected row to delete it");
            //    }
            //}
            //catch (Exception p)
            //{ MessageBox.Show(p.ToString()); }
        }
    
           
                    
            
          
        

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (TextWriter tw = new StreamWriter(@"C:\Users\Omar\Desktop\patient.txt"))
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        tw.Write($"{dataGridView1.Rows[i].Cells[j].Value.ToString()}" + "\t ");

                        if (j == dataGridView1.Columns.Count - 1)
                        {
                            tw.Write(",");
                        }
                    }
                    tw.WriteLine();
                }
            }

        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                MessageBox.Show("Please selected row to edit ", "Warining", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                Update up = new Update();
                this.Hide();
                up.Show();
                up.Add(dataGridView1.SelectedRows[0].Cells[1].Value.ToString(), dataGridView1.SelectedRows[0].Cells[2].Value.ToString(),
                    dataGridView1.SelectedRows[0].Cells[3].Value.ToString(),
                    dataGridView1.SelectedRows[0].Cells[4].Value.ToString(), dataGridView1.SelectedRows[0].Cells[5].Value.ToString(),
                    dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                
                    
            }
        }

        private void Patient_Details_Resize(object sender, EventArgs e)
        {
            int x = (this.Width-panel1.Width)/2;
            int y = 30;
            panel1.Location = new Point(x, y);
          
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            Search se = new Search();

            this.Hide();

            se.Show();
        }
    }
}

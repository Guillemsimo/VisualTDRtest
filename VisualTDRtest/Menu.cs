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
using VisualTDRtest.Classes;

namespace VisualTDRtest
{
    public partial class Menu : Form
    {
        public Boolean logueado;
        public String usu;
        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;
        Login login = new Login();
        public string pass;
        ConnLogin test = new ConnLogin();


        public Menu()
        {
            InitializeComponent();
            
        }

        
        private async void Menu_Load(object sender, EventArgs e)
        {


            this.Hide();
            
            if (logueado == true)
            {
                this.Show();
                label3.Text = usu;
                await test.Email(usu, pass);
                label4.Text = test.Tornadis;
                try
                {

                    dataGridView1.Rows.Clear();

                    string si = await test.Test(usu);
                    string[] no = si.Split(';');
                    int i = no.Length;
                    int h = (i - 1) / 4;

                    int n = 0;
                    while (h > n)
                    {
                        int v = dataGridView1.Rows.Add();
                        dataGridView1.Rows[v].Cells[0].Value = no[((n * 4) + 1)];
                        dataGridView1.Rows[v].Cells[1].Value = no[((n * 4) + 2)];
                        dataGridView1.Rows[v].Cells[2].Value = no[((n * 4) + 3)];
                        dataGridView1.Rows[v].Cells[3].Value = no[((n * 4) + 4)];
                        n++;
                    }
                    label10.Text = h.ToString();
                }
                catch (Exception ex)
                {

                }

            }
            else
            {
                this.Hide();
                login.Show();
                
            }
            
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            
            try
            {

                dataGridView1.Rows.Clear();
                
                string si = await test.Test(usu);
                string[] no = si.Split(';');
                int i = no.Length;
                int h = (i - 1) / 4;
                
                int n = 0;
                while (h > n) {
                    int v = dataGridView1.Rows.Add();
                    dataGridView1.Rows[v].Cells[0].Value = no[((n * 4 )+ 1)];
                    dataGridView1.Rows[v].Cells[1].Value = no[((n * 4 )+ 2)];
                    dataGridView1.Rows[v].Cells[2].Value = no[((n * 4 )+ 3)];
                    dataGridView1.Rows[v].Cells[3].Value = no[((n * 4 )+ 4)];
                    n++;
                }
                label10.Text = h.ToString();
            }catch(Exception ex)
            {

            }
        }

        protected override void WndProc(ref Message message)
        {
            base.WndProc(ref message);

            if (message.Msg == WM_NCHITTEST && (int)message.Result == HTCLIENT)
                message.Result = (IntPtr)HTCAPTION;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void Menu_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Vols sortir de l'aplicació?", "Sortida", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                System.Windows.Forms.Application.Exit();
            }
            else if (dialogResult == DialogResult.No)
            {

            }
            
        }

        private void label6_Click(object sender, EventArgs e)
        {
            
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Vols tancar la sessió?", "Tancar sessió", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                logueado = false;
                this.Close();
                login.Show();
            }
            else if (dialogResult == DialogResult.No)
            {

            }
            
        }
    }
}

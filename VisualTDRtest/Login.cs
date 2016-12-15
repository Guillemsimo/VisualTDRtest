using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisualTDRtest.Classes;

namespace VisualTDRtest
{
    
    public partial class Login : Form
    {
         

        public Login()
        {
            InitializeComponent();
             
        }

        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            VisualTDRtest.Menu men = new VisualTDRtest.Menu();
            String usu=textBox1.Text;
            
            String pass = textBox2.Text;
            men.pass = pass;
            ConnLogin login= new ConnLogin();
            

            try
            {
                string length = await login.Login( usu, pass);
                MessageBox.Show(login.sTornada);
                if (login.sTornada.Equals("Login Complet. Hola " +usu))
                {
                   
                   
                    this.Hide();
                    men.logueado = true;
                    men.usu = usu;
                    men.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error"+ex.Message);
            }



        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Registre registre = new VisualTDRtest.Registre();
            registre.Show();
        }

        public void closeLog()
        {
            Form si;
            si = this;
            si.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }

    
}


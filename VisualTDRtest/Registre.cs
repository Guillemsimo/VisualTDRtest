using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisualTDRtest.Classes;

namespace VisualTDRtest
{
    public partial class Registre : Form
    {
        public Registre()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            
            String usu = textBox1.Text;
            String email = textBox2.Text;
            String pass = textBox3.Text;
            
            ConnLogin registre = new ConnLogin();

            try
            {
                string length = await registre.Login(usu,email,pass);
                MessageBox.Show(registre.sTornada);
                //if (login.sTornada.Equals("Login Complet. Hola " +usu))
                //{
                //    logueado = true;
                //    VisualTDRtest.Menu men = new VisualTDRtest.Menu();
                //    this.Close();
                //    men.Show();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Login login = new Login();
            login.ShowDialog();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

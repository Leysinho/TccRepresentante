using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using TCCRepresentante.Contexto;

namespace TCCRepresentante
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lblUsuario_Click(object sender, EventArgs e)
        {

        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {

        }

        private void btnAcessar_Click(object sender, EventArgs e)
        {
            TccRepresentantes db = new TccRepresentantes();
            LoginUsuarios login = db.LoginUsuarios.Where(a => a.Usuario == txtUsuario.Text && a.Senha == txtSenha.Text).FirstOrDefault();

            if (login == null)
            {
                MessageBox.Show("Usuário não existe","Alerta",MessageBoxButtons.OK);
            }
            else if(login.Usuario=="Admin")
            {
                Registro Registro = new Registro();
                Registro.Show();
                this.Hide();
            }
            else
            {
                VotaRepresentante VotaRepresentante = new VotaRepresentante();
                VotaRepresentante.Show();
                this.Hide();
               
            }
        }

        private void txtUsuario_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}

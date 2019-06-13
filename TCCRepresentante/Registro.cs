using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AcessoBanco;
using System.Data.Entity;
using TCCRepresentante.Contexto;

namespace TCCRepresentante
{
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();


            AcessoDados banco = new AcessoDados();
            TccRepresentantes db = new TccRepresentantes();
            //banco.

            String sqlCmd = "select Nome from Turmas";
            

            SqlDataReader reader = (SqlDataReader)banco.ExecutarPersistência(CommandType.Text,sqlCmd,true);

            if (reader.HasRows)
            {
                foreach (DbDataRecord dr in reader)
                {
                    this.comboBox1.Items.Add(dr["Turmas.Nome"]);

                }
            }         
        }
        
        private void RestricaoRepresentante()
        {
            TccRepresentantes db = new TccRepresentantes();
            var representantes = db.Alunos.Where(a => a.Representante == true).ToArray();
            if (representantes.Count() == 4)
            {
                label3.Visible = false;
                rbSim.Visible = false;
                radioButton2.Visible = false;
            }
        }
        private void lblNome_Click(object sender, EventArgs e)
        {

        }

        private void Registro_Load(object sender, EventArgs e)
        {
            RestricaoRepresentante();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool representante = false;
            if (rbSim.Checked)
            {
                representante = true;
            }
            else
            {
                representante = false;
            }
            
            TccRepresentantes db = new TccRepresentantes();

            Alunos aluno = new Alunos { Aluno = textBox1.Text, CGM = Convert.ToInt32(maskedTextBox1.Text), Representante = representante, Turma = comboBox1.Text };

            LoginUsuarios logUsu = new LoginUsuarios();

            logUsu.Usuario = textBox1.Text;
            logUsu.Senha = maskedTextBox1.Text;


            if (representante)
            {
                Voto voto = new Voto { candiato = Convert.ToInt32(maskedTextBox1.Text), Voto1 = 0, Alunos=aluno};
                db.Voto.Add(voto);

            }


            db.Alunos.Add(aluno);
            db.LoginUsuarios.Add(logUsu);

            db.SaveChanges();

            textBox1.Text = "";
            maskedTextBox1.Text = "";
            comboBox1.Text = "";
            rbSim.Checked = false;
            radioButton2.Checked = false;

            RestricaoRepresentante();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (true)
            {
                
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Registro_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Deseja encerrar a inserção de registro?", "Registro",
               MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }

            Application.OpenForms["Form1"].Activate();
            Application.OpenForms["Form1"].Show();

            this.Hide();
            this.Dispose();
            
        }

        private void Registro_FormClosed(object sender, FormClosedEventArgs e)
        {
            
           
            
        }
    }
}

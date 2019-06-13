using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using TCCRepresentante.Contexto;

namespace TCCRepresentante
{

    public partial class VotaRepresentante : Form
    {
        
        public VotaRepresentante()
        {
            InitializeComponent();
        }
        private object Representante()
        {
            TccRepresentantes db = new TccRepresentantes();
            var representantes = db.Alunos.Where(a => a.Representante == true).ToList();
            if (representantes == null)
            {
                return null;
            }
            else
            {
                int x = 0;
                foreach (var item in representantes)
                {
                    if (x > 3)
                        break;

                    if (x == 0)
                        lblName1.Text = item.Aluno;

                    if (x == 1)
                        lblName2.Text = item.Aluno;

                    if (x == 2)
                        lblNome3.Text = item.Aluno;

                    if (x == 3)
                        lblName4.Text = item.Aluno;

                    x++;
                }

                /*
                lblName1.Text = representantes[0].Aluno;
                lblName2.Text = representantes[1].Aluno;
                lblNome3.Text = representantes[2].Aluno;
                lblName4.Text = representantes[3].Aluno;
                */
                return representantes;
            }
        }
        private void VotaRepresentante_Load(object sender, EventArgs e)
        {
            //de onde vai pegar as imagens (diretório)
            //como carregar uma imagem para o picturebox

            Representante();
        }

        private void VotaRepresentante_Shown(object sender, EventArgs e)
        {

            //string appPath = Path.GetDirectoryName(Application.ExecutablePath);


            pictureBox1.Image = Image.FromFile(@"..\..\Images\candidato1.bmp");
            pictureBox2.Image = Image.FromFile(@"..\..\Images\candidato2.bmp");
            pictureBox3.Image = Image.FromFile(@"..\..\Images\candidato3.bmp");
            pictureBox4.Image = Image.FromFile(@"..\..\Images\candidato4.bmp");

            /*
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box  
                pictureBox1.Image = new Bitmap(open.FileName);
            }
            */
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
                if (MessageBox.Show("Confirma Voto?", "Voto",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    string nomeRpresentate = string.Empty;

                    if (radioButton1.Checked)
                        nomeRpresentate = lblName1.Text;
                    if (radioButton2.Checked)
                        nomeRpresentate = lblName2.Text;
                    if (radioButton3.Checked)
                        nomeRpresentate = lblNome3.Text;
                    if (radioButton3.Checked)
                        nomeRpresentate = lblName4.Text;

                    //grava voto no banco de dados
                    TccRepresentantes db = new TccRepresentantes();

                    Alunos aluno = db.Alunos.Where(a => a.Aluno == nomeRpresentate).FirstOrDefault();
                    Voto voto = db.Voto.Where(v => v.Alunos.Aluno == nomeRpresentate).FirstOrDefault();

                    /*voto.Voto1 = voto.Voto1 + 1;*/
                    Voto novoVoto = new Voto() { Alunos = aluno, Voto1 = 0, candiato = voto.candiato };
                    db.Voto.Add(novoVoto);

                    db.SaveChanges();

                    Application.OpenForms["Form1"].Activate();
                    Application.OpenForms["Form1"].Show();

                    this.Hide();
                    this.Dispose();
                }

            }

            private void label1_Click(object sender, EventArgs e)
            {

            }

            private void label3_Click(object sender, EventArgs e)
            {

            }
        }
    }


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCCRepresentante
{
    public class Candidato
    {
        public  String CandNome { get; set; }
        public String Turma { get; set; }
        public Int16 CGM { get; set; }
        //public  CanImagem { get; set; }
    }
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new VotaRepresentante());
        }
    }
}
/*using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Voto3.Properties;

namespace Voto3
{
    public partial class Form1 : Form
    {
        //Onde serão guardados os candidatos.
        private readonly List<Candidato> _candidatos = new List<Candidato>();
        private int _key = -1;

        public class Candidato
        {
            public Int16 CanLegenda { get; set; }
            public String CanNome { get; set; }
            public Int16 CanVoto { get; set; }
            public Image CanImagem { get; set; }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Adicionando candidados (Número Legenda, Nome, Número de votos, Imagem)
            _candidatos.Add(new Candidato { CanLegenda = 12, CanNome = "Bolsonaro", CanVoto = 0, CanImagem = Resources._12 });
            _candidatos.Add(new Candidato { CanLegenda = 13, CanNome = "Lula", CanVoto = 0, CanImagem = Resources._13 });
            _candidatos.Add(new Candidato { CanLegenda = 18, CanNome = "Marina", CanVoto = 0, CanImagem = Resources._18 });
            _candidatos.Add(new Candidato { CanLegenda = 0, CanNome = "Branco", CanVoto = 0, CanImagem = Resources.none });
            pictureBox1.Image = Resources.none;

            //Para todos os botões de digitos, faremos um handle único já que todos tem a mesma função.
            string[] numeros = { "btn0", "btn1", "btn2", "btn3", "btn4", "btn5", "btn6", "btn7", "btn8", "btn9" };
            foreach (var botao in Controls.OfType<Button>().Where(botao => numeros.Contains(botao.Name)))
                botao.Click += Click_Button;

            //Botão Corrigir: Limpa labels para corrigir número do candidato
            btnCorrige.Click += (o, args) =>
            {
                lblDigito1.Text = String.Empty; lblDigito2.Text = String.Empty;
                pictureBox1.Image = Resources.none;
            };

            btnConfirmar.Click += (o, args) => { Votar(); btnCorrige.PerformClick(); };

            btnBranco.Click += (o, args) =>
            {
                _key = 0;
                btnConfirmar.Enabled = true;
                btnConfirmar.PerformClick();
            };
        }

        //Método para o handle de todos os dígitos
        public void Click_Button(object sender, EventArgs e)
        {
            lblInfo.Text = String.Empty;
            if (string.IsNullOrEmpty(lblDigito1.Text))
                lblDigito1.Text = ((Button)sender).Text;
            else
            {
                lblDigito2.Text = ((Button)sender).Text;
                _key = Int16.Parse(lblDigito1.Text + lblDigito2.Text);
                var w = new Form { Size = new Size(0, 0) };
                Task.Delay(TimeSpan.FromSeconds(1))
                    .ContinueWith(t => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());
                //Verifica se o candidato digitado existe.
                if (!_candidatos.Exists(x => x.CanLegenda == _key))
                {
                    MessageBox.Show(w, @"Candidato Não Existe !", @"Erro !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnCorrige.PerformClick();
                }
                else
                {
                    pictureBox1.Image = _candidatos.FirstOrDefault(x => x.CanLegenda == _key)?.CanImagem;
                    lblInfo.Text = _candidatos.FirstOrDefault(x => x.CanLegenda == _key)?.CanNome;
                }
                btnConfirmar.Enabled = true;
            }
        }

        public void Votar()
        {
            try
            {
                //Adiciona voto ao candidato digitado.
                _candidatos.FirstOrDefault(x => x.CanLegenda == _key).CanVoto++;
                //Apresenta um MessageBox de confirmação de voto por 1 segundo.
                var w = new Form { Size = new Size(0, 0) };
                Task.Delay(TimeSpan.FromSeconds(1))
                    .ContinueWith(t => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());
                MessageBox.Show(w, @"Voto Confirmado", @"Urna Eletrônica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //Limpa alguns controles
                pictureBox1.Image = Resources.none;
                _key = -1;
                btnConfirmar.Enabled = false;
                lblInfo.Text = String.Empty;
                //Verifica a quantidade de votos totais.
                var votos = _candidatos.Sum(x => x.CanVoto);
                // Se quantidade de votos é igual a 10, encerra a votação e mostra o vencedor.
                if (votos != 10) return;
                var vencedor = _candidatos.OrderByDescending(x => x.CanVoto).FirstOrDefault(x => x.CanLegenda != 0);
                lblInfo.Text = string.Format(@"O Vencedor é o Candidato {0} com {1} votos !", vencedor?.CanNome, vencedor?.CanVoto);
                //Zera os votos de todos os candidatos.
                _candidatos.ForEach(x => x.CanVoto = 0);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
} */
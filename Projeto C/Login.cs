using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Projeto_C
{
    public partial class Login : System.Windows.Forms.Form
    {
        public Login()
        {
            InitializeComponent();
        }        

        private void Form1_Load(object sender, EventArgs e)
        {
            string utilizadores = @"utilizadores.txt";
            StreamWriter sw;
            if(File.Exists(utilizadores))
            {
                //não faz nada
            }
            else
            {
                sw = File.CreateText(utilizadores);
                sw.WriteLine("admin;admin@admin;admin;admin");
                sw.WriteLine("serviçosinf;serviços@informáticos.esmad;serviçosinformáticos;serviçosinf");
                sw.Close();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        //BOTAO CRIAR CONTA
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            this.Hide();
            CriarConta f2 = new CriarConta();//criar novo form para registar
            f2.Show();//mostrar o form2 para registar
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        //BOTAO LOGIN
        private void button1_Click(object sender, EventArgs e)
        {            
            string utilizadores = @"utilizadores.txt";
            if (File.Exists(utilizadores))
            {
                //abre o ficheiro para leitura
                StreamReader sr = File.OpenText(utilizadores);
                string linha = "";
                //lê p ficheiro continuamente até atingir uma linha em que não haja nada escrito
                while ((linha = sr.ReadLine()) != null)
                {
                    //Determina a posição do primeiro ";" para verificar se o nome do 
                    //utilizador se encontra na base de dados
                    int pos = linha.IndexOf(";");
                    //Verifica se já existe um utilizador com o nome na textbox1
                    if (textBox1.Text == linha.Substring(0, pos))
                    {
                        //Posição do último ";" para poder verificar a password
                        int pos2 = linha.LastIndexOf(";") + 1;
                        int fim = linha.Length;
                        //Número de caracteres que vão desde o último ";" até ao fim da linha
                        int fim2 = fim - pos2;
                        //Confirma se a password está correta
                        if (textBox2.Text == linha.Substring(pos2, fim2))
                        {
                            pessoas.nomeut = textBox1.Text;
                            MessageBox.Show("Bem vindo " + textBox1.Text);                            
                            PaginaPrincipal f3 = new PaginaPrincipal();
                            f3.Show();
                            //Neste caso tem de ser .hide porque, como o form1 é o principal, 
                            //este tem de estar sempre ativo senão o programa desliga
                            this.Hide();
                            //O break serve para quando o programa encontrar o utilizador que pretende
                            //na base de dados este parar o "if" pois já não é necessário este continuar
                            break;
                        }
                        //else caso a pw esteja errada
                        else
                        {
                            MessageBox.Show("Password errada!");
                            textBox2.Text = "";
                        }
                        //goto end para não aparecer a messagebox abaixo desnecessáriamente
                        goto end;
                    }

                }
                //if caso não se verifique que existe o nome de utilizador
                if (linha == null)
                {
                    MessageBox.Show("Utilizador não autenticado! Crie conta primeiro.");
                }
            end:;
                sr.Close();
            }
            //else quando não existe ficheiro, logo é necessario criar conta para criar o ficheiro
            else
            {
                MessageBox.Show("Utilizador não autenticado! Crie conta primeiro.");
            }
        }

        //BOTAO SAIR
        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
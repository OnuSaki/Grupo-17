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
    public partial class CriarConta : System.Windows.Forms.Form
    {
        public CriarConta()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login f = new Login();
            f.Show();
            this.Close();
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string utilizadores = @"utilizadores.txt";
            //Localização do ficheiro = Projeto C\Projeto C\bin\Debug
            StreamWriter sw;
            //Verifica se o existe o ficheiro
            if (File.Exists(utilizadores)) //Se existir executa o que está abaixo
            {
                //Verifica se existe algum campo em branco
                if ((textBox3.Text == "") || (textBox4.Text == "") || (textBox1.Text == "") || (textBox2.Text == ""))
                {
                    MessageBox.Show("Deixou algum espaço em branco.");
                    textBox3.Text = "";
                    textBox4.Text = "";
                }
                //Verifica se as passwords coincidem
                else if (textBox3.Text != textBox4.Text)
                {
                    MessageBox.Show("As passwords não coincidem.");
                    textBox3.Text = "";
                    textBox4.Text = "";
                }
                else if ((textBox3.Text == textBox4.Text) && (textBox3.Text != "") && (textBox4.Text != ""))
                {
                    StreamReader sr = File.OpenText(utilizadores);
                    string linha = "";
                    while ((linha = sr.ReadLine()) != null)
                    {
                        int pos = linha.IndexOf(";");
                        //Verifica se já existe um utilizador com o nome na textbox1
                        if (textBox1.Text == linha.Substring(0, pos))
                        {
                            MessageBox.Show("Nome de utilizador indisponível.");
                            textBox1.Text = "";
                            textBox2.Text = "";
                            textBox3.Text = "";
                            textBox4.Text = "";
                            goto end;
                        }
                    }
                    sr.Close();
                    //Se não existir ninguem, abre o ficheiro
                    using (sw = File.AppendText(utilizadores))
                    {
                        //Escreve uma linha com as informações do utilizador
                        sw.WriteLine(textBox1.Text + ";" + textBox2.Text + ";" + "docente" + ";" + textBox3.Text);
                        sw.Close();
                        MessageBox.Show("Conta criada com sucesso");
                        Login f = new Login();
                        f.Show();
                        this.Close();
                    }
                end:;
                    sr.Close();
                }
            }
            else //Se não existir, executa o código a seguir
            {
                //Verifica se existe algum campo em branco
                if ((textBox3.Text == null) || (textBox4.Text == null) || (textBox1.Text == null) || (textBox2.Text == null))
                {
                    MessageBox.Show("Deixou algum espaço em branco.");
                    textBox3.Text = "";
                    textBox4.Text = "";
                }
                //Verifica se as passwords coincidem
                else if (textBox3.Text != textBox4.Text)
                {
                    MessageBox.Show("As passwords não coincidem.");
                    textBox3.Text = "";
                    textBox4.Text = "";
                }
                else if ((textBox3.Text == textBox4.Text) && (textBox3.Text != null) && (textBox4.Text != null))
                {
                    //Se o ficheiro não existir cria-se um novo
                    using (sw = File.CreateText(utilizadores))
                    {
                        //Escreve uma linha com as informações do utilizador
                        sw.WriteLine(textBox1.Text + ";" + textBox2.Text + ";" + "docente" + ";" + textBox3.Text);
                        sw.Close();
                        MessageBox.Show("Conta criada com sucesso");
                        Login f = new Login();
                        f.Show();
                        this.Close();
                    }
                }
            }
        }
    }
}

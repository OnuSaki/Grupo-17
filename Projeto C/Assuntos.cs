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
    public partial class Assuntos : Form
    {        
        public Assuntos()
        {
            InitializeComponent();            
        }
        
        //BOTAO/IMAGEM RETROCEDER
        private void button3_Click(object sender, EventArgs e)
        {
            Form f = new PaginaPrincipal();
            f.Show();
            this.Close();
        }

        private void Assuntos_Load(object sender, EventArgs e)
        {
            string assuntos = @"assuntos.txt";
            if (File.Exists(assuntos))
            {
                StreamReader sr = File.OpenText(assuntos);
                string linha = "";
                while ((linha = sr.ReadLine()) != null)
                {
                    listBox1.Items.Add(linha);
                }
                sr.Close();
            }
        }


        //BOTAO ADICIONAR
        private void button1_Click(object sender, EventArgs e)
        {
            int cont = 0;
            //coloca tudo em minusculas para facilitar a comparaçao a encontrar igualdade nos assuntos
            string assunto = richTextBox1.Text.ToLower();            
            //localizaçao do fichero assuntos
            string ficheiro = @"assuntos.txt";
            if (File.Exists(ficheiro))
            {
                StreamReader sr = File.OpenText(ficheiro);
                if (File.Exists(ficheiro))
                {
                    string linha = "";
                    while ((linha = sr.ReadLine()) != null)
                    {
                        //posiçao do ';'
                        int pos = linha.LastIndexOf(";") + 1;
                        //posiçao do ';' da ultima linha
                        int posx = linha.IndexOf(";");
                        //obtem a string desde a posiçao 0 ate ao n de carateres pretendidos
                        string numero = linha.Substring(0,posx);
                        // int n é a conversao da string em int
                        int n = Convert.ToInt32(numero);
                        //contador 'cont' que estava em cima passa a ser o numero inteiro 'n'
                        cont = n;
                        //tamanho da frase
                        int fim = linha.Length;
                        //numero de carateres do ';' ate ao fim da frase
                        int pos2 = fim - pos;
                        if (assunto == linha.Substring(pos, pos2))
                        {
                            MessageBox.Show("Assunto já existente");
                            sr.Close();
                            //goto end para não repetir o sr.Close()
                            goto end;
                        }
                        //caso não tenha nada escrito
                        if (richTextBox1.Text == "")
                        {
                            MessageBox.Show("Nenhum assunto para ser adicionado.");
                            sr.Close();
                            goto end;
                        }
                    }
                    //este sr.close esta aqui para o caso de o while chegar ao fim sem encontrar um assunto igual
                    sr.Close();
                end:;
                    //ciclo if para caso de não encontrar assunto igual
                    if (linha == null)
                    {
                        //CONTADOR PARA O ASSUNTO
                        cont = cont + 1;//numero lido la em cima +1
                        listBox1.Items.Add(cont + ";" + assunto);
                        //abre o ficheiro para escrever no final
                        StreamWriter sw = File.AppendText(ficheiro);
                        sw.WriteLine("{0};{1}", cont, assunto);                        
                        MessageBox.Show("Assunto adicionado com sucesso.");
                        richTextBox1.Text = "";
                        sw.Close();
                    }
                }                
            }
            //caso nao exista ficheiro
            else
            {
                //CONTADOR PARA O ASSUNTO
                cont = cont + 1;//numero lido la em cima +1
                listBox1.Items.Add(cont + ";" + assunto);
                StreamWriter sw = File.CreateText(ficheiro);
                sw.WriteLine("{0};{1}", cont, assunto);
                MessageBox.Show("Assunto adicionado com sucesso.");
                richTextBox1.Text = "";
                sw.Close();
            }          
            
            listBox1.Items.Clear();
            StreamReader sr2 = File.OpenText(ficheiro);
            string linha2;
            while ((linha2 = sr2.ReadLine()) != null)
            {                
                listBox1.Items.Add(linha2);
            }
            sr2.Close();
            
        }

        //BOTAO LIMPAR
        private void button2_Click(object sender, EventArgs e)
        {
            //limpar a caixa de texto
            richTextBox1.Text = "";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {            
        }
    }
}

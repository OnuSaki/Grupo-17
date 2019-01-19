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
    public partial class Form4 : System.Windows.Forms.Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            //O form, ao dar load, carrega todas as salas para a listbox1
            string salas = @"salas.txt";
            if (File.Exists(salas))
            {
                StreamReader sr = File.OpenText(salas);
                string linha;
                while ((linha = sr.ReadLine()) != null)
                {
                    listBox1.Items.Add(linha);
                }
                sr.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string salas = @"salas.txt";
            StreamReader sr;
            //Verifica se o ficheiro salas.txt existe
            if (File.Exists(salas))
            {
                sr = File.OpenText(salas);
                string linha;
                while ((linha = sr.ReadLine()) != null)
                {
                    //Confirma se a sala já está presente no ficheiro
                    //Se tiver manda a mensagem que já se encontra no sistema
                    if (linha == maskedTextBox1.Text.ToUpper())
                    {
                        MessageBox.Show("A sala " + maskedTextBox1.Text.ToUpper() + " já se encontra no sistema");
                        maskedTextBox1.Text = "";
                        sr.Close();
                        goto end;
                    }
                    if (maskedTextBox1.MaskFull==false)
                    {
                        MessageBox.Show("Preencha os espaços em branco.");
                        sr.Close();
                        goto end;
                    }
                }
                //Se ainda não estiver no sistema, fecha o StreamReader
                sr.Close();
                //Adiciona a sala à listbox1 para depois ser passado ao ficheiro salas.txt
                listBox1.Items.Add(maskedTextBox1.Text.ToUpper());
                listBox1.Sorted = true;
                StreamWriter sw = File.AppendText(salas);
                sw.WriteLine(maskedTextBox1.Text.ToUpper());
                MessageBox.Show("Sala registada com sucesso");
                maskedTextBox1.Text = "";
                sw.Close();
            end:;
            }
            //Se o ficheiro salas.txt ainda não existir, cria um ficheiro novo e regista a primeira sala
            else
            {
                StreamWriter sw = File.CreateText(salas);
                sw.WriteLine(maskedTextBox1.Text.ToUpper());
                MessageBox.Show("Sala registada com sucesso");
                sw.Close();
            }
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {           
            string salas = @"salas.txt";
            if (File.Exists(salas))
            {
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    //Confirmação se a sala se encontra no sistema
                    if (maskedTextBox1.Text.ToUpper() == listBox1.Items[i].ToString())
                    {
                        //Se estiver registada no sistema, apaga todo o texto do ficheiro salas.txt e volta a 
                        //escrever de acordo com a listbox1 sem a sala que se removeu
                        string linha;
                        listBox1.Items.Remove(maskedTextBox1.Text.ToUpper());
                        //Apagar todo o texto do ficheiro
                        File.WriteAllText(@"salas.txt", "");
                        StreamWriter sw = File.AppendText(salas);
                        //Escrever o novo texto
                        string num = listBox1.Items.Count.ToString();
                        int num1 = Convert.ToInt16(num);
                        for (int a = 0; a < num1; a++)
                        {
                            linha = listBox1.Items[a].ToString();
                            sw.WriteLine(linha);
                        }
                        sw.Close();
                        MessageBox.Show("Sala removida com sucesso");
                        maskedTextBox1.Text = "";
                        goto end;
                    }           
                }
                MessageBox.Show("A sala " + maskedTextBox1.Text.ToUpper() + " não se encontra no sistema");
                maskedTextBox1.Text = "";
            end:;
            }
            else
            {
                MessageBox.Show("A sala " + maskedTextBox1.Text.ToUpper() + " não se encontra no sistema");
                maskedTextBox1.Text = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form f = new PaginaPrincipal();
            f.Show();
            this.Close();            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
    }


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
    public partial class Gestao_de_Software : Form
    {
        public Gestao_de_Software()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form f = new PaginaPrincipal();
            f.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //limpa a text box do software depois de mudar de sala
            textBox1.Text = "";            
            string salas = @"salas.txt";
            StreamReader sr;
            //confirma se existe o ficheiro salas
            if (File.Exists(salas))
            {
                //existindo, abre-o para colocar que salas se encontram no sistema
                sr = File.OpenText(salas);
                string linha;
                while ((linha = sr.ReadLine()) != null)
                {
                    listBox2.Items.Add(linha);
                }
                sr.Close();
                //ficheiro .txt com a sala que se pretende verificar
                string sala = @"" + comboBox1.Text + ".txt";
                string num = listBox2.Items.Count.ToString();
                int num1 = Convert.ToInt16(num);
                for (int i = 0; i < num1; i++)
                {
                    //Verifica se existe a sala no sistema
                    if (comboBox1.Text == listBox2.Items[i].ToString())
                    {
                        if (File.Exists(sala))
                        {
                            //abre o ficheiro e copia para a listbox1 os softwares já instalados nessa sala
                            sr = File.OpenText(sala);
                            while ((linha = sr.ReadLine()) != null)
                            {
                                listBox1.Items.Add(linha);
                            }
                            sr.Close();
                            //Após abrir o ficheiro da sala, escondem-se os botões inicias para que possa aparecer os
                            //botões para adicionar um software novo à sala ou trocar a sala que se pretende verificar
                            //que software se encontra instalado
                            //Label Software
                            label2.Visible = true;
                            //label licença
                            label3.Visible = true;
                            //Textbox à frente da label software
                            textBox1.Visible = true;
                            //textbox à frente da label licença
                            comboBox2.Visible = true;
                            //botão adicionar software
                            button2.Visible = true;
                            //botão verificar outra sala
                            button4.Visible = true;
                            //botão verificar software
                            button1.Visible = false;
                            //label sala
                            label1.Visible = false;
                            //combobox sala
                            comboBox1.Visible = false;                            
                            goto end;
                        }
                        else
                        {
                            //se o ficheiro da sala ainda não existir cria o ficheiro para essa sala
                            StreamWriter sw = File.CreateText(sala);
                            sw.Close();
                            //abre o ficheiro e copia para a listbox1 os softwares já instalados nessa sala
                            sr = File.OpenText(sala);
                            while ((linha = sr.ReadLine()) != null)
                            {
                                listBox1.Items.Add(linha);
                            }
                            sr.Close();
                            //Após abrir o ficheiro da sala, escondem-se os botões inicias para que possa aparecer os
                            //botões para adicionar um software novo à sala ou trocar a sala que se pretende verificar
                            //que software se encontra instalado
                            //Label Software
                            label2.Visible = true;
                            //label licença
                            label3.Visible = true;
                            //Textbox à frente da label software
                            textBox1.Visible = true;
                            //textbox à frente da label licença
                            comboBox2.Visible = true;
                            //botão adicionar software
                            button2.Visible = true;
                            //botão verificar outra sala
                            button4.Visible = true;
                            //botão verificar software
                            button1.Visible = false;
                            //label sala
                            label1.Visible = false;
                            //combobox sala
                            comboBox1.Visible = false;
                            goto end;
                        }
                    }
                }
                MessageBox.Show("Sala não registada! Por favor, registe primeiro a sala em Gestão de salas");
            }
            else
            {
                MessageBox.Show("Ainda não registou nenhuma sala! Por favor, registe primeiro a sala em Gestão de Salas");
            }
        end:;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Software software = new Software();
            string sala = @"" + comboBox1.Text + ".txt";
            software.software = textBox1.Text;
            software.tipo = comboBox2.Text;
            software.hora = DateTime.Now.ToString("HH:mm");
            software.data = DateTime.Today.ToString("dd/MM/yyyy");
            //Confirma se o software já está instalado nessa sala ou não
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                StreamReader sr = File.OpenText(sala);
                string linha;
                while ((linha = sr.ReadLine()) != null)
                {
                    int pos = linha.IndexOf(";");
                    if (textBox1.Text == linha.Substring(0, pos))
                    {
                        MessageBox.Show("Software já instalado!");
                        sr.Close();
                        goto end;
                    }
                }
                sr.Close();
            }
            //Se ainda não existir nenhum software instalado executa este código pois nunca chega a entrar no
            //ciclo "for" por o lisbox1.items.count será 0, ou seja, será igual ao i.
            if (listBox1.Items.Count == 0)
            {
                listBox1.Items.Add(software.software + "; " + software.data + "; " + software.hora + "; " + software.tipo);
                StreamWriter sw1 = File.AppendText(sala);
                sw1.WriteLine(software.software + "; " + software.data + "; " + software.hora + "; " + software.tipo);
                sw1.Close();
                goto aqui;
            }
            //Se já houver algum software executa isto
            listBox1.Items.Add(software.software + "; " + software.data + "; " + software.hora + "; " + software.tipo);
            StreamWriter sw = File.AppendText(sala);
            sw.WriteLine(software.software + "; " + software.data + "; " + software.hora + "; " + software.tipo);
            sw.Close();
        end:;
        aqui:;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Limpa a listbox1 inteira
            listBox1.Items.Clear();
            //Esconde os botões que estavam expostos e mostra os que estavam escondidos para ficar como se
            //tivesse acabado de abrir o form
            //Label Software
            label2.Visible = false;
            //label licença
            label3.Visible = false;
            //Textbox à frente da label software
            textBox1.Visible = false;
            //textbox à frente da label licença
            comboBox2.Visible = false;
            //botão adicionar software
            button2.Visible = false;
            //botão verificar outra sala
            button4.Visible = false;
            //botão verificar software
            button1.Visible = true;
            //label sala
            label1.Visible = true;
            //textbox para escrever que sala se pretende verificar
            comboBox1.Visible = true;
            comboBox1.Text = "";
        }

        private void Gestao_de_Software_Load(object sender, EventArgs e)
        {
            string salas = @"salas.txt";
            StreamReader sr;
            //confirma se existe o ficheiro salas
            if (File.Exists(salas))
            {
                //existindo, abre-o para colocar que salas se encontram no sistema
                sr = File.OpenText(salas);
                string linha;
                while ((linha = sr.ReadLine()) != null)
                {
                    comboBox1.Items.Add(linha);
                }
                sr.Close();
            }
            //combobox2 itens            
            comboBox2.Items.Add("Open Source");
            comboBox2.Items.Add("Comercial Software");
            comboBox2.Items.Add("Freeware");
            comboBox2.Items.Add("30 Days Trial");
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}

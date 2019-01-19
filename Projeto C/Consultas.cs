using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_C
{
    public partial class Consultas : Form
    {
        public Consultas()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form f = new PaginaPrincipal();
            f.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form ver_software = new Verificar_Software();
            ver_software.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form ver_notificacoes = new Verificar_Notificações();
            ver_notificacoes.Show();
            this.Hide();
        }

        private void Consultas_Load(object sender, EventArgs e)
        {

        }
    }
}

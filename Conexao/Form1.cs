using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conexao
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //try
            //{
            Conexao.ConexaoClient cone = new Conexao.ConexaoClient("Conexao");
            dataGridView1.DataSource = cone.ExecutaConsulta(CommandType.StoredProcedure, "[dbo].[aspSelectFullProduto]");

            
               // MessageBox.Show(cone.ExecutaConsulta(CommandType.StoredProcedure,""));
            //}
            //catch (Exception Erro)
            //{

            //    MessageBox.Show("Erro: " + Erro.Message);
            //}
        }
    }
}

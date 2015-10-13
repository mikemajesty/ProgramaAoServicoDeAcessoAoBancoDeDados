using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frmConectar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       static DataSet produto = null;
        Servico.ConexaoClient c = new Servico.ConexaoClient("BasicHttpBinding_IConexao");

        private void Form1_Load(object sender, EventArgs e)
        {
            AtualizarGrid();

        }

        private void AtualizarGrid()
        {
            c.LimparParametros();
            produto = c.ExecutaConsulta(CommandType.StoredProcedure, "aspSelectFullProduto");
           
            dataGridView1.DataSource = produto.Tables[0];

        }

        private void btn_Salvar_Click(object sender, EventArgs e)
        {
            Produto prod = new Produto
            {
                Nome = txt_Nome.Text,
                Categoria = txt_Categoria.Text,
                Marca = txt_Marca.Text,
                Tipo = txt_Tipo.Text,
                PrecoCompra = Convert.ToDouble(txt_PrecoCompra.Text),
                PrecoVenda = Convert.ToDouble(txt_PrecoVenda.Text),
                QtdEstoque = Convert.ToInt32(txt_qtdEstoque.Text)
            };
            c.LimparParametros();
            c.AdicionarParametros("@Nome", prod.Nome);
            c.AdicionarParametros("@Tipo", prod.Tipo);
            c.AdicionarParametros("@Categoria", prod.Categoria);
            c.AdicionarParametros("@Marca", prod.Marca);
            c.AdicionarParametros("@PrecoCompra", prod.PrecoCompra);
            c.AdicionarParametros("@PrecoVenda", prod.PrecoVenda);
            c.AdicionarParametros("@QtdEstoque", prod.QtdEstoque);
            if (c.ExecutaComando(CommandType.StoredProcedure, "aspInsertProduto") != null)
            {
                MessageBox.Show("Cliente Salvo Com Sucesso!","Aviso");
                AtualizarGrid();
            }
            else
            {
                MessageBox.Show("Não Foi Possível Salvar Cliente No Banco","Erro");
            }
            //AtualizarGrid();
        }
    }
}

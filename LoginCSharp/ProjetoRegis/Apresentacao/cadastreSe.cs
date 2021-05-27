using ProjetoRegis.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProjetoRegis.Apresentacao
{
    public partial class cadastreSe : Form
    {
        public cadastreSe()
        {
            InitializeComponent();
        }

        private void btn_cadastrar_Click(object sender, EventArgs e)
        {
            cadastreSe cad = new cadastreSe();
            Controller controle = new Controller();
            String mensagem = controle.Cadastrar(txbLogin.Text, txbSenha.Text, txbConfirmarSenha.Text);
            if (controle.acessar)
            {
                MessageBox.Show(mensagem, "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else {
                MessageBox.Show(controle.msg, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cadastreSe_Load(object sender, EventArgs e)
        {

        }
    }
}

using Cruzamento_Toyota.DbAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Cruzamento_Toyota
{
    public partial class Painel : Form
    {
        public Painel()
        {
            InitializeComponent();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsuarioBanco u = new UsuarioBanco();
            Painel p = new Painel();
            CTOracleSession cTOracleSession = new CTOracleSession(u.Usuario, u.Senha, u.Servidor, u.Schema, u.Host, u.Porta);

            cTOracleSession.FecharConexao();
            p.Close();
        }

        private void btnSairPainel_Click(object sender, EventArgs e)
        {
            //UsuarioBanco u = new UsuarioBanco();
            Painel p = new Painel();
            //CTOracleSession cTOracleSession = new CTOracleSession(u.Usuario, u.Senha, u.Servidor, u.Schema, u.Host, u.Porta);

            //cTOracleSession.FecharConexao();
            p.Close();
        }

        private void Painel_Load(object sender, EventArgs e)
        {

        }

        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TelaConsulta t = new TelaConsulta();
            t.Show();
        }

    }
}

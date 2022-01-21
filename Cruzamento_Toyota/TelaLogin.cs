using Cruzamento_Toyota.DbAccess;
using Cruzamento_Toyota.Partial;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cruzamento_Toyota
{
    public partial class TelaLogin : Form
    {
        public TelaLogin()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            UsuarioBanco u = new UsuarioBanco();
            CTUsuario c = new CTUsuario();
            Painel p = new Painel();


            u.Usuario = txtUsuarioBanco.Text;
            u.Senha = txtSenhaBanco.Text;
            u.Servidor = txtServidorBanco.Text;
            u.Schema = txtShemaBanco.Text;
            u.Host = txtHostBanco.Text;
            u.Porta = txtPorta.Text;

            bool credenciasOK = c.ValidarUsuario(u.Usuario, u.Senha, u.Servidor, u.Schema, u.Host, u.Porta);

            if (credenciasOK)
            {
                p.Show();
            }
            
        }
    }
}

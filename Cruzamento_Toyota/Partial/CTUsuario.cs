using Cruzamento_Toyota.DbAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Cruzamento_Toyota.Partial
{
    public partial class CTUsuario
    {
        public bool ValidarUsuario(string usuario, string senha, string servidor, string schema, string host, string porta)
        {
            UsuarioBanco u = new UsuarioBanco();
            
            CTOracleSession oracleSession = new CTOracleSession(usuario, senha, servidor, schema, host, porta);
            bool conexao;

            if (oracleSession.TestarConexao())
            {
                conexao = true;
               MessageBox.Show("Conexão Estabelecida com Sucesso!");
            }
            else
            {
                conexao = false;
                MessageBox.Show("Conexão Falhou!!");
            }

            return conexao;
        }
    }
}

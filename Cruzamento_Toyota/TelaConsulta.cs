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
    public partial class TelaConsulta : Form
    {
        public TelaConsulta()
        {
            InitializeComponent();
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            string strSQL;
            strSQL = txtConsulta.Text;
            string resultado;

            CTOracleSession oracleSession = new CTOracleSession("nbs", "new", "orcl", "nbs", "192.168.10.4", "1521");

            resultado = oracleSession.ExecutaSql(strSQL);

            MessageBox.Show(resultado);
        }
    }
}

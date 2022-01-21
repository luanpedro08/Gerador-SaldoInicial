using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Cruzamento_Toyota.DbAccess
{
    public class CTOracleSession
    {
        public OracleConnection oracleConnection { get; set; }
        public OracleTransaction oracleTransaction { get; set; }
        public OracleDataAdapter oracleDataAdapter { get; set; }
        private string usuario, senha, servidor, schema, host, porta;


        public CTOracleSession(string usuario, string senha, string servidor, string schema, string host, string porta)
        {
            try
            {
                this.usuario = usuario;
                this.senha = senha;
                this.servidor = servidor;
                this.schema = schema;
                this.host = host;
                this.porta = porta;

                oracleConnection = new OracleConnection(GetConnectionString());
                oracleDataAdapter = new OracleDataAdapter();

            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao tentar instanciar conexão. {e.Message}");
            }

        }

        public string GetConnectionString()
        {
            string connectionString = $"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={host})(PORT={porta}))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME={servidor})));User Id={usuario};Password={senha};";
            //string connectionString = $"SERVER = (DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = {host})(PORT = {porta}))(CONNECT_DATA = (SERVICE_NAME = {servidor}))); uid = {usuario}; pwd = {senha};";
            return connectionString;
        }

        public bool TestarConexao()
        {
            try
            {
                if (oracleConnection.State == ConnectionState.Open)
                {
                    return true;
                }
                else
                {
                    oracleConnection.Open();
                    return oracleConnection.State == ConnectionState.Open;
                }

            }
            catch (Exception)
            {

                return false;
            }
            
        }

        public void AbrirConexao()
        {
            try
            {
                if (oracleConnection.State != ConnectionState.Open)
                {
                    oracleConnection.Open();
                }
            }
            catch (Exception e)
            {

                throw new Exception($"Não foi possivel abrir conexão com oracle.{e.Message}");
            }
        }

        public void FecharConexao()
        {
            try
            {
                if (oracleConnection.State != ConnectionState.Closed)
                {
                    oracleConnection.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Ocorreu um erro fechar conexão. {e.Message}.");
            }
            
        }

        public void Commit()
        {
            if (oracleConnection.State == ConnectionState.Open)
            {
                oracleTransaction.Commit();
            }
        }

        public string ExecutaSql(string strSql)
        {
            OracleCommand comando = new OracleCommand(strSql, oracleConnection);

            AbrirConexao();

            OracleDataReader reader = comando.ExecuteReader();

            reader.Read();

            string resultado = Convert.ToString(reader);

            return resultado;
        }

        public DataTable ExecutaSQL(String sql)
        {

        }


    }
}

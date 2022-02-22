using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Security;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Gera_SaldoInicial
{
    public partial class TelaInicial : Form
    {
        public TelaInicial()
        {
            InitializeComponent();

            CbExibirSistemas();
        }

        private void btnSelecionarArquivo_Click(object sender, EventArgs e)
        {
            //define as propriedades do controle
           
            OpenFileDialog ofd = new OpenFileDialog();
            ArquivoSaldoInicial arq = new ArquivoSaldoInicial();

            CriarDiretorio(arq.Caminho);

            ofd.Multiselect = true;
            ofd.Title = "Selecionar Arquivo";
            ofd.InitialDirectory = arq.Caminho;

            //Exibir todos tipos de arquivos
            ofd.Filter = "Arquivos All files (*.*)|*.*";
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            ofd.FilterIndex = 2;
            ofd.RestoreDirectory = true;
            ofd.ReadOnlyChecked = true;
            ofd.ShowReadOnly = true;

            DialogResult dr = ofd.ShowDialog();

            if (dr == DialogResult.OK)

            {
                // Le os arquivos selecionados 
                foreach (String arquivo in ofd.FileNames)
                {
                    txtSelecionarArquivo.Enabled = false;
                    txtSelecionarArquivo.Text = arquivo;
                    // Preencher Grid
                    try
                    {
                        TratarArquivo(GerarSaldoFinal());
                    }
                    catch (SecurityException ex)
                    {
                        // O usuário  não possui permissão para ler arquivos
                        MessageBox.Show("Erro ao tentar abrir arquivo.\n\n" +
                                                    "Mensagem : " + ex.Message + "\n\n" + ex.StackTrace);
                    }
                    catch (Exception ex)
                    {
                        //Mensagem para Formato de conta não encotrado
                        MessageBox.Show("Formato de conta não encontrado. Verifique se o relatório possui espaços em banco no inicio da linha ou Informe um formato de conta valido!");
                    }
                }
            }
        }//fim do evento botão Selecionar

        public void CbExibirSistemas()
        {
            comboBox1.Items.Add("SISDIA");
            comboBox1.Items.Add("DEALERNET");
            comboBox1.Items.Add("NBS");
            comboBox1.Items.Add("WELLS");
        }

        public string CriarDiretorio(string caminho)
        {
            bool diretorioCriado = File.Exists(caminho);
            string retornaDiretorio = caminho;
            
            try
            {
                //Cria o diretorio caso nao exista
                if (caminho != string.Empty & diretorioCriado == false)
                {
                    var nomeDiretorio = Directory.CreateDirectory(caminho);
                    retornaDiretorio = nomeDiretorio.ToString();

                }

                return retornaDiretorio;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
           
        }

        public bool GerarSaldoFinal()
        {
            bool saldoFinal = chkSaldoFinal.Checked;
            return saldoFinal;
        }

        public void TratarArquivo(bool saldoFinal)
        {


            ArquivoSaldoInicial a = new ArquivoSaldoInicial();
            string nomeArquivo = txtSelecionarArquivo.Text;// @"C:\Conversao\saldoInicial\conferencia_indaiatuba.txt";
            a.Caminho = nomeArquivo;
            string mascaraConta = string.Empty;

            int inicioConta = 0;
            int tamanhoConta = txtFormatoConta.TextLength;
            int inicioValor = 0;
            int tamanhoValor = 0;
            int inicioDescricao = 0;
            int tamanhoDescricao = 0;
            string formatoConta = txtFormatoConta.Text;
            string cnpj = txtCNPJ.Text;

            //Se for Balancete Sisdia
            if ("SISDIA" == comboBox1.Text)
            {
                //inicioConta = 0;
                //int tamanhoConta = txtFormatoConta.TextLength;
                //inicioValor = 0;
                tamanhoValor = 18;
                inicioDescricao = 17;
                tamanhoDescricao = 38;
                //string formatoConta = txtFormatoConta.Text;


                if (saldoFinal)
                {
                    inicioValor = 129;
                }
                else
                {
                    inicioValor = 58;
                }
            }

            //Se for Balancete Wells
            if ("WELLS" == comboBox1.Text)
            {
                //inicioConta = 0;
                //int tamanhoConta = txtFormatoConta.TextLength;
                //inicioValor = 0;
                tamanhoValor = 44;
                inicioDescricao = 41;
                tamanhoDescricao = 41;
                //string formatoConta = txtFormatoConta.Text;


                if (saldoFinal)
                {
                    inicioValor = 164;
                }
                else
                {
                    inicioValor = 82;
                }
            }
            

            List<ArquivoSaldoInicial> registros = new List<ArquivoSaldoInicial>();
            string linha;
            int contaLinha = 0;

            string nomeEmpresa = string.Empty;
            string cnpjEmpresa = string.Empty;
            // string descricao = "SALDOINICIAL";
            List<String> contas = new List<string>();
            List<String> valores = new List<string>();
            List<String> descricao = new List<string>();

            StreamReader reader = new StreamReader(nomeArquivo);

            string caracterNaoPermitidos = $"[^0-9]";
            string caracteresPermitidos = VerificarFormatoConta(formatoConta);
            string strReplace = string.Empty;

            Regex rgx = new Regex(caracterNaoPermitidos);
            Regex rgxValidaFormato = new Regex(caracteresPermitidos, RegexOptions.None);

            dataGridView.DataSource = null;
            dataGridView.Rows.Clear();
            dataGridView.Refresh();

            while ((linha = reader.ReadLine()) != null)
            {
                dataGridView.ColumnCount = 5;

                dataGridView.Columns[0].Name = "Empresa";
                dataGridView.Columns[1].Name = "Conta";
                dataGridView.Columns[2].Name = "Valor";
                dataGridView.Columns[3].Name = "CNPJ";
                dataGridView.Columns[4].Name = "Descricao";

                
                //Preenchendo lista conta/Valores
                if (!string.IsNullOrEmpty(rgx.Replace(linha, strReplace)) & rgxValidaFormato.IsMatch(linha))
                {
                    contas.Add(linha.Substring(inicioConta,tamanhoConta).Trim());
                    valores.Add(linha.Substring(inicioValor,tamanhoValor).Trim());
                    descricao.Add(linha.Substring(inicioDescricao,tamanhoDescricao).Trim());
                }

                //Pegando Nome da Empresa balancete sisdia
                if (contaLinha == 0 && "SISDIA" == comboBox1.Text)
                {
                    nomeEmpresa = linha.Substring(0, 35).Trim();
                    a.NomeEmpresa = nomeEmpresa;
                }

                //Pegando Nome da Empresa balancete Wells
                if (contaLinha == 5 && "WELLS" == comboBox1.Text)
                {
                    nomeEmpresa = linha.Substring(18, 60).Trim();
                    a.NomeEmpresa = nomeEmpresa;
                }

                //Pegando CNPJ Empresa
                if (string.IsNullOrEmpty(cnpj))
                {
                    if (contaLinha == 3)
                    {
                        cnpjEmpresa = linha.Substring(10, 18).Trim();
                    }
                }
                else
                {
                    cnpjEmpresa = cnpj;
                }
                

                contaLinha++;
                a.PassoLinha = contaLinha;

                //MessageBox.Show($"Numero linha: {a.PassoLinha}. Descricao:{linha}");

            }

            for (int i = 0; i < contas.Count; i++)
            {
                dataGridView.Rows.Add(nomeEmpresa, contas[i],valores[i], cnpjEmpresa, descricao[i]);
            }

        }

        public bool CriarArquivoSaldoInicial()
        {
            var nomeEmpresa = string.Empty;
            string dataSaldoInicial = txtDataSaldoInicial.Text;

            //Pegando nome da empresa
            for (int i = 0; i < (dataGridView.Rows.Count - dataGridView.Rows.Count + 1); i++)
            {
                var dataGridViewsRows = dataGridView.Rows[i] as DataGridViewRow;
                var celula = dataGridViewsRows.Cells[0];
                nomeEmpresa = celula.Value.ToString();
            }

            string nomeArquivo = $"C:\\Conversao\\saldoInicial\\saldoInicial_{nomeEmpresa}.txt";
            System.IO.Path.GetDirectoryName(nomeArquivo);

            bool arquivoCriado = false;

            if (nomeArquivo != string.Empty)
            {
                var arquivo = File.Create(nomeArquivo);
                arquivoCriado = File.Exists(nomeArquivo);

                arquivo.Close();

                if (arquivoCriado == true)
                {
                    MontarArquivo(nomeEmpresa, dataSaldoInicial);
                    MessageBox.Show("Arquivo Criado com sucesso! Diretorio C:conversao/saldoInicial");
                }
                
                arquivo.Close();
            }
            if (arquivoCriado == false)
            {
                return false;
            }
            
            return true;
            
        }

        private void MontarArquivo(string nomeempresa, string dataFixa)
        {
            string caminho = @"C:\\Conversao\\saldoInicial\\";
            
            string caracterPermitidos = $"[^0-9]";
            string descricaoFixa = ";0;SALDOINICIAL;1;0;0;0;";

            string strReplace = string.Empty;


            using (var writer = new StreamWriter(Path.Combine(caminho, $"saldoInicial_{nomeempresa}.txt"), true))
            {
                for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
                {
                    string celulaValor = dataGridView[2,i].Value.ToString();
                    string celulaConta = dataGridView[1,i].Value.ToString();
                    string celulaCNPJ = dataGridView[3,i].Value.ToString();
                    string DadosFixo = ";0;SALDOINICIAL;1;0;0;0;";
                    string lancamentoPositivo = $"1;{Regex.Replace(celulaCNPJ, caracterPermitidos, strReplace)};{dataFixa};0;{Regex.Replace(celulaConta,caracterPermitidos, strReplace)};0;0;0;{Regex.Replace(celulaValor, caracterPermitidos,strReplace)}{DadosFixo}";
                    string lancamentoNegativo = $"1;{Regex.Replace(celulaCNPJ, caracterPermitidos, strReplace)};{dataFixa};0;0;0;{Regex.Replace(celulaConta, caracterPermitidos, strReplace)};0;{Regex.Replace(celulaValor, caracterPermitidos, strReplace)}{DadosFixo}";

                    if (!celulaValor.Contains("-"))
                    {
                        writer.WriteLine(lancamentoPositivo);
                    }
                    else
                    {
                        writer.WriteLine(lancamentoNegativo);
                    }
                }
                writer.Close();
            }

        }

        private string VerificarFormatoConta(string formatoConta)
        {
            string tipoConta = string.Empty;

            switch (formatoConta)
            {
                //Formato de conta 1
                case "1.":
                    tipoConta = $"^[0-9]. ";
                    break;

                case "1":
                    tipoConta = $"^[0-9]. ";
                    break;

                //Formato de conta 1.1  
                case "1.1.":
                    tipoConta = $"^([0-9].[0-9]. )";
                    break;

                case "1.1":
                    tipoConta = $"^([0-9].[0-9]. )";
                    break;

                //Formato de conta 1.1.1
                case "1.1.1.":
                    tipoConta = $"^([0-9].[0-9].[0-9]. )";
                    break;

                case "1.1.1":
                    tipoConta = $"^([0-9].[0-9].[0-9]. )";
                    break;

                //Formato de Conta 1.1.1.01    
                case "1.1.1.01.":
                    tipoConta = $"^[0-9].[0-9].[0-9].[0-9][0-9]. ";
                    break;

                case "1.1.1.01":
                    tipoConta = $"^[0-9].[0-9].[0-9].[0-9][0-9]. ";
                    break;

                //Formato conta 1.1.1.01.01    
                case "1.1.1.01.01.":
                    tipoConta = $"^[0-9].[0-9].[0-9].[0-9][0-9].[0-9][0-9]. ";
                    break;

                case "1.1.1.01.01":
                    tipoConta = $"^[0-9].[0-9].[0-9].[0-9][0-9].[0-9][0-9]. ";
                    break;

                //Formato conta 1.1.1.01.01.001
                case "1.1.1.01.01.001":
                    tipoConta = $"^[0-9].[0-9].[0-9].[0-9][0-9].[0-9][0-9].[0-9][0-9][0-9] ";
                    break;

                //Formato conta 1.1.1.01.01.0001    
                case "1.1.1.01.01.0001":
                    tipoConta = $"^[0-9].[0-9].[0-9].[0-9][0-9].[0-9][0-9].[0-9][0-9][0-9][0-9] ";
                    break;

                //Formato conta 1.1.1.01.01.00001    
                case "1.1.1.01.01.00001":
                    tipoConta = $"^[0-9].[0-9].[0-9].[0-9][0-9].[0-9][0-9].[0-9][0-9][0-9][0-9][0-9] ";
                    break;

                //Formato conta 1.1.1.1    
                case "1.1.1.1":
                    tipoConta = $"^([0-9].[0-9].[0-9].[0-9]. )";
                    break;

                case "1.1.1.1.":
                    tipoConta = $"^([0-9].[0-9].[0-9].[0-9]. )";
                    break;

                //Formato conta 1.1.1.1.01
                case "1.1.1.1.01":
                    tipoConta = $"^([0-9].[0-9].[0-9].[0-9].[0-9][0-9] )";
                    break;

                case "1.1.1.1.01.":
                    tipoConta = $"^([0-9].[0-9].[0-9].[0-9].[0-9][0-9]. )";
                    break;

                //Formato conta 1.1.1.1.01.01
                case "1.1.1.1.01.01":
                    tipoConta = $"^[0-9].[0-9].[0-9].[0-9].[0-9][0-9].[0-9][0-9] ";
                    break;

                case "1.1.1.1.01.01.":
                    tipoConta = $"^[0-9].[0-9].[0-9].[0-9].[0-9][0-9].[0-9][0-9] ";
                    break;

                //Formato conta 1.1.1.1.01.01.001
                case "1.1.1.1.01.01.001":
                    tipoConta = $"^[0-9].[0-9].[0-9].[0-9].[0-9][0-9].[0-9][0-9].[0-9][0-9][0-9] ";
                    break;

                case "1.1.1.1.01.01.001.":
                    tipoConta = $"^[0-9].[0-9].[0-9].[0-9].[0-9][0-9].[0-9][0-9].[0-9][0-9][0-9] ";
                    break;

                //Formato conta 1.1.1.1.01.01.0001
                case "1.1.1.1.01.01.0001":
                    tipoConta = $"^[0-9].[0-9].[0-9].[0-9].[0-9][0-9].[0-9][0-9].[0-9][0-9][0-9][0-9] ";
                    break;

                case "1.1.1.1.01.01.0001.":
                    tipoConta = $"^[0-9].[0-9].[0-9].[0-9].[0-9][0-9].[0-9][0-9].[0-9][0-9][0-9][0-9] ";
                    break;

                //Formato conta 1.1.1.01.01.01
                case "1.1.1.01.01.01":
                    tipoConta = $"^[0-9].[0-9].[0-9].[0-9][0-9].[0-9][0-9].[0-9][0-9] ";
                    break;

                case "1.1.1.01.01.01.":
                    tipoConta = $"^[0-9].[0-9].[0-9].[0-9][0-9].[0-9][0-9].[0-9][0-9] ";
                    break;

                //Formato conta 1.1.1.01.01.01.001
                case "1.1.1.01.01.01.001":
                    tipoConta = $"^[0-9].[0-9].[0-9].[0-9][0-9].[0-9][0-9].[0-9][0-9].[0-9][0-9][0-9] ";
                    break;

                case "1.1.1.01.01.01.001.":
                    tipoConta = $"^[0-9].[0-9].[0-9].[0-9][0-9].[0-9][0-9].[0-9][0-9].[0-9][0-9][0-9] ";
                    break;

                //Formato conta 1.1.1.01.01.01.0001  
                case "1.1.1.01.01.01.0001":
                    tipoConta = $"^[0-9].[0-9].[0-9].[0-9][0-9].[0-9][0-9].[0-9][0-9].[0-9][0-9][0-9][0-9] ";
                    break;
            }

            if (!string.IsNullOrEmpty(tipoConta))
            {
                return tipoConta;

            }
            else
            {
                return tipoConta;
            }
        }

        private void btnGerarArquivo_Click(object sender, EventArgs e)
        {
            ArquivoSaldoInicial arquivo = new ArquivoSaldoInicial();

            CriarArquivoSaldoInicial();
        }

    }
}

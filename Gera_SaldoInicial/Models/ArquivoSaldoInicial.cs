using System;
using System.Collections.Generic;
using System.Text;

namespace Gera_SaldoInicial
{
    public class ArquivoSaldoInicial
    {
        public ArquivoSaldoInicial(){}
        public string Conta { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public string Caminho { get; set; }
        public string NomeEmpresa { get; set; }

        //Teste
        public int PassoLinha { get; set; }


        public ArquivoSaldoInicial(string conta, string descricao, decimal valor, string caminho)
        {
            this.Conta = conta;
            this.Descricao = descricao;
            this.Valor = valor;
            this.Caminho = caminho;
        }
    }
}

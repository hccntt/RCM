﻿using RCM.Domain.Models.FornecedorModels;
using RCM.Domain.Models.NotaFiscalModels;
using System;

namespace RCM.Domain.Models.DuplicataModels
{
    public class Duplicata 
    {
        public int Id { get; private set; }
        public string NumeroDocumento { get; private set; }
        public string Observacao { get; private set; }
        public int NotaFiscalId { get; private set; }
        public virtual NotaFiscal NotaFiscal { get; private set; }
        public DateTime DataEmissao { get; private set; }
        public DateTime DataVencimento { get; private set; }
        public int FornecedorId { get; private set; }
        public virtual Fornecedor Fornecedor { get; private set; }
        public decimal Valor { get; private set; }

        public bool Pago { get; private set; }
        public decimal? ValorPago { get; private set; }
        public DateTime? DataPagamento { get; private set; }

        private Duplicata() { }

        public Duplicata(string numeroDocumento, DateTime dataEmissao, DateTime dataVencimento, Fornecedor fornecedor, decimal valor)
        {
            NumeroDocumento = numeroDocumento;
            DataEmissao = dataEmissao;
            DataVencimento = dataVencimento;
            Fornecedor = fornecedor;
            Valor = valor;
        }

        public void Pagar(DateTime dataPagamento, decimal valorPago)
        {
            if (Pago)
                return;

            DataPagamento = dataPagamento;
            ValorPago = valorPago;
            Pago = true;
        }
    }
}
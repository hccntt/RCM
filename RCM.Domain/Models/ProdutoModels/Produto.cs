﻿using RCM.Domain.Models.FornecedorModels;
using System.Collections.Generic;

namespace RCM.Domain.Models.ProdutoModels
{
    public class Produto
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Aplicacao { get; private set; }
        public int Quantidade { get; private set; }
        public decimal PrecoVenda { get; private set; }

        private List<Fornecedor> _fornecedores;
        public virtual IReadOnlyList<Fornecedor> Fornecedores
        {
            get
            {
                return _fornecedores;
            }
        }

        private Produto() { }

        public Produto(string nome, string aplicacao, int quantidade, decimal precoVenda)
        {
            Nome = nome;
            Aplicacao = aplicacao;
            Quantidade = quantidade;
            PrecoVenda = precoVenda;

            _fornecedores = new List<Fornecedor>();
        }
    }
}

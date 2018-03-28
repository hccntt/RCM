﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RCM.Application.ViewModels
{
    public class ClienteViewModel
    {
        [Display(Name = "Id")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo Id é requerido.")]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo nome é requerido.")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "O campo nome deve ter entre 10 e 100 caracteres.")]
        public string Nome { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "Contatos")]
        public List<ContatoViewModel> Contatos { get; set; }

        [Display(Name = "Endereços")]
        public List<EnderecoViewModel> Enderecos { get; set; }

        [Display(Name = "Cheques")]
        public List<ChequeViewModel> Cheques { get; set; }
    }
}
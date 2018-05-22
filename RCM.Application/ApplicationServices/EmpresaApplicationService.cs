﻿using AutoMapper;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels;
using RCM.Domain.Commands.EmpresaCommands;
using RCM.Domain.Core.Commands;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.Repositories;
using System.Threading.Tasks;

namespace RCM.Application.ApplicationServices
{
    public class EmpresaApplicationService : IEmpresaApplicationService
    {
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;

        public EmpresaApplicationService(IEmpresaRepository empresaRepository, IMapper mapper, IMediatorHandler mediator)
        {
            _empresaRepository = empresaRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public EmpresaViewModel Get()
        {
            var model = _empresaRepository.Get();
            return _mapper.Map<EmpresaViewModel>(model);
        }

        public Task<CommandResult> AddOrUpdate(EmpresaViewModel viewModel)
        {
            var command = new AddOrUpdateEmpresaCommand(viewModel.Id, viewModel.RazaoSocial, viewModel.NomeFantasia, viewModel.Descricao);
            command.AttachContato(viewModel.Contato.Celular, viewModel.Contato.Email, viewModel.Contato.TelefoneComercial, viewModel.Contato.TelefoneResidencial, viewModel.Contato.Observacao);
            command.AttachEndereco(viewModel.Endereco.Numero, viewModel.Endereco.Rua, viewModel.Endereco.Bairro, viewModel.Endereco.Complemento, viewModel.Endereco.CidadeId, viewModel.Endereco.CEP);
            command.AttachDocumento(viewModel.Documento.CadastroNacional, viewModel.Documento.CadastroEstadual);

            return _mediator.SendCommand(command);
        }

        public Task<CommandResult> AttachLogo(byte[] logo)
        {
            return _mediator.SendCommand(new AttachEmpresaLogoCommand(logo));
        }
    }
}

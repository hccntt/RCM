﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels;
using RCM.Domain.DomainNotificationHandlers;
using RCM.Domain.Models.CidadeModels;
using RCM.Presentation.Web.Controllers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RCM.Presentation.Web.Areas.Platform.Controllers
{
    [Authorize]
    [Area("Platform")]
    public class CidadesController : BaseController
    {
        private readonly ICidadeApplicationService _cidadeApplicationService;
        private readonly IEstadoApplicationService _estadoApplicationService;

        public CidadesController(ICidadeApplicationService cidadeApplicationService, IEstadoApplicationService estadoApplicationService, IDomainNotificationHandler domainNotificationHandler) : base(domainNotificationHandler)
        {
            _cidadeApplicationService = cidadeApplicationService;
            _estadoApplicationService = estadoApplicationService;
        }

        public IActionResult Index(string nome = null)
        {
            var nomeSpecification = new CidadeNomeSpecification(nome);

            var list = _cidadeApplicationService.Get(
                nomeSpecification
                .ToExpression());

            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CidadeViewModel cidade)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return View(cidade);
            }

            var commandResult = await _cidadeApplicationService.Add(cidade);

            if (commandResult.Success)
            {
                NotifyCommandResultSuccess();
                return RedirectToAction(nameof(Index));
            }
            else
                NotifyCommandResultErrors(commandResult.Errors);

            return View(cidade);
        }

        public async Task<IActionResult> Remove(Guid id)
        {
            var commandResult = await _cidadeApplicationService.Remove(id);

            if (commandResult.Success)
            {
                NotifyCommandResultSuccess();
                return RedirectToAction(nameof(Index));
            }
            else
                NotifyCommandResultErrors(commandResult.Errors);

            return RedirectToAction(nameof(Index));
        }

        public JsonResult GetEstados()
        {
            return Json(_estadoApplicationService.Get()
                .OrderBy(e => e.Nome));
        }
    }
}
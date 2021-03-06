﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FS.DDDTop.Web.Models;
using FS.DDDTop.Domain.Interfaces;
using AutoMapper;
using FS.DDDTop.Domain.Entities;
using StackExchange.Profiling;

namespace FS.DDDTop.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper _mapper;
        private readonly IClienteRepository _clienteRepository;

        public HomeController(ILogger<HomeController> logger, IMapper mapper, IClienteRepository clienteRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _clienteRepository = clienteRepository;
        }

        public IActionResult Index()
        {
            Cliente cliente, cliente2;
            ClienteViewModel clienteViewModel;

            using (MiniProfiler.Current.Step("DB"))
            {
                //Por algum motivo, a conexão está sendo fechada após a primeira chamada no repository e aberta novamente na segunda chamada
                cliente = _clienteRepository.GetByIdComEagerLoading(1);
                cliente2 = _clienteRepository.GetById(2);

                //Criei um contexto sem usar injeção de dependência para ver se a conexão também fecha e abre,
                //e mesmo usando o mesmo contexto (using) o comportamento se repete.
                //TODO: Investigar melhor isso
                //var optionsBuilder = new DbContextOptionsBuilder<EFContext>();
                //var connection = @"Server=(localdb)\mssqllocaldb;Database=DDDTop;Trusted_Connection=True;";
                //optionsBuilder.UseSqlServer(connection);
                //var context = new EFContext(optionsBuilder.Options);
                //using (context)
                //{
                //    var rep = new ClienteRepository(context);
                //    cliente = rep.GetById(1);
                //    cliente2 = rep.GetById(2);
                //}
            }

            using (MiniProfiler.Current.Step("Mapper"))
            {
                clienteViewModel = _mapper.Map<Cliente, ClienteViewModel>(cliente);
            }

            return View(clienteViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

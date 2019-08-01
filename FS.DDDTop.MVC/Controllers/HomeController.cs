using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FS.DDDTop.MVC.Models;
using AutoMapper;
using FS.DDDTop.Infra.Data.Repositories;
using FS.DDDTop.Domain.Interfaces;
using FS.DDDTop.Domain.Entities;
using FS.DDDTop.MVC.ViewModels;

namespace FS.DDDTop.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IClienteRepository _clienteRepository;

        public HomeController(IMapper mapper, IClienteRepository clienteRepository)
        { 
            _mapper = mapper;
            _clienteRepository = clienteRepository;
        }

        public IActionResult Index()
        {
            var clienteViewModel = _mapper.Map<Cliente, ClienteViewModel>(_clienteRepository.GetById(1));

            ViewData["cliente"] = clienteViewModel;

            return View();
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

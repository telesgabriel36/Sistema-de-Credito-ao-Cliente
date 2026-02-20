using System.ComponentModel;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Projeto_Credito_Cliente.Models;
using Projeto_Credito_Cliente.Services.Interfaces;

namespace Projeto_Credito_Cliente.Controllers;

public class ClienteController : Controller
{
    private readonly ILogger<ClienteController> _logger;

    private readonly IServiceCliente _serviceCli;
    public ClienteController(ILogger<ClienteController> logger, IServiceCliente serviceCli)
    {
        _logger = logger;

        _serviceCli = serviceCli;
    }

    public async Task<IActionResult> Index()
    {
        var clientes = await _serviceCli.GetAllEntityes();

        return View(clientes);
    }


    [HttpGet]
    public IActionResult Create()
    {

        return View();
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Cliente cliente)
    {

        if (!ModelState.IsValid)
        {
            return View(cliente);
        }

        var clienteCadastrado = await _serviceCli.RegisterEntity(cliente);

        if (clienteCadastrado == null)
        {
            return View(cliente);
        }


        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var clienteDetalhado = await _serviceCli.GetEntityById(id);

        if (clienteDetalhado == null)
        {
            return RedirectToAction("Index");
        }

        return View(clienteDetalhado);
    }


    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var clienteExiste = await _serviceCli.GetEntityById(id);

        if (clienteExiste == null)
        {
            return RedirectToAction("Index");
        }

        return View(clienteExiste);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Cliente cliente)
    {
        if (!ModelState.IsValid)
        {
            return View(cliente);
        }

        var atualizado = await _serviceCli.UpdateEntity(cliente);

        if (!atualizado)
        {
            //Aqui farei um tratamento de mensagem de erro para exibir através de um tempdata
        }

        return RedirectToAction("Index");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {

        var deletado = await _serviceCli.RemoveEntity(id);

        if (!deletado)
        {
            //Tratamento de mensagem de erro com tempData...
        }

        return RedirectToAction("Index");

    }



}

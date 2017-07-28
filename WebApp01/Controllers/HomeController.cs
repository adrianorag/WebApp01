using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp01.Models;
using WebApp01.Services;
using WebApp01.ViewModels;

namespace WebApp01.Controllers
{
    public class HomeController : Controller
    {

        private readonly IUsuarioService usuarioService;
        
        public HomeController(IUsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }


        public ActionResult Index()
        {
            var ListUsuario = usuarioService.GetAllUsuarios();
            return View(ListUsuario);
        }

        [HttpGet]
        public ActionResult Cadastro()
        {
            var Usuario = new UsuarioViewModel();
            return View(Usuario);
        }

        [HttpPost]
        public ActionResult Cadastro(UsuarioViewModel usuarioViewModel)
        {
            if (!ModelState.IsValid) {
                usuarioViewModel.Mensagem = "Existe um erro de validação da model";
            }
            else
            {
                usuarioService.SaveUsuario(usuarioViewModel.Usuario);
                usuarioViewModel.Mensagem = "Cadastrado com sucesso!!";
            }
            
            return View(usuarioViewModel);
        }


        [HttpGet]
        public ActionResult EditarCadastro(int id)
        {
            var UsuarioModel = new UsuarioViewModel();
            UsuarioModel.Usuario = usuarioService.GetUSUSU(id);
            return View(UsuarioModel);
        }

        [HttpPost]
        public ActionResult EditarCadastro(UsuarioViewModel usuarioViewModel)
        {
            if (!ModelState.IsValid)
            {
                usuarioViewModel.Mensagem = "Existe um erro de validação da model";
            }
            else
            {
                usuarioService.SaveUsuario(usuarioViewModel.Usuario);
                usuarioViewModel.Mensagem = "Cadastrado com sucesso!!";
            }

            return View(usuarioViewModel);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
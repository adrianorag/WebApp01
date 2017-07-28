using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApp01.Models;

namespace WebApp01.Services
{
    public class UsuarioService : IUsuarioService
    {

        public List<Usuario> GetAllUsuarios()
        {
            var ListUsuario = new List<Usuario>();

            using (var db = new WebAppBDContext())
            {
                ListUsuario = db.Usuario.ToList();
            }

            return ListUsuario;
        }

        public Usuario GetUsuario(int ID)
        {
            var usuario = new Usuario();

            using (var db = new WebAppBDContext())
            {
                usuario = db.Usuario.Where(p => p.Id== ID).ToList().FirstOrDefault();
            }

            return usuario;
        }

        public int SaveUsuario(Usuario usuario)
        {
            var rt = 0;
            using (var db = new WebAppBDContext())
            {
                if(usuario.Id != 0)
                {
                    db.Usuario.Attach(usuario);
                    var entry = db.Entry(usuario);
                    entry.State = EntityState.Modified;
                }
                else
                {
                    db.Usuario.Add(usuario);
                }
                
                rt= db.SaveChanges();
            }

            return rt;
        }


        public Usuario GetUsuarioDapper(int ID)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["WebAppBDContext"].ConnectionString))
            {
                return db.Query<Usuario>("Select * from Usuarios Where Id = @ID", new { ID }).SingleOrDefault();
            }

        }



    }
}
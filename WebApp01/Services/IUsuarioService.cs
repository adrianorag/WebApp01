using System.Collections.Generic;
using WebApp01.Models;

namespace WebApp01.Services
{
    public interface IUsuarioService
    {

        List<Usuario> GetAllUsuarios();
        int SaveUsuario(Usuario usuario);
        Usuario GetUsuario(int ID);
        Usuario GetUSUSU(int ID);
    }
}

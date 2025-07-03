using System.Collections.Generic;
using System.Linq;

namespace WinFormsApp100
{
    public class AutenticacionService
    {
        private List<Usuario> usuariosRegistrados;

        public AutenticacionService()
        {
            // Lista de usuarios simulada (puedes conectar luego a una BD)
            usuariosRegistrados = new List<Usuario>
            {
                new Usuario("admin", "1234"),
                new Usuario("usuario1", "clave1")
            };
        }

        public bool ValidarCredenciales(string nombreUsuario, string contraseña)
        {
            return usuariosRegistrados.Any(u =>
                u.NombreUsuario == nombreUsuario &&
                u.Contraseña == contraseña);
        }
    }
}

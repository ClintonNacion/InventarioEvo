using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WinFormsApp100
{
    public class AutenticacionService
    {
        private readonly string rutaArchivo;
        private Dictionary<string, string> usuariosRegistrados;

        public AutenticacionService()
        {
            // Guardar el archivo en la misma carpeta que el ejecutable
            rutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "usuarios.txt");

            InicializarArchivoUsuarios();
            CargarUsuarios();
        }

        /// <summary>
        /// Crea el archivo usuarios.txt si no existe con un usuario por defecto.
        /// </summary>
        private void InicializarArchivoUsuarios()
        {
            if (!File.Exists(rutaArchivo))
            {
                File.WriteAllText(rutaArchivo, "admin:1234" + Environment.NewLine);
            }
        }

        /// <summary>
        /// Carga usuarios desde usuarios.txt al diccionario.
        /// </summary>
        private void CargarUsuarios()
        {
            usuariosRegistrados = new Dictionary<string, string>();

            foreach (var linea in File.ReadAllLines(rutaArchivo))
            {
                var partes = linea.Split(':');
                if (partes.Length == 2)
                {
                    string usuario = partes[0].Trim();
                    string contraseña = partes[1].Trim();
                    usuariosRegistrados[usuario] = contraseña;
                }
            }
        }

        /// <summary>
        /// Verifica si las credenciales son correctas.
        /// </summary>
        public bool ValidarCredenciales(string usuario, string contraseña)
        {
            return usuariosRegistrados.TryGetValue(usuario, out string pass)
                && pass == contraseña;
        }

        /// <summary>
        /// Agrega un nuevo usuario al archivo y al diccionario.
        /// </summary>
        public bool AgregarUsuario(string usuario, string contraseña)
        {
            if (usuariosRegistrados.ContainsKey(usuario))
                return false;

            usuariosRegistrados[usuario] = contraseña;
            File.AppendAllText(rutaArchivo, $"{usuario}:{contraseña}{Environment.NewLine}");
            return true;
        }

        /// <summary>
        /// Devuelve una lista de los nombres de usuario.
        /// </summary>
        public List<string> ObtenerUsuarios()
        {
            return usuariosRegistrados.Keys.ToList();
        }
    }
}


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp100
{
    public class AutenticacionService
    {
        private readonly string rutaArchivo;
        private Dictionary<string, string> usuariosRegistrados;

        private Dictionary<string, int> intentosFallidos = new();
        private Dictionary<string, DateTime> usuariosBloqueados = new();
        private readonly int MAX_INTENTOS = 3;
        private readonly TimeSpan DURACION_BLOQUEO = TimeSpan.FromMinutes(1);

        public AutenticacionService()
        {
            rutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "usuarios.txt");
            InicializarArchivoUsuarios();
            CargarUsuarios();
        }

        private void InicializarArchivoUsuarios()
        {
            if (!File.Exists(rutaArchivo))
            {
                File.WriteAllText(rutaArchivo, "admin:1234" + Environment.NewLine);
            }
        }

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

        public bool ValidarCredenciales(string usuario, string contraseña)
        {
            if (usuariosBloqueados.ContainsKey(usuario))
            {
                if (DateTime.Now < usuariosBloqueados[usuario])
                {
                    return false;
                }
                else
                {
                    usuariosBloqueados.Remove(usuario);
                    intentosFallidos[usuario] = 0;
                }
            }

            bool valido = usuariosRegistrados.TryGetValue(usuario, out string pass)
                && pass == contraseña;

            if (valido)
            {
                intentosFallidos[usuario] = 0;
                return true;
            }
            else
            {
                if (!intentosFallidos.ContainsKey(usuario))
                    intentosFallidos[usuario] = 0;

                intentosFallidos[usuario]++;

                if (intentosFallidos[usuario] >= MAX_INTENTOS)
                {
                    usuariosBloqueados[usuario] = DateTime.Now + DURACION_BLOQUEO;
                    MessageBox.Show("Se han realizado 3 intentos fallidos. Usuario bloqueado por 1 minuto.",
                                    "Bloqueado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                return false;
            }
        }

        public bool EstaBloqueado(string usuario)
        {
            return usuariosBloqueados.ContainsKey(usuario) && DateTime.Now < usuariosBloqueados[usuario];
        }

        public bool AgregarUsuario(string usuario, string contraseña)
        {
            if (usuariosRegistrados.ContainsKey(usuario))
                return false;

            usuariosRegistrados[usuario] = contraseña;
            File.AppendAllText(rutaArchivo, $"{usuario}:{contraseña}{Environment.NewLine}");
            return true;
        }

        public List<string> ObtenerUsuarios()
        {
            return usuariosRegistrados.Keys.ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.IO;

namespace CapaNegocio
{
    public class CN_Recursos
    {

        public static string GenerarClave()
        {
            string clave =Guid.NewGuid().ToString("N").Substring(0,5);
            return clave;
        }


        public static string ConvertirSha256(string texto)
        {
            StringBuilder Sb = new StringBuilder();
            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(texto));

                foreach (byte b in result)
                {
                    Sb.Append(b.ToString("x2"));
                }

                return Sb.ToString();
            }
        }

        public static bool EnviarCorreo(string correo, string asunto, string mensaje)
        {
            bool resultado = false;
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.To.Add(correo);
                    mail.From = new MailAddress("javicatalina7@gmail.com");
                    mail.Subject = asunto;
                    mail.Body = mensaje;
                    mail.IsBodyHtml = true;

                    using (var smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential("javicatalina7@gmail.com", "wdqpfqwnrafiduok");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                        resultado = true;
                    }
                }
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Error al enviar correo: {ex.Message}");
                resultado = false;
            }

            return resultado;
        }



    }

}

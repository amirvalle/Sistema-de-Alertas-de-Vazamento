using System;
using System.Net;
using System.Net.Mail;

namespace GasLeakAlert
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== SIMULADOR DE DETECÇÃO DE VAZAMENTOS ===");

           
            int limiteSeguro = 300; 
            int intervaloLeitura = 5000; 

            while (true)
            {
                int gasLevel = LerSensor();
                Console.WriteLine($"[{DateTime.Now}] Nível de gás: {gasLevel} ppm");

                if (gasLevel > limiteSeguro)
                {
                    EnviarAlerta(gasLevel);
                }

                System.Threading.Thread.Sleep(intervaloLeitura);
            }
        }

        static int LerSensor()
        {
           
            Random rand = new Random();
            return rand.Next(0, 1000);
        }

        static void EnviarAlerta(int nivelGas)
        {
            try
            {
                using (var smtp = new SmtpClient("smtp.gmail.com"))
                using (var email = new MailMessage())
                {
                    email.From = new MailAddress("seuemail@gmail.com");
                    email.To.Add("alerta@empresa.com");
                    email.Subject = "ALERTA: Vazamento de Gás Detectado!";
                    email.Body = $"Nível crítico: {nivelGas} ppm\nData: {DateTime.Now}";

                    smtp.Port = 587;
                    smtp.Credentials = new NetworkCredential("seuemail@gmail.com", "apppassword");
                    smtp.EnableSsl = true;

                    smtp.Send(email);
                    Console.WriteLine("ALERTA: E-mail enviado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERRO ao enviar alerta: {ex.Message}");
            }
        }
    }
}
# GasLeakAlert - Sistema de Detecção de Vazamentos de Gás

Um simulador em C# que monitora níveis de gás e envia alertas por email quando detecta vazamentos perigosos.

## Funcionalidades

- 📊 Leitura simulada de sensores de gás (valores aleatórios entre 0-1000 ppm)
- 🚨 Detecção de níveis perigosos (acima de 300 ppm)
- ✉️ Envio automático de alertas por email
- ⏱️ Verificação periódica a cada 5 segundos

## Estrutura do Código Principal

```csharp
using System;
using System.Net;
using System.Net.Mail;

namespace GasLeakAlert
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configurações do sistema
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



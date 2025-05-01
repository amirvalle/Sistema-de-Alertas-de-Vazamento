# GasLeakAlert - Sistema de Detecção de Vazamentos de Gás

## 📌 Visão Geral  
Um programa em C# que simula o monitoramento contínuo de vazamento de gás, enviando alertas por e-mail quando os níveis excedem o limite seguro.  
---
## Funcionalidades

- 📊 Leitura simulada de sensores de gás (valores aleatórios entre 0-1000 ppm)
- 🚨 Detecção de níveis perigosos (acima de 300 ppm)
- ✉️ Envio automático de alertas por email
- ⏱️ Verificação periódica a cada 5 segundos

## Estrutura do Código Principal

csharp
```
using System;
using System.Net;
using System.Net.Mail;

namespace GasLeakAlert
{
    class Program
    {
        static void Main(string[] args)
        {

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
```
## ⚙️ Como Funciona  
O programa opera em um loop infinito, realizando as seguintes ações a cada **5 segundos**:  

1. **Simula a leitura do sensor** (`LerSensor()`).  
2. **Exibe o valor no console** (em ppm - partes por milhão).  
3. **Se o nível > 300 ppm**, dispara um e-mail de alerta (`EnviarAlerta()`).  

🔧 Configuração
Para usar o sistema de alerta por e-mail, substitua no código:

Campo no Código	Descrição
"seuemail@gmail.com"	Seu e-mail do Gmail (remetente).
"apppassword"	Senha de aplicativo (se usar 2FA).
"alerta@empresa.com"	E-mail do destinatário do alerta.

📋 Pré-requisitos
.NET Framework ou .NET Core instalado (Versão 8.0)

Conta Gmail configurada para envios

Conexão com internet

🚀 Melhorias Futuras
Interface gráfica

Integração com sensores reais

Sistema de logs em arquivo

Múltiplos níveis de alerta

Desligamento seguro automático

▶️ Executando o Projeto
```
dotnet run
```
Nota: Projeto educacional. Um sistema real requer hardware específico e mais camadas de segurança.
📄 Exemplo de Saída

```
[01/04/2024 10:15:22] Nível de gás: 210 ppm
[01/04/2024 10:15:27] Nível de gás: 350 ppm [ALERTA! E-mail enviado]
```

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;


namespace ExemploSendGrid
{
    internal class Exemplo
    {
        private static void Main()
        {
            Execute().Wait();
        }

        public static async Task Execute()
        {
            //chave
            var apiKey = Environment.GetEnvironmentVariable("SENDGRID_APIKEY");
            //cliente
            var client = new SendGridClient(apiKey);
            
            //mensagem
            var msg = new SendGridMessage()
            {
                //remetente
                From = new EmailAddress("test@example.com", "DX Team"),
                Subject = "Hello World from the SendGrid CSharp SDK!",
                PlainTextContent = "Hello, Email!",
                HtmlContent = "<strong>Hello, Email!</strong>"
            };
            //add destinatario
            msg.AddTo(new EmailAddress("test@example.com", "Test User"));
            var response = await client.SendEmailAsync(msg);
        }
    }
}

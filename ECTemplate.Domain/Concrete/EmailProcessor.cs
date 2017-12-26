using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using ECTemplate.Domain.Abstract;
using ECTemplate.Domain.Entities;

namespace ECTemplate.Domain.Concrete
{
    public class EmailSettings
    {
        public string MailToAddress { get; set; }
        public string MailFromAddress { get; set; }
        public bool WriteAsFile = false;
        public string FileLocation = @"c:\sports_store_emails";
    }

    public class EmailProcessor
    {
        private EmailSettings emailSettings;

        public EmailProcessor(EmailSettings settings)
        {
            emailSettings = settings;
        }

        public void ProcessOrder(Cart cart, Addresses shippingInfo)
        {
                StringBuilder body = new StringBuilder()
                    .AppendLine("A new order has been submitted")
                    .AppendLine("---")
                    .AppendLine("Items:");

                foreach (var line in cart.Lines)
                {
                    var subtotal = line.Product.Price * line.Quantity;
                    body.AppendFormat("{0} x {1} (subtotal: {2:c})", line.Quantity,
                    line.Product.Name,
                    subtotal);
                    body.AppendLine();
                }

                body.AppendFormat("Total order value: {0:c}", cart.ComputeTotalValue())
                .AppendLine()
                .AppendLine("---")
                .AppendLine("Ship to:")
                .AppendLine(shippingInfo.ShippingFirstName + ", " + shippingInfo.ShippingLastName)
                .AppendLine(shippingInfo.ShippingAddress)
                .AppendLine(shippingInfo.ShippingAddress2 ?? "")
                .AppendLine(shippingInfo.ShippingCity)
                .AppendLine(shippingInfo.ShippingState ?? "")
                .AppendLine(shippingInfo.ShippingCountry)
                .AppendLine(shippingInfo.ShippingZip)
                .AppendLine("---");

            SendMail("New order submitted!", body);
        }

        public void OrderShipped()
        {
            StringBuilder body = new StringBuilder()
                .AppendLine("You should receive your order in 5 - 7 business days.");

            SendMail("Your Order is Shipped!", body);
        }

        public void Contact(string fromUserEmail, string fromUserName)
        {

        }

        public void SendMail(string subject, StringBuilder body)
        {
            using (var smtpClient = new SmtpClient())
            {
                if (emailSettings.WriteAsFile)
                {
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.EnableSsl = false;
                }

                MailMessage mailMessage = new MailMessage();
                mailMessage.To.Add(new MailAddress(emailSettings.MailToAddress));
                mailMessage.Subject = subject;
                mailMessage.Body = body.ToString();

                if (!string.IsNullOrEmpty(emailSettings.MailFromAddress))
                    mailMessage.From = new MailAddress(emailSettings.MailFromAddress);

                if (emailSettings.WriteAsFile)
                {
                    mailMessage.BodyEncoding = Encoding.ASCII;
                }
                smtpClient.Send(mailMessage);
            }
            
        }
    }
}

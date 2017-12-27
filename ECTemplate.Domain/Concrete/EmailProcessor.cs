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
        /// <summary>
        /// A default constructor that uses to initialize the properties.
        /// </summary>
        public EmailSettings() { }

        /// <summary>
        /// Gets or sets the recipient
        /// </summary>
        public string MailToAddress { get; set; }

        /// <summary>
        /// Gets or sets the sender.
        /// </summary>
        public string MailFromAddress { get; set; }

        /// <summary>
        /// Gets or sets the write as file.
        /// </summary>
        public bool WriteAsFile = false;
    }

    public class EmailProcessor
    {
        private EmailSettings emailSettings;

        /// <summary>
        /// An argument constructor that uses to initialize the EmailSettings instance.
        /// </summary>
        /// <param name="settings"></param>
        public EmailProcessor(EmailSettings settings)
        {
            emailSettings = settings;
        }

        /// <summary>
        /// Send an email to the user's account, which contains the item in the shopping cart
        /// and the shipping information.
        /// </summary>
        /// <param name="cart"></param>
        /// <param name="shippingInfo"></param>
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

        /// <summary>
        /// Send an email to the user once the order is shipped.
        /// </summary>
        public void OrderShipped()
        {
            StringBuilder body = new StringBuilder()
                .AppendLine("You should receive your order in 5 - 7 business days.");

            SendMail("Your Order is Shipped!", body);
        }

        /// <summary>
        /// Allow the user to send an email to contact us.
        /// </summary>
        /// <param name="fromUserEmail">The user email.</param>
        /// <param name="fromUserName">The user name.</param>
        public void Contact(string fromUserEmail, string fromUserName)
        {

        }

        /// <summary>
        /// Send an email to the user.
        /// </summary>
        /// <param name="subject">The subject of the email.</param>
        /// <param name="body">The body of the email.</param>
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

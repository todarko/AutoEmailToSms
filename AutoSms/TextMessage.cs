using System;
using System.Collections.Generic;
using System.Text;
using MailKit.Net.Smtp;
using MimeKit;

namespace AutoSms
{
    public class TextMessage
    {
        public string To { get; set; }
        public string Body { get; set; }
        public string EmailAuthenticate { get; set; }
        public string Token { get; set; }
        public string TextType { get; set; }
        public string TextServiceProvider { get; set; }
        public string EmailServiceProvider { get; set; }

        public void SendTextMessage(TextMessage textMessage, int portNumber = 465, bool UseSsl = true) 
        {
            if(!long.TryParse(textMessage.To, out _))
            {
                throw new AutoSmsException("Please use only integers for the phone number.");
            }
            if (textMessage.To.Length != 10)
            {
                throw new AutoSmsException("Please make sure the phone number is 10 digits.");
            }
            if (!IsValidEmail(textMessage.EmailAuthenticate))
            {
                throw new AutoSmsException("Please use a valid email address.");
            }

            var toAddress = MailboxAddress.Parse(textMessage.To + textMessage.TextServiceProvider);
            toAddress.Name = textMessage.To;
            var fromAddress = MailboxAddress.Parse(textMessage.EmailAuthenticate);
            fromAddress.Name = textMessage.EmailAuthenticate;

            var mailMessage = new MimeMessage();
            mailMessage.From.Add(fromAddress);
            mailMessage.To.Add(toAddress);
            mailMessage.Body = new TextPart("plain")
            {
                Text = textMessage.Body
            };

            using (var smtpClient = new SmtpClient())
            {
                smtpClient.Connect(textMessage.EmailServiceProvider, portNumber, UseSsl);
                smtpClient.Authenticate(textMessage.EmailAuthenticate, textMessage.Token);
                smtpClient.Send(mailMessage);
                smtpClient.Disconnect(true);
            }
        }

        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public class AutoSmsException : Exception
        {
            public AutoSmsException()
            {
            }

            public AutoSmsException(string message)
                : base(message)
            {
            }

            public AutoSmsException(string message, Exception inner)
                : base(message, inner)
            {
            }
        }
    }
}

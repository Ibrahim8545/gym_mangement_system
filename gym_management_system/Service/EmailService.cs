using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace gym_management_system.Service
{
    public class EmailService
    {
        public bool sendEmail(string recipientEmail, string subject, string body, Image image = null) 
        {
            string senderEmail = "pulseupgym@gmail.com";
            string senderPassword = "gpmr vcnt czsm rtva";
            string smtpServer = "smtp.gmail.com";
            int smtpPort = 587;
            using (SmtpClient smtpClient = new SmtpClient(smtpServer))
            {
                smtpClient.Port = smtpPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);
                smtpClient.EnableSsl = true;
                using (MailMessage mailMessage = new MailMessage(senderEmail, recipientEmail))
                {
                    mailMessage.Subject = subject;
                    mailMessage.Body = body;
                    if(image != null)
                    {
                        ImageConverter converter = new ImageConverter();
                        byte[] imageBytes = (byte[])converter.ConvertTo(image, typeof(byte[]));
                        MemoryStream memoryStream = new MemoryStream(imageBytes);
                        mailMessage.Attachments.Add(new Attachment(memoryStream, "image.png"));
                    }
                    try
                    {
                        smtpClient.Send(mailMessage);
                        Console.WriteLine("Email sent successfully.");
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error sending email: {ex.Message}");
                        return false;
                    }
                }
            }
        }
    }
}

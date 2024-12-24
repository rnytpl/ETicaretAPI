using ETicaretAPI.Application.Abstractions.Services;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace ETicaretAPI.Infrastructure.Services
{
    public class MailService : IMailService
    {

        readonly IConfiguration _configuration;

        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendMailAsync(string to, string subject, string body, bool isBodyHtml = true)
        {
            await SendMailAsync(new[] {to}, subject, body, isBodyHtml);
        }

        public async Task SendMailAsync(string[] tos, string subject, string body, bool isBodyHtml = true)
        {

            MailMessage mail = new();

            mail.IsBodyHtml = isBodyHtml;
            foreach (var to in tos)
            {
                mail.To.Add(to);
                mail.Subject = subject;
                mail.Body = body;
                mail.From = new("info@omniharvest.io", subject, System.Text.Encoding.UTF8);


                SmtpClient smtp = new SmtpClient();

                smtp.Credentials = new NetworkCredential(_configuration["Mail:Email"], _configuration["Mail:Password"]);
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Host = _configuration["Mail:Host"];

                await smtp.SendMailAsync(mail);
            }
        }

        public async Task SendPasswordResetMailAsync(string to, string userId, string resetToken)
        {
            string mail = $@"
            <!DOCTYPE html>
            <html lang=""en"">
                <head>
                    <meta charset=""UTF-8"">
                    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                    <style>
                        body {{
                            font-family: Arial, sans-serif;
                            line-height: 1.6;
                            color: #333333;
                            background-color: #f9f9f9;
                            margin: 0;
                            padding: 0;
                        }}
                        .container {{
                            width: 100%;
                            max-width: 600px;
                            margin: 0 auto;
                            padding: 20px;
                            background-color: #ffffff;
                            border: 1px solid #dddddd;
                            border-radius: 8px;
                            box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
                        }}
                        a {{
                            color: #0066cc;
                            text-decoration: none;
                        }}
                        a:hover {{
                            text-decoration: underline;
                        }}
                        .footer {{
                            margin-top: 20px;
                            font-size: 12px;
                            color: #777777;
                        }}
                    </style>
                </head>
                <body>
                    <div class=""container"">
                        <h2>Password Reset Request</h2>
                        <p>Dear User,</p>
                        <p>
                            You can reset your password using the link below. If you did not request a password reset, you can safely ignore this email.
                        </p>
                        <p>
                            <a 
                                href=""{_configuration["ClientUrl"]}/update-password/{userId}/{resetToken}""
                                target=""_self""
                            >
                                Click here to reset your password
                            </a>
                        </p>
                        <p>Thank you, <br> The OmniHarvest Team</p>
                        <div class=""footer"">
                            <p>
                                If you have any questions, please contact our support team at 
                                <a href=""mailto:info@omniharvest.io"">info@omniharvest.io</a>.
                            </p>
                            <p>© 2024 OmniHarvest. All rights reserved.</p>
                        </div>
                    </div>
                </body>
            </html>
            ";

            await SendMailAsync(to, "Password Reset Request", mail);

        }

        public async Task SendCompletedOrderMailAsync(string to, string userName, string orderCode, DateTime orderDate, string address)
        {
            string mail = $@"
                <!DOCTYPE html>
                <html lang=""en"">
                    <head>
                        <meta charset=""UTF-8"">
                        <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                        <style>
                            body {{
                                font-family: Arial, sans-serif;
                                line-height: 1.6;
                                color: #333333;
                                background-color: #f9f9f9;
                                margin: 0;
                                padding: 0;
                            }}
                            .container {{
                                width: 100%;
                                max-width: 600px;
                                margin: 0 auto;
                                padding: 20px;
                                background-color: #ffffff;
                                border: 1px solid #dddddd;
                                border-radius: 8px;
                                box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
                            }}
                            a {{
                                color: #0066cc;
                                text-decoration: none;
                            }}
                            a:hover {{
                                text-decoration: underline;
                            }}
                            .footer {{
                                margin-top: 20px;
                                font-size: 12px;
                                color: #777777;
                            }}
                        </style>
                    </head>
                    <body>
                        <div class=""container"">
                            <h2>Order Completed</h2>
                            <p>Dear {userName},</p>
                            <p>
                                Congratulations! Your order has been successfully completed.
                                Below are the details of your order:
                            </p>
                            <p>
                                <strong>Order Summary:</strong><br>
                                Order Code: <strong>{orderCode}</strong><br>
                                Order Date: <strong>{orderDate}</strong><br>
                                Shipping Address: <strong>{address}</strong>
                            </p>
                            <p>
                                Thank you for shopping with us! We hope you enjoy your purchase.
                            </p>
                            <p>If you have any questions or need assistance, please don't hesitate to contact our support team.</p>
                            <p>Thank you, <br> The OmniHarvest Team</p>
                            <div class=""footer"">
                                <p>
                                    For any inquiries, feel free to reach out to us at 
                                    <a href=""mailto:info@omniharvest.io"">info@omniharvest.io</a>.
                                </p>
                                <p>© 2024 OmniHarvest. All rights reserved.</p>
                            </div>
                        </div>
                    </body>
                </html>
                ";

            await SendMailAsync(to, "Order Complete", mail);

        }
    }
}

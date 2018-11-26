public static bool reportBug()
        {
            //activate the right settings in gmx:
            //click on email
            //click on settings (bottom left)
            //click on POP3/IMAP Abruf
            //click on POP3 und IMAP Zugriff erlauben
            //you can also see SMTP sever here
            try
            {
                Console.WriteLine("Enter Message: ");

                string msg;

                msg = Console.ReadLine();

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("senderMail");
                mail.To.Add("receiverMail");

                SmtpClient client = new SmtpClient();
                client.Port = 25;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Host = "mail.gmx.net";
                mail.Subject = "Bug Report";
                mail.Body = msg;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("senderMail", "senderPW");

                client.Send(mail);

                Console.WriteLine("Email has been sent!");
                Console.ReadLine();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }


using System;
using System.Collections.Generic;
using Mandrill;
using Mandrill.Models;
using Mandrill.Requests.Messages;

public class mandrillEmail
{
    public async void SendUpdatingMail(string message, string from,string to)
    {
        MandrillApi api = new MandrillApi("1651d8f826afa14ff4d978a7e63c53fd-us5");
        UserInfo info = await api.UserInfo();
        Console.WriteLine(info.Username);

        var email = new EmailMessage();

        var correos = new List<EmailAddress>();
        correos.Add(new EmailAddress(to));

        email.To = correos;

        email.Subject = String.Format("there was an update");

        email.FromEmail = from;
        email.FromName = "Napoleon";


        email.TrackOpens = true;
        email.Html =
            $"hello ";

        await api.SendMessage(new SendMessageRequest(email));
    }
}
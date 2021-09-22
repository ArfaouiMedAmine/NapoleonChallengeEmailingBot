using System;
using System.Linq;
using HtmlAgilityPack;

namespace NapoleonChallengeEmailingBot
{
    class Program
    {
        static void Main(string[] args)
        {
            mandrillEmail email = new mandrillEmail();
            HtmlWeb binancewebsite= new HtmlWeb();
            HtmlDocument document =  binancewebsite.Load("https://www.binance.com/en/futures-activity/leaderboard?type=myProfile&encryptedUid=8D27A8FA0C0A726CF01A7D11E0095577");

           
            var message = "hold on Napoleon there an update and you should get notified by mail";
            var listInitial = document.DocumentNode.SelectNodes("//div[@data-bn-type='text']").ToList();
            var c= 10;
            for (int i = 0; i < c; i++)
            {
                HtmlDocument documentUpdated =  binancewebsite.Load("https://www.binance.com/en/futures-activity/leaderboard?type=myProfile&encryptedUid=8D27A8FA0C0A726CF01A7D11E0095577");
                var listUpdated = document.DocumentNode.SelectNodes("//div[@data-bn-type='text']").ToList();
                if (listInitial!=listUpdated)
                {
                   Console.WriteLine(message);
                   email.SendUpdatingMail(message,"Napoleon","mohamedamine.arfaoui@esprit.tn");
                }
                c++;

            }
        }
    }
}

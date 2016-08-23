using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace My.LineBot.LineBot
{
    public class LineBotClient
    {
        private readonly HttpClient Client;
        public LineBotClient(string ChannelID, string ChannelSecret, string MID)
        {
            Client = new HttpClient();
            Client.DefaultRequestHeaders
                 .Add("X-Line-ChannelID", ChannelID);
            Client.DefaultRequestHeaders
                 .Add("X-Line-ChannelSecret", ChannelSecret);
            Client.DefaultRequestHeaders
                 .Add("X-Line-Trusted-User-With-ACL", MID);
        }

        public async void PostAsJsonAsync(dynamic Result)
        {

            HttpResponseMessage res = await Client.PostAsJsonAsync("https://trialbot-api.line.me/v1/events",
                  new
                  {
                      to = new[] { Result.content.from },
                      toChannel = "1383378250",
                      eventType = "138311608800106203",
                      content = new
                      {
                          contentType = 1,
                          toType = 1,
                          text = $">>>>> {Result.content.text}",
                      }
                  });
        }


        //public async void SendMessage()
        //{
        //Change contentType ,User FROM
        /*
            1	Text message   

                          "content":{
                            "contentType":1,
                            "toType":1,
                            "text":"Hello, Jose!"
                          }
            2	Image message   
                           "content":{
                            "contentType":2,
                            "toType":1,
                            "originalContentUrl":"http://example.com/original.jpg",
                            "previewImageUrl":"http://example.com/preview.jpg"
                          }
            3	Video message  
                          "content":{
                            "contentType":3,
                            "toType":1,
                            "originalContentUrl":"http://example.com/original.mp4",
                            "previewImageUrl":"http://example.com/preview.jpg"
                          }
            4	Audio message    "originalContentUrl":"http://example.com/original.m4a",
                           "content":{
                            "contentType":4,
                            "toType":1,
                            "originalContentUrl":"http://example.com/original.m4a",
                            "contentMetadata":{
                              "AUDLEN":"240000"
                           }
            7	Location message
                        "content":{
                        "contentType":7,
                        "toType":1,
                        "text":"Convention center",
                        "location":{
                          "title":"Convention center",
                          "latitude":35.61823286112982,
                          "longitude":139.72824096679688
                        }
            8	Sticker message
                      "content":{
                        "contentType":8,
                        "toType":1,
                        "contentMetadata":{
                          "STKID":"3",
                          "STKPKGID":"332",
                          "STKVER":"100"
                        }
                      }
            10	Contact message
        */

        //}
    }
}

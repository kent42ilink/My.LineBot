using My.LineBot.LineBot;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace My.LineBot.Controllers
{
    public class ChatController : ApiController
    {
        public async Task<HttpResponseMessage> Post()
        {
            try
            {
                var contentString = await Request.Content.ReadAsStringAsync();

                dynamic contentObj = JsonConvert.DeserializeObject(contentString);

                var result = contentObj.result[0];

                //Change Your ChannelID ChannelSecret MID
                LineBotClient LineBot = new LineBotClient("{ChannelID}", "{ChannelSecret}", "{MID}");


                LineBot.PostAsJsonAsync(result);
                return new HttpResponseMessage(System.Net.HttpStatusCode.OK);

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
            }


        }
    }
}
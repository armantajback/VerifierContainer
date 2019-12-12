
namespace VerifierContainer.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    [Route("Egress")]
    public class EgressController : Controller
    {


        [HttpGet("Verify/{host?}")]
        public async Task<ActionResult<string>> Get(string host=null)
        {
            host = host ?? AlexaTop100Websites[RandomGenerator.Next(0, AlexaTop100Websites.Length)];

            return await EndpointChecker.GetEndpoint(host, 80);
        }

        static readonly Random RandomGenerator = new Random();

        static readonly string[] AlexaTop100Websites = new[]
        {
            "google.com",
            "youtube.com",
            "tmall.com",
            "baidu.com",
            "qq.com",
            "facebook.com",
            "taobao.com",
            "sohu.com",
            "wikipedia.org",
            "login.tmall.com",
            "yahoo.com",
            "360.cn",
            "jd.com",
            "amazon.com",
            "sina.com.cn",
            "reddit.com",
            "weibo.com",
            "pages.tmall.com",
            "live.com",
            "vk.com",
            "okezone.com",
            "netflix.com",
            "blogspot.com",
            "chaturbate.com",
            "office.com",
            "csdn.net",
            "instagram.com",
            "alipay.com",
            "xinhuanet.com",
            "yahoo.co.jp",
            "microsoft.com",
            "twitter.com",
            "aliexpress.com",
            "babytree.com",
            "livejasmin.com",
            "bing.com",
            "stackoverflow.com",
            "apple.com",
            "google.com.hk",
            "naver.com",
            "ebay.com",
            "twitch.tv",
            "force.com",
            "microsoftonline.com",
            "amazon.co.jp",
            "tianya.cn",
            "pornhub.com",
            "tribunnews.com",
            "linkedin.com",
            "msn.com",
            "google.co.in",
            "adobe.com",
            "yandex.ru",
            "wordpress.com",
            "panda.tv",
            "dropbox.com",
            "amazon.in",
            "mail.ru",
            "imdb.com",
            "china.com.cn",
            "zhanqi.tv",
            "myshopify.com",
            "whatsapp.com",
            "bongacams.com",
            "google.com.br",
            "mama.cn",
            "caijing.com.cn",
            "google.co.jp",
            "soso.com",
            "booking.com",
            "espn.com",
            "spotify.com",
            "rednet.cn",
            "medium.com",
            "google.de",
            "amazonaws.com",
            "trello.com",
            "detail.tmall.com",
            "amazon.co.uk",
            "github.com",
            "ok.ru",
            "instructure.com",
            "w3schools.com",
            "detik.com",
            "bbc.com",
            "xvideos.com",
            "paypal.com",
            "imgur.com",
            "huanqiu.com",
            "amazon.de",
            "indeed.com",
            "nytimes.com",
            "hao123.com",
            "xhamster.com",
            "tumblr.com",
            "google.ru",
            "google.es",
            "onlinesbi.com",
            "yy.com",
            "cnn.com"
        };
    }
}

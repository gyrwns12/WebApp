using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApp.Controllers;

public class HomeController : Controller
{
    public async Task<IActionResult> Index()
    {
        HttpClientHandler handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
        };
        HttpClient client = new HttpClient(handler);
        var response = await client.GetStringAsync("http://10.98.53.40:8080/home");
        ViewBag.Message = response;
        return View();
    }
}

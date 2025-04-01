using System.Text;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using MS.UI.DtoLayer.IdentityDtos.RegisterDtos;

namespace MS.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RegisterController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateRegisterDto crdto)
        {
            if (crdto.Password == crdto.ConfirmPassword)
            {
                var client = _httpClientFactory.CreateClient();
                var data = JsonConvert.SerializeObject(crdto);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("http://localhost:5001/api/Registers", content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            return View();
        }
    }
}

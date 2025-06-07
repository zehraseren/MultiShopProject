using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Localization;

namespace MS.WebUI.Controllers;

public class CultureController : Controller
{
    public IActionResult SetLanguage(string culture, string returnUrl)
    {
        // Tarayıcıya dil bilgisi içeren bir çerez bırakılır
        Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)), new CookieOptions
        {
            Expires = DateTimeOffset.UtcNow.AddYears(1) // 1 yıl geçerli olur
        });

        // Kullanıcıyı geldiği sayfaya geri yönlendirilır
        return LocalRedirect(returnUrl);
    }
}

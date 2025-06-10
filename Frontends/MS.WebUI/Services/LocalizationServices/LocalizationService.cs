using Microsoft.Extensions.Localization;

namespace MS.WebUI.Services.LocalizationServices;

public class LocalizationService
{
    private readonly IStringLocalizerFactory _stringLocalizerFactory;

    public LocalizationService(IStringLocalizerFactory stringLocalizerFactory)
    {
        _stringLocalizerFactory = stringLocalizerFactory;
    }

    public LocalizedString GetKey(string key, Type resourceType)
    {
        var assemblyName = resourceType.Assembly.GetName().Name;
        var localizer = _stringLocalizerFactory.Create(resourceType.Name, assemblyName);
        return localizer[key];
    }
}

using System.Reflection;
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
        var assemblyName = new AssemblyName(resourceType.GetTypeInfo().Assembly.FullName);
        var localizer = _stringLocalizerFactory.Create(resourceType.Name, assemblyName.Name);
        return localizer[key];
    }
}

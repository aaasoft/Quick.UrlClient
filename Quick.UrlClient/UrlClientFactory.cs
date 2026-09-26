namespace Quick.UrlClient;

public static class UrlClientFactory
{
    private static Dictionary<string, Func<string, IUrlClient>> createFuncDict = new();

    public static void RegisterScheme(string scheme, Func<string, IUrlClient> createFunc)
    {
        createFuncDict[scheme] = createFunc;
    }

    public static string[] GetAllSchemes() => createFuncDict.Keys.ToArray();

    public static IUrlClient Build(string url)
    {
        var uri = new Uri(url);
        if (!createFuncDict.TryGetValue(uri.Scheme, out var createFunc))
            throw new NotImplementedException($"Unknown scheme: {uri.Scheme}");
        return createFunc.Invoke(url);
    }
}

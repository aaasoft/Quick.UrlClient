namespace Quick.UrlClient;

public abstract class AbstractUrlClientOptions
{
    public string Url { get; private set; }

    protected AbstractUrlClientOptions() { }
    protected AbstractUrlClientOptions(string url)
    {
        Url = url;
        var uri = new Uri(url);
        ParseUri(uri);
    }

    protected virtual void ParseUri(Uri uri) { }
}

namespace Quick.UrlClient.WebSocket;

public class WebSocketUrlClientOptions : AbstractUrlClientOptions
{
    internal Uri Uri { get; private set; }
    public WebSocketUrlClientOptions() { }
    public WebSocketUrlClientOptions(string url) : base(url) { }
    protected override void ParseUri(Uri uri)
    {
        Uri = uri;
    }
}

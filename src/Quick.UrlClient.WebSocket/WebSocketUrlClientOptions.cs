namespace Quick.UrlClient.WebSocket;

public class WebSocketUrlClientOptions
{
    public Uri Uri { get; set; }

    public WebSocketUrlClientOptions() { }
    public WebSocketUrlClientOptions(Uri uri)
    {
        Uri = uri;
    }
}

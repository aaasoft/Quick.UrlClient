namespace Quick.UrlClient;

public interface IUrlClient : IDisposable
{
    string Url { get; }
    int SendTimeout { get; set; }
    int ReceiveTimeout { get; set; }
    void Open();
    Task OpenAsync(CancellationToken cancellationToken);
    Stream GetStream();
    void Close();
}

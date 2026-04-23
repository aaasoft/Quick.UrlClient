namespace Quick.UrlClient;

public interface IUrlClient : IDisposable
{
    string Url{get;}
    void Open();
    Task OpenAsync(CancellationToken cancellationToken);
    Stream GetStream();
    void Close();
}

namespace Quick.UrlClient;

public interface IUrlClient : IDisposable
{
    void Open();
    Task OpenAsync(CancellationToken cancellationToken);
    Stream GetStream();
    void Close();
}

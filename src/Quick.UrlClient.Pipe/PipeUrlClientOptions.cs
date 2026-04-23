using System;
using System.IO.Pipes;

namespace Quick.UrlClient.Pipe;

public class PipeUrlClientOptions
{
    public string ServerName { get; set; }
    public string PipeName { get; set; }
    public int ConnectTimeout { get; set; } = 5000;
    public int? WriteTimeout { get; set; }
    public int? ReadTimeout { get; set; }
    public string Direction { get; set; } = nameof(PipeDirection.InOut);
    public string Options { get; set; } = nameof(PipeOptions.Asynchronous);
    public string ReadMode { get; set; } = nameof(PipeTransmissionMode.Byte);

    public PipeUrlClientOptions() { }
    public PipeUrlClientOptions(Uri uri)
    {
        ServerName = uri.Host;
        PipeName = uri.LocalPath;
        var query = System.Web.HttpUtility.ParseQueryString(uri.Query);
        foreach (var key in query.AllKeys)
        {
            var v = query.Get(key);
            switch (key)
            {
                case nameof(Direction):
                    Direction = v;
                    break;
                case nameof(Options):
                    Options = v;
                    break;
                case nameof(ReadMode):
                    ReadMode = v;
                    break;
                case nameof(ConnectTimeout):
                    ConnectTimeout = int.Parse(v);
                    break;
                case nameof(WriteTimeout):
                    WriteTimeout = int.Parse(v);
                    break;
                case nameof(ReadTimeout):
                    ReadTimeout = int.Parse(v);
                    break;
            }
        }
    }
}

namespace Common;

public class HeaderAddInterceptor : DelegatingHandler
{
    private readonly string _headerName;
    private readonly string _headerValue;
    public HeaderAddInterceptor() : this("tenant","uat")
    {
    }

    public HeaderAddInterceptor(string headerName, string headerValue)
    {
        _headerName = headerName;
        _headerValue = headerValue;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        request.Headers.Add(_headerName, _headerValue);
        return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
    }
}

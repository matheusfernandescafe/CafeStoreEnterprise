using CSE.WebApp.MVC.Extensions;
using System.Net.Http.Headers;

namespace CSE.WebApp.MVC.Services.Handlers;

public class HttpClientAuthorizationDelegatingHandler(IUser user) : DelegatingHandler
{
    private readonly IUser _user = user;

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var authorizationHeader = _user.ObterHttpContext()?.Request.Headers.Authorization;

        if (!string.IsNullOrEmpty(authorizationHeader))
        {
            request.Headers.Add("Authorization", [authorizationHeader]);
        }

        var token = _user.ObterUserToken();

        if (token != null)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        return base.SendAsync(request, cancellationToken);
    }
}

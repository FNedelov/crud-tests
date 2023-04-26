using CRUD.Common;

namespace CRUD.Web.Blazor.Classes
{
    public static class HelperMethods
    {
        public static HttpRequestMessage GenerateRequestMessage(string requestUrl, HttpMethod httpMethod, StringContent? requestContent = default, string? bearerToken = default)
        {
            var requestMessage = new HttpRequestMessage()
            {
                RequestUri = new Uri(requestUrl),
                Method = httpMethod,
                Content = requestContent
            };

            if (bearerToken != default)
                requestMessage.Headers.Add("Authorization", $"Bearer {bearerToken}");

#warning give Windows user here (JWT or prop?)
            requestMessage.Headers.Add(Constants.HEADER_USER, $"userTestName");
            var authHeader = requestMessage.Headers.Select(x => x).Where(y => y.Key == "Authorization").FirstOrDefault();

            return requestMessage;
        }
    }
}
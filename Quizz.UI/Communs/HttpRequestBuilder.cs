using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class HttpRequestBuilder
{
  private HttpMethod method = null;
  private string requestUri = "";
  private HttpContent content = null;
  private string bearerToken = "";
  private string acceptHeader = "application/json";
  private TimeSpan timeout = new TimeSpan(0, 0, 15);

  public HttpRequestBuilder()
  {
  }

  public HttpRequestBuilder AddMethod(HttpMethod method)
  {
    this.method = method;
    return this;
  }

  public HttpRequestBuilder AddRequestUri(string requestUri)
  {
    this.requestUri = requestUri;
    return this;
  }

  public HttpRequestBuilder AddContent(HttpContent content)
  {
    this.content = content;
    return this;
  }

  public HttpRequestBuilder AddBearerToken(string bearerToken)
  {
    this.bearerToken = bearerToken;
    return this;
  }

  public HttpRequestBuilder AddAcceptHeader(string acceptHeader)
  {
    this.acceptHeader = acceptHeader;
    return this;
  }

  public HttpRequestBuilder AddTimeout(TimeSpan timeout)
  {
    this.timeout = timeout;
    return this;
  }

  private void addHeaders(System.Net.Http.HttpClient httpClient)
  {
    httpClient.DefaultRequestHeaders.Remove("userIP");
    httpClient.DefaultRequestHeaders.Add("userIP", "192.168.1.1");
  }

  public async Task<HttpResponseMessage> SendAsync()
  {
    // Check required arguments  
   // EnsureArguments();

    // Setup request  
    var request = new HttpRequestMessage
    {
      Method = this.method,
      RequestUri = new Uri(this.requestUri)
    };

    if (this.content != null)
      request.Content = this.content;

    if (!string.IsNullOrEmpty(this.bearerToken))
      request.Headers.Authorization =
        new AuthenticationHeaderValue("Bearer", this.bearerToken);

    request.Headers.Accept.Clear();
    if (!string.IsNullOrEmpty(this.acceptHeader))
      request.Headers.Accept.Add(
         new MediaTypeWithQualityHeaderValue(this.acceptHeader));

    // Mise jour du client  
    var client = new System.Net.Http.HttpClient();
    client.Timeout = this.timeout;

    addHeaders(client);
   

    return await client.SendAsync(request);
  }
}
  public static class HttpRequestFactory
  {
    public static async Task<HttpResponseMessage> Get(string requestUri)
    {
      var builder = new HttpRequestBuilder()
                          .AddMethod(HttpMethod.Get)
                          .AddRequestUri(requestUri);

      return await builder.SendAsync();
    }

    public static async Task<HttpResponseMessage> Post(
       string requestUri, object value)
    {
      var builder = new HttpRequestBuilder()
                          .AddMethod(HttpMethod.Post)
                          .AddRequestUri(requestUri)
                          .AddContent(new JsonContent(value));

      return await builder.SendAsync();
    }

    public static async Task<HttpResponseMessage> Put(
       string requestUri, object value)
    {
      var builder = new HttpRequestBuilder()
                          .AddMethod(HttpMethod.Put)
                          .AddRequestUri(requestUri)
                          .AddContent(new JsonContent(value));

      return await builder.SendAsync();
    }

    public static async Task<HttpResponseMessage> Patch(
       string requestUri, object value)
    {
      var builder = new HttpRequestBuilder()
                          .AddMethod(new HttpMethod("PATCH"))
                          .AddRequestUri(requestUri)
                          .AddContent(new PatchContent(value));

      return await builder.SendAsync();
    }

    public static async Task<HttpResponseMessage> Delete(string requestUri)
    {
      var builder = new HttpRequestBuilder()
                          .AddMethod(HttpMethod.Delete)
                          .AddRequestUri(requestUri);

      return await builder.SendAsync();
    }
  }


public class JsonContent : StringContent
{
  public JsonContent(object value)
      : base(JsonConvert.SerializeObject(value), Encoding.UTF8,
"application/json")
  {
  }

  public JsonContent(object value, string mediaType)
      : base(JsonConvert.SerializeObject(value), Encoding.UTF8, mediaType)
  {
  }
}

public class PatchContent : StringContent
{
  public PatchContent(object value)
      : base(JsonConvert.SerializeObject(value), Encoding.UTF8,
                "application/json-patch+json")
  {
  }
}

public class FileContent : MultipartFormDataContent
{
  public FileContent(string filePath, string apiParamName)
  {
    var filestream = File.Open(filePath, FileMode.Open);
    var filename = Path.GetFileName(filePath);

    Add(new StreamContent(filestream), apiParamName, filename);
  }
}
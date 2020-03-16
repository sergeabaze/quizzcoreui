using System;
using System.Threading.Tasks;
using Quizz.Service.DTOS;

namespace Quizz.Service
{
  public class TypeClientService :ApiClient, ITypeClientService
  {
    private Uri BaseEndpoint { get; set; }
    private const string GET_ALL ="/api/v1/TypeClient/{0}";
    private const string GET_BYID = "";
    private const string POST = "";
    private const string PUT= "";
    private const string DELETE = "";

    public TypeClientService(Uri _baseEndpoint)
    :base(_baseEndpoint)
    {

    }
    public TypeClientService(){}

    public Task<TypeClientDto> ObtenirelisteAsync()
    {
      throw new NotImplementedException();
    }
  }

}
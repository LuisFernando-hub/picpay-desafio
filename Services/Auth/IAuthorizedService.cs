namespace picpay_desafio.Services.Auth
{
    public interface IAuthorizedService
    {
       Task<bool> AuthorizeAsync();
    }
}

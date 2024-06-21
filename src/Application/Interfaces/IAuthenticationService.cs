using Application.Models.Requests;

public interface IAuthenticationService
{
    string Autenticar(AuthenticationRequest authenticationRequest);
}
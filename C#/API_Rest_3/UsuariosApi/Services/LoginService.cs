using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using UsuariosApi.Data.Request;
using UsuariosApi.Models;

namespace UsuariosApi.Services
{
    public class LoginService
    {
        private SignInManager<IdentityUser<int>> _signInManager;
        private TokenService _tokenService;

        public LoginService(SignInManager<IdentityUser<int>> signInManager, TokenService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public Result LogaUsuario(LoginRequest request)
        {
            Task<SignInResult> resultadoIdentity = _signInManager.PasswordSignInAsync(request.Username, request.Password, false, false);

            IdentityUser<int> identityUser = _signInManager
                .UserManager
                .Users
                .FirstOrDefault(usuario => usuario.NormalizedUserName == request.Username.ToUpper());

            if (resultadoIdentity.Result.Succeeded)
            {
                Token token = _tokenService.CreateToken(identityUser);
                
                if (identityUser.EmailConfirmed == false) return Result.Fail("Email não confirmado");

                // Envia o JWT no 'body' da requisição
                return Result.Ok().WithSuccess(token.Value);
            }

            return Result.Fail("Usuário e/ou senha incorretos");
        }
    }
}

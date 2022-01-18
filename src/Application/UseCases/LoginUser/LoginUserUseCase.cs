﻿using Domain.Entities;
using Domain.Models.Requests;
using Domain.Repositories;
using Infrastructure.Services;
using System.Threading.Tasks;

namespace Application.UseCases.LoginUser
{
    public class LoginUserUseCase : ILoginUserUseCase
    {
        private IUserRepository _repository;
        private ITokenService _service;

        public LoginUserUseCase(IUserRepository repository, ITokenService service)
        {
            this._repository = repository;
            this._service = service;
        }

        public async Task Execute(LoginUserRequest request)
        {
            User? user = await this._repository.GetUser(request.Login, request.Password);

            _service.GenerateToken(user!);

            await Task.CompletedTask;
        }
    }
}
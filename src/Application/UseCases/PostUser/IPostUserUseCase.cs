﻿namespace Application.UseCases.PostUser
{
    using Domain.Models.Requests;
    using System.Threading.Tasks;

    public interface IPostUserUseCase
    {
        Task Execute(PostUserRequest requestModel);
    }
}
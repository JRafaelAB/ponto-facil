﻿using Domain.Exceptions;
using Domain.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Base
{
    public abstract class BaseController : ControllerBase
    {
        protected void ValidateRequest<T>(T request)
        {
            if (!TryValidateModel(request))
            {
                throw new InvalidRequestException(ModelState.GetErrorList());
            }
        }
    }
}

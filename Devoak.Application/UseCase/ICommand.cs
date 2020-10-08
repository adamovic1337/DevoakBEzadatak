using System;
using System.Collections.Generic;
using System.Text;

namespace Devoak.Application.UseCase
{
    public interface ICommand<in TRequest> : IUseCase
    {
        void Execute(TRequest request);
    }
}

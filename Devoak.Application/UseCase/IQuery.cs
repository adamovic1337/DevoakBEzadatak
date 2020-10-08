using System;
using System.Collections.Generic;
using System.Text;

namespace Devoak.Application.UseCase
{
    public interface IQuery<in TSearch, out TResult> : IUseCase
    {
        TResult Execute(TSearch search);
    }
}

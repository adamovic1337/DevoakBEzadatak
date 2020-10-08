using System;
using System.Collections.Generic;
using System.Text;

namespace Devoak.Application.UseCase
{
    public interface IUseCase
    {
        int Id { get; }
        string Description { get; }    
    }
}

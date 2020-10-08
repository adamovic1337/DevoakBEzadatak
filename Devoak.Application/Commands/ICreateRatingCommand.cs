using Devoak.Application.DataTransfer;
using Devoak.Application.UseCase;
using System;
using System.Collections.Generic;
using System.Text;

namespace Devoak.Application.Commands
{
    public interface ICreateRatingCommand : ICommand<RatingDto>
    {
    }
}

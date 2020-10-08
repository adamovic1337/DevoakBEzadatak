using AutoMapper;
using Devoak.Application.DataTransfer;
using Devoak.Application.Queries;
using Devoak.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Devoak.Implementation.Queries
{
    public class GetUserQuery : IGetUserQuery
    {
        private readonly DevoakContext _context;
        private readonly IMapper _mapper;

        public GetUserQuery(DevoakContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 401;

        public string Description => "Get User";

        public IEnumerable<UserDto> Execute(int search)
        {
            var query = _context.Users.AsQueryable();
            query = query.Where(user => user.Id == search);

            return query.Select(user => _mapper.Map<UserDto>(user)).ToList();
        }
    }
}

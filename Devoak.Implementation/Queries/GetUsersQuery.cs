using AutoMapper;
using Devoak.Application.DataTransfer;
using Devoak.Application.Queries;
using Devoak.Application.Searches;
using Devoak.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Devoak.Implementation.Queries
{
    public class GetUsersQuery : IGetUsersQuery
    {
        private readonly DevoakContext _context;
        private readonly IMapper _mapper;

        public GetUsersQuery(DevoakContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public int Id => 403;

        public string Description => "Get Users";

        public IEnumerable<UserDto> Execute(UserSearch search)
        {
            var query = _context.Users.AsQueryable();

            if (!string.IsNullOrEmpty(search.Username) || !string.IsNullOrWhiteSpace(search.Username))
            {
                query = query.Where(user => user.Username.ToLower().Contains(search.Username.ToLower()));
            }

            return query.Select(user => _mapper.Map<UserDto>(user)).ToList();
        }
    }
}

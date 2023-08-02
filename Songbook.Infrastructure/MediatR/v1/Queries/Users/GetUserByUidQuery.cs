using AutoMapper;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Songbook.Domain.Repositories.v1;
using Songbook.Domain.Response.v1.Common;
using Songbook.Domain.Response.v1.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Songbook.Infrastructure.MediatR.v1.Queries.Users
{
    public class GetUserByUidQuery : IRequest<GenericResponse<GetUserByUidResponse>>
    {
        public string Uid { get; set; }
        public GetUserByUidQuery(string uid)
        {
            Uid = uid;
        }
    }

    public class GetUserByUidQueryHandler : IRequestHandler<GetUserByUidQuery, GenericResponse<GetUserByUidResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository userRepository;

        public GetUserByUidQueryHandler(IMapper mapper, IUserRepository userRepository)
        {
            this._mapper = mapper;
            this.userRepository = userRepository;
        }
        public async Task<GenericResponse<GetUserByUidResponse>> Handle(GetUserByUidQuery request, CancellationToken cancellationToken)
        {
            var result = new GenericResponse<GetUserByUidResponse>();
            var user = await userRepository.GetByUidAsync(request.Uid);
            result.Data = _mapper.Map<GetUserByUidResponse>(user);
            return result;
        }
    }
}

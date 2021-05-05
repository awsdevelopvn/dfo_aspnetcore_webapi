using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DFO_Application.Exceptions;
using DFO_Application.Interfaces;
using DFO_Application.Wrappers;
using DFO_Domain.Entities;
using MediatR;

namespace DFO_Application.Features.Users.Queries
{
    public class GetUserByIdQuery: IRequest<ResponseBase<UserViewModel>>
    {
        public int Id { get; set; }
        public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, ResponseBase<UserViewModel>>
        {
            private readonly IGenericRepositoryAsync<DFOUser> _userRepository;
            private readonly IMapper _mapper;
            public GetUserByIdQueryHandler(IGenericRepositoryAsync<DFOUser> userRepository, IMapper mapper)
            {
                _userRepository = userRepository;
                _mapper = mapper;
            }
            public async Task<ResponseBase<UserViewModel>> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
            {
                var user = await _userRepository.GetByIdAsync(query.Id);
                if (user == null) throw new ApiException("User Not Found.");
                return new ResponseBase<UserViewModel>(_mapper.Map<UserViewModel>(user));
            }
        }
    }
}
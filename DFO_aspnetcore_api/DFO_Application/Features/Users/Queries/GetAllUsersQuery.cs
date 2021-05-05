using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DFO_Application.Interfaces;
using DFO_Application.Wrappers;
using DFO_Domain.Entities;
using MediatR;

namespace DFO_Application.Features.Users.Queries
{
    public class GetAllUsersQuery: IRequest<PagedResponse<IEnumerable<UserViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        
        public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, PagedResponse<IEnumerable<UserViewModel>>>
        {
            private readonly IGenericRepositoryAsync<DFOUser> _userRepository;
            private readonly IMapper _mapper;
            public GetAllUsersQueryHandler(IGenericRepositoryAsync<DFOUser> userRepository, IMapper mapper)
            {
                _userRepository = userRepository;
                _mapper = mapper;
            }

            public async Task<PagedResponse<IEnumerable<UserViewModel>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
            {
                var validFilter = _mapper.Map<GetAllUsersParameter>(request);
                var users = await _userRepository.GetPagedReponseAsync(validFilter.PageNumber,validFilter.PageSize);
                var usersViewModel = _mapper.Map<IEnumerable<UserViewModel>>(users);
                return new PagedResponse<IEnumerable<UserViewModel>>(usersViewModel, validFilter.PageNumber, validFilter.PageSize);           
            }
        }
    }
}
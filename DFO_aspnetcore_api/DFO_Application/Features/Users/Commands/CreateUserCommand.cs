using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DFO_Application.Features.Users.Queries;
using DFO_Application.Interfaces;
using DFO_Application.Wrappers;
using DFO_Domain.Entities;
using MediatR;

namespace DFO_Application.Features.Users.Commands
{
    public partial class CreateUserCommand: IRequest<ResponseBase<UserViewModel>>
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Address { get; set; }
        [Required]
        public int? Age { get; set; }
    }
    
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ResponseBase<UserViewModel>>
    {
        private readonly IGenericRepositoryAsync<DFOUser> _userRepository;
        private readonly IMapper _mapper;
        public CreateUserCommandHandler(IGenericRepositoryAsync<DFOUser> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<UserViewModel>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<DFOUser>(request);
            var result = await _userRepository.AddAsync(user);
            return new ResponseBase<UserViewModel>(_mapper.Map<UserViewModel>(result));
        }
    }
}
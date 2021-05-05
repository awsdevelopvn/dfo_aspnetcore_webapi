using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DFO_Application.Exceptions;
using DFO_Application.Features.Users.Queries;
using DFO_Application.Interfaces;
using DFO_Application.Wrappers;
using DFO_Domain.Entities;
using MediatR;

namespace DFO_Application.Features.Users.Commands
{
    public class UpdateUserCommand: IRequest<ResponseBase<UserViewModel>>
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public int? Age { get; set; }
        [MaxLength(50)]
        public string Address { get; set; }
        public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, ResponseBase<UserViewModel>>
        {
            private readonly IGenericRepositoryAsync<DFOUser> _userRepository;
            private readonly IMapper _mapper;
            public UpdateUserCommandHandler(IGenericRepositoryAsync<DFOUser> userRepository, IMapper mapper)
            {
                _userRepository = userRepository;
                _mapper = mapper;
            }
            
            public async Task<ResponseBase<UserViewModel>> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
            {
                var user = await _userRepository.GetByIdAsync(command.Id);

                if (user == null)
                {
                    throw new ApiException("User Not Found.");
                }
                
                user.Name = command.Name;
                user.Age = command.Age;
                user.Address = command.Address;
                await _userRepository.UpdateAsync(user);
                return new ResponseBase<UserViewModel>(_mapper.Map<UserViewModel>(user));
            }
        }
    }
}
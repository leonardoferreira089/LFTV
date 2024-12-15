using LFTV.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LFTV.Application.Commands.User
{
    public class UserCommandHandler :
        IRequestHandler<CreateUserCommand, int>,
        IRequestHandler<UpdateUserCommand, bool>,
        IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        // Injection du repository User
        public UserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // Handler pour la création d'un utilisateur
        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new LFTV.Domain.Entities.User
            {
                Username = request.Username,
                PasswordHash = request.PasswordHash, // Vous devrez peut-être ajouter un mécanisme de hachage ici
                Role = request.Role
            };

            await _userRepository.AddAsync(user);
            return user.Id;
        }

        // Handler pour la mise à jour d'un utilisateur
        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);

            if (user == null)
                return false;

            user.Username = request.Username;
            user.PasswordHash = request.PasswordHash;
            user.Role = request.Role;

            await _userRepository.UpdateAsync(user);
            return true;
        }

        // Handler pour la suppression d'un utilisateur
        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);

            if (user == null)
                return false;

            await _userRepository.DeleteAsync(user);
            return true;
        }
    }

}

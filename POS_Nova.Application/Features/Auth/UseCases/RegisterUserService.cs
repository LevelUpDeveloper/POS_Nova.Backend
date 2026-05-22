using POS_Nova.Application.Features.Auth.DTOs;
using POS_Nova.Application.Interfaces.Persistence;
using POS_Nova.Domain.Entities;
using POS_Nova.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS_Nova.Application.Exceptions;

namespace POS_Nova.Application.Features.Auth.UseCases
{
    public class RegisterUserService
    {
        private readonly IUserRepository _user;
        private readonly IRoleRepository _roleRepository;
        private readonly IPasswordHasher _passwordHasher;

        public RegisterUserService(IUserRepository userRepository, IRoleRepository roleRepository, IPasswordHasher passwordHasher)
        {
            _user = userRepository;
            _roleRepository = roleRepository;
            _passwordHasher = passwordHasher;
        }


        public async Task<UserRegisterResponseDto> Execute(UserRegisterRequestDto userRegisterRequest)
        {

            var registeredEmailExists = await _user.ExistByEmail(userRegisterRequest.Email);

            if (registeredEmailExists)
            {
                throw new ConflictException("Ya se encuentra registrado ese correo");
            }


            var registeredUserNameExists = await _user.ExistByUserName(userRegisterRequest.UserName);

            if (registeredUserNameExists)
            {
                throw new ConflictException("Nombre de usuario ya registrado");
            }


            var passwordMatch = _passwordHasher.HashPassword(userRegisterRequest.Password);


            var user = User.Create(userRegisterRequest.UserName, userRegisterRequest.Email, passwordMatch);

           
            var role = await _roleRepository.GetByName(userRegisterRequest.Role);     
            
            if (role == null)
            {
                throw new NotFoundException("Rol no existente");
            }

            user.AssignRole(role);


            await _user.CreateAsync(user);

            return new UserRegisterResponseDto
            {   
                UserName = userRegisterRequest.UserName,
                Email = userRegisterRequest.Email
            };

        }
    }

}

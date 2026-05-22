using POS_Nova.Application.Exceptions;
using POS_Nova.Application.Features.Auth.DTOs;
using POS_Nova.Application.Interfaces.Persistence;
using POS_Nova.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace POS_Nova.Application.Features.Auth.UseCases
{
    public class RegisterRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RegisterRoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<RoleRegisterResponseDto> Execute(RoleRegisterRequestDto roleRegisterRequest)
        {
            var roleExists = await _roleRepository.ExistByName(roleRegisterRequest.Name);
            if (roleExists)
            {
                throw new ConflictException("Ya se encuentra registrado ese rol");
            }

            var role = Role.Create(roleRegisterRequest.Name, roleRegisterRequest.Description);

            await _roleRepository.CreateAsync(role);


            return new RoleRegisterResponseDto 
            {
                Name = role.Name, 
                Description = role.Description 
            };
        }
    }
}

using AutoMapper;
using Business.Interfaces;
using DataAccess.Interfaces;
using Dtos;
using Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class UserService : IUserService
    {


        private readonly IRepository<AppCustomer> _customerRepository;
        private readonly IRepository<AppRole> _roleRepository;
        private readonly IMapper _mapper;

        public UserService(IRepository<AppCustomer> repository, IMapper mapper, IRepository<AppRole> roleRepository)
        {
            _customerRepository = repository;
            _mapper = mapper;
            _roleRepository = roleRepository;
        }

    }
}

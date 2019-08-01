﻿using AutoMapper;
using WebShop.Users.AppServices.Queries;
using WebShop.Users.Contracts.ApplicationUser;
using WebShop.Users.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebShop.Messaging;

namespace WebShop.Users.AppServices.Handlers
{
    public class ProfileGetHandler : IQueryHandler<ProfileGetQuery, ProfileView>
    {

        private readonly IApplicationUsersUnitOfWork _applicationUsersUnitOfWork;
        private readonly IMapper _mapper;
        public ProfileGetHandler(IApplicationUsersUnitOfWork applicationUsersUnitOfWork, IMapper mapper)
        {
            _applicationUsersUnitOfWork = applicationUsersUnitOfWork;
            _mapper = mapper;
        }

        public async Task<ProfileView> HandleAsync(ProfileGetQuery query)
        {
            return _mapper.Map<ProfileView>(await _applicationUsersUnitOfWork.ApplicationUsers.GetUser(query.Id));
        }
    }
}

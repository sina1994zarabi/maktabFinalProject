﻿using App.Domain.Core.DTOs.ClientDto;
using App.Domain.Core.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Repository
{
    public interface IClientRepository
	{
		Task Add(CreateClientDto client,CancellationToken cancellation);
		Task<Client> Get(int id,CancellationToken cancellation);
		Task<List<Client>> GetAll(CancellationToken cancellation);
		Task<Client> GetClientInfo(int id, CancellationToken cancellation);
		Task Delete(int id, CancellationToken cancellation);
		Task Update(UpdateClientDto client, CancellationToken cancellation);
	}
}

using Application.Models;
using Application.Models.Requests;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IClienteService
    {
        Cliente Create(ClienteCreateRequest clienteCreateRequest);
        void Delete(int id);
        List<ClienteDto> GetAll();
        List<Cliente> GetAllFullData();
        ClienteDto GetById(int id);
        void Update(int id, ClienteUpdateRequest clienteUpdateRequest);
    }
}

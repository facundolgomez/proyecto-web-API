using Application.Models.Requests;
using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IMascotaService
    {
        MascotaDto Create(MascotaCreateRequest mascotaCreateRequest);
        void Update(int id, MascotaUpdateRequest mascotaUpdateRequest);
        void Delete(int id);
        List<MascotaDto> GetAll();
        
        MascotaDto GetById(int id);

        List<MascotaDto> GetPetsWithReservations();
    }
}

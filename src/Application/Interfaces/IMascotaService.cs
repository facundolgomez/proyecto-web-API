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
    public interface IMascotaService
    {
        Mascota Create(MascotaCreateRequest mascotaCreateRequest);
        void Delete(int id);
        List<MascotaDto> GetAll();
        List<Mascota> GetAllFullData();
        MascotaDto GetById(int id);
        void Update(int id, MascotaUpdateRequest mascotaUpdateRequest);
    }

}

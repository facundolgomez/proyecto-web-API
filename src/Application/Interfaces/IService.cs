using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IService<T, TCreateRequest, TUpdateRequest, TDto>
    {
        TDto Create(TCreateRequest createRequest);
        void Delete(int id);
        List<TDto> GetAll();
        List<T> GetAllFullData();
        TDto GetById(int id);
        void Update(int id, TUpdateRequest updateRequest);
    }
}

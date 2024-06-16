using Application.Interfaces;
using AutoMapper;
using Domain.Exceptions;
using Domain.Interfaces;

public class GenericService<T, TCreateRequest, TUpdateRequest, TDto> : IService<T, TCreateRequest, TUpdateRequest, TDto>
    where T : class
{
    private readonly IRepository<T> _repository;
    private readonly IMapper _mapper;

    public GenericService(IRepository<T> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper; //instancia de IMapper, que se utiliza para mapear entre diferentes tipos de objetos.
    }

    public TDto Create(TCreateRequest createRequest)
    {
        var entity = _mapper.Map<T>(createRequest); //mapea ClienteCreateRequest a una entidad cliente
        var addedEntity = _repository.Add(entity);
        var dto = _mapper.Map<TDto>(addedEntity); //mapea la entidad cliente agregada de vuelta a clienteDto para devolverla
        return dto; 
    }

    public void Delete(int id)
    {
        var entity = _repository.GetById(id);
        if (entity == null)
            throw new NotFoundException($"No se encontro esa entidad con el id {id}");

        _repository.Delete(entity);
    }

    public List<TDto> GetAll()
    {
        var entities = _repository.GetAll();
        return _mapper.Map<List<TDto>>(entities);
    }

    public List<T> GetAllFullData()
    {
        return _repository.GetAll();
    }

    public TDto GetById(int id)
    {
        var entity = _repository.GetById(id);
        if (entity == null)
            throw new NotFoundException($"No se encontro esa entidad con el id {id}");

        return _mapper.Map<TDto>(entity);
    }

    public void Update(int id, TUpdateRequest updateRequest)
    {
        var entity = _repository.GetById(id);
        if (entity == null)
            throw new NotFoundException($"No se encontro esa entidad con el id {id}");

        _mapper.Map(updateRequest, entity); // Aplica los cambios del request model a la entidad
        _repository.Update(entity);
    }
}

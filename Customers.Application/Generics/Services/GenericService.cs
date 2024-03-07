using AutoMapper;
using Customers.Application.Generics.Interfaces;
using Customers.Domain.Entities.Base;
using Customers.Domain.Interfaces;

namespace Customers.Application.Generics.Services
{
    public class GenericService<SaveDto,UpdateDto, Dto, Entity> : IGenericService<SaveDto,UpdateDto, Dto, Entity>
        where SaveDto : class
        where UpdateDto : class
        where Dto : class
        where Entity : class, IBase
    {
        private readonly IGenericRepository<Entity> _repository;
        private readonly IMapper _mapper;

        public GenericService(IGenericRepository<Entity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task Update(UpdateDto vm, int id)
        {
            Entity entity = _mapper.Map<Entity>(vm);
            entity.Id = id;
            await _repository.UpdateAsync(entity);
        }

        public virtual async Task<SaveDto> Add(SaveDto vm)
        {
            Entity entity = _mapper.Map<Entity>(vm);

            entity = await _repository.AddAsync(entity);

            SaveDto entityVm = _mapper.Map<SaveDto>(entity);

            return entityVm;
        }

        public virtual async Task Delete(int id)
        {
            await _repository.SoftDeleteAsync(id);
        }

        public virtual async Task<Dto> GetByIdDto(int id)
        {
            var entity = await _repository.GetByIdAsync(id);

            Dto vm = _mapper.Map<Dto>(entity);
            return vm;
        }

        public virtual async Task<List<Dto>> GetAllDto()
        {
            var entityList = await _repository.GetAllAsync();

            return _mapper.Map<List<Dto>>(entityList);
        }
    }
}

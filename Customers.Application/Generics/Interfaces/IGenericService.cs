namespace Customers.Application.Generics.Interfaces
{
    public interface IGenericService<SaveDto,UpdateDto, Dto, Entity>
        where SaveDto : class
        where UpdateDto : class
        where Dto : class
        where Entity : class
    {
        Task Update(UpdateDto vm, int id);

        Task<SaveDto> Add(SaveDto vm);

        Task Delete(int id);

        Task<Dto> GetByIdDto(int id);

        Task<List<Dto>> GetAllDto();
    }
}

namespace Customers.Application.Generics.Interfaces
{
    public interface IGenericService<SaveDto, Dto, Entity>
        where SaveDto : class
        where Dto : class
        where Entity : class
    {
        Task Update(SaveDto vm, int id);

        Task<SaveDto> Add(SaveDto vm);

        Task Delete(int id);

        Task<Dto> GetByIdDto(int id);

        Task<List<Dto>> GetAllDto();

        Task<List<Dto>> GetAllDtoWithPagination(int pageNumber, int pageSize);
    }
}

using Sooqak.DTO.PaginationDTO;

namespace Sooqak.Interface
{
    public interface IPaged<TOutput>
    {
        Task<PagedResult<TOutput>> GetPagedAsync(
        IQueryable<TOutput> query,
        int pageNumber,
        int pageSize
   );
    }
}

using Microsoft.EntityFrameworkCore;
using Sooqak.DTO.PaginationDTO;
using Sooqak.Interface;

namespace Sooqak.Services
{
    public class PagedService<TOutput> : IPaged<TOutput>
    {
        public async Task<PagedResult<TOutput>> GetPagedAsync(
            IQueryable<TOutput> query,
            int pageNumber,
            int pageSize)
        {
            var totalCount = await query.CountAsync();

            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<TOutput>
            {
                Items = items,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = totalCount
            };
        }
    }

}



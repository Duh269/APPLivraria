using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ILivroRepository
    {
        Task<IEnumerable<LivroDto>> GetAllAsync();
        Task<LivroDto> GetByIdAsync(int id);
        Task AddAsync(LivroDto livro);
        Task UpdateAsync(LivroDto livro);
        Task DeleteAsync(int id);
    }

}

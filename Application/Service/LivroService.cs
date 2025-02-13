using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{

    public interface ILivroService {

        Task<IEnumerable<LivroDto>> GetAllLivrosAsync();
        Task<LivroDto> GetLivroByIdAsync(int id);
        Task AddLivroAsync(LivroDto livro);
        Task UpdateLivroAsync(LivroDto livro);
        Task DeleteLivroAsync(int id);

    }

    public class LivroService : ILivroService
    {
        private readonly ILivroRepository _livroRepository;

        public LivroService(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public async Task<IEnumerable<LivroDto>> GetAllLivrosAsync() => await _livroRepository.GetAllAsync();
        public async Task<LivroDto> GetLivroByIdAsync(int id) => await _livroRepository.GetByIdAsync(id);
        public async Task AddLivroAsync(LivroDto livro) => await _livroRepository.AddAsync(livro);
        public async Task UpdateLivroAsync(LivroDto livro) => await _livroRepository.UpdateAsync(livro);
        public async Task DeleteLivroAsync(int id) => await _livroRepository.DeleteAsync(id);
    }
}

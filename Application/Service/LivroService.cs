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

        Task<IEnumerable<Livro>> GetAllLivrosAsync();
        Task<Livro> GetLivroByIdAsync(int id);
        Task AddLivroAsync(Livro livro);
        Task UpdateLivroAsync(Livro livro);
        Task DeleteLivroAsync(int id);

    }

    public class LivroService : ILivroService
    {
        private readonly ILivroRepository _livroRepository;

        public LivroService(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public async Task<IEnumerable<Livro>> GetAllLivrosAsync() => await _livroRepository.GetAllAsync();
        public async Task<Livro> GetLivroByIdAsync(int id) => await _livroRepository.GetByIdAsync(id);
        public async Task AddLivroAsync(Livro livro) => await _livroRepository.AddAsync(livro);
        public async Task UpdateLivroAsync(Livro livro) => await _livroRepository.UpdateAsync(livro);
        public async Task DeleteLivroAsync(int id) => await _livroRepository.DeleteAsync(id);
    }
}

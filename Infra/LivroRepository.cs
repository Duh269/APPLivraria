﻿using Domain.Entities;
using Domain.Interfaces;
using Infra;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private readonly AppDbContext _context;

        public LivroRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LivroDto>> GetAllAsync() => await _context.Livros.ToListAsync();
        public async Task<LivroDto> GetByIdAsync(int id) => await _context.Livros.FindAsync(id);
        public async Task AddAsync(LivroDto livro) { _context.Livros.Add(livro); await _context.SaveChangesAsync(); }
        public async Task UpdateAsync(LivroDto livro) { _context.Livros.Update(livro); await _context.SaveChangesAsync(); }
        public async Task DeleteAsync(int id)
        {
            var livro = await _context.Livros.FindAsync(id);
            if (livro != null) { _context.Livros.Remove(livro); await _context.SaveChangesAsync(); }
        }
    }
}

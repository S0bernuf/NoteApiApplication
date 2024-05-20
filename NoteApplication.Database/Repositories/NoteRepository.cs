using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApplication.Database.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly NoteDbContext _context;

        public NoteRepository(NoteDbContext context)
        {
            _context = context;
        }

        public async Task AddNoteAsync(Note note)
        {
            await _context.Notes.AddAsync(note);
            await _context.SaveChangesAsync();
        }

        public async Task<Note> GetNoteByIdAsync(int id)
        {
            return await _context.Notes.Include(n => n.User).FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task UpdateNoteAsync(Note note)
        {
            _context.Notes.Update(note);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteNoteAsync(Note note)
        {
            _context.Notes.Remove(note);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Note>> SearchNotesByTitleAsync(string title, int userId)
        {
            return await _context.Notes.Where(n => n.UserId == userId && n.Title.Contains(title)).ToListAsync();
        }

        public async Task<List<Note>> FilterNotesByCategoryAsync(int categoryId, int userId)
        {
            return await _context.Notes.Where(n => n.UserId == userId && n.CategoryId == categoryId).ToListAsync();
        }
    }
}

using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApplication.Database.Repositories
{
    public interface INoteRepository
    {
        Task AddNoteAsync(Note note);
        Task<Note> GetNoteByIdAsync(int id);
        Task UpdateNoteAsync(Note note);
        Task DeleteNoteAsync(Note note);
        Task<List<Note>> SearchNotesByTitleAsync(string title, int userId);
        Task<List<Note>> FilterNotesByCategoryAsync(int categoryId, int userId);
    }
}

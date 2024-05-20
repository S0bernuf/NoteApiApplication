using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoteApplication.BusinessLogic.Dtos;
using WepApi.Dtos;

namespace NoteApplication.BusinessLogic.Services
{
    public interface INoteService
    {
        Task<ServiceResponse<Note>> CreateNoteAsync(NoteCreate dto, string userName);
        Task<ServiceResponse<Note>> UpdateNoteAsync(NoteUpdate dto, string userName);
        Task<ServiceResponse<bool>> DeleteNoteAsync(int id, string userName);
        Task<ServiceResponse<List<Note>>> SearchNotesAsync(string title, string userName);
        Task<ServiceResponse<List<Note>>> FilterNotesByCategoryAsync(int categoryId, string userName);
    }
}

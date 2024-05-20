using DataAccess.Models;
using NoteApplication.Database.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoteApplication.BusinessLogic.Dtos;
using WepApi.Dtos;

namespace NoteApplication.BusinessLogic.Services
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;
        private readonly IUserRepository _userRepository;

        public NoteService(INoteRepository noteRepository, IUserRepository userRepository)
        {
            _noteRepository = noteRepository;
            _userRepository = userRepository;
        }

        public async Task<ServiceResponse<Note>> CreateNoteAsync(NoteCreate dto, string userName)
        {
            var user = await _userRepository.GetUserByNameAsync(userName);
            var note = new Note
            {
                Title = dto.Title,
                Text = dto.Text,
                PhotoPath = dto.PhotoPath,
                CategoryId = dto.CategoryId,
                UserId = user.Id
            };
            await _noteRepository.AddNoteAsync(note);

            return new ServiceResponse<Note> { Success = true, Data = note };
        }

        public async Task<ServiceResponse<Note>> UpdateNoteAsync(NoteUpdate dto, string userName)
        {
            var note = await _noteRepository.GetNoteByIdAsync(dto.Id);
            if (note == null || note.User.UserName != userName)
                return new ServiceResponse<Note> { Success = false, Message = "Note not found or access denied" };

            note.Title = dto.Title;
            note.Text = dto.Text;
            note.PhotoPath = dto.PhotoPath;
            note.CategoryId = dto.CategoryId;
            await _noteRepository.UpdateNoteAsync(note);

            return new ServiceResponse<Note> { Success = true, Data = note };
        }

        public async Task<ServiceResponse<bool>> DeleteNoteAsync(int id, string userName)
        {
            var note = await _noteRepository.GetNoteByIdAsync(id);
            if (note == null || note.User.UserName != userName)
                return new ServiceResponse<bool> { Success = false, Message = "Note not found or access denied" };

            await _noteRepository.DeleteNoteAsync(note);

            return new ServiceResponse<bool> { Success = true, Data = true };
        }

        public async Task<ServiceResponse<List<Note>>> SearchNotesAsync(string title, string userName)
        {
            var user = await _userRepository.GetUserByNameAsync(userName);
            var notes = await _noteRepository.SearchNotesByTitleAsync(title, user.Id);
            return new ServiceResponse<List<Note>> { Success = true, Data = notes };
        }

        public async Task<ServiceResponse<List<Note>>> FilterNotesByCategoryAsync(int categoryId, string userName)
        {
            var user = await _userRepository.GetUserByNameAsync(userName);
            var notes = await _noteRepository.FilterNotesByCategoryAsync(categoryId, user.Id);
            return new ServiceResponse<List<Note>> { Success = true, Data = notes };
        }
    }
}

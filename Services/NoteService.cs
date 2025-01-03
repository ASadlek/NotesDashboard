﻿using Microsoft.EntityFrameworkCore;
using Notes.Data;

namespace Notes.Services;

public class NoteService
{
    private readonly ApplicationDbContext _context;

    public NoteService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Note>> GetAllNotesAsync()
    {
        return await _context.Notes.ToListAsync();
    }

    public async Task<Note?> GetNoteByIdAsync(int id)
    {
        return await _context.Notes.FindAsync(id);
    }

    public async Task AddNoteAsync(Note note)
    {
        _context.Notes.Add(note);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateNoteAsync(Note note, string message)
    {
        //await store.SetPhoneNumberAsync(user, phoneNumber, CancellationToken).ConfigureAwait(false);
        //await store.SetPhoneNumberConfirmedAsync(user, false, CancellationToken).ConfigureAwait(false);
        //await UpdateSecurityStampInternal(user).ConfigureAwait(false);
        //return await UpdateUserAsync(user).ConfigureAwait(false);
        note.FirstName = message;
        _context.Notes.Update(note);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteNoteAsync(int id)
    {
        var note = await GetNoteByIdAsync(id);
        if (note != null)
        {
            _context.Notes.Remove(note);
            await _context.SaveChangesAsync();
        }
    }
}
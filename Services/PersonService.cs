using Microsoft.EntityFrameworkCore;
using Notes.Data;

namespace Notes.Services;

public class PersonService
{
    private readonly ApplicationDbContext _context;

    public PersonService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Person>> GetAllPeopleAsync()
    {
        return await _context.People.ToListAsync();
    }

    public async Task<Person?> GetPersonByIdAsync(int id)
    {
        return await _context.People.FindAsync(id);
    }

    public async Task AddPersonAsync(Person person)
    {
        _context.People.Add(person);
        await _context.SaveChangesAsync();
    }

    public async Task UpdatePersonAsync(Person person)
    {
        _context.People.Update(person);
        await _context.SaveChangesAsync();
    }

    public async Task DeletePersonAsync(int id)
    {
        var person = await GetPersonByIdAsync(id);
        if (person != null)
        {
            _context.People.Remove(person);
            await _context.SaveChangesAsync();
        }
    }
}
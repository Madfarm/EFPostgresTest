using EFPostTest.Data;
using EFPostTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFPostgresTest.Controllers;


[ApiController]
[Route("api/collections")]
public class JacketsController : ControllerBase
{
    private readonly PsqlDbContext _context;
    public JacketsController(PsqlDbContext context) 
    {
        _context = context;
    }

    
    [HttpGet]
    public async Task<ActionResult<List<Collection>>> Get()
    {
        var collections = await _context.CollectionsTable.ToListAsync();
        
        if (collections.Count != 0)
        {
            return collections;
        }

        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Jacket>> GetById(int id)
    {
        var jacket = await _context.JacketsTable.FindAsync(id);

        if (jacket is null)
        {
            return NoContent();
        }

        return jacket;
    }

    [HttpPost]
    public async Task<ActionResult<Jacket>> CreateJacket([FromBody] JacketDto jacketDto)
    {
        Jacket newJacket = new()
        {
            Price = jacketDto.Price,
            Size = jacketDto.Size,
            Material = jacketDto.Material,
        };

        await _context.JacketsTable.AddAsync(newJacket);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new {id = newJacket.Id}, newJacket);
    }


    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteJacket(int id)
    {
        var jacket = await _context.JacketsTable.FindAsync(id);

        if (jacket is null)
        {
            return NotFound();
        }

        _context.JacketsTable.Remove(jacket);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Jacket>> EditJacket(int id, JacketDto updated)
    {
        var jacket = await _context.JacketsTable.FindAsync(id);

        if (jacket is null) 
        {
            return NoContent();
        }

        jacket.Price = updated.Price;
        jacket.Size = updated.Size;
        jacket.Material = updated.Material;

        _context.Entry(jacket).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch(Exception e) 
        {
            Console.WriteLine(e);
        }

        return NoContent();
    }
}
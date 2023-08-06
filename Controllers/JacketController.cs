using EFPostTest.Data;
using EFPostTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFPostgresTest.Controllers;

[ApiController]
[Route("[controller]")]
public class JacketController : ControllerBase
{
    private readonly PsqlDbContext _context;
    public JacketController(PsqlDbContext context) 
    {
        _context = context;
    }

    // lets gooo
    [HttpGet]
    public async Task<ActionResult<List<Jacket>>> Get()
    {
        var jackets = await _context.JacketsTable.ToListAsync();
        
        if (jackets.Count != 0)
        {
            return jackets;
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
}
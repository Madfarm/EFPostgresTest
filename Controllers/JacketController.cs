using EFPostTest.Data;
using Microsoft.AspNetCore.Mvc;

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
}
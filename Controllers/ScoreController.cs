using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScoreAPI.DatabaseConnection;
using ScoreAPI.Entities;

namespace Controllers;

[Route("api/[controller]")]
[ApiController]
public class ScoreController : ControllerBase
{
    private readonly DataContext _context;

    public ScoreController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<ItemsWrapper>> GetTodoItems()
    {
        ItemsWrapper itens = new( 
            await _context.Scores
            .OrderByDescending(s => s.Points)
            .Take(10)
            .ToListAsync());
        return itens;
    }

    [HttpPost]
    public async Task<ActionResult<Score>> PostScore(string name, int points)
    {
        var score = new Score
        {
            Name = name,
            Points = points
        };

        var result = _context.Scores.Add(score);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(PostScore),
            new { id = result.Entity.Id}
        );
    }

    public class ItemsWrapper
    {
        public ItemsWrapper(List<Score> scores) => Scores = scores;

        public List<Score> Scores { get; set; }
    }
}
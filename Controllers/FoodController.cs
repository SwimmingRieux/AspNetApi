using FoodApi.Data;
using FoodApi.Models;
using FoodApi.DTOs.Food;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace FoodApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FoodController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public FoodController(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<Food>>> GetFoods()
    {
        return await _context.Foods.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Food>> GetFood(int id)
    {
        var food = await _context.Foods.FirstAsync(f => f.FoodId == id);
        if (food == null)
        {
            return NotFound();
        }

        return food;
    }

    [HttpPost]
    public async Task<ActionResult<Food>> AddFood(FoodCreate foodCreate)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var food = _mapper.Map<Food>(foodCreate);
        _context.Foods.Add(food);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetFood), new { id = food.FoodId }, food);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutFood(int id, FoodUpdate foodUpdate)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var food = await _context.Foods.FindAsync(id);
        if (food == null)
        {
            return NotFound();
        }

        _mapper.Map(foodUpdate, food);
        _context.Entry(food).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFood(int id)
    {
        var food = await _context.Foods.FindAsync(id);
        if (food == null)
        {
            return NotFound();
        }

        _context.Foods.Remove(food);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}

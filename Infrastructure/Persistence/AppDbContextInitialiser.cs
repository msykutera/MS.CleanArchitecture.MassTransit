using Microsoft.Extensions.Logging;

namespace Infrastructure.Persistence;

public class AppDbContextInitialiser
{
    private readonly ILogger<AppDbContextInitialiser> _logger;
    private readonly AppDbContext _context;

    public AppDbContextInitialiser(ILogger<AppDbContextInitialiser> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task TrySeedAsync()
    {
        // Default data
        // Seed, if necessary
        //if (!_context.TodoLists.Any())
        //{
        //    _context.TodoLists.Add(new TodoList
        //    {
        //        Title = "Todo List",
        //        Items =
        //        {
        //            new TodoItem { Title = "Make a todo list 📃" },
        //            new TodoItem { Title = "Check off the first item ✅" },
        //            new TodoItem { Title = "Realise you've already done two things on the list! 🤯"},
        //            new TodoItem { Title = "Reward yourself with a nice, long nap 🏆" },
        //        }
        //    });

        //    await _context.SaveChangesAsync();
        //}
    }
}

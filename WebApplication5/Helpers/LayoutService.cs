using Pustok.Contexts;
using Pustok.Models;

namespace Pustok.Helpers;

public class LayoutService
{
    PustokDbContext _context { get; }

    public LayoutService(PustokDbContext context)
    {
        _context = context;
    }

    public async Task<Setting> GetSettingsAsync()
        => await _context.Settings.FindAsync(1);
}

using TicketEntry.Shared.Entities;

namespace TicketEntry.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        public SeedDb(DataContext context)
        {
            _context = context;

        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync(); //si no hay bd la crea
            if (!_context.Tickets.Any())
            {
                //_context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Ticket ON");
                int id = 0;
                for (int i = 0; i < 50000; i++)
                {
                    id++;
                    if (i == 100) id += 100;
                    var ticket = new Ticket() { Used = false };

                    _context.Tickets.Add(ticket);

                }
                await _context.SaveChangesAsync();
                //_context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Ticket OFF");
            }

        }
    }
}

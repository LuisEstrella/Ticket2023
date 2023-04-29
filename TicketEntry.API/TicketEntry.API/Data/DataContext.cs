using Microsoft.EntityFrameworkCore;
using TicketEntry.Shared.Entities;

namespace TicketEntry.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Ticket> Tickets { get; set; }

    }
}

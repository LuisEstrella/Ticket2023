using TicketEntry.Shared.Enums;

namespace TicketEntry.Shared.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public DateTime? UseDate { get; set; }
        public bool Used { get; set; }
        public EntranceType? Entrance { get; set; }
    }
}

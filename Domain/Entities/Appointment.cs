using Barberia.Backend.Domain.Enums;

namespace Barberia.Backend.Domain.Entities
{
    public class Appointment    //CITA
    {
        public int Id { get; set; }
        public AppointmentStatus Status { get; set; }
        public int BarberId { get; set; }
        public Barber Barber { get; set; } = null!;
        public int ClientId { get; set; }
        public Client Client { get; set; } = null!;
        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; } = null!;
        public int ServiceId { get; set; }
        public Service Service { get; set; } = null!;
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

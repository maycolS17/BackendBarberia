namespace Barberia.Backend.Domain.Entities
{
    public class Schedule       //HORARIO
    {
        public int Id { get; set; }
        public int BarberId { get; set; }
        public Barber Barber { get; set; } = null!;
        public DateOnly WorkDate { get; set; }
        public TimeOnly TimeStart { get; set; }
        public TimeOnly TimeEnd { get; set; }
        public bool IsActive { get; private set; } = true;
        public void Deactivate()
        {
            IsActive = false;
        }
        public void Activate() 
        { 
            IsActive = true;
        }

    }
}

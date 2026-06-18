namespace Barberia.Backend.Domain.Entities
{
    public class Barber     //BARBERO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string? Specialty { get; set; }
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

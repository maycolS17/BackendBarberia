namespace Barberia.Backend.Domain.Entities
{
    public class Service        //SERVICIO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; }  = string.Empty;
        public decimal Price { get; set; }
        public int DurationMinutes { get; set; }
        public string? ImageUrl { get; set; }
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

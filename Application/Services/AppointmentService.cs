using Barberia.Backend.Application.Interfaces;
using Barberia.Backend.Domain.Entities;
using Barberia.Backend.Domain.Enums;

namespace Barberia.Backend.Application.Services
{
    public class AppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly ClientService _clientService;
        private readonly BarberService _barberService;
        private readonly ServiceCatalogService _serviceCatalogService;
        private readonly ScheduleService _scheduleService;

        public AppointmentService(IAppointmentRepository appointmentRepository, ClientService clientService, BarberService barberService, ServiceCatalogService serviceCatalogService, ScheduleService scheduleService)
        {
            _appointmentRepository = appointmentRepository;
            _clientService = clientService;
            _barberService = barberService;
            _scheduleService = scheduleService;
            _serviceCatalogService = serviceCatalogService;
        }

        public async Task<Appointment> CreateAsync(Appointment appointment, Client client, Barber barber, Service service, Schedule schedule)
        {

            //creando variables para obtener los datos exisitentes y validarlos
            var ExistingOrCreateClient = await _clientService.GetOrCreateAsync(client);

            var ExistingAndActiveBarber = await _barberService.GetByIdAsync(barber.Id);

            var ExistingAndActiveService = await _serviceCatalogService.GetByIdAsync(service.Id);

            var ExistingAndActiveScheldule = await _scheduleService.GetByIdAsync(schedule.Id);

            //validando que el horario y el barbero coincidan
            if (ExistingAndActiveScheldule.BarberId != ExistingAndActiveBarber.Id)
            {
                throw new Exception("El barbero no coincide con el horario seleccionado.");
            }

            //creando variables para cambiar el formato  de timeStart y timeEnd a DateTime para poder comparar con la fecha de inicio y fin de la cita
            var scheduleStart = ExistingAndActiveScheldule.WorkDate.ToDateTime(ExistingAndActiveScheldule.TimeStart);
            var scheduleEnd = ExistingAndActiveScheldule.WorkDate.ToDateTime(ExistingAndActiveScheldule.TimeEnd);


            //calculando la fecha de fin de la cita sumando el inicio de la cita con la duracion del servicio
            appointment.EndDateTime = appointment.StartDateTime.AddMinutes(ExistingAndActiveService.DurationMinutes);


            //validando que la fecha de inicio sea menor que la fecha de fin y que la cita este dentro del horario de trabajo
            if (appointment.EndDateTime <= appointment.StartDateTime)
            {
                throw new Exception("el fin de la cita debe ser mayor que el inicio de la cita");
            }

            if (appointment.StartDateTime < scheduleStart || appointment.EndDateTime > scheduleEnd)
            {
                throw new Exception("La cita no esta dentro del horario de trabajo");
            }

            //validando que la cita no se sobreponga con otra cita existente
            var ValidateAppointment = await _appointmentRepository.GetByBarberAndWorkDateAsync(ExistingAndActiveBarber.Id, ExistingAndActiveScheldule.WorkDate);

            foreach (var ExistingAppointment in ValidateAppointment)
            {
                if(appointment.StartDateTime < ExistingAppointment.EndDateTime && appointment.EndDateTime > ExistingAppointment.StartDateTime)
                {
                    throw new Exception("La cita se sobrepone sobre la cita existente");
                }
            }

            //actualizando los datos de la cita con los datos existentes
            appointment.ClientId = ExistingOrCreateClient.Id;
            appointment.BarberId = ExistingAndActiveBarber.Id;
            appointment.ServiceId = ExistingAndActiveService.Id;
            appointment.ScheduleId = ExistingAndActiveScheldule.Id;
            appointment.TotalPrice = ExistingAndActiveService.Price;
            appointment.Status = AppointmentStatus.PendingPayment;
            appointment.CreatedAt = DateTime.UtcNow;

            //crear la cita en base a los datos validados y actualizados
            var CreateAppointment = await _appointmentRepository.CreateAsync(appointment);

            return CreateAppointment;
        }

        public async Task<List<Appointment>> GetByStatusAsync(AppointmentStatus status)
        {
            var appointment = await _appointmentRepository.GetByStatusAsync(status);

            return appointment;
        }

        public async Task<Appointment> UpdateStatusAsync(int id, AppointmentStatus status)
        {
            var appointment = await _appointmentRepository.UpdateStatusAsync(id, status);

            return appointment;
        }

        public async Task<Appointment> GetByIdAsync(int id)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(id);

            if (appointment == null)
                throw new Exception("Cita no encontrada.");

            return appointment;
        }
    }
}

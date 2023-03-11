namespace FilmesApi.Data.Dtos
{
    public class ReadAddressDto
    {
        public Guid Uid { get; set; }
        public string LineOne { get; set; }
        public string LineTwo { get; set; }
        public int Number { get; set; }
        public DateTime AppointmentTime { get; set; } = DateTime.Now;
    }
}

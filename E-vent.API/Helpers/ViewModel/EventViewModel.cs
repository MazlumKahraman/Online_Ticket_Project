namespace E_vent.API.Helpers.ViewModel
{
	public class EventViewModel
	{
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime BegginigTime { get; set; }
        public DateTime LastAttendance { get; set; }
        public string Description { get; set; }
        public string Adress { get; set; } = null!;
        public decimal Price { get; set; }
        public string CategoryName { get; set; }
        public string CityName { get; set; }
        public int Quato { get; set; }

    }
}

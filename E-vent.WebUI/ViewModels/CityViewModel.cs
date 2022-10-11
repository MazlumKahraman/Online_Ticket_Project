namespace E_vent.WebUI.ViewModels
{
    public class CityViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public ICollection<EventViewModel> Events { get; set; }
    }
}

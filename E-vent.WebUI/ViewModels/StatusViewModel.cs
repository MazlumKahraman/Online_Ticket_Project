namespace E_vent.WebUI.ViewModels
{
    public class StatusViewModel
    {
        public int Id { get; set; }
        public string StatusName { get; set; }

        public ICollection<EventViewModel> Events { get; set; }
    }
}

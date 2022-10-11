namespace E_vent.WebUI.ViewModels
{
    public class ApiViewModel <T> where T : class
    {
        public T? Entity { get; set; }
        public string? ResponseMessage { get; set; }
        public bool Success { get; set; }
    }
}

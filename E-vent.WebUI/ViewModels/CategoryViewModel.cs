using System.Reflection.PortableExecutable;

namespace E_vent.WebUI.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<EventViewModel> Events { get; set; }
    }
}

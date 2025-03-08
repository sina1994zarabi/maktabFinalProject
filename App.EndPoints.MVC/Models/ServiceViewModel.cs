using App.Domain.Core.Entities.Services;

namespace App.EndPoints.MVC.Models
{
    public class ServiceViewModel
    {
        public List<Service> Services { get; set; }
        public List<Category> Categories { get; set; }
        public List<SubCategory> SubCategories { get; set; }
    }
}

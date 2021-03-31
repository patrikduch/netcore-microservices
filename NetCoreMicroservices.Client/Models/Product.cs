using System.ComponentModel.DataAnnotations;

namespace NetCoreMicroservices.Client.Models
{
    public class Product
    {
        public string Id { get; set; }
        [Display(Name="Název")]
        public string Name { get; set; }
        [Display(Name = "Kategorie")]
        public string Category { get; set; }
        [Display(Name = "Popis")]
        public string Description { get; set; }
        public string ImageFile { get; set; }
        public decimal Price { get; set; }
    }
}

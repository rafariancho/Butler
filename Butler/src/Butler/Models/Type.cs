using System.ComponentModel.DataAnnotations;

namespace Butler.Models
{
    public enum Type
    {
        [Display(Name = "Lunch")]
        Lunch,
        [Display(Name = "Dinner")]
        Dinner
    }
}
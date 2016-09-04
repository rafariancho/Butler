
using System.ComponentModel.DataAnnotations;

namespace Butler.Models
{
    public enum Consistency
    {
        [Display(Name = "Heavy meal")]
        Heavy,
        [Display(Name = "Normal meal")]
        Normal,
        [Display(Name = "Light meal")]
        Light
    }
}
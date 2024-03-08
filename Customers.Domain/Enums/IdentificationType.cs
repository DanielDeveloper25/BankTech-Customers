using System.ComponentModel.DataAnnotations;

namespace Customers.Domain.Enums
{
    public enum IdentificationType
    {
        [Display(Name = "IDCard")]
        IDCard = 1,
        [Display(Name = "Pasaport")]
        Pasaport
    }
}

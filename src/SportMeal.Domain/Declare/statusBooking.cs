using System.ComponentModel.DataAnnotations;

namespace SportMeal.Domain.Declare {
    public enum statusBooking : int
    {
        [Display(Name = "Создан")]
        Create = 1,

        [Display(Name = "Оплачен")]
        Payment = 2,

        [Display(Name = "Отменен")]
        Сancellation = 3,

        [Display(Name = "Завершен")]
        End = 4
    }
}

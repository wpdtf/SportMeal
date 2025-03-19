namespace Booking.UI.StaticModel;

public class CurrentUser
{
    public static string Role { get; set; } = "Админ";
    public static string FullName { get; set; }
    public static bool isClient { get; set; } = false;
    public static int ClientId { get; set; } = 0;
}


namespace SportMeal.Api;

/// <summary>
/// Набор настроек из appSetting.json
/// </summary>
public class AppSettings
{
    /// <summary>
    /// Строки подключения
    /// </summary>
    [ValidateObjectMembers]
    public ConnectionStrings ConnectionStrings { get; set; }

    /// <summary>
    /// Время на которое будет сохраняться запрос в кэше.
    /// </summary>
    public int RequestStorageTimeForMinutes { get; set; }
}

public class ConnectionStrings
{
    /// <summary>
    /// Подключение к MS SQL
    /// </summary>
    [Required]
    public string MsSqlConnection { get; set; }
}


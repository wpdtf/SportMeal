namespace SportMeal.Domain.Entities
{
    /// <summary>
    /// Модель для обработки и сохранения запроса при наличии ключа идемпотентности.
    /// </summary>
    public class IdempotentResponse
    {
        /// <summary>
        /// Статус код запроса.
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// Контент запроса для возврата данных.
        /// </summary>
        public string Content { get; set; }
    }
}

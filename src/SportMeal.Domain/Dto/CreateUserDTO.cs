namespace SportMeal.Domain.Dto
{
    public class CreateUserDTO
    {
        /// <summary>
        /// Логин
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Ключ записи
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Телефон клиента (если еще нет его ключа
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Дата актуальности данных
        /// </summary>
        public DateTime DateLactActual { get; set; }
    }
}

using SportMeal.Domain.Entities;
using Guna.UI2.WinForms;
using System.Text.RegularExpressions;
using LocalClient = SportMeal.Domain.Entities.Client;

namespace Booking.UI.FormDialog;

public partial class FormEditClient : Form
{
    private LocalClient ClientModel { get; set; }
    private FormClient ClientForm { get; set; }
    private FormAuth FormAuth { get; set; }
    private int Option { get; set; }

    public FormEditClient(int option, LocalClient clientModel, FormClient formClient = null, FormAuth formAuth = null)
    {
        InitializeComponent();
        ClientModel = clientModel;
        Option = option;
        ClientForm = formClient;
        FormAuth = formAuth;
    }

    private void FormEditStaff_Load(object sender, EventArgs e)
    {
        if (Option == 1)
        {
            if (FormAuth is not null)
            {
                guna2Button2.Text = "Зарегестрироваться";
                label1.Text = "Регистрация";

                guna2CheckBox1.Checked = false;
                guna2CheckBox1.Visible = false;
                guna2CheckBox2.Checked = false;
            }
            else
            {
                guna2Button2.Text = "Добавить";
                label1.Text = "Добавление";

                label5.Visible = false;
                label10.Visible = false;
                label13.Visible = false;
                guna2TextBox4.Visible = false;
                guna2TextBox9.Visible = false;
                guna2TextBox10.Visible = false;
                guna2CheckBox2.Visible = false;
            }
        }
        else
        {
            guna2TextBox1.Text = ClientModel.Last_name;
            guna2TextBox2.Text = ClientModel.First_name;
            guna2TextBox3.Text = ClientModel.Middle_name;
            guna2TextBox5.Text = ClientModel.Phone;
            guna2TextBox6.Text = ClientModel.Email;
            guna2TextBox7.Text = ClientModel.Passport;
            guna2TextBox8.Text = ClientModel.DriverLicense;
            guna2CheckBox1.Checked = ClientModel.Blocked;
            guna2DateTimePicker1.Value = ClientModel.Birthdate;
            guna2DateTimePicker2.Value = ClientModel.DateStartDriving;
            guna2Button2.Text = "Сохранить";
            label1.Text = "Изменение";

            label5.Visible = false;
            label10.Visible = false;
            guna2TextBox4.Visible = false;
            guna2TextBox9.Visible = false;
            guna2TextBox10.Visible = false;
            guna2CheckBox2.Visible = false;
        }
    }

    private async void guna2Button2_Click_1(object sender, EventArgs e)
    {
        if (!CheckValidation())
        {
            return;
        }

        LocalClient client = new()
        {
            ClientId = ClientModel.ClientId,
            Last_name = guna2TextBox1.Text,
            First_name = guna2TextBox2.Text,
            Middle_name = guna2TextBox3.Text,
            Birthdate = guna2DateTimePicker1.Value,
            Phone = guna2TextBox5.Text,
            Email = guna2TextBox6.Text,
            Passport = guna2TextBox7.Text,
            DriverLicense = guna2TextBox8.Text,
            DateStartDriving = guna2DateTimePicker2.Value,
            Blocked = guna2CheckBox1.Checked,
            Experience = 0
        };

        var api = new ApiClient<Staff>(new Uri("http://localhost:5000/api/booking-car"));
        await api.PutAsync("client/edit", client);

        if (FormAuth is not null)
        {
            await UpdateClientUser();
            return;
        }

        await ClientForm.UpdateDateAsync();
        this.Close();
        return;
    }

    private bool CheckValidation()
    {
        var validationMessage = "";

        if (string.IsNullOrEmpty(guna2TextBox1.Text))
        {
            validationMessage = "Фамилия не может быть пустой.";
        }

        if (guna2TextBox1.Text.Length < 2 || guna2TextBox1.Text.Length > 50)
        {
            validationMessage = "Фамилия должна содержать от 2 до 50 символов.";
        }

        if (ContainsDigits(guna2TextBox1.Text))
        {
            validationMessage = "Фамилия не может содержать цифры.";
        }

        if (string.IsNullOrEmpty(guna2TextBox2.Text))
        {
            validationMessage = "Имя не может быть пустым.";
        }

        if (guna2TextBox2.Text.Length < 2 || guna2TextBox2.Text.Length > 50)
        {
            validationMessage = "Имя должно содержать от 2 до 50 символов.";
        }

        if (ContainsDigits(guna2TextBox2.Text))
        {
            validationMessage = "Имя не может содержать цифры.";
        }

        if (ContainsDigits(guna2TextBox3.Text))
        {
            validationMessage = "Отчество не может содержать цифры.";
        }

        var phoneRegex = new Regex(@"^9\d{9}$");
        if (!phoneRegex.IsMatch(guna2TextBox5.Text))
        {
            validationMessage = "Номер телефона должен начинаться с 9 и содержать только цифры.";
        }

        var emailRegex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
        if (!emailRegex.IsMatch(guna2TextBox6.Text))
        {
            validationMessage = "Неправильная почта.";
        }

        if (guna2DateTimePicker1.Value > DateTime.Now.AddYears(-18))
        {
            validationMessage = "Маленький возраст.";
        }

        if (guna2DateTimePicker1.Value.AddYears(18) < guna2DateTimePicker1.Value)
        {
            validationMessage = "Водительский стаж считаем с 18 лет.";
        }

        if (FormAuth is not null)
        {
            if (validationMessage.Count() == 0)
            {
                validationMessage = ValidLoginPassword();
            }
        }

        if (validationMessage.Count() > 0)
        {
            MessageBox.Show(validationMessage, "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        return true;
    }

    /// <summary>
    /// Метод для проверки строки на наличие цифр.
    /// </summary>
    /// <param name="input">Строка для проверки.</param>
    /// <returns>True, если строка содержит цифры, иначе False.</returns>
    private bool ContainsDigits(string input)
    {
        return input.Any(char.IsDigit);
    }

    private async Task UpdateClientUser()
    {
        CreateUserDTO user = new()
        {
            Login = guna2TextBox4.Text,
            Password = HashPassword(guna2TextBox9.Text),
            Phone = guna2TextBox5.Text,
            DateLactActual = DateTime.Now.AddDays(60)
        };

        var api = new ApiClient<Staff>(new Uri("http://localhost:5000/api/booking-car"));
        if (await api.PutAsync("client/auth", user))
        {
            MessageBox.Show("Авторизуйтесь повторно!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            this.Close();
        }
    }

    private string HashPassword(string password)
    {
        byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(bytes);
    }

    private string ValidLoginPassword()
    {
        var login = guna2TextBox4.Text;
        var password = guna2TextBox9.Text;
        var validationMessage = "";

        if (string.IsNullOrWhiteSpace(login))
        {
            validationMessage = "Логин не может быть пустым.";
        }

        if (login.Length < 6)
        {
            validationMessage = "Логин должен содержать хотя бы 6 символов.";
        }

        if (!Regex.IsMatch(login, @"^[a-zA-Z0-9]+$"))
        {
            validationMessage = "Логин может содержать только латинские буквы и цифры.";
        }

        if (string.IsNullOrWhiteSpace(password))
        {
            validationMessage = "Пароль не может быть пустым.";
        }

        if (password.Length < 6)
        {
            validationMessage = "Пароль должен содержать хотя бы 6 символов.";
        }

        if (!Regex.IsMatch(password, @"[A-Z]"))
        {
            validationMessage = "Пароль должен содержать хотя бы одну заглавную букву.";
        }

        if (!Regex.IsMatch(password, @"[a-z]"))
        {
            validationMessage = "Пароль должен содержать хотя бы одну строчную букву.";
        }

        if (!Regex.IsMatch(password, @"[0-9]"))
        {
            validationMessage = "Пароль должен содержать хотя бы одну цифру.";
        }

        if (!(password == guna2TextBox10.Text))
        {
            validationMessage = "Пароль должен содержать хотя бы одну цифру.";
        }

        return validationMessage;
    }

    private void guna2CheckBox2_CheckedChanged(object sender, EventArgs e)
    {
        if (guna2CheckBox2.Checked)
        {
            guna2TextBox10.PasswordChar = '\0';
        }
        else
        {
            guna2TextBox10.PasswordChar = '*';

        }
    }
}

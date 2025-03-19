using System.Text.RegularExpressions;

namespace Booking.UI.FormDialog;

public partial class FormListLogin : Form
{
    private List<User> UserModel { get; set; }
    private int UserId { get; set; }
    private int ClientId { get; set; }

    public FormListLogin(int userId, int clientId)
    {
        InitializeComponent();
        UserId = userId;
        ClientId = clientId;
    }

    private async void FormEditStaff_Load(object sender, EventArgs e)
    {
        await UpdateAsync();
        guna2DateTimePicker1.Value = DateTime.Now.AddDays(30);
    }

    private async Task UpdateAsync()
    {
        var api = new ApiClient<List<User>>(new Uri("http://localhost:5000/api/booking-car"));

        if (UserId > 0)
        {
            UserModel = await api.GetAsync($"tech-support/auth?userId={UserId}&isFull=true");
            guna2DataGridView1.DataSource = UserModel;
        }
        else
        {
            UserModel = await api.GetAsync($"client/auth?userId={ClientId}");
            guna2DataGridView1.DataSource = UserModel;
        }
    }

    private async void guna2Button2_Click_1(object sender, EventArgs e)
    {
        if (!CheckValidation())
        {
            return;
        }

        CreateUserDTO user = new()
        {
            Login = guna2TextBox3.Text,
            Password = HashPassword(guna2TextBox4.Text),
            UserId = UserId,
            Phone = "",
            DateLactActual = guna2DateTimePicker1.Value
        };

        if (ClientId > 0)
        {
            user.UserId = ClientId;
        }

        var api = new ApiClient<User>(new Uri("http://localhost:5000/api/booking-car"));
        if (UserId > 0)
        {
            await api.PutAsync("tech-support/auth", user);
        }
        else
        {
            await api.PutAsync("client/auth", user);
        }
        await UpdateAsync();
    }

    private string HashPassword(string password)
    {
        byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(bytes);
    }

    private void guna2TextBox1_TextChanged(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(guna2TextBox1.Text))
        {
            var searchText = guna2TextBox1.Text.Trim().ToLower();

            var filters = UserModel
                .Where(p =>
                    p.Login.ToLower().Contains(searchText)
                )
                .ToList();

            guna2DataGridView1.DataSource = filters;
        }
        else
        {
            guna2DataGridView1.DataSource = UserModel;
        }
    }

    private bool CheckValidation()
    {
        var login = guna2TextBox3.Text;
        var password = guna2TextBox4.Text;
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

        if (guna2DateTimePicker1.Value < DateTime.Now)
        {
            validationMessage = "Дата окончания должна быть больше текущей даты.";
        }

        if (validationMessage.Count() > 0)
        {
            MessageBox.Show(validationMessage, "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        return true;
    }
}

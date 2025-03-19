using LocalClient = SportMeal.Domain.Entities.Client;

namespace Booking.UI.FormDialog;

public partial class FormAuth : Form
{
    public FormAuth()
    {
        InitializeComponent();
    }

    private void Guna2Button1_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }

    private string HashPassword(string password)
    {
        byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(bytes);
    }

    private async void Guna2Button2_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(guna2TextBox1.Text) || string.IsNullOrEmpty(guna2TextBox2.Text))
        {
            MessageBox.Show("Заполните логин и пароль.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var api = new ApiClient<LocalClient>(new Uri("http://localhost:5000/api/booking-car"));

        var authDto = new AuthDTO()
        {
            Login = guna2TextBox1.Text,
            Password = HashPassword(guna2TextBox2.Text)
        };

        var user = await api.PostAsync("client/auth", authDto);

        if (user is null)
        {
            return;
        }

        if (user.Blocked)
        {
            MessageBox.Show("Вас заблокировали, обратитесь к администратору.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        CurrentUser.FullName = user.Last_name + " " + user.First_name;
        CurrentUser.Role = "клиент";
        CurrentUser.isClient = true;
        CurrentUser.ClientId = user.ClientId;

        SelectedClient.First_name = user.First_name;
        SelectedClient.Last_name = user.First_name;
        SelectedClient.Phone = user.Phone;
        SelectedClient.ClientId = user.ClientId;

        FormMain formMain = new();
        formMain.Show();
        this.Hide();
    }

    private void label4_Click(object sender, EventArgs e)
    {
        FormEditClient formEdit = new(1, new(), formAuth: this);
        formEdit.ShowDialog();
    }

    private void guna2Button3_Click_1(object sender, EventArgs e)
    {
        Application.Exit();
    }

    private async void guna2Button4_Click_1(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(guna2TextBox4.Text) || string.IsNullOrEmpty(guna2TextBox3.Text))
        {
            MessageBox.Show("Заполните логин и пароль.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var api = new ApiClient<Auth>(new Uri("http://localhost:5000/api/booking-car"));

        var authDto = new AuthDTO()
        {
            Login = guna2TextBox4.Text,
            Password = HashPassword(guna2TextBox3.Text)
        };

        var user = await api.PostAsync("tech-support/auth", authDto);

        if (user is null)
        {
            return;
        }

        if (user.IsDelete)
        {
            MessageBox.Show("Вас удалили, обратитесь к администратору.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        CurrentUser.FullName = user.FullName;
        CurrentUser.Role = user.Position;
        CurrentUser.isClient = false;

        FormMain formMain = new();
        formMain.Show();
        this.Hide();
    }
}

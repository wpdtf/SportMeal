using System.Security.Cryptography;
using System.Windows.Forms;
using System.Text;
using SportMeal.UI.Client;
using SportMeal.UI.Domain.Models;
using Booking.UI;
using SportMeal.UI.StaticModel;

namespace SportMeal.UI.FormDialog;

public partial class FormAuth : Form
{
    private readonly ApiClient _apiClient;

    public FormAuth(ApiClient apiClient)
    {
        InitializeComponent();
        _apiClient = apiClient;
    }

    private string HashPassword(string password)
    {
        byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(bytes);
    }

    private void Guna2Button1_Click_1(object sender, EventArgs e)
    {
        Application.Exit();
    }

    private async void Guna2Button2_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(guna2TextBox1.Text) || string.IsNullOrEmpty(guna2TextBox2.Text))
        {
            MessageBox.Show("Заполните логин и пароль.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var request = new AuthDTO()
        {
            Login = guna2TextBox1.Text,
            Password = HashPassword(guna2TextBox2.Text)
        };

        try
        {
            var result = await _apiClient.AuthenticateAsync(request);

            if (result is Clients or Employee)
            {
                FormMain formMain = new(_apiClient);
                formMain.Show();
                this.Hide();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void label4_Click(object sender, EventArgs e)
    {
        FormRegister form = new(_apiClient);
        form.Show();
    }
}

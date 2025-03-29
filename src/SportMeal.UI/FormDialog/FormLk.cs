using SportMeal.UI.Client;
using SportMeal.UI.customElement;
using SportMeal.UI.Domain.Models;
using SportMeal.UI.StaticModel;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SportMeal.UI.FormDialog;

public partial class FormLk : Form
{
    private readonly ApiClient _apiClient;
    private readonly FormMain _mainForm;
    private Clients _client;
    private int ClientId;
    private bool IsFullUpdate = false;

    public FormLk(ApiClient apiClient, FormMain mainForm, int idClient)
    {
        InitializeComponent();
        ClientId = idClient;
        _apiClient = apiClient;
        _mainForm = mainForm;
        UpdateInfoClientAsync();
    }

    private async Task UpdateInfoClientAsync()
    {
        try
        {
            _client = await _apiClient.GetClientIfnoAync(ClientId);

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        _txtFirstName.Text = _client.FirstName;
        _txtLastName.Text = _client.LastName;
        _txtPhone.Text = _client.Phone;
        _txtEmail.Text = _client.Email;
        Height.Text = _client.Height.ToString();
        Weight.Text = _client.Weight.ToString();

        status1.Checked = _client.Goal == "Похудеть";
        status2.Checked = _client.Goal == "Накачаться";
        status3.Checked = _client.Goal == "Поддержка";

        datebirth.Value = _client.DateBirth;
    }

    private async void _btnClose_Click(object sender, EventArgs e)
    {
        await UpdateClose();
        this.Close();
    }

    private async void FormRegister_FormClosing(object sender, FormClosingEventArgs e)
    {
        await UpdateClose();
    }

    public async Task UpdateClose()
    {
        if (IsFullUpdate)
        {
            await _mainForm.UploadFormAsync();
            await _mainForm.UploadProductAsync();
            await _mainForm.UploadOrderAsync();
        }
    }

    private void FormLk_Load(object sender, EventArgs e)
    {

    }

    private async void _btnCancel_Click_1(object sender, EventArgs e)
    {
        this.Close();
    }

    private async void _btnRegister_Click(object sender, EventArgs e)
    {
        if (!ValidateFields())
        {
            return;
        }

        var editClient = new Clients()
        {
            Id = ClientId,
            FirstName = _txtFirstName.Text,
            LastName = _txtLastName.Text,
            Phone = _txtPhone.Text,
            Email = _txtEmail.Text,
            DateBirth = datebirth.Value,
            Height = Convert.ToDecimal(Height.Text),
            Weight = Convert.ToDecimal(Weight.Text),
            Goal = status1.Checked ? "Похудеть" : status2.Checked ? "Накачаться" : "Поддержка"
        };

        try
        {
            await _apiClient.UpdateAsync(ClientId, editClient);

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        
        IsFullUpdate = true;
        this.Close();
    }

    private bool ValidateFields()
    {
        if (string.IsNullOrWhiteSpace(_txtFirstName.Text))
        {
            MessageBox.Show("Введите имя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            _txtFirstName.Focus();
            return false;
        }

        if (!(new Regex(@"^[а-яА-Я]+$")).IsMatch(_txtFirstName.Text))
        {
            MessageBox.Show("Введите корректное имя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            _txtFirstName.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(_txtLastName.Text))
        {
            MessageBox.Show("Введите фамилию", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            _txtLastName.Focus();
            return false;
        }

        if (!(new Regex(@"^[а-яА-Я]+$")).IsMatch(_txtLastName.Text))
        {
            MessageBox.Show("Введите корректную фамилию", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            _txtLastName.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(_txtEmail.Text))
        {
            MessageBox.Show("Введите email", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            _txtEmail.Focus();
            return false;
        }


        if (!(new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")).IsMatch(_txtEmail.Text))
        {
            MessageBox.Show("Введите корректный email", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            _txtEmail.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(_txtPhone.Text))
        {
            MessageBox.Show("Введите номер телефона", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            _txtPhone.Focus();
            return false;
        }

        var phoneRegex = new Regex(@"^9\d{9}$");
        if (!phoneRegex.IsMatch(_txtPhone.Text))
        {
            MessageBox.Show("Номер телефона должен начинаться с 9 и содержать еще 9 цифр", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            _txtPhone.Focus();
            return false;
        }

        if (!Regex.IsMatch(Height.Text, @"^\d+,\d+$") && !IsValidNumber(Height.Text))
        {
            MessageBox.Show("Необходимо указать корректный рост.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            _txtPhone.Focus();
            return false;
        }

        if (!Regex.IsMatch(Weight.Text, @"^\d+,\d+$") && !IsValidNumber(Weight.Text))
        {
            MessageBox.Show("Необходимо указать корректный вес.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            _txtPhone.Focus();
            return false;
        }

        return true;
    }

    static bool IsValidNumber(string text)
    {
        if (decimal.TryParse(text, NumberStyles.Any, CultureInfo.GetCultureInfo("ru-RU"), out decimal num))
        {
            return num >= 30m && num <= 220m;
        }
        return false;
    }
} 
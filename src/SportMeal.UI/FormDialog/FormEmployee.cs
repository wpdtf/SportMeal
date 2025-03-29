using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Suite;
using SportMeal.UI.Client;
using SportMeal.UI.Domain.Models;
using SportMeal.UI.StaticModel;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace SportMeal.UI.FormDialog;

public partial class FormEmployee : Form
{
    private readonly ApiClient _apiClient;
    private readonly FormList _mainForm;
    private Employee _employee;
    private bool IsCreate;

    public FormEmployee(ApiClient apiClient, FormList mainForm, Employee? employee)
    {
        InitializeComponent();
        IsCreate = employee == null;
        _employee = employee;
        _apiClient = apiClient;
        _mainForm = mainForm;

        if (IsCreate)
        {
            _btnRegister.Text = "Создать";
        }
        else
        {
            _btnRegister.Text = "Сохранить";
            _txtFirstName.Text = _employee.FirstName;
            _txtLastName.Text = _employee.LastName;
            _txtPhone.Text = _employee.Phone;
            _txtEmail.Text = _employee.Email;
            UpdateLogin();

            status1.Checked = _employee.Position == "Менеджер по продажам";
            status2.Checked = _employee.Position == "Старший менеджер";
            status3.Checked = _employee.Position == "Админ";
        }
    }

    private async void FormRegister_FormClosing(object sender, FormClosingEventArgs e)
    {
        await UpdateClose();
    }

    public async Task UpdateLogin()
    {
        try
        {
            _txtLogin.Text = await _apiClient.GetLoginAsync(_employee.Id);
            _employee.Users = new User() { Login = _txtLogin.Text };
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
    }

    public async Task UpdateClose()
    {
        var listCateg = new List<Employee>();

        try
        {
            listCateg = await _apiClient.GetEmployeeAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        await _mainForm.UploadDataAsync(listCateg);
    }

    private async void _btnRegister_Click(object sender, EventArgs e)
    {
        if (!ValidateFields())
        {
            return;
        }

        var editEmployee = new Employee()
        {
            Id = IsCreate ? 0 : _employee.Id,
            FirstName = _txtFirstName.Text,
            LastName = _txtLastName.Text,
            Email = _txtEmail.Text,
            Phone = _txtPhone.Text,
            UserId = IsCreate ? 0 : _employee.UserId,
            Position = status1.Checked ? "Менеджер по продажам" : status2.Checked ? "Старший менеджер" : "Админ",
            Users = new User()
            {
                Login = _txtLogin.Text,
                PasswordHash = HashPassword(_txtPassword.Text)
            }
        };

        try
        {
            if (IsCreate)
            {
                await _apiClient.CreateAsync(editEmployee);
            }
            else
            {
                await _apiClient.UpdateAsync(editEmployee);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (!IsCreate)
        {
            if (_txtLogin.Text != _employee.Users.Login)
            {
                var employeeDto = new EmployeeDto()
                {
                    EmployeeId = _employee.Id,
                    Login = _txtLogin.Text,
                    Password = HashPassword(_txtPassword.Text)
                };

                try
                {
                    await _apiClient.UpdateAsync(employeeDto);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }

        this.Close();
    }

    private bool ValidateFields()
    {
        if (string.IsNullOrWhiteSpace(_txtLogin.Text))
        {
            MessageBox.Show("Введите логин", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            _txtLogin.Focus();
            return false;
        }

        if (_txtLogin.Text != _employee.Users.Login && string.IsNullOrWhiteSpace(_txtPassword.Text))
        {
            MessageBox.Show("Введите пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            _txtPassword.Focus();
            return false;
        }

        if (_txtLogin.Text != _employee.Users.Login && _txtPassword.Text != _txtPasswordConfirm.Text)
        {
            MessageBox.Show("Пароли не совпадают", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            _txtPasswordConfirm.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(_txtFirstName.Text))
        {
            MessageBox.Show("Введите имя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            _txtFirstName.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(_txtLastName.Text))
        {
            MessageBox.Show("Введите фамилию", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            _txtLastName.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(_txtEmail.Text))
        {
            MessageBox.Show("Введите email", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            _txtEmail.Focus();
            return false;
        }

        var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        if (!emailRegex.IsMatch(_txtEmail.Text))
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

        return true;
    }

    private void _btnCancel_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private string HashPassword(string password)
    {
        byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(bytes);
    }

    private void guna2CheckBox2_CheckedChanged(object sender, EventArgs e)
    {
        if (guna2CheckBox2.Checked)
        {
            _txtPassword.PasswordChar = '\0';
        }
        else
        {
            _txtPassword.PasswordChar = '●';

        }
    }
} 
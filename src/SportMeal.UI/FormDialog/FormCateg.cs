using SportMeal.UI.Client;
using System.Globalization;
using System.Text.RegularExpressions;

namespace SportMeal.UI.FormDialog;

public partial class FormCateg : Form
{
    private readonly ApiClient _apiClient;
    private readonly FormList _mainForm;
    private Category _categ;
    private bool IsCreate;

    public FormCateg(ApiClient apiClient, FormList mainForm, Category? categ)
    {
        InitializeComponent();
        IsCreate = categ == null;
        _categ = categ;
        _apiClient = apiClient;
        _mainForm = mainForm;

        if (IsCreate)
        {
            _btnRegister.Text = "Создать";
        }
        else
        {
            _btnRegister.Text = "Сохранить";
            _Name.Text = _categ.Name;
            _Description.Text = _categ.Description;
        }
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
        var listCateg = new List<Category>();

        try
        {
            listCateg = await _apiClient.GetCategoriesAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        await _mainForm.UploadDataAsync(listCateg);
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

        var editCateg = new Category()
        {
            Id = IsCreate ? 0 : _categ.Id,
            Name = _Name.Text,
            Description = _Description.Text
        };

        try
        {
            if (IsCreate)
            {
                await _apiClient.CreateAsync(editCateg);
            }
            else
            {
                await _apiClient.UpdateAsync(editCateg);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        
        this.Close();
    }

    private bool ValidateFields()
    {
        if (string.IsNullOrWhiteSpace(_Name.Text))
        {
            MessageBox.Show("Введите имя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            _Name.Focus();
            return false;
        }

        if (!(new Regex(@"^[а-яА-Я]+$")).IsMatch(_Name.Text))
        {
            MessageBox.Show("Введите корректное имя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            _Name.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(_Description.Text))
        {
            MessageBox.Show("Введите фамилию", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            _Description.Focus();
            return false;
        }

        return true;
    }
} 
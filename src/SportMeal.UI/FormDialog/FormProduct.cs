using SportMeal.UI.Client;
using SportMeal.UI.customElement;
using System.Globalization;
using System.Text.RegularExpressions;

namespace SportMeal.UI.FormDialog;

public partial class FormProduct : Form
{
    private readonly ApiClient _apiClient;
    private readonly FormList _mainForm;
    private Product _product;
    private bool IsCreate;
    private List<Category> _listCateg;

    public event Action<CustomCheckBoxItem> SelectionChanged;
    private CustomCheckBoxItem _selectedItem = default;
    public CustomCheckBoxItem GetSelectedItem() => _selectedItem;

    public FormProduct(ApiClient apiClient, FormList mainForm, Product? product)
    {
        InitializeComponent();
        IsCreate = product == null;
        _product = product;
        _apiClient = apiClient;
        _mainForm = mainForm;

        if (IsCreate)
        {
            _btnRegister.Text = "Создать";
        }
        else
        {
            _btnRegister.Text = "Сохранить";
            _Name.Text = _product.Name;
            _Description.Text = _product.Description;
            Amount.Text = _product.Price.ToString();
            Count.Text = _product.StockQuantity.ToString();
        }

        UpdateCategories();
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
        var listCateg = new List<Product>();

        try
        {
            listCateg = await _apiClient.GetProductsAsync();
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

        var editProduct = new Product()
        {
            Id = IsCreate ? 0 : _product.Id,
            Name = _Name.Text,
            Description = _Description.Text,
            Price = Convert.ToDecimal(Amount.Text),
            StockQuantity = Convert.ToInt32(Count.Text),
            CategoryId = _selectedItem.ItemId
        };

        try
        {
            if (IsCreate)
            {
                await _apiClient.CreateAsync(editProduct);
            }
            else
            {
                await _apiClient.UpdateAsync(editProduct);
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

        if (string.IsNullOrWhiteSpace(_Description.Text))
        {
            MessageBox.Show("Введите фамилию", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            _Description.Focus();
            return false;
        }

        if (!Regex.IsMatch(Amount.Text, @"^\d+,\d+$") && !IsValidNumberDecimal(Amount.Text))
        {
            MessageBox.Show("Необходимо указать корректную стоимость.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Amount.Focus();
            return false;
        }

        if (!Regex.IsMatch(Count.Text, @"^\d$") && !IsValidNumberInt(Count.Text))
        {
            MessageBox.Show("Необходимо указать корректное количество.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Count.Focus();
            return false;
        }

        if (_selectedItem is null)
        {
            MessageBox.Show("Необходимо указать категорию товара.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Count.Focus();
            return false;
        }

        return true;
    }

    static bool IsValidNumberInt(string text)
    {
        if (int.TryParse(text, NumberStyles.Any, CultureInfo.GetCultureInfo("ru-RU"), out int num))
        {
            return num >= 0 && num <= int.MaxValue;
        }
        return false;
    }

    static bool IsValidNumberDecimal(string text)
    {
        if (decimal.TryParse(text, NumberStyles.Any, CultureInfo.GetCultureInfo("ru-RU"), out decimal num))
        {
            return num >= 0m && num <= decimal.MaxValue;
        }
        return false;
    }

    private async Task UpdateCategories()
    {
        try
        {
            _listCateg = await _apiClient.GetCategoriesAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        flowLayoutPanel1.Controls.Clear();

        foreach (var categ in _listCateg)
        {
            var customItem = new CustomCheckBoxItem(categ.Name, categ.Id, categ.BeLike)
            {
                Cursor = Cursors.Hand
            };

            customItem.CheckBox.CheckedChanged += (s, e) =>
            {
                if (customItem.IsChecked)
                {
                    if (_selectedItem != null && _selectedItem != customItem)
                    {
                        _selectedItem.IsChecked = false;
                    }
                    _selectedItem = customItem;
                    SelectionChanged?.Invoke(customItem);
                }
                else if (_selectedItem == customItem)
                {
                    _selectedItem = null;
                    SelectionChanged?.Invoke(null);
                }
            };

            customItem.Click += (s, e) =>
            {
                customItem.CheckBox.Checked = !customItem.CheckBox.Checked;
            };

            customItem.CheckBox.Checked = _product is not null && _product.CategoryId == categ.Id;

            flowLayoutPanel1.Controls.Add(customItem);
        }
    }
} 
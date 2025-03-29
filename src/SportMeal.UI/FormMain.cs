using SportMeal.UI.Client;
using SportMeal.UI.customElement;
using SportMeal.UI.Domain.Models;
using SportMeal.UI.FormDialog;
using SportMeal.UI.StaticModel;
using System.Windows.Forms;

namespace SportMeal.UI;

public partial class FormMain : Form
{
    private Form _acriveForm;
    private readonly ApiClient _apiClient;
    public event Action<CustomCheckBoxItem> SelectionChanged;
    private CustomCheckBoxItem _selectedItem = default;
    private List<Category> _listCateg;
    private List<Order> _listOrder;
    private List<Product> _product;

    public CustomCheckBoxItem GetSelectedItem() => _selectedItem;

    public FormMain(ApiClient азiClient)
    {
        InitializeComponent();
        _apiClient = азiClient;
    }

    private async void FormMain_Load(object sender, EventArgs e)
    {
        SetAccess(CurrentUser.Position);
        await UploadFormAsync();
        await UploadProductAsync();
        await UploadOrderAsync();
    }

    private void SetAccess(string role)
    {
        switch (role.ToLower())
        {
            case "менеджер по продажам":
                guna2Button7.Dispose();
                Guna2Button2.Text = "Отчеты";
                break;
            case "старший менеджер":
                guna2Button7.Dispose();
                Guna2Button2.Text = "Отчеты";
                Guna2Button2.Enabled = false;
                break;
            case "админ":
                Guna2Button2.Text = "Отчеты";
                break;
            case "":
                guna2Button7.Dispose();
                guna2Button6.Dispose();
                guna2Button5.Dispose();
                guna2Button4.Dispose();
                break;
        }
    }

    public async Task UploadFormAsync()
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

            // Можно добавить обработчики событий
            customItem.CheckBox.CheckedChanged += (s, e) =>
            {
                if (customItem.IsChecked)
                {
                    // Снимаем выделение с предыдущего элемента
                    if (_selectedItem != null && _selectedItem != customItem)
                    {
                        _selectedItem.IsChecked = false;
                    }
                    _selectedItem = customItem;
                    SelectionChanged?.Invoke(customItem);
                }
                else if (_selectedItem == customItem)
                {
                    // Если сняли выделение с текущего выбранного
                    _selectedItem = null;
                    SelectionChanged?.Invoke(null);
                }
                UploadProductAsync();
            };

            customItem.Click += (s, e) =>
            {
                customItem.CheckBox.Checked = !customItem.CheckBox.Checked;
            };

            flowLayoutPanel1.Controls.Add(customItem);
        }
    }

    public async Task UploadProductAsync()
    {
        try
        {
            if (_selectedItem is null)
            {
                _product = await _apiClient.GetProductsAsync();
            }
            else
            {
                _product = await _apiClient.GetProductsAsync(_selectedItem.ItemId);
            }

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        flowLayoutPanel2.Controls.Clear();

        foreach (var item in _product)
        {
            var customItem = new CustomProductItem(item.Id, item.Name, _listCateg.FirstOrDefault(i => i.Id == item.CategoryId).Name, item.Description, item.Price, item.BeLike)
            {
            };

            customItem.AddToOrderButton.Click += (s, e) =>
            {
                AddToOrderAsync(customItem.ProductId, item.Price);
            };

            customItem.AddToOrderButton.Enabled = CurrentUser.Position == "" ? true : false;

            flowLayoutPanel2.Controls.Add(customItem);
        }
    }

    public async Task UploadOrderAsync()
    {
        try
        {
            if (CurrentUser.Position == "")
            {
                _listOrder = await _apiClient.GetClientOrdersAsync(CurrentUser.Id);
            }
            else
            {
                _listOrder = await _apiClient.GetClientOrdersAsync();
            }

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        flowLayoutPanel3.Controls.Clear();

        foreach (var item in _listOrder)
        {
            var customItem = new CustomOrder(item.Id, item.OrderDate, item.TotalAmount, item.Status)
            {
            };

            customItem.EditButton.Visible = item.Status == OrderStatus.Новый && CurrentUser.Position == "" ? true : false;

            customItem.EditButton.Click += (s, e) =>
            {
                EditOrderItem(item.Id);
            };

            flowLayoutPanel3.Controls.Add(customItem);
        }
    }

    private async Task AddToOrderAsync(int idProduct, decimal unitPrice)
    {
        var orderItem = _listOrder.FirstOrDefault(i => i.Status == OrderStatus.Новый);

        if (orderItem == null)
        {
            var newOrder = new Order()
            {
                ClientId = CurrentUser.Id,
                OrderDate = DateTime.Now,
                TotalAmount = 0,
                Status = OrderStatus.Новый
            };

            orderItem = await _apiClient.CreateAsync(newOrder);
        }

        var item = new OrderItem()
        {
            OrderId = orderItem.Id,
            ProductId = idProduct,
            Quantity = 1,
            UnitPrice = unitPrice
        };

        await _apiClient.CreateAsync(orderItem.Id, item);

        await UploadOrderAsync();
    }

    private void guna2ControlBox2_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }

    private async void EditOrderItem(int orderId)
    {
        FormEditOrderItem form = new(_apiClient, this, orderId);
        form.Show();
    }

    private void guna2Button4_Click_1(object sender, EventArgs e)
    {
        //продукты
        FormList form = new(this, _apiClient, _product);
        form.Show();
    }

    private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
    {

    }

    private void Guna2Button2_Click(object sender, EventArgs e)
    {
        if (CurrentUser.Position == "")
        {
            FormLk form = new(_apiClient, this, CurrentUser.Id);
            form.Show();
        }
        else
        {
            //Отчеты
            FormList form = new(this, _apiClient, null);
            form.Show();
        }
    }

    private void guna2Button5_Click(object sender, EventArgs e)
    {
        //категории
        FormList form = new(this, _apiClient, _listCateg);
        form.Show();
    }

    private async void guna2Button7_Click(object sender, EventArgs e)
    {
        //сотрудники
        var listEmployee = new List<Employee>();

        try
        {
            listEmployee = await _apiClient.GetEmployeeAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        FormList form = new(this, _apiClient, listEmployee);
        form.Show();
    }

    private void guna2Button6_Click(object sender, EventArgs e)
    {
        //заказы
        FormList form = new(this, _apiClient, _listOrder);
        form.Show();
    }
}

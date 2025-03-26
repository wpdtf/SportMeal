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
                break;
            case "старший менеджер":
                guna2Button7.Dispose();
                break;
            case "":
                guna2Button7.Dispose();
                guna2Button6.Dispose();
                guna2Button5.Dispose();
                guna2Button4.Dispose();
                break;
        }
    }

    private async Task UploadFormAsync()
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
            var customItem = new CustomCheckBoxItem(categ.Name, categ.Id)
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

    private async Task UploadProductAsync()
    {
        var product = new List<Product>();
        try
        {
            if (_selectedItem is null)
            {
                product = await _apiClient.GetProductsAsync();
            }
            else
            {
                product = await _apiClient.GetProductsAsync(_selectedItem.ItemId);
            }

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        flowLayoutPanel2.Controls.Clear();

        foreach (var item in product)
        {
            var customItem = new CustomProductItem(item.Id, item.Name, _listCateg.FirstOrDefault(i => i.Id == item.CategoryId).Name, item.Description, item.Price)
            {
            };

            customItem.AddToOrderButton.Click += (s, e) =>
            {
                AddToOrderAsync(customItem.ProductId, item.Price);
            };

            customItem.AddToOrderButton.Visible = CurrentUser.Position == "" ? true : false;

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

            customItem.EditButton.Visible = item.Status == OrderStatus.Новый ? true : false;

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

            orderItem = await _apiClient.CreateOrderAsync(newOrder);
        }

        var item = new OrderItem()
        {
            OrderId = orderItem.Id,
            ProductId = idProduct,
            Quantity = 1,
            UnitPrice = unitPrice
        };

        await _apiClient.AddItemInOrderAsync(orderItem.Id, item);

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

    }

    private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
    {

    }
}

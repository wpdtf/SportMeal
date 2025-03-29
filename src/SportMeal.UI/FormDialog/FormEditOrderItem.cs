using SportMeal.UI.Client;
using SportMeal.UI.customElement;
using SportMeal.UI.Domain.Models;
using SportMeal.UI.StaticModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SportMeal.UI.FormDialog;

public partial class FormEditOrderItem : Form
{
    private readonly ApiClient _apiClient;
    private readonly FormMain _mainForm;
    private int OrderId;

    public FormEditOrderItem(ApiClient apiClient, FormMain mainForm, int orderId)
    {
        InitializeComponent();
        OrderId = orderId;
        _apiClient = apiClient;
        _mainForm = mainForm;
        UpdateInfoOrder();
        UpdateOrderItem();
    }

    private async Task UpdateOrderItem()
    {
        var listOrderItem = new List<OrderItemFull>();

        try
        {
            listOrderItem = await _apiClient.GetOrderItemFullAsync(OrderId);

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        flowLayoutPanel1.Controls.Clear();

        foreach (var item in listOrderItem)
        {
            var customItem = new CustomOrderItem(item.Id, item.ProductId, item.Name, item.Category, item.Quantity, item.UnitPrice)
            {
            };

            customItem.AddButton.Click += (s, e) =>
            {
                UpdateQuantity(customItem.OrderItemId, customItem.ProductId, customItem.Quantity + 1, customItem.UnitPrice / customItem.Quantity * (customItem.Quantity + 1));
            };

            customItem.DeleteButton.Click += (s, e) =>
            {
                if (customItem.Quantity - 1 == 0)
                {
                    DeleteOrderItem(customItem.OrderItemId);
                }
                else
                {
                    UpdateQuantity(customItem.OrderItemId, customItem.ProductId, customItem.Quantity - 1, customItem.UnitPrice / customItem.Quantity * (customItem.Quantity - 1));
                }
            };

            flowLayoutPanel1.Controls.Add(customItem);
        }
    }

    public async Task UpdateInfoOrder()
    {
        var order = new Order();

        try
        {
            order = await _apiClient.GetOrderInfo(OrderId);

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        label3.Text = $"Просмотр заказа: {order.Id}";
        _lblPhone.Text = $"к оплате {order.TotalAmount} руб.";
    }

    public async Task DeleteOrderItem(int ItemId)
    {
        try
        {
            await _apiClient.DeleteAsync(ItemId);

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        await UpdateInfoOrder();
        await UpdateOrderItem();
    }

    private async Task UpdateQuantity(int itemId, int productId, int quantity, decimal unitPrice)
    {
        var orderItem = new OrderItem()
        {
            OrderId = OrderId,
            Id = itemId,
            ProductId = productId,
            Quantity = quantity,
            UnitPrice = unitPrice
        };

        try
        {
            await _apiClient.UpdateAsync(itemId, orderItem);

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        await UpdateInfoOrder();
        await UpdateOrderItem();
    }

    private async Task UpdateStatusOrder(OrderStatus orderStatus)
    {
        try
        {
            await _apiClient.UpdateAsync(OrderId, orderStatus);
            this.Close();

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
    }

    private async void _btnRegister_Click(object sender, EventArgs e)
    {
        await UpdateStatusOrder(OrderStatus.ВОбработке);
    }


    private async void _btnClose_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private async void _btnCancel_Click(object sender, EventArgs e)
    {
        await UpdateStatusOrder(OrderStatus.Отменен);
    }

    private void FormRegister_FormClosing(object sender, FormClosingEventArgs e)
    {
        _mainForm.UploadOrderAsync();
    }
} 
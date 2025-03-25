using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Suite;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml;

namespace SportMeal.UI.customElement;

public class CustomOrderItem : Guna2Panel
{
    private int orderId;
    private DateTime dateOrder;
    private decimal totalAmount;
    private OrderStatus orderStatus;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public Guna2HtmlLabel NameLabel { get; private set; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public Guna2HtmlLabel DateLabel { get; private set; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public Guna2HtmlLabel AmountLabel { get; private set; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public Guna2HtmlLabel StatusLabel { get; private set; }

    [DefaultValue("")]
    public int OrderId
    {
        get => orderId;
        set
        {
            if (orderId != value)
            {
                orderId = value;
            }
        }
    }

    [DefaultValue("")]
    public DateTime DateOrder
    {
        get => dateOrder;
        set
        {
            if (dateOrder != value)
            {
                dateOrder = value;
            }
        }
    }

    [DefaultValue("")]
    public decimal TotalAmount
    {
        get => totalAmount;
        set
        {
            if (totalAmount != value)
            {
                totalAmount = value;
            }
        }
    }

    [DefaultValue(0.0)]
    public OrderStatus OrderStatus
    {
        get => orderStatus;
        set
        {
            if (orderStatus != value)
            {
                orderStatus = value;
            }
        }
    }

    public CustomOrderItem()
    {
        InitializeComponent();
    }

    public CustomOrderItem(int orderId, DateTime dateOrder, decimal totalAmount, OrderStatus orderStatus) : this()
    {
        OrderId = orderId;
        DateOrder = dateOrder;
        TotalAmount = totalAmount;
        OrderStatus = orderStatus;
        NameLabel.Text = $"Заказ: {orderId}";
        DateLabel.Text = $"от {dateOrder}";
        AmountLabel.Text = $"на {totalAmount}р.";
        StatusLabel.Text = orderStatus.ToString();
    }

    private void InitializeComponent()
    {
        // Настройка панели
        this.Size = new Size(165, 110);
        this.BorderRadius = 10;
        this.FillColor = Color.White;
        this.BorderThickness = 1;
        this.BorderColor = Color.FromArgb(16, 90, 101);
        this.Margin = new Padding(5);

        NameLabel = new Guna2HtmlLabel();
        NameLabel.Size = new Size(165, 20);
        NameLabel.Font = new Font("Segoe UI Semibold", 12f, FontStyle.Bold);
        NameLabel.Location = new Point(10, 5);
        NameLabel.ForeColor = Color.Black;

        StatusLabel = new Guna2HtmlLabel();
        StatusLabel.Size = new Size(165, 20);
        StatusLabel.Font = new Font("Segoe UI Semibold", 12f, FontStyle.Bold);
        StatusLabel.Location = new Point(10, 30);
        StatusLabel.ForeColor = Color.Black;

        AmountLabel = new Guna2HtmlLabel();
        AmountLabel.Size = new Size(165, 20);
        AmountLabel.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Regular);
        AmountLabel.Location = new Point(10, 60);
        AmountLabel.ForeColor = Color.Black;

        DateLabel = new Guna2HtmlLabel();
        DateLabel.Size = new Size(165, 20);
        DateLabel.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Regular);
        DateLabel.Location = new Point(12, 85);
        DateLabel.ForeColor = Color.Black;

        // Добавление элементов
        this.Controls.Add(NameLabel);
        this.Controls.Add(DateLabel);
        this.Controls.Add(AmountLabel);
        this.Controls.Add(StatusLabel);
    }
}
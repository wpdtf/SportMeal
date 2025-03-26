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
    private int _orderItemId;
    private int _productId;
    private string _productName;
    private string _categoriesName;
    private int _quantity;
    private decimal _unitPrice;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public Guna2HtmlLabel NameLabel { get; private set; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public Guna2HtmlLabel CategoriesLabel { get; private set; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public Guna2HtmlLabel QuantityLabel { get; private set; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public Guna2HtmlLabel UnitPriceLabel { get; private set; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public Guna2Button DeleteButton { get; private set; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public Guna2Button AddButton { get; private set; }

    [DefaultValue("")]
    public int OrderItemId
    {
        get => _orderItemId;
        set
        {
            if (_orderItemId != value)
            {
                _orderItemId = value;
            }
        }
    }

    [DefaultValue("")]
    public int Quantity
    {
        get => _quantity;
        set
        {
            if (_quantity != value)
            {
                _quantity = value;
            }
        }
    }

    [DefaultValue("")]
    public int ProductId
    {
        get => _productId;
        set
        {
            if (_productId != value)
            {
                _productId = value;
            }
        }
    }

    [DefaultValue("")]
    public string ProductName
    {
        get => _productName;
        set
        {
            if (_productName != value)
            {
                _productName = value;
            }
        }
    }

    [DefaultValue("")]
    public string CategoriesName
    {
        get => _categoriesName;
        set
        {
            if (_categoriesName != value)
            {
                _categoriesName = value;
            }
        }
    }

    [DefaultValue(0.0)]
    public decimal UnitPrice
    {
        get => _unitPrice;
        set
        {
            if (_unitPrice != value)
            {
                _unitPrice = value;
            }
        }
    }

    public CustomOrderItem()
    {
        InitializeComponent();
    }

    public CustomOrderItem(int orderItemId, int productId, string productName, string categoriesName, int quantity, decimal unitPrice) : this()
    {
        OrderItemId = orderItemId;
        ProductId = productId;
        ProductName = productName;
        CategoriesName = categoriesName;
        Quantity = quantity;
        UnitPrice = unitPrice;
        NameLabel.Text = productName;
        CategoriesLabel.Text = categoriesName;
        QuantityLabel.Text = $"Количество: {quantity}";
        UnitPriceLabel.Text = $"Итоговая цена: {unitPrice} руб";
    }

    private void InitializeComponent()
    {
        // Настройка панели
        this.Size = new Size(440, 110);
        this.BorderRadius = 10;
        this.FillColor = Color.White;
        this.BorderThickness = 1;
        this.BorderColor = Color.FromArgb(0, 0, 192);
        this.Margin = new Padding(5);

        AddButton = new Guna2Button();
        AddButton.Text = "➕";
        AddButton.Font = new Font("Segoe UI Emoji", 15f);
        AddButton.Size = new Size(50, 50);
        AddButton.Location = new Point(320, 50);
        AddButton.BorderRadius = 15;
        AddButton.FillColor = Color.Transparent;
        AddButton.ForeColor = Color.FromArgb(0, 0, 192);
        AddButton.HoverState.FillColor = Color.LightGray;
        AddButton.HoverState.ForeColor = Color.DimGray;

        DeleteButton = new Guna2Button();
        DeleteButton.Text = "➖";
        DeleteButton.Font = new Font("Segoe UI Emoji", 15f);
        DeleteButton.Size = new Size(50, 50);
        DeleteButton.Location = new Point(380, 50);
        DeleteButton.BorderRadius = 15;
        DeleteButton.FillColor = Color.Transparent;
        DeleteButton.ForeColor = Color.FromArgb(0, 0, 192);
        DeleteButton.HoverState.FillColor = Color.LightGray;
        DeleteButton.HoverState.ForeColor = Color.DimGray;

        NameLabel = new Guna2HtmlLabel();
        NameLabel.Size = new Size(100, 20);
        NameLabel.Font = new Font("Segoe UI Semibold", 15f, FontStyle.Bold);
        NameLabel.Location = new Point(10, 5);
        NameLabel.ForeColor = Color.Black;

        CategoriesLabel = new Guna2HtmlLabel();
        CategoriesLabel.Size = new Size(100, 20);
        CategoriesLabel.Font = new Font("Segoe UI Semibold", 10f, FontStyle.Regular);
        CategoriesLabel.Location = new Point(10, 35);
        CategoriesLabel.ForeColor = Color.Black;

        QuantityLabel = new Guna2HtmlLabel();
        QuantityLabel.Size = new Size(100, 20);
        QuantityLabel.Font = new Font("Segoe UI Semibold", 12f, FontStyle.Regular);
        QuantityLabel.Location = new Point(10, 65);
        QuantityLabel.ForeColor = Color.Black;

        UnitPriceLabel = new Guna2HtmlLabel();
        UnitPriceLabel.Size = new Size(100, 20);
        UnitPriceLabel.Font = new Font("Segoe UI Semibold", 12f, FontStyle.Bold);
        UnitPriceLabel.Location = new Point(10, 85);
        UnitPriceLabel.ForeColor = Color.Black;

        // Добавление элементов
        this.Controls.Add(NameLabel);
        this.Controls.Add(CategoriesLabel);
        this.Controls.Add(QuantityLabel);
        this.Controls.Add(UnitPriceLabel);
        this.Controls.Add(AddButton);
        this.Controls.Add(DeleteButton);
    }
}
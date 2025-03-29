using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Suite;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml;

namespace SportMeal.UI.customElement;

public class CustomProductItem : Guna2Panel
{
    private int _productId;
    private string _productName;
    private string _categoryName;
    private string _description;
    private decimal _price;
    private int _beLike;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public Guna2Button AddToOrderButton { get; private set; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public Guna2HtmlLabel NameLabel { get; private set; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public Guna2HtmlLabel CategoryNameLabel { get; private set; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public Guna2HtmlLabel DescriptionLabel { get; private set; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public Guna2HtmlLabel BelikeLabel { get; private set; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public Guna2HtmlLabel PriceLabel { get; private set; }

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
    public string CategoryName
    {
        get => _categoryName;
        set
        {
            if (_categoryName != value)
            {
                _categoryName = value;
            }
        }
    }

    [DefaultValue("")]
    public string Description
    {
        get => _description;
        set
        {
            if (_description != value)
            {
                _description = value;
            }
        }
    }

    [DefaultValue(0.0)]
    public decimal Price
    {
        get => _price;
        set
        {
            if (_price != value)
            {
                _price = value;
            }
        }
    }

    [DefaultValue("")]
    public int BeLike
    {
        get => _beLike;
        set
        {
            if (_beLike != value)
            {
                _beLike = value;
            }
        }
    }

    public CustomProductItem()
    {
        InitializeComponent();
    }

    public CustomProductItem(int productId, string productName, string categoryName, string description, decimal price, int beLike = 0) : this()
    {
        ProductId = productId;
        ProductName = productName;
        CategoryName = categoryName;
        Description = description;
        Price = price;
        BeLike = beLike;
        BelikeLabel.Text = beLike == 1 ? "⭐️" : "";
        NameLabel.Text = productName;
        CategoryNameLabel.Text = categoryName;
        DescriptionLabel.Text = description;
        PriceLabel.Text = $"{price} р.";
    }

    private void InitializeComponent()
    {
        // Настройка панели
        this.Size = new Size(570, 150);
        this.BorderRadius = 10;
        this.FillColor = Color.White;
        this.BorderThickness = 1;
        this.BorderColor = Color.FromArgb(0, 0, 192);
        this.Margin = new Padding(5);

        // Создание кнопки "Добавить в заказ"
        AddToOrderButton = new Guna2Button();
        AddToOrderButton.Text = "Добавить в заказ";
        AddToOrderButton.Size = new Size(160, 30);
        AddToOrderButton.Location = new Point(390, 10);
        AddToOrderButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        AddToOrderButton.Animated = true;
        AddToOrderButton.BorderColor = Color.FromArgb(16, 90, 101);
        AddToOrderButton.BorderRadius = 12;
        AddToOrderButton.Cursor = Cursors.Hand;
        AddToOrderButton.DisabledState.BorderColor = Color.DarkGray;
        AddToOrderButton.DisabledState.CustomBorderColor = Color.DarkGray;
        AddToOrderButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
        AddToOrderButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
        AddToOrderButton.FillColor = Color.FromArgb(0, 0, 192);
        AddToOrderButton.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
        AddToOrderButton.ForeColor = Color.White;
        AddToOrderButton.Margin = new Padding(4);

        NameLabel = new Guna2HtmlLabel();
        NameLabel.Size = new Size(120, 30);
        NameLabel.Font = new Font("Segoe UI Semibold", 15f, FontStyle.Bold);
        NameLabel.Location = new Point(10, 10); 
        NameLabel.ForeColor = Color.Black;

        CategoryNameLabel = new Guna2HtmlLabel();
        CategoryNameLabel.Size = new Size(80, 30);
        CategoryNameLabel.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Regular);
        CategoryNameLabel.Location = new Point(12, 40);
        CategoryNameLabel.ForeColor = Color.Black;

        DescriptionLabel = new Guna2HtmlLabel();
        DescriptionLabel.Size = new Size(400, 100);
        DescriptionLabel.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Regular);
        DescriptionLabel.Location = new Point(10, 65);
        DescriptionLabel.ForeColor = Color.Black;

        PriceLabel = new Guna2HtmlLabel();
        PriceLabel.Size = new Size(120, 30);
        PriceLabel.Font = new Font("Segoe UI Semibold", 10f, FontStyle.Regular);
        PriceLabel.Location = new Point(390, 45);
        PriceLabel.ForeColor = Color.Black;

        BelikeLabel = new Guna2HtmlLabel();
        BelikeLabel.Font = new Font("Segoe UI Emoji", 12f);
        BelikeLabel.Size = new Size(20, 20);
        BelikeLabel.Location = new Point(360, 10);
        BelikeLabel.ForeColor = Color.FromArgb(0, 0, 192);

        // Добавление элементов
        this.Controls.Add(AddToOrderButton);
        this.Controls.Add(NameLabel);
        this.Controls.Add(CategoryNameLabel);
        this.Controls.Add(DescriptionLabel);
        this.Controls.Add(PriceLabel);
        this.Controls.Add(BelikeLabel);
    }
}
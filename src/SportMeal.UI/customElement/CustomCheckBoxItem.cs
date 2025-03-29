using Guna.UI2.WinForms;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SportMeal.UI.customElement;

public class CustomCheckBoxItem : Guna2Panel
{
    private int _itemId;
    private int _beLike;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public Guna2CheckBox CheckBox { get; private set; }

    [DefaultValue(0)]
    public int ItemId
    {
        get => _itemId;
        set
        {
            if (_itemId != value)
            {
                _itemId = value;
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

    public CustomCheckBoxItem()
    {
        // Конструктор по умолчанию для дизайнера
        InitializeComponent();
    }

    public CustomCheckBoxItem(string text, int id, int beLike = 0) : this()
    {
        ItemId = id;
        BeLike = beLike;

        var like = beLike == 1 ? "⭐️" : "";

        CheckBox.Text = $"{like} {text}";
    }

    private void InitializeComponent()
    {
        // Настройка панели
        this.Size = new Size(200, 40);
        this.BorderRadius = 10;
        this.FillColor = Color.White;
        this.BorderThickness = 1;
        this.BorderColor = Color.FromArgb(0, 0, 192);
        this.Margin = new Padding(5);

        // Создание чекбокса
        CheckBox = new Guna2CheckBox();
        CheckBox.CheckedState.BorderRadius = 2;
        CheckBox.CheckedState.BorderThickness = 0;
        CheckBox.CheckedState.FillColor = Color.FromArgb(0, 0, 192);
        CheckBox.AutoSize = false;
        CheckBox.Size = new Size(180, 30);
        CheckBox.Location = new Point(10, 5);
        CheckBox.TextAlign = ContentAlignment.MiddleLeft;

        // Добавление элементов
        this.Controls.Add(CheckBox);
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsChecked
    {
        get => CheckBox.Checked;
        set => CheckBox.Checked = value;
    }
}
using Guna.UI2.WinForms;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SportMeal.UI.customElement;

public class CustomCheckBoxItem : Guna2Panel
{
    private int _itemId;
    private string _itemTag;

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
                OnPropertyChanged();
            }
        }
    }

    [DefaultValue("")]
    public string ItemTag
    {
        get => _itemTag;
        set
        {
            if (_itemTag != value)
            {
                _itemTag = value;
                OnPropertyChanged();
            }
        }
    }

    public CustomCheckBoxItem()
    {
        // Конструктор по умолчанию для дизайнера
        InitializeComponent();
    }

    public CustomCheckBoxItem(string text, int id, string tag = null) : this()
    {
        ItemId = id;
        ItemTag = tag;
        CheckBox.Text = text;
    }

    private void InitializeComponent()
    {
        // Настройка панели
        this.Size = new Size(200, 40);
        this.BorderRadius = 10;
        this.FillColor = Color.White;
        this.BorderThickness = 1;
        this.BorderColor = Color.FromArgb(16, 90, 101);
        this.Margin = new Padding(5);

        // Создание чекбокса
        CheckBox = new Guna2CheckBox();
        CheckBox.CheckedState.BorderRadius = 2;
        CheckBox.CheckedState.BorderThickness = 0;
        CheckBox.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
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

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        // Можно добавить логику обработки изменений свойств
    }

    // Метод для сериализации (если нужно)
    private bool ShouldSerializeItemId() => ItemId != 0;
    private bool ShouldSerializeItemTag() => !string.IsNullOrEmpty(ItemTag);
}
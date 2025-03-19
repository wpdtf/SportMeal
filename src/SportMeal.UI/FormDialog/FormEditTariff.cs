using Guna.UI2.WinForms;
using System.Text.RegularExpressions;

namespace Booking.UI.FormDialog;

public partial class FormEditTariff : Form
{
    private Tariff TariffModel { get; set; }
    private FormTariff TariffForm { get; set; }
    private int Option { get; set; }

    public FormEditTariff(int option, Tariff tariffModel, FormTariff formTarrif)
    {
        InitializeComponent();
        TariffModel = tariffModel;
        Option = option;
        TariffForm = formTarrif;
    }

    private void FormEditStaff_Load(object sender, EventArgs e)
    {
        if (Option == 1)
        {
            guna2Button2.Text = "Добавить";
            label1.Text = "Добавление";
        }
        else
        {
            guna2TextBox1.Text = TariffModel.Name;
            guna2TextBox2.Text = TariffModel.Description;
            guna2TextBox5.Text = TariffModel.Price.ToString();
            guna2Button2.Text = "Сохранить";
            label1.Text = "Изменение";
        }
    }

    private async void guna2Button2_Click_1(object sender, EventArgs e)
    {
        if (!CheckValidation())
        {
            return;
        }

        Tariff tariff = new()
        {
            TariffId = TariffModel.TariffId,
            Name = guna2TextBox1.Text,
            Description = guna2TextBox2.Text,
            Price = Convert.ToInt32(guna2TextBox5.Text)
        };

        var api = new ApiClient<Staff>(new Uri("http://localhost:5000/api/booking-car"));

        await api.PutAsync("booking/tariff", tariff);
        await TariffForm.UpdateDateAsync();
        this.Close();
        return;
    }

    private bool CheckValidation()
    {
        var validationMessage = "";

        if (string.IsNullOrEmpty(guna2TextBox1.Text))
        {
            validationMessage = "Наименование не может быть пустым.";
        }

        if (guna2TextBox1.Text.Length < 2 || guna2TextBox1.Text.Length > 50)
        {
            validationMessage = "Наименование должно содержать от 2 до 50 символов.";
        }

        if (ContainsDigits(guna2TextBox1.Text))
        {
            validationMessage = "Наименование не может содержать цифры.";
        }

        if (!guna2TextBox5.Text.All(char.IsDigit) && !(int.Parse(guna2TextBox5.Text) > 0))
        {
            validationMessage = "Стоимость может быть только положительной.";
        }

        if (validationMessage.Count() > 0)
        {
            MessageBox.Show(validationMessage, "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        return true;
    }

    /// <summary>
    /// Метод для проверки строки на наличие цифр.
    /// </summary>
    /// <param name="input">Строка для проверки.</param>
    /// <returns>True, если строка содержит цифры, иначе False.</returns>
    private bool ContainsDigits(string input)
    {
        return input.Any(char.IsDigit);
    }
}

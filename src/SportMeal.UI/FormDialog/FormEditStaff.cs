using System.Text.RegularExpressions;
using Windows.Networking;

namespace Booking.UI.FormDialog;

public partial class FormEditStaff : Form
{
    private Staff StaffModel { get; set; }
    private FormStaff FormStaff { get; set; }
    private int Option { get; set; }

    public FormEditStaff(int option, Staff staffModel, FormStaff formStaff)
    {
        InitializeComponent();
        StaffModel = staffModel;
        Option = option;
        FormStaff = formStaff;
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
            guna2TextBox1.Text = StaffModel.Last_name;
            guna2TextBox3.Text = StaffModel.First_name;
            guna2TextBox2.Text = StaffModel.Middle_name;
            guna2DateTimePicker1.Value = StaffModel.Birthdate;
            guna2TextBox4.Text = StaffModel.Phone;
            guna2CheckBox1.Checked = StaffModel.Dismissed;
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
        
        Staff staff = new()
        {
            Last_name = guna2TextBox1.Text,
            First_name = guna2TextBox3.Text,
            Middle_name = guna2TextBox2.Text,
            Birthdate = guna2DateTimePicker1.Value,
            Phone = guna2TextBox4.Text,
            UserId = StaffModel.UserId,
            Dismissed = guna2CheckBox1.Checked,
            Position = Convert.ToInt16(guna2ComboBox1.Text.Split('-')[0]),
            PositionTxt = guna2ComboBox1.Text.Split('-')[1]
        };

        var api = new ApiClient<Staff>(new Uri("http://localhost:5000/api/booking-car"));

        await api.PutAsync("tech-support/staff", staff);
        await FormStaff.UpdateDateAsync();
        this.Close();
        return;
    }

    private bool CheckValidation()
    {
        var validationMessage = "";

        if (string.IsNullOrEmpty(guna2TextBox1.Text))
        {
            validationMessage = "Фамилия не может быть пустой.";
        }

        if (guna2TextBox1.Text.Length < 2 || guna2TextBox1.Text.Length > 50)
        {
            validationMessage = "Фамилия должна содержать от 2 до 50 символов.";
        }

        if (ContainsDigits(guna2TextBox1.Text))
        {
            validationMessage = "Фамилия не может содержать цифры.";
        }

        if (string.IsNullOrEmpty(guna2TextBox3.Text))
        {
            validationMessage = "Имя не может быть пустым.";
        }

        if (guna2TextBox3.Text.Length < 2 || guna2TextBox3.Text.Length > 50)
        {
            validationMessage = "Имя должно содержать от 2 до 50 символов.";
        }

        if (ContainsDigits(guna2TextBox3.Text))
        {
            validationMessage = "Имя не может содержать цифры.";
        }

        if (ContainsDigits(guna2TextBox2.Text))
        {
            validationMessage = "Отчество не может содержать цифры.";
        }

        var phoneRegex = new Regex(@"^9\d{9}$");
        if (!phoneRegex.IsMatch(guna2TextBox4.Text))
        {
            validationMessage = "Номер телефона должен начинаться с 9 и содержать только цифры.";
        }

        if (guna2DateTimePicker1.Value > DateTime.Now.AddYears(-18))
        {
            validationMessage = "Сотруднику должно быть больше 18 лет.";
        }

        if (guna2ComboBox1.Text.Count() == 0)
        {
            validationMessage = "Необходимо выбрать значение в выпадающем списке";
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

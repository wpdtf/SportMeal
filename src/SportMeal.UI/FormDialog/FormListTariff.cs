using System.Reflection;
using System.Text.RegularExpressions;

namespace Booking.UI.FormDialog;

public partial class FormListTariff : Form
{
    private List<Tariff> TarifModel { get; set; }
    private FormCar CarForm { get; set; }
    private int CarId { get; set; }

    public FormListTariff(int carId, FormCar formCar)
    {
        InitializeComponent();
        CarId = carId;
        CarForm = formCar;
    }

    private async void FormEditStaff_Load(object sender, EventArgs e)
    {
        await UpdateAsync();
    }

    private async Task UpdateAsync()
    {
        var api = new ApiClient<List<Tariff>>(new Uri("http://localhost:5000/api/booking-car"));

        TarifModel = await api.GetAsync($"booking/tariff");
        guna2DataGridView1.DataSource = TarifModel;
    }

    private async void guna2Button2_Click_1(object sender, EventArgs e)
    {
        if (!IsSelecedRow())
        {
            return;
        }

        if (!CheckValidation())
        {
            return;
        }

        var api = new ApiClient<User>(new Uri("http://localhost:5000/api/booking-car"));

        await api.PutNotBodyAsync($"booking/tariffToCar?tariff={(int)guna2DataGridView1.SelectedRows[0].Cells[0].Value}&carId={CarId}");
        await CarForm.UpdateTarif();
        this.Close();
    }

    public string HashPassword(string password)
    {
        byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(bytes);
    }

    private void guna2TextBox1_TextChanged(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(guna2TextBox1.Text))
        {
            var searchText = guna2TextBox1.Text.Trim().ToLower();

            var filters = TarifModel
                .Where(p =>
                    p.Name.ToLower().Contains(searchText)
                )
                .ToList();

            guna2DataGridView1.DataSource = filters;
        }
        else
        {
            guna2DataGridView1.DataSource = TarifModel;
        }
    }

    private bool CheckValidation()
    {
        var tariffId = (int)guna2DataGridView1.SelectedRows[0].Cells[0].Value;
        var validationMessage = "";

        if (CarForm._tariff.Any(model => model.TariffId == tariffId))
        {
            validationMessage = "Такой тариф уже есть у автомобиля.";
        }

        if (validationMessage.Count() > 0)
        {
            MessageBox.Show(validationMessage, "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        return true;
    }

    private bool IsSelecedRow()
    {
        if (guna2DataGridView1.SelectedRows.Count <= 0 || TarifModel.Count == 0)
        {
            MessageBox.Show("Выберите автомобиль для данного действия.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return false;
        }
        return true;
    }
}

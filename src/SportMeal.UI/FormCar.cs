using Guna.UI2.WinForms;
using System.Data;

namespace Booking.UI
{
    public partial class FormCar : Form
    {
        private List<Car> _car;
        public List<Tariff> _tariff;
        private bool isUpdate = true;

        public FormCar()
        {
            InitializeComponent();

            switch (CurrentUser.Role.ToLower())
            {
                case "клиент":
                    Guna2Button1.Visible = false;
                    guna2Button2.Visible = false;
                    guna2Button3.Visible = false;
                    guna2Button4.Visible = false;
                    break;
            }
        }

        public async Task UpdateDateAsync()
        {
            isUpdate = true;
            var api = new ApiClient<List<Car>>(new Uri("http://localhost:5000/api/booking-car"));

            _car = await api.GetAsync($"booking/car?onlyActive={CurrentUser.isClient}");
            guna2DataGridView1.DataSource = _car;

            isUpdate = false;
            await UpdateTarif();
        }

        private async void FormAdmin_Load(object sender, EventArgs e)
        {
            await UpdateDateAsync();
        }

        private void Guna2Button1_Click(object sender, EventArgs e)
        {
            if (!IsSelecedRow())
            {
                return;
            }

            var selectedRow = guna2DataGridView1.SelectedRows[0];
            Car car = new()
            {
                CarId = (int)selectedRow.Cells[0].Value,
                Brand = selectedRow.Cells[1].Value.ToString(),
                Mark = selectedRow.Cells[2].Value.ToString(),
                YearStart = (int)selectedRow.Cells[3].Value,
                Color = selectedRow.Cells[4].Value.ToString(),
                CarNumber = selectedRow.Cells[5].Value.ToString(),
                VIN = selectedRow.Cells[6].Value.ToString(),
                Active = (bool)selectedRow.Cells[7].Value,
                MinimalExperience = (int)selectedRow.Cells[8].Value,
                Class = (int)selectedRow.Cells[9].Value,
                ClassTxt = ""
            };

            FormEditCar edit = new(2, car, this);
            edit.ShowDialog();
        }

        private bool IsSelecedRow()
        {
            if (guna2DataGridView1.SelectedRows.Count <= 0 || _car.Count == 0)
            {
                MessageBox.Show("Выберите автомобиль для данного действия.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private async void FilterData(string searchText)
        {
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                searchText = searchText.Trim().ToLower();

                var filters = _car
                    .Where(p =>
                        p.Brand.ToLower().Contains(searchText) ||
                        p.Mark.ToLower().Contains(searchText) ||
                        p.VIN.ToLower().Contains(searchText)
                    )
                    .ToList();

                guna2DataGridView1.DataSource = filters;
            }
            else
            {
                guna2DataGridView1.DataSource = _car;
            }

        }

        private async void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            isUpdate = true;
            FilterData(guna2TextBox1.Text);

            isUpdate = false;
            await UpdateTarif();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            FormEditCar formEdit = new(1, new(), this);
            formEdit.ShowDialog();
        }

        private async void guna2DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            await UpdateTarif();
        }

        public async Task UpdateTarif()
        {
            if (isUpdate)
            {
                return;
            }

            if (!IsSelecedRow())
            {
                return;
            }

            var api = new ApiClient<List<Tariff>>(new Uri("http://localhost:5000/api/booking-car"));
            _tariff = await api.GetAsync($"booking/tariffToCar?carId={(int)guna2DataGridView1.SelectedRows[0].Cells[0].Value}");
            guna2DataGridView2.DataSource = _tariff;
        }

        private async void guna2Button3_Click(object sender, EventArgs e)
        {
            if (!IsSelecedRow())
            {
                return;
            }

            if (guna2DataGridView2.SelectedRows.Count <= 0 || _tariff.Count == 0)
            {
                MessageBox.Show("Выберите тариф для данного действия.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var api = new ApiClient<TariffCar>(new Uri("http://localhost:5000/api/booking-car"));


            await api.PutNotBodyAsync($"booking/tariffToCar?tariff={(int)guna2DataGridView2.SelectedRows[0].Cells[0].Value}&carId={(int)guna2DataGridView1.SelectedRows[0].Cells[0].Value}");
            await UpdateTarif();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (!IsSelecedRow())
            {
                return;
            }

            FormListTariff listTariff = new((int)guna2DataGridView1.SelectedRows[0].Cells[0].Value, this);
            listTariff.ShowDialog();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            if (!IsSelecedRow())
            {
                return;
            }

            var selectedRow = guna2DataGridView1.SelectedRows[0];

            SelectedCar.CarId = (int)selectedRow.Cells[0].Value;
            SelectedCar.Brand = selectedRow.Cells[1].Value.ToString();
            SelectedCar.Color = selectedRow.Cells[4].Value.ToString();
            SelectedCar.MinimalExperience = (int)selectedRow.Cells[8].Value;

            MessageBox.Show($"Автомобиль {SelectedCar.CarId} - {SelectedCar.Brand} {SelectedCar.Color} выбран", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            if (!IsSelecedRow())
            {
                return;
            }

            if (guna2DataGridView2.SelectedRows.Count <= 0 || _tariff.Count == 0)
            {
                MessageBox.Show("Выберите тариф для данного действия.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            var selectedRow = guna2DataGridView2.SelectedRows[0];

            SelectedTariff.TarrifId = (int)selectedRow.Cells[0].Value;
            SelectedTariff.Name = selectedRow.Cells[1].Value.ToString();

            MessageBox.Show($"Тариф {SelectedTariff.TarrifId} - {SelectedTariff.Name} выбран", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

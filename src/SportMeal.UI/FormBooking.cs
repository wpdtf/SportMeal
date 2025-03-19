using SportMeal.Domain.Declare;
using SportMeal.Domain.Entities;
using Guna.UI2.WinForms;
using Windows.Media.Protection.PlayReady;
using LocalBooking = SportMeal.Domain.Entities.Booking;
using LocalClient = SportMeal.Domain.Entities.Client;

namespace Booking.UI
{
    public partial class FormBooking : Form
    {
        private List<LocalBooking> _booking;

        private List<LocalClient> _client;
        private List<Car> _car;
        private string TariffName;
        private bool isUpdate = true;

        public FormBooking()
        {
            InitializeComponent();

            switch (CurrentUser.Role.ToLower())
            {
                case "клиент":
                    Guna2Button1.Visible = false;
                    guna2Button3.Visible = false;
                    guna2DataGridView2.Dispose();
                    break;
            }
        }

        public async Task UpdateDateAsync()
        {
            isUpdate = true;
            var api = new ApiClient<List<LocalBooking>>(new Uri("http://localhost:5000/api/booking-car"));

            _booking = await api.GetAsync($"booking/booking?clientId={CurrentUser.ClientId}");
            guna2DataGridView1.DataSource = _booking;
            isUpdate = false;
            await UpdateOptionallyInfoAsync();
        }

        private async Task UpdateOptionallyInfoAsync()
        {
            if (isUpdate)
            {
                return;
            }
            else
            {
                guna2DataGridView3.DataSource = new List<Car>();
            }

            if (!IsSelecedRow())
            {
                return;
            }

            if (!(CurrentUser.Role.ToLower() == "клиент"))
            {
                var apiClient = new ApiClient<List<LocalClient>>(new Uri("http://localhost:5000/api/booking-car"));
                _client = await apiClient.GetAsync($"client/list?clientId={guna2DataGridView1.SelectedRows[0].Cells[2].Value}");
                guna2DataGridView2.DataSource = _client;
            }

            var apiCar = new ApiClient<List<Car>>(new Uri("http://localhost:5000/api/booking-car"));
            _car = await apiCar.GetAsync($"booking/car?carId={guna2DataGridView1.SelectedRows[0].Cells[1].Value}");
            guna2DataGridView3.DataSource = _car;

            var apiTariff = new ApiClient<List<Tariff>>(new Uri("http://localhost:5000/api/booking-car"));
            TariffName = (await apiTariff.GetAsync($"booking/tariff?tariffId={guna2DataGridView1.SelectedRows[0].Cells[6].Value}"))[0].Name;
            guna2TextBox2.Text = TariffName;
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
            LocalBooking booking = new()
            {
                BookingId = (int)selectedRow.Cells[0].Value,
                CarId = (int)selectedRow.Cells[1].Value,
                ClientId = (int)selectedRow.Cells[2].Value,
                Status = (statusBooking)selectedRow.Cells[3].Value,
                BookingTime = Convert.ToInt32(selectedRow.Cells[4].Value),
                BookingStart = Convert.ToDateTime(selectedRow.Cells[5].Value),
                TariffId = (int)selectedRow.Cells[6].Value
            };

            selectedRow = guna2DataGridView2.SelectedRows[0];
            LocalClient client = new()
            {
                ClientId = (int)selectedRow.Cells[0].Value,
                Last_name = selectedRow.Cells[1].Value.ToString(),
                First_name = selectedRow.Cells[2].Value.ToString(),
                Middle_name = selectedRow.Cells[3].Value.ToString(),
                Phone = selectedRow.Cells[5].Value.ToString(),
            };

            selectedRow = guna2DataGridView3.SelectedRows[0];
            Car car = new()
            {
                CarId = (int)selectedRow.Cells[0].Value,
                Brand = selectedRow.Cells[1].Value.ToString(),
                Color = selectedRow.Cells[4].Value.ToString(),
                MinimalExperience = (int)selectedRow.Cells[8].Value
            };

            FormEditBooking edit = new(2, booking, client, car, this, TariffName);
            edit.ShowDialog();
        }

        private bool IsSelecedRow()
        {
            if (_booking.Count == 0)
            {
                return false;
            }

            if (guna2DataGridView1.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Выберите аренду для данного действия.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        private async Task FilterData(string searchText)
        {
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                searchText = searchText.Trim().ToLower();

                var filters = _booking
                    .Where(p =>
                        p.BookingId.ToString().ToLower().Contains(searchText) ||
                        p.CarId.ToString().ToLower().Contains(searchText) ||
                        p.ClientId.ToString().ToLower().Contains(searchText)
                    )
                    .ToList();

                guna2DataGridView1.DataSource = filters;
            }
            else
            {
                guna2DataGridView1.DataSource = _booking;
            }
        }

        private async void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            isUpdate = true;
            await FilterData(guna2TextBox1.Text);
            isUpdate = false;
            await UpdateOptionallyInfoAsync();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            FormEditBooking edit = new(1, new(), new(), new(), this, "");
            edit.ShowDialog();
        }

        private async void guna2DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            await UpdateOptionallyInfoAsync();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (!IsSelecedRow())
            {
                return;
            }

            Incident incident = new()
            {
                BookingId = (int)guna2DataGridView1.SelectedRows[0].Cells[0].Value
            };

            FormEditIncident edit = new(2, incident);
            edit.ShowDialog();
        }
    }
}

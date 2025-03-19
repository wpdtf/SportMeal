using LocalClient = SportMeal.Domain.Entities.Client;

namespace Booking.UI
{
    public partial class FormClient : Form
    {
        private List<LocalClient> _client;

        public FormClient()
        {
            InitializeComponent();
        }

        public async Task UpdateDateAsync()
        {
            var api = new ApiClient<List<LocalClient>>(new Uri("http://localhost:5000/api/booking-car"));

            _client = await api.GetAsync("client/list");
            guna2DataGridView1.DataSource = _client;
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
            LocalClient client = new()
            {
                ClientId = (int)selectedRow.Cells[0].Value,
                Last_name = selectedRow.Cells[1].Value.ToString(),
                First_name = selectedRow.Cells[2].Value.ToString(),
                Middle_name = selectedRow.Cells[3].Value.ToString(),
                Birthdate = Convert.ToDateTime(selectedRow.Cells[4].Value),
                Phone = selectedRow.Cells[5].Value.ToString(),
                Email = selectedRow.Cells[6].Value.ToString(),
                Passport = selectedRow.Cells[7].Value.ToString(),
                DriverLicense = selectedRow.Cells[8].Value.ToString(),
                DateStartDriving = Convert.ToDateTime(selectedRow.Cells[9].Value),
                Blocked = (bool)selectedRow.Cells[10].Value,
                Experience = (int)selectedRow.Cells[11].Value
            };

            FormEditClient edit = new(2, client, formClient: this);
            edit.ShowDialog();
        }

        private bool IsSelecedRow()
        {
            if (guna2DataGridView1.SelectedRows.Count <= 0 || _client.Count == 0)
            {
                MessageBox.Show("Выберите клиента для данного действия.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void FilterData(string searchText)
        {
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                searchText = searchText.Trim().ToLower();

                var filters = _client
                    .Where(p =>
                        p.Last_name.ToLower().Contains(searchText) ||
                        p.First_name.ToLower().Contains(searchText) ||
                        p.Email.ToLower().Contains(searchText) ||
                        p.Phone.ToLower().Contains(searchText)
                    )
                    .ToList();

                guna2DataGridView1.DataSource = filters;
            }
            else
            {
                guna2DataGridView1.DataSource = _client;
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            FilterData(guna2TextBox1.Text);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            FormEditClient formEdit = new(1, new(), formClient: this);
            formEdit.ShowDialog();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (!IsSelecedRow())
            {
                return;
            }

            var selectedRow = guna2DataGridView1.SelectedRows[0];

            SelectedClient.ClientId = (int)selectedRow.Cells[0].Value;
            SelectedClient.First_name = selectedRow.Cells[2].Value.ToString();
            SelectedClient.Last_name = selectedRow.Cells[1].Value.ToString();
            SelectedClient.Phone = selectedRow.Cells[5].Value.ToString();

            MessageBox.Show($"Клиент {SelectedClient.ClientId} - {SelectedClient.Last_name} {SelectedClient.First_name} выбран", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (!IsSelecedRow())
            {
                return;
            }

            FormListLogin formLogin = new(0, (int)guna2DataGridView1.SelectedRows[0].Cells[0].Value);
            formLogin.ShowDialog();
        }
    }
}

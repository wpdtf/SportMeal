namespace Booking.UI
{
    public partial class FormTariff : Form
    {
        private List<Tariff> _tariff;

        public FormTariff()
        {
            InitializeComponent();
        }

        public async Task UpdateDateAsync()
        {
            var api = new ApiClient<List<Tariff>>(new Uri("http://localhost:5000/api/booking-car"));

            _tariff = await api.GetAsync("booking/tariff");
            guna2DataGridView1.DataSource = _tariff;
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
            Tariff tariff = new()
            {
                TariffId = (int)selectedRow.Cells[0].Value,
                Name = selectedRow.Cells[1].Value.ToString(),
                Price = (int)selectedRow.Cells[2].Value,
                Description = selectedRow.Cells[3].Value.ToString()
            };

            FormEditTariff edit = new(2, tariff, this);
            edit.ShowDialog();
        }

        private bool IsSelecedRow()
        {
            if (guna2DataGridView1.SelectedRows.Count <= 0 || _tariff.Count == 0)
            {
                MessageBox.Show("Выберите тариф для данного действия.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void FilterData(string searchText)
        {
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                searchText = searchText.Trim().ToLower();

                var filters = _tariff
                    .Where(p =>
                        p.Name.ToLower().Contains(searchText)
                    )
                    .ToList();

                guna2DataGridView1.DataSource = filters;
            }
            else
            {
                guna2DataGridView1.DataSource = _tariff;
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            FilterData(guna2TextBox1.Text);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            FormEditTariff formEdit = new(1, new(), this);
            formEdit.ShowDialog();
        }
    }
}

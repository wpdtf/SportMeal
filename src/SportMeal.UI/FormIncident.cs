namespace Booking.UI
{
    public partial class FormIncident : Form
    {
        private List<Incident> _incident;

        public FormIncident()
        {
            InitializeComponent();
        }

        public async Task UpdateDateAsync()
        {
            var api = new ApiClient<List<Incident>>(new Uri("http://localhost:5000/api/booking-car"));

            _incident = await api.GetAsync("booking/incident");
            guna2DataGridView1.DataSource = _incident;
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
            Incident incident = new()
            {
                IncidentId = (int)selectedRow.Cells[0].Value,
                ClientGuilty = (bool)selectedRow.Cells[1].Value,
                Description = selectedRow.Cells[2].Value.ToString(),
                NomerTicket = selectedRow.Cells[3].Value.ToString(),
                BookingId = (int)selectedRow.Cells[4].Value
            };

            FormEditIncident edit = new(2, incident, this);
            edit.ShowDialog();
        }

        private bool IsSelecedRow()
        {
            if (guna2DataGridView1.SelectedRows.Count <= 0 || _incident.Count == 0)
            {
                MessageBox.Show("Выберите инцидент для данного действия.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void FilterData(string searchText)
        {
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                searchText = searchText.Trim().ToLower();

                var filters = _incident
                    .Where(p =>
                        p.Description.ToLower().Contains(searchText) ||
                        p.NomerTicket.ToLower().Contains(searchText)
                    )
                    .ToList();

                guna2DataGridView1.DataSource = filters;
            }
            else
            {
                guna2DataGridView1.DataSource = _incident;
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            FilterData(guna2TextBox1.Text);
        }
    }
}

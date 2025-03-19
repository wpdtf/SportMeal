namespace Booking.UI
{
    public partial class FormStaff : Form
    {
        private List<Staff> _staff;

        public FormStaff()
        {
            InitializeComponent();
        }

        public async Task UpdateDateAsync()
        {
            var api = new ApiClient<List<Staff>>(new Uri("http://localhost:5000/api/booking-car"));

            _staff = await api.GetAsync("tech-support/staff");
            guna2DataGridView1.DataSource = _staff;
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
            Staff staff = new()
            {
                UserId = (int)selectedRow.Cells[0].Value,
                Last_name = selectedRow.Cells[1].Value.ToString(),
                First_name = selectedRow.Cells[2].Value.ToString(),
                Middle_name = selectedRow.Cells[3].Value.ToString(),
                Phone = selectedRow.Cells[4].Value.ToString(),
                Birthdate = (DateTime)selectedRow.Cells[5].Value,
                Dismissed = (bool)selectedRow.Cells[6].Value,
                Position = (short)selectedRow.Cells[7].Value,
                PositionTxt = ""
            };

            FormEditStaff edit = new(2, staff, this);
            edit.ShowDialog();
        }

        private bool IsSelecedRow()
        {
            if (guna2DataGridView1.SelectedRows.Count <= 0 || _staff.Count == 0)
            {
                MessageBox.Show("Выберите сотрудника для данного действия.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void FilterData(string searchText)
        {
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                searchText = searchText.Trim().ToLower();

                var filters = _staff
                    .Where(p =>
                        p.First_name.ToLower().Contains(searchText) ||
                        p.Last_name.ToLower().Contains(searchText) ||
                        p.Middle_name.ToLower().Contains(searchText) ||
                        p.Phone.ToLower().Contains(searchText)
                    )
                    .ToList();

                guna2DataGridView1.DataSource = filters;
            }
            else
            {
                guna2DataGridView1.DataSource = _staff;
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            FilterData(guna2TextBox1.Text);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            FormEditStaff formEdit = new(1, new(), this);
            formEdit.ShowDialog();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (!IsSelecedRow())
            {
                return;
            }

            FormListLogin formLogin = new((int)guna2DataGridView1.SelectedRows[0].Cells[0].Value, 0);
            formLogin.ShowDialog();
        }
    }
}

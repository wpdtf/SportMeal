namespace Booking.UI;

public partial class FormMain : Form
{
    private Form _acriveForm;

    public FormMain()
    {
        InitializeComponent();
    }

    private void OpenForm(Form childForm)
    {
        if (_acriveForm != null)
            _acriveForm.Close();
        _acriveForm = childForm;
        childForm.TopLevel = false;
        childForm.FormBorderStyle = FormBorderStyle.None;
        childForm.Dock = DockStyle.Fill;
        guna2ShadowPanel1.Controls.Add(childForm);
        guna2ShadowPanel1.Tag = childForm;
        childForm.BringToFront();
        childForm.Show();
    }
    private void FormMain_Load(object sender, EventArgs e)
    {
        SetAccess(CurrentUser.Role);
    }

    private void SetAccess(string role)
    {
        switch (role.ToLower())
        {
            case "менеджер":
                Guna2Button2.Dispose();
                Guna2Button4.Dispose();
                break;
            case "маркетолог":
                Guna2Button1.Dispose();
                Guna2Button6.Dispose();
                Guna2Button4.Dispose();
                Guna2Button5.Dispose();
                guna2Button8.Dispose();
                guna2Button7.Dispose();
                break;
            case "клиент":
                Guna2Button6.Dispose();
                Guna2Button4.Dispose();
                guna2Button8.Dispose();
                guna2Button7.Dispose();
                Guna2Button2.Dispose();
                break;
        }
    }

    private void Guna2Button1_Click(object sender, EventArgs e)
    {
        OpenForm(new FormCar());
    }

    private void Guna2Button2_Click(object sender, EventArgs e)
    {
        OpenForm(new FormReport());
    }

    private void Guna2Button6_Click(object sender, EventArgs e)
    {
        OpenForm(new FormIncident());
    }

    private void Guna2Button5_Click(object sender, EventArgs e)
    {
        OpenForm(new FormBooking());
    }

    private void Guna2Button3_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }

    private void Guna2Button4_Click(object sender, EventArgs e)
    {
        OpenForm(new FormStaff());
    }

    private void guna2Button7_Click(object sender, EventArgs e)
    {
        OpenForm(new FormClient());
    }

    private void guna2Button8_Click(object sender, EventArgs e)
    {
        OpenForm(new FormTariff());
    }
}

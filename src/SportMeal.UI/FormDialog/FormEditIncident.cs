namespace Booking.UI.FormDialog;

public partial class FormEditIncident : Form
{
    private Incident IncidentModel { get; set; }
    private FormIncident IncidentForm { get; set; }
    private int Option { get; set; }

    public FormEditIncident(int option, Incident incedent, FormIncident formIncident = null)
    {
        InitializeComponent();
        IncidentModel = incedent;
        Option = option;
        IncidentForm = formIncident;
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
            guna2TextBox1.Text = IncidentModel.NomerTicket;
            guna2TextBox5.Text = IncidentModel.Description;
            guna2CheckBox1.Checked = IncidentModel.ClientGuilty;
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

        Incident incident = new()
        {
            IncidentId = IncidentModel.IncidentId,
            ClientGuilty = guna2CheckBox1.Checked,
            Description = guna2TextBox5.Text,
            NomerTicket = guna2TextBox1.Text,
            BookingId = IncidentModel.BookingId
        };

        var api = new ApiClient<Staff>(new Uri("http://localhost:5000/api/booking-car"));

        await api.PutAsync("booking/incident", incident);
        
        if (IncidentForm is not null)
        {
            await IncidentForm.UpdateDateAsync();
        }

        this.Close();
        return;
    }

    private bool CheckValidation()
    {
        var validationMessage = "";

        if (string.IsNullOrEmpty(guna2TextBox1.Text))
        {
            validationMessage = "Тикет не может быть пустым.";
        }

        if (guna2TextBox1.Text.Length < 2 || guna2TextBox1.Text.Length > 50)
        {
            validationMessage = "Тикет должнен содержать от 2 до 50 символов.";
        }

        if (string.IsNullOrEmpty(guna2TextBox5.Text))
        {
            validationMessage = "Описание не может быть пустым.";
        }

        if (validationMessage.Count() > 0)
        {
            MessageBox.Show(validationMessage, "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        return true;
    }
}

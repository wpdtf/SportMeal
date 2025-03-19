using SportMeal.Domain.Entities;
using ScottPlot;

namespace Booking.UI.FormDialog;

public partial class FormReportBooking : Form
{
    private List<ReportForClientBooking> Booking { get; set; }
    private List<ReportForClientIncident> Incident { get; set; }
    private int TypeOpen { get; set; }

    public FormReportBooking(List<ReportForClientBooking> booking, int typeOpen, List<ReportForClientIncident> incident)
    {
        InitializeComponent();
        Booking = booking;
        TypeOpen = typeOpen;
        Incident = incident;
    }

    private async void FormEditStaff_Load(object sender, EventArgs e)
    {
        if (TypeOpen == 1)
        {
            UpdateBooking();
        }
        else
        {
            UpdateIncident();
        }
    }

    private void UpdateBooking()
    {
        var dailyBookings = Booking
            .GroupBy(b => b.BookingStart.Date)
            .Select(g => new { Date = g.Key, Count = g.Count() })
            .OrderBy(x => x.Date)
            .ToList();

        double[] xValues = dailyBookings.Select(x => x.Date.ToOADate()).ToArray();
        double[] yValues = dailyBookings.Select(x => (double)x.Count).ToArray();

        var plot = formsPlot2.Plot;
        plot.Title("Количество аренд по дням");
        plot.XLabel("Дата");
        plot.YLabel("Количество аренд");

        var scatter = plot.Add.Scatter(xValues, yValues);
        scatter.Label = "Аренды";

        plot.ShowLegend();

        formsPlot2.Refresh();
    }

    private void UpdateIncident()
    {
        var dailyBookings = Incident
            .GroupBy(b => b.BookingStart.Date)
            .Select(g => new { Date = g.Key, Count = g.Count() })
            .OrderBy(x => x.Date)
            .ToList();

        double[] xValues = dailyBookings.Select(x => x.Date.ToOADate()).ToArray();
        double[] yValues = dailyBookings.Select(x => (double)x.Count).ToArray();

        var plot = formsPlot2.Plot;
        plot.Title("Количество инцидентов по дням");
        plot.XLabel("Дата");
        plot.YLabel("Количество инцидетов");

        var scatter = plot.Add.Scatter(xValues, yValues);
        scatter.Label = "инциденты";

        plot.ShowLegend();

        formsPlot2.Refresh();
    }

}

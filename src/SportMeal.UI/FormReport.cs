using SportMeal.Domain.Entities;
using OfficeOpenXml;
using System.Threading.Tasks;

namespace Booking.UI
{
    public partial class FormReport : Form
    {
        private List<ReportForClientBooking> _report;
        private List<ReportForClientIncident> _incident;


        public FormReport()
        {
            InitializeComponent();
        }

        public async Task UpdateDateReportAsync()
        {
            var api = new ApiClient<List<ReportForClientBooking>>(new Uri("http://localhost:5000/api/booking-car"));

            _report = await api.GetAsync("report/client-to-booking");
            guna2DataGridView1.DataSource = _report;
        }

        public async Task UpdateDateIncidentAsync()
        {
            var api = new ApiClient<List<ReportForClientIncident>>(new Uri("http://localhost:5000/api/booking-car"));

            _incident = await api.GetAsync("report/client-to-incident");
            guna2DataGridView1.DataSource = _incident;
        }

        private async void guna2Button2_Click(object sender, EventArgs e)
        {
            if (guna2ComboBox1.Text == "Данные по всем поездкам клиентов")
            {
                await UpdateDateReportAsync();
            }
            else if (guna2ComboBox1.Text == "Данные по всем инцидентам в рамках поездок клиентов")
            {
                await UpdateDateIncidentAsync();
            }
            else
            {
                MessageBox.Show("Выберете отчет.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            var isReport = true;

            if (guna2ComboBox1.Text == "Данные по всем поездкам клиентов")
            {
                if (_report.Count > 0)
                {
                    using var saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Excel Files|*.xlsx"; // Фильтр для выбора только Excel-файлов
                    saveFileDialog.Title = "Сохранить файл Excel";
                    saveFileDialog.FileName = "Бронирования.xlsx"; // Имя файла по умолчанию

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = saveFileDialog.FileName;

                        isReport = false;
                        WriteToExcel(_report, filePath);

                        MessageBox.Show($"Данные успешно записаны в файл: {filePath}", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else if (guna2ComboBox1.Text == "Данные по всем инцидентам в рамках поездок клиентов")
            {
                if (_incident.Count > 0)
                {
                    using var saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Excel Files|*.xlsx"; // Фильтр для выбора только Excel-файлов
                    saveFileDialog.Title = "Сохранить файл Excel";
                    saveFileDialog.FileName = "Инциденты.xlsx"; // Имя файла по умолчанию

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = saveFileDialog.FileName;

                        isReport = false;
                        WriteToExcel(_incident, filePath);

                        MessageBox.Show($"Данные успешно записаны в файл: {filePath}", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

            if (isReport)
            {
                MessageBox.Show("Отсутствуют данные для выгрузки.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            var isReport = true;

            if (guna2ComboBox1.Text == "Данные по всем поездкам клиентов")
            {
                if (_report.Count > 0)
                {
                    isReport = false;
                    FormReportBooking report = new(_report, 1, new());
                    report.ShowDialog();
                }
            }
            else if (guna2ComboBox1.Text == "Данные по всем инцидентам в рамках поездок клиентов")
            {
                if (_incident.Count > 0)
                {
                    isReport = false;
                    FormReportBooking report = new(new(), 2, _incident);
                    report.ShowDialog();
                }
            }

            if (isReport)
            {
                MessageBox.Show("Отсутствуют данные для выгрузки.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Записывает список объектов в Excel-файл.
        /// </summary>
        /// <typeparam name="T">Тип модели данных.</typeparam>
        /// <param name="data">Список объектов для записи.</param>
        /// <param name="filePath">Путь для сохранения.</param>
        public void WriteToExcel<T>(IEnumerable<T> data, string filePath)
        {
            // Устанавливаем контекст лицензии для EPPlus (требуется для коммерческого использования)
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            // Создаем новый Excel-пакет
            using (var package = new ExcelPackage())
            {
                // Добавляем лист в файл
                var worksheet = package.Workbook.Worksheets.Add("Data");

                // Получаем свойства модели
                var properties = typeof(T).GetProperties();

                // Записываем заголовки столбцов
                for (int i = 0; i < properties.Length; i++)
                {
                    worksheet.Cells[1, i + 1].Value = properties[i].Name;
                }

                // Записываем данные
                int row = 2;
                foreach (var item in data)
                {
                    for (int col = 0; col < properties.Length; col++)
                    {
                        var value = properties[col].GetValue(item)?.ToString() ?? string.Empty;
                        worksheet.Cells[row, col + 1].Value = value;
                    }
                    row++;
                }

                // Авто-подгонка ширины столбцов
                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                // Сохраняем файл
                var fileInfo = new FileInfo(filePath);
                package.SaveAs(fileInfo);
            }
        }
    }
}

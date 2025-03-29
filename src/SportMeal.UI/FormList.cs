using OfficeOpenXml;
using SportMeal.UI.Client;
using SportMeal.UI.FormDialog;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SportMeal.UI;

public partial class FormList : Form
{
    private object _data;
    private readonly ApiClient _apiClient;
    private readonly FormMain _formMain;

    public FormList(FormMain formMain, ApiClient apiClient, object data)
    {
        InitializeComponent();
        _apiClient = apiClient;
        _formMain = formMain;
        _data = data;
        if (_data is not null)
        {
            UploadDataAsync(_data);
        }

        if (_data is List<Order>)
        {
            guna2Button2.Visible = true;
            guna2Button2.Text = "НаПредыдущийСтатус";
            guna2Button1.Text = "НаСледующийСтатус";
            guna2Button4.Text = "Отменить";
        }
        else if (_data is null)
        {
            guna2Button2.Visible = true;
            guna2Button2.Text = "Выгрузить";
            guna2Button1.Text = "ПродажиПоДням";
            guna2Button4.Text = "ПродажиПродуктов";
        }
        else
        {
            guna2Button2.Visible = false;
            guna2Button1.Text = "Добавить";
            guna2Button4.Text = "Редактировать";
        }
    }

    private async void FormMain_Load(object sender, EventArgs e)
    {
    }

    public async Task UploadDataAsync(object data)
    {
        guna2DataGridView1.DataSource = data;
    }

    private void guna2ControlBox2_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private bool IsSelecedRow()
    {
        if (guna2DataGridView1.SelectedRows.Count <= 0)
        {
            MessageBox.Show("Выберите запись для данного действия.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return false;
        }
        return true;
    }

    private async void guna2Button4_Click_1(object sender, EventArgs e)
    {
        if (!IsSelecedRow())
        {
            return;
        }

        var selectedRow = guna2DataGridView1.SelectedRows[0];

        if (_data is List<Category>)
        {
            var localCateg = new Category()
            {
                Id = (int)selectedRow.Cells[0].Value,
                Name = selectedRow.Cells[1].Value.ToString(),
                Description = selectedRow.Cells[2].Value.ToString()
            };

            FormCateg frm = new FormCateg(_apiClient, this, localCateg);
            frm.Show();
        }
        else if (_data is List<Product>)
        {
            var localProduct = new Product()
            {
                Id = (int)selectedRow.Cells[0].Value,
                CategoryId = (int)selectedRow.Cells[1].Value,
                Name = selectedRow.Cells[2].Value.ToString(),
                Description = selectedRow.Cells[3].Value.ToString(),
                Price = (decimal)selectedRow.Cells[4].Value,
                StockQuantity = (int)selectedRow.Cells[5].Value
            };

            FormProduct frm = new FormProduct(_apiClient, this, localProduct);
            frm.Show();
        }
        else if (_data is List<Order>)
        {
            if (!IsSelecedRow())
            {
                return;
            }
            var orderId = (int)selectedRow.Cells[0].Value;
            var orderStatus = (OrderStatus)selectedRow.Cells[4].Value;

            if (orderStatus is OrderStatus.Отменен)
            {
                MessageBox.Show("Нет возможности перевести на предыдущий статус", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            orderStatus = OrderStatus.Отменен;

            await UpdateStatusOrder(orderId, orderStatus);
        }
        else if (_data is List<Employee>)
        {
            var localProduct = new Employee()
            {
                Id = (int)selectedRow.Cells[0].Value,
                FirstName = selectedRow.Cells[1].Value.ToString(),
                LastName = selectedRow.Cells[2].Value.ToString(),
                Phone = selectedRow.Cells[3].Value.ToString(),
                Email = selectedRow.Cells[4].Value.ToString(),
                Position = selectedRow.Cells[5].Value.ToString(),
            };

            FormEmployee frm = new FormEmployee(_apiClient, this, localProduct);
            frm.Show();
        }
        else
        {
            try
            {
                _data = await _apiClient.GetReportProductAsync();
                await UploadDataAsync(_data);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }

    private async void guna2Button1_Click(object sender, EventArgs e)
    {
        if (_data is List<Category>)
        {
            FormCateg frm = new FormCateg(_apiClient, this, null);
            frm.Show();
        }
        else if (_data is List<Product>)
        {
            FormProduct frm = new FormProduct(_apiClient, this, null);
            frm.Show();
        }
        else if (_data is List<Order>)
        {
            if (!IsSelecedRow())
            {
                return;
            }
            var selectedRow = guna2DataGridView1.SelectedRows[0];

            var orderId = (int)selectedRow.Cells[0].Value;
            var orderStatus = (OrderStatus)selectedRow.Cells[4].Value;

            if (orderStatus is OrderStatus.Завершен or OrderStatus.Отменен)
            {
                MessageBox.Show("Нет возможности перевести на следующий статус", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            orderStatus = orderStatus == OrderStatus.Новый ? OrderStatus.ВОбработке : OrderStatus.Завершен;

            await UpdateStatusOrder(orderId, orderStatus);
        }
        else if (_data is List<Employee>)
        {
            FormEmployee frm = new FormEmployee(_apiClient, this, null);
            frm.Show();
        }
        else
        {
            try
            {
                _data = await _apiClient.GetReportSalesAsync();
                await UploadDataAsync(_data);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }

    private async Task UpdateStatusOrder(int OrderId, OrderStatus orderStatus)
    {
        try
        {
            await _apiClient.UpdateAsync(OrderId, orderStatus);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            await UploadDataAsync(await _apiClient.GetClientOrdersAsync());
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
    }

    private async void guna2Button2_Click(object sender, EventArgs e)
    {
        if (guna2Button2.Text == "НаПредыдущийСтатус")
        {
            if (!IsSelecedRow())
            {
                return;
            }
            var selectedRow = guna2DataGridView1.SelectedRows[0];

            var orderId = (int)selectedRow.Cells[0].Value;
            var orderStatus = (OrderStatus)selectedRow.Cells[4].Value;

            if (orderStatus == OrderStatus.Новый)
            {
                MessageBox.Show("Нет возможности перевести на предыдущий статус", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            orderStatus = orderStatus == OrderStatus.ВОбработке ? OrderStatus.Новый :
                orderStatus == OrderStatus.Отменен ? OrderStatus.Новый : OrderStatus.ВОбработке;

            await UpdateStatusOrder(orderId, orderStatus);
        }
        else
        {
            if (_data is List<SalesReport> or List<ProductPopularityReport>)
            {
                using var saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Files|*.xlsx"; // Фильтр для выбора только Excel-файлов
                saveFileDialog.Title = "Сохранить файл Excel";
                saveFileDialog.FileName = "Отчет.xlsx"; // Имя файла по умолчанию

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    if (_data is List<SalesReport> salesReports)
                    {
                        WriteToExcel(salesReports, filePath);
                    }
                    else if (_data is List<ProductPopularityReport> popularityReports)
                    {
                        WriteToExcel(popularityReports, filePath);
                    }

                    MessageBox.Show($"Данные успешно записаны в файл: {filePath}", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show($"Выберете отчет!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }

    private void _txtFirstName_TextChanged(object sender, EventArgs e)
    {
        if (guna2DataGridView1.DataSource == null) return;

        var data = (guna2DataGridView1.DataSource as IEnumerable)?.Cast<object>();
        if (data == null) return;

        var searchText = SearchText.Text.ToLower();

        if (string.IsNullOrWhiteSpace(searchText))
        {
            guna2DataGridView1.DataSource = _data;
            return;
        }

        var filtered = data.Where(item =>
        {
            var properties = item.GetType().GetProperties();
            return properties.Any(prop =>
            {
                var value = prop.GetValue(item)?.ToString()?.ToLower();
                return value != null && value.Contains(searchText);
            });
        }).ToList();

        guna2DataGridView1.DataSource = filtered.Any() ? filtered : data;
    }

    private async void FormList_FormClosed(object sender, FormClosedEventArgs e)
    {
        await _formMain.UploadFormAsync();
        await _formMain.UploadProductAsync();
        await _formMain.UploadOrderAsync();
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

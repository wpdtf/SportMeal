using System.Windows.Forms;

namespace SportMeal.UI;

partial class FormList
{
    /// <summary>
    /// Обязательная переменная конструктора.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Освободить все используемые ресурсы.
    /// </summary>
    /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Код, автоматически созданный конструктором форм Windows

    /// <summary>
    /// Требуемый метод для поддержки конструктора — не изменяйте 
    /// содержимое этого метода с помощью редактора кода.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormList));
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
        guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
        label3 = new Label();
        panel2 = new Panel();
        guna2ControlBox3 = new Guna.UI2.WinForms.Guna2ControlBox();
        guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
        guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
        guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(components);
        guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
        guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
        guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
        guna2Button4 = new Guna.UI2.WinForms.Guna2Button();
        guna2ImageButton1 = new Guna.UI2.WinForms.Guna2ImageButton();
        guna2DataGridView1 = new Guna.UI2.WinForms.Guna2DataGridView();
        panel2.SuspendLayout();
        guna2Panel1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)guna2DataGridView1).BeginInit();
        SuspendLayout();
        // 
        // guna2BorderlessForm1
        // 
        guna2BorderlessForm1.AnimationInterval = 100;
        guna2BorderlessForm1.BorderRadius = 20;
        guna2BorderlessForm1.ContainerControl = this;
        guna2BorderlessForm1.DockIndicatorTransparencyValue = 1D;
        guna2BorderlessForm1.DragStartTransparencyValue = 1D;
        guna2BorderlessForm1.TransparentWhileDrag = true;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
        label3.ForeColor = Color.White;
        label3.Location = new Point(14, 14);
        label3.Margin = new Padding(4, 0, 4, 0);
        label3.Name = "label3";
        label3.Size = new Size(151, 20);
        label3.TabIndex = 17;
        label3.Text = "Спортивные товары";
        // 
        // panel2
        // 
        panel2.BackColor = Color.FromArgb(0, 0, 192);
        panel2.Controls.Add(guna2ControlBox3);
        panel2.Controls.Add(guna2ControlBox2);
        panel2.Controls.Add(guna2ControlBox1);
        panel2.Controls.Add(label3);
        panel2.Dock = DockStyle.Top;
        panel2.Location = new Point(0, 0);
        panel2.Margin = new Padding(4);
        panel2.Name = "panel2";
        panel2.Size = new Size(1339, 40);
        panel2.TabIndex = 15;
        // 
        // guna2ControlBox3
        // 
        guna2ControlBox3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        guna2ControlBox3.Animated = true;
        guna2ControlBox3.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox;
        guna2ControlBox3.Cursor = Cursors.Hand;
        guna2ControlBox3.CustomizableEdges = customizableEdges10;
        guna2ControlBox3.FillColor = Color.FromArgb(0, 0, 64);
        guna2ControlBox3.IconColor = Color.White;
        guna2ControlBox3.Location = new Point(1249, 5);
        guna2ControlBox3.Margin = new Padding(3, 2, 3, 2);
        guna2ControlBox3.Name = "guna2ControlBox3";
        guna2ControlBox3.ShadowDecoration.CustomizableEdges = customizableEdges11;
        guna2ControlBox3.Size = new Size(35, 30);
        guna2ControlBox3.TabIndex = 20;
        // 
        // guna2ControlBox2
        // 
        guna2ControlBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        guna2ControlBox2.Animated = true;
        guna2ControlBox2.Cursor = Cursors.Hand;
        guna2ControlBox2.CustomizableEdges = customizableEdges12;
        guna2ControlBox2.FillColor = Color.FromArgb(0, 0, 64);
        guna2ControlBox2.IconColor = Color.White;
        guna2ControlBox2.Location = new Point(1290, 5);
        guna2ControlBox2.Margin = new Padding(3, 2, 3, 2);
        guna2ControlBox2.Name = "guna2ControlBox2";
        guna2ControlBox2.ShadowDecoration.CustomizableEdges = customizableEdges13;
        guna2ControlBox2.Size = new Size(35, 30);
        guna2ControlBox2.TabIndex = 19;
        guna2ControlBox2.Click += guna2ControlBox2_Click;
        // 
        // guna2ControlBox1
        // 
        guna2ControlBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        guna2ControlBox1.Animated = true;
        guna2ControlBox1.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
        guna2ControlBox1.Cursor = Cursors.Hand;
        guna2ControlBox1.CustomizableEdges = customizableEdges14;
        guna2ControlBox1.FillColor = Color.FromArgb(0, 0, 64);
        guna2ControlBox1.IconColor = Color.White;
        guna2ControlBox1.Location = new Point(1209, 5);
        guna2ControlBox1.Margin = new Padding(3, 2, 3, 2);
        guna2ControlBox1.Name = "guna2ControlBox1";
        guna2ControlBox1.ShadowDecoration.CustomizableEdges = customizableEdges15;
        guna2ControlBox1.Size = new Size(35, 30);
        guna2ControlBox1.TabIndex = 18;
        // 
        // guna2DragControl1
        // 
        guna2DragControl1.DockIndicatorTransparencyValue = 1D;
        guna2DragControl1.DragStartTransparencyValue = 1D;
        guna2DragControl1.TargetControl = panel2;
        guna2DragControl1.UseTransparentDrag = true;
        // 
        // guna2Panel1
        // 
        guna2Panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        guna2Panel1.BackColor = Color.White;
        guna2Panel1.BorderColor = Color.FromArgb(0, 0, 192);
        guna2Panel1.BorderThickness = 1;
        guna2Panel1.Controls.Add(guna2Button2);
        guna2Panel1.Controls.Add(guna2Button1);
        guna2Panel1.Controls.Add(guna2Button4);
        guna2Panel1.Controls.Add(guna2ImageButton1);
        guna2Panel1.CustomizableEdges = customizableEdges8;
        guna2Panel1.Location = new Point(0, 40);
        guna2Panel1.Name = "guna2Panel1";
        guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges9;
        guna2Panel1.Size = new Size(1339, 81);
        guna2Panel1.TabIndex = 16;
        // 
        // guna2Button2
        // 
        guna2Button2.Anchor = AnchorStyles.Right;
        guna2Button2.Animated = true;
        guna2Button2.BorderColor = Color.FromArgb(16, 90, 101);
        guna2Button2.BorderRadius = 12;
        guna2Button2.Cursor = Cursors.Hand;
        guna2Button2.CustomizableEdges = customizableEdges1;
        guna2Button2.DisabledState.BorderColor = Color.DarkGray;
        guna2Button2.DisabledState.CustomBorderColor = Color.DarkGray;
        guna2Button2.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
        guna2Button2.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
        guna2Button2.FillColor = Color.FromArgb(0, 0, 192);
        guna2Button2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
        guna2Button2.ForeColor = Color.White;
        guna2Button2.Location = new Point(779, 16);
        guna2Button2.Margin = new Padding(4);
        guna2Button2.Name = "guna2Button2";
        guna2Button2.ShadowDecoration.CustomizableEdges = customizableEdges2;
        guna2Button2.Size = new Size(178, 50);
        guna2Button2.TabIndex = 46;
        guna2Button2.Text = "НаПредыдущийСтатус";
        guna2Button2.Click += guna2Button2_Click;
        // 
        // guna2Button1
        // 
        guna2Button1.Anchor = AnchorStyles.Right;
        guna2Button1.Animated = true;
        guna2Button1.BorderColor = Color.FromArgb(16, 90, 101);
        guna2Button1.BorderRadius = 12;
        guna2Button1.Cursor = Cursors.Hand;
        guna2Button1.CustomizableEdges = customizableEdges3;
        guna2Button1.DisabledState.BorderColor = Color.DarkGray;
        guna2Button1.DisabledState.CustomBorderColor = Color.DarkGray;
        guna2Button1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
        guna2Button1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
        guna2Button1.FillColor = Color.FromArgb(0, 0, 192);
        guna2Button1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
        guna2Button1.ForeColor = Color.White;
        guna2Button1.Location = new Point(965, 16);
        guna2Button1.Margin = new Padding(4);
        guna2Button1.Name = "guna2Button1";
        guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges4;
        guna2Button1.Size = new Size(178, 50);
        guna2Button1.TabIndex = 45;
        guna2Button1.Text = "Добавить";
        guna2Button1.Click += guna2Button1_Click;
        // 
        // guna2Button4
        // 
        guna2Button4.Anchor = AnchorStyles.Right;
        guna2Button4.Animated = true;
        guna2Button4.BorderColor = Color.FromArgb(16, 90, 101);
        guna2Button4.BorderRadius = 12;
        guna2Button4.Cursor = Cursors.Hand;
        guna2Button4.CustomizableEdges = customizableEdges5;
        guna2Button4.DisabledState.BorderColor = Color.DarkGray;
        guna2Button4.DisabledState.CustomBorderColor = Color.DarkGray;
        guna2Button4.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
        guna2Button4.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
        guna2Button4.FillColor = Color.FromArgb(0, 0, 192);
        guna2Button4.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
        guna2Button4.ForeColor = Color.White;
        guna2Button4.Location = new Point(1151, 16);
        guna2Button4.Margin = new Padding(4);
        guna2Button4.Name = "guna2Button4";
        guna2Button4.ShadowDecoration.CustomizableEdges = customizableEdges6;
        guna2Button4.Size = new Size(178, 50);
        guna2Button4.TabIndex = 44;
        guna2Button4.Text = "Редактировать";
        guna2Button4.Click += guna2Button4_Click_1;
        // 
        // guna2ImageButton1
        // 
        guna2ImageButton1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
        guna2ImageButton1.CheckedState.ImageSize = new Size(64, 64);
        guna2ImageButton1.HoverState.ImageSize = new Size(64, 64);
        guna2ImageButton1.Image = (Image)resources.GetObject("guna2ImageButton1.Image");
        guna2ImageButton1.ImageOffset = new Point(0, 0);
        guna2ImageButton1.ImageRotate = 0F;
        guna2ImageButton1.Location = new Point(3, 3);
        guna2ImageButton1.Name = "guna2ImageButton1";
        guna2ImageButton1.PressedState.ImageSize = new Size(64, 64);
        guna2ImageButton1.ShadowDecoration.CustomizableEdges = customizableEdges7;
        guna2ImageButton1.Size = new Size(56, 75);
        guna2ImageButton1.TabIndex = 0;
        // 
        // guna2DataGridView1
        // 
        guna2DataGridView1.AllowUserToAddRows = false;
        guna2DataGridView1.AllowUserToDeleteRows = false;
        guna2DataGridView1.AllowUserToResizeRows = false;
        dataGridViewCellStyle1.BackColor = Color.White;
        dataGridViewCellStyle1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
        dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
        dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(231, 229, 255);
        dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(71, 69, 94);
        guna2DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
        guna2DataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        guna2DataGridView1.BackgroundColor = Color.WhiteSmoke;
        dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = Color.FromArgb(0, 0, 192);
        dataGridViewCellStyle2.Font = new Font("Segoe UI", 11.25F);
        dataGridViewCellStyle2.ForeColor = Color.White;
        dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(0, 0, 192);
        dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
        guna2DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
        guna2DataGridView1.ColumnHeadersHeight = 40;
        guna2DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
        guna2DataGridView1.Cursor = Cursors.Hand;
        dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle3.BackColor = Color.White;
        dataGridViewCellStyle3.Font = new Font("Segoe UI", 11.25F);
        dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
        dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
        dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
        dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
        guna2DataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
        guna2DataGridView1.GridColor = Color.FromArgb(231, 229, 255);
        guna2DataGridView1.Location = new Point(0, 125);
        guna2DataGridView1.Margin = new Padding(4);
        guna2DataGridView1.Name = "guna2DataGridView1";
        guna2DataGridView1.ReadOnly = true;
        guna2DataGridView1.RowHeadersVisible = false;
        guna2DataGridView1.RowHeadersWidth = 51;
        guna2DataGridView1.Size = new Size(1339, 440);
        guna2DataGridView1.TabIndex = 18;
        guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
        guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
        guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.ForeColor = SystemColors.ControlText;
        guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
        guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
        guna2DataGridView1.ThemeStyle.BackColor = Color.WhiteSmoke;
        guna2DataGridView1.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
        guna2DataGridView1.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(51, 182, 185);
        guna2DataGridView1.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
        guna2DataGridView1.ThemeStyle.HeaderStyle.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
        guna2DataGridView1.ThemeStyle.HeaderStyle.ForeColor = Color.White;
        guna2DataGridView1.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
        guna2DataGridView1.ThemeStyle.HeaderStyle.Height = 40;
        guna2DataGridView1.ThemeStyle.ReadOnly = true;
        guna2DataGridView1.ThemeStyle.RowsStyle.BackColor = Color.White;
        guna2DataGridView1.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        guna2DataGridView1.ThemeStyle.RowsStyle.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
        guna2DataGridView1.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
        guna2DataGridView1.ThemeStyle.RowsStyle.Height = 25;
        guna2DataGridView1.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
        guna2DataGridView1.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
        // 
        // FormList
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        ClientSize = new Size(1339, 562);
        Controls.Add(guna2DataGridView1);
        Controls.Add(guna2Panel1);
        Controls.Add(panel2);
        FormBorderStyle = FormBorderStyle.None;
        Icon = (Icon)resources.GetObject("$this.Icon");
        Margin = new Padding(4);
        Name = "FormList";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Form1";
        Load += FormMain_Load;
        panel2.ResumeLayout(false);
        panel2.PerformLayout();
        guna2Panel1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)guna2DataGridView1).EndInit();
        ResumeLayout(false);

    }

    #endregion

    private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Label label3;
    private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
    private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox3;
    private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox2;
    private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
    private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
    private Guna.UI2.WinForms.Guna2ImageButton guna2ImageButton1;
    private Guna.UI2.WinForms.Guna2Button guna2Button4;
    private Guna.UI2.WinForms.Guna2Button guna2Button1;
    private Guna.UI2.WinForms.Guna2DataGridView guna2DataGridView1;
    private Guna.UI2.WinForms.Guna2Button guna2Button2;
}


using Guna.UI2.WinForms;

namespace SportMeal.UI.FormDialog;

partial class FormCateg
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCateg));
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        panel2 = new Panel();
        guna2ControlBox1 = new Guna2ControlBox();
        guna2ControlBox2 = new Guna2ControlBox();
        label3 = new Label();
        guna2DragControl1 = new Guna2DragControl(components);
        guna2BorderlessForm1 = new Guna2BorderlessForm(components);
        guna2ImageButton1 = new Guna2ImageButton();
        _lblLastName = new Guna2HtmlLabel();
        _lblFirstName = new Guna2HtmlLabel();
        _btnCancel = new Guna2Button();
        _btnRegister = new Guna2Button();
        _Description = new Guna2TextBox();
        _Name = new Guna2TextBox();
        panel2.SuspendLayout();
        SuspendLayout();
        // 
        // panel2
        // 
        panel2.BackColor = Color.FromArgb(0, 0, 192);
        panel2.Controls.Add(guna2ControlBox1);
        panel2.Controls.Add(guna2ControlBox2);
        panel2.Controls.Add(label3);
        panel2.Dock = DockStyle.Top;
        panel2.ForeColor = SystemColors.ActiveCaption;
        panel2.Location = new Point(0, 0);
        panel2.Margin = new Padding(4);
        panel2.Name = "panel2";
        panel2.Size = new Size(472, 40);
        panel2.TabIndex = 27;
        // 
        // guna2ControlBox1
        // 
        guna2ControlBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        guna2ControlBox1.Animated = true;
        guna2ControlBox1.Cursor = Cursors.Hand;
        guna2ControlBox1.CustomizableEdges = customizableEdges1;
        guna2ControlBox1.FillColor = Color.FromArgb(0, 0, 64);
        guna2ControlBox1.IconColor = Color.White;
        guna2ControlBox1.Location = new Point(434, 4);
        guna2ControlBox1.Margin = new Padding(3, 2, 3, 2);
        guna2ControlBox1.Name = "guna2ControlBox1";
        guna2ControlBox1.ShadowDecoration.CustomizableEdges = customizableEdges2;
        guna2ControlBox1.Size = new Size(35, 30);
        guna2ControlBox1.TabIndex = 21;
        guna2ControlBox1.Click += _btnClose_Click;
        // 
        // guna2ControlBox2
        // 
        guna2ControlBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        guna2ControlBox2.Animated = true;
        guna2ControlBox2.Cursor = Cursors.Hand;
        guna2ControlBox2.CustomizableEdges = customizableEdges3;
        guna2ControlBox2.FillColor = Color.FromArgb(0, 0, 64);
        guna2ControlBox2.IconColor = Color.White;
        guna2ControlBox2.Location = new Point(667, 5);
        guna2ControlBox2.Margin = new Padding(3, 2, 3, 2);
        guna2ControlBox2.Name = "guna2ControlBox2";
        guna2ControlBox2.ShadowDecoration.CustomizableEdges = customizableEdges4;
        guna2ControlBox2.Size = new Size(35, 30);
        guna2ControlBox2.TabIndex = 20;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
        label3.ForeColor = Color.White;
        label3.Location = new Point(10, 11);
        label3.Margin = new Padding(4, 0, 4, 0);
        label3.Name = "label3";
        label3.Size = new Size(166, 20);
        label3.TabIndex = 17;
        label3.Text = "Изменение категории";
        // 
        // guna2DragControl1
        // 
        guna2DragControl1.DockIndicatorTransparencyValue = 1D;
        guna2DragControl1.DragStartTransparencyValue = 1D;
        guna2DragControl1.TargetControl = panel2;
        guna2DragControl1.UseTransparentDrag = true;
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
        // guna2ImageButton1
        // 
        guna2ImageButton1.CheckedState.ImageSize = new Size(64, 64);
        guna2ImageButton1.HoverState.ImageSize = new Size(64, 64);
        guna2ImageButton1.Image = (Image)resources.GetObject("guna2ImageButton1.Image");
        guna2ImageButton1.ImageOffset = new Point(0, 0);
        guna2ImageButton1.ImageRotate = 0F;
        guna2ImageButton1.Location = new Point(10, 47);
        guna2ImageButton1.Name = "guna2ImageButton1";
        guna2ImageButton1.PressedState.ImageSize = new Size(64, 64);
        guna2ImageButton1.ShadowDecoration.CustomizableEdges = customizableEdges13;
        guna2ImageButton1.Size = new Size(56, 61);
        guna2ImageButton1.TabIndex = 29;
        // 
        // _lblLastName
        // 
        _lblLastName.BackColor = Color.Transparent;
        _lblLastName.Font = new Font("Segoe UI", 9F);
        _lblLastName.ForeColor = Color.Black;
        _lblLastName.Location = new Point(12, 123);
        _lblLastName.Name = "_lblLastName";
        _lblLastName.Size = new Size(61, 17);
        _lblLastName.TabIndex = 43;
        _lblLastName.Text = "Описание:";
        // 
        // _lblFirstName
        // 
        _lblFirstName.BackColor = Color.Transparent;
        _lblFirstName.Font = new Font("Segoe UI", 9F);
        _lblFirstName.ForeColor = Color.Black;
        _lblFirstName.Location = new Point(72, 54);
        _lblFirstName.Name = "_lblFirstName";
        _lblFirstName.Size = new Size(89, 17);
        _lblFirstName.TabIndex = 42;
        _lblFirstName.Text = "Наименование:";
        // 
        // _btnCancel
        // 
        _btnCancel.BorderRadius = 5;
        _btnCancel.CustomizableEdges = customizableEdges5;
        _btnCancel.DisabledState.BorderColor = Color.DarkGray;
        _btnCancel.DisabledState.CustomBorderColor = Color.DarkGray;
        _btnCancel.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
        _btnCancel.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
        _btnCancel.FillColor = Color.FromArgb(0, 0, 192);
        _btnCancel.Font = new Font("Segoe UI", 9F);
        _btnCancel.ForeColor = Color.White;
        _btnCancel.Location = new Point(360, 242);
        _btnCancel.Name = "_btnCancel";
        _btnCancel.ShadowDecoration.CustomizableEdges = customizableEdges6;
        _btnCancel.Size = new Size(100, 40);
        _btnCancel.TabIndex = 38;
        _btnCancel.Text = "Выйти";
        _btnCancel.Click += _btnCancel_Click_1;
        // 
        // _btnRegister
        // 
        _btnRegister.BorderRadius = 5;
        _btnRegister.CustomizableEdges = customizableEdges7;
        _btnRegister.DisabledState.BorderColor = Color.DarkGray;
        _btnRegister.DisabledState.CustomBorderColor = Color.DarkGray;
        _btnRegister.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
        _btnRegister.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
        _btnRegister.FillColor = Color.FromArgb(0, 0, 192);
        _btnRegister.Font = new Font("Segoe UI", 9F);
        _btnRegister.ForeColor = Color.White;
        _btnRegister.Location = new Point(248, 242);
        _btnRegister.Name = "_btnRegister";
        _btnRegister.ShadowDecoration.CustomizableEdges = customizableEdges8;
        _btnRegister.Size = new Size(100, 40);
        _btnRegister.TabIndex = 37;
        _btnRegister.Text = "Сохранить";
        _btnRegister.Click += _btnRegister_Click;
        // 
        // _Description
        // 
        _Description.BorderRadius = 12;
        _Description.Cursor = Cursors.IBeam;
        _Description.CustomizableEdges = customizableEdges9;
        _Description.DefaultText = "";
        _Description.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
        _Description.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
        _Description.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
        _Description.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
        _Description.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
        _Description.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
        _Description.ForeColor = Color.Black;
        _Description.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
        _Description.Location = new Point(12, 143);
        _Description.Multiline = true;
        _Description.Name = "_Description";
        _Description.PlaceholderText = "";
        _Description.SelectedText = "";
        _Description.ShadowDecoration.CustomizableEdges = customizableEdges10;
        _Description.Size = new Size(448, 81);
        _Description.TabIndex = 34;
        // 
        // _Name
        // 
        _Name.BorderRadius = 12;
        _Name.Cursor = Cursors.IBeam;
        _Name.CustomizableEdges = customizableEdges11;
        _Name.DefaultText = "";
        _Name.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
        _Name.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
        _Name.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
        _Name.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
        _Name.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
        _Name.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
        _Name.ForeColor = Color.Black;
        _Name.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
        _Name.Location = new Point(72, 72);
        _Name.Name = "_Name";
        _Name.PlaceholderText = "";
        _Name.SelectedText = "";
        _Name.ShadowDecoration.CustomizableEdges = customizableEdges12;
        _Name.Size = new Size(170, 36);
        _Name.TabIndex = 33;
        // 
        // FormCateg
        // 
        AllowDrop = true;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        ClientSize = new Size(472, 300);
        Controls.Add(_lblLastName);
        Controls.Add(_lblFirstName);
        Controls.Add(_btnCancel);
        Controls.Add(_btnRegister);
        Controls.Add(_Description);
        Controls.Add(_Name);
        Controls.Add(guna2ImageButton1);
        Controls.Add(panel2);
        Font = new Font("Segoe UI", 9F);
        FormBorderStyle = FormBorderStyle.None;
        Icon = (Icon)resources.GetObject("$this.Icon");
        Margin = new Padding(4);
        Name = "FormCateg";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Регистрация";
        FormClosing += FormRegister_FormClosing;
        Load += FormLk_Load;
        panel2.ResumeLayout(false);
        panel2.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }
    private Panel panel2;
    private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox2;
    private Label label3;
    private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
    private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
    private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
    private Guna2ImageButton guna2ImageButton1;
    private Guna2HtmlLabel _lblLastName;
    private Guna2HtmlLabel _lblFirstName;
    private Guna2Button _btnCancel;
    private Guna2Button _btnRegister;
    private Guna2TextBox _Description;
    private Guna2TextBox _Name;
} 
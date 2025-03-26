using Guna.UI2.WinForms;

namespace SportMeal.UI.FormDialog;

partial class FormEditOrderItem
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
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEditOrderItem));
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        _btnRegister = new Guna2Button();
        _btnCancel = new Guna2Button();
        _lblPhone = new Guna2HtmlLabel();
        panel2 = new Panel();
        guna2ControlBox1 = new Guna2ControlBox();
        guna2ControlBox2 = new Guna2ControlBox();
        label3 = new Label();
        guna2DragControl1 = new Guna2DragControl(components);
        guna2BorderlessForm1 = new Guna2BorderlessForm(components);
        flowLayoutPanel1 = new FlowLayoutPanel();
        guna2ImageButton1 = new Guna2ImageButton();
        panel2.SuspendLayout();
        SuspendLayout();
        // 
        // _btnRegister
        // 
        _btnRegister.BorderRadius = 5;
        _btnRegister.CustomizableEdges = customizableEdges1;
        _btnRegister.DisabledState.BorderColor = Color.DarkGray;
        _btnRegister.DisabledState.CustomBorderColor = Color.DarkGray;
        _btnRegister.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
        _btnRegister.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
        _btnRegister.FillColor = Color.FromArgb(0, 0, 192);
        _btnRegister.Font = new Font("Segoe UI", 9F);
        _btnRegister.ForeColor = Color.White;
        _btnRegister.Location = new Point(113, 47);
        _btnRegister.Name = "_btnRegister";
        _btnRegister.ShadowDecoration.CustomizableEdges = customizableEdges2;
        _btnRegister.Size = new Size(176, 40);
        _btnRegister.TabIndex = 7;
        _btnRegister.Text = "Оплачен";
        _btnRegister.Click += _btnRegister_Click;
        // 
        // _btnCancel
        // 
        _btnCancel.BorderRadius = 5;
        _btnCancel.CustomizableEdges = customizableEdges3;
        _btnCancel.DisabledState.BorderColor = Color.DarkGray;
        _btnCancel.DisabledState.CustomBorderColor = Color.DarkGray;
        _btnCancel.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
        _btnCancel.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
        _btnCancel.FillColor = Color.FromArgb(0, 0, 192);
        _btnCancel.Font = new Font("Segoe UI", 9F);
        _btnCancel.ForeColor = Color.White;
        _btnCancel.Location = new Point(315, 47);
        _btnCancel.Name = "_btnCancel";
        _btnCancel.ShadowDecoration.CustomizableEdges = customizableEdges4;
        _btnCancel.Size = new Size(135, 40);
        _btnCancel.TabIndex = 8;
        _btnCancel.Text = "Отменить заказ";
        _btnCancel.Click += _btnCancel_Click;
        // 
        // _lblPhone
        // 
        _lblPhone.BackColor = Color.Transparent;
        _lblPhone.Font = new Font("Segoe UI", 12F);
        _lblPhone.ForeColor = Color.Black;
        _lblPhone.Location = new Point(113, 93);
        _lblPhone.Name = "_lblPhone";
        _lblPhone.Size = new Size(141, 23);
        _lblPhone.TabIndex = 15;
        _lblPhone.TabStop = false;
        _lblPhone.Text = "к оплате 5 900 руб.";
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
        guna2ControlBox1.CustomizableEdges = customizableEdges5;
        guna2ControlBox1.FillColor = Color.FromArgb(0, 0, 64);
        guna2ControlBox1.IconColor = Color.White;
        guna2ControlBox1.Location = new Point(434, 4);
        guna2ControlBox1.Margin = new Padding(3, 2, 3, 2);
        guna2ControlBox1.Name = "guna2ControlBox1";
        guna2ControlBox1.ShadowDecoration.CustomizableEdges = customizableEdges6;
        guna2ControlBox1.Size = new Size(35, 30);
        guna2ControlBox1.TabIndex = 21;
        guna2ControlBox1.Click += _btnClose_Click;
        // 
        // guna2ControlBox2
        // 
        guna2ControlBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        guna2ControlBox2.Animated = true;
        guna2ControlBox2.Cursor = Cursors.Hand;
        guna2ControlBox2.CustomizableEdges = customizableEdges7;
        guna2ControlBox2.FillColor = Color.FromArgb(0, 0, 64);
        guna2ControlBox2.IconColor = Color.White;
        guna2ControlBox2.Location = new Point(667, 5);
        guna2ControlBox2.Margin = new Padding(3, 2, 3, 2);
        guna2ControlBox2.Name = "guna2ControlBox2";
        guna2ControlBox2.ShadowDecoration.CustomizableEdges = customizableEdges8;
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
        label3.Size = new Size(138, 20);
        label3.TabIndex = 17;
        label3.Text = "Просмотр заказа: ";
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
        // flowLayoutPanel1
        // 
        flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        flowLayoutPanel1.AutoScroll = true;
        flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
        flowLayoutPanel1.Location = new Point(0, 122);
        flowLayoutPanel1.Name = "flowLayoutPanel1";
        flowLayoutPanel1.Size = new Size(472, 379);
        flowLayoutPanel1.TabIndex = 28;
        flowLayoutPanel1.WrapContents = false;
        // 
        // guna2ImageButton1
        // 
        guna2ImageButton1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
        guna2ImageButton1.CheckedState.ImageSize = new Size(64, 64);
        guna2ImageButton1.HoverState.ImageSize = new Size(64, 64);
        guna2ImageButton1.Image = (Image)resources.GetObject("guna2ImageButton1.Image");
        guna2ImageButton1.ImageOffset = new Point(0, 0);
        guna2ImageButton1.ImageRotate = 0F;
        guna2ImageButton1.Location = new Point(0, 41);
        guna2ImageButton1.Name = "guna2ImageButton1";
        guna2ImageButton1.PressedState.ImageSize = new Size(64, 64);
        guna2ImageButton1.ShadowDecoration.CustomizableEdges = customizableEdges9;
        guna2ImageButton1.Size = new Size(56, 75);
        guna2ImageButton1.TabIndex = 29;
        // 
        // FormEditOrderItem
        // 
        AllowDrop = true;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        ClientSize = new Size(472, 500);
        Controls.Add(guna2ImageButton1);
        Controls.Add(flowLayoutPanel1);
        Controls.Add(panel2);
        Controls.Add(_lblPhone);
        Controls.Add(_btnCancel);
        Controls.Add(_btnRegister);
        Font = new Font("Segoe UI", 9F);
        FormBorderStyle = FormBorderStyle.None;
        Icon = (Icon)resources.GetObject("$this.Icon");
        Margin = new Padding(4);
        Name = "FormEditOrderItem";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Регистрация";
        FormClosing += FormRegister_FormClosing;
        panel2.ResumeLayout(false);
        panel2.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }
    private Guna.UI2.WinForms.Guna2Button _btnRegister;
    private Guna.UI2.WinForms.Guna2Button _btnCancel;
    private Guna.UI2.WinForms.Guna2HtmlLabel _lblPhone;
    private Panel panel2;
    private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox2;
    private Label label3;
    private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
    private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
    private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
    private FlowLayoutPanel flowLayoutPanel1;
    private Guna2ImageButton guna2ImageButton1;
} 
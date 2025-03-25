using Guna.UI2.WinForms;

namespace SportMeal.UI.FormDialog;

partial class FormRegister
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
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges19 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges20 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges21 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges22 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRegister));
        _txtLogin = new Guna2TextBox();
        _txtPassword = new Guna2TextBox();
        _txtPasswordConfirm = new Guna2TextBox();
        _txtFirstName = new Guna2TextBox();
        _txtLastName = new Guna2TextBox();
        _txtEmail = new Guna2TextBox();
        _txtPhone = new Guna2TextBox();
        _btnRegister = new Guna2Button();
        _btnCancel = new Guna2Button();
        _lblLogin = new Guna2HtmlLabel();
        _lblPassword = new Guna2HtmlLabel();
        _lblPasswordConfirm = new Guna2HtmlLabel();
        _lblFirstName = new Guna2HtmlLabel();
        _lblLastName = new Guna2HtmlLabel();
        _lblEmail = new Guna2HtmlLabel();
        _lblPhone = new Guna2HtmlLabel();
        panel2 = new Panel();
        guna2ControlBox1 = new Guna2ControlBox();
        guna2ControlBox2 = new Guna2ControlBox();
        label3 = new Label();
        guna2DragControl1 = new Guna2DragControl(components);
        guna2BorderlessForm1 = new Guna2BorderlessForm(components);
        panel2.SuspendLayout();
        SuspendLayout();
        // 
        // _txtLogin
        // 
        _txtLogin.BorderRadius = 12;
        _txtLogin.Cursor = Cursors.IBeam;
        _txtLogin.CustomizableEdges = customizableEdges1;
        _txtLogin.DefaultText = "";
        _txtLogin.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
        _txtLogin.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
        _txtLogin.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
        _txtLogin.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
        _txtLogin.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
        _txtLogin.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
        _txtLogin.ForeColor = Color.Black;
        _txtLogin.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
        _txtLogin.Location = new Point(20, 85);
        _txtLogin.Name = "_txtLogin";
        _txtLogin.PlaceholderText = "";
        _txtLogin.SelectedText = "";
        _txtLogin.ShadowDecoration.CustomizableEdges = customizableEdges2;
        _txtLogin.Size = new Size(212, 36);
        _txtLogin.TabIndex = 0;
        // 
        // _txtPassword
        // 
        _txtPassword.BorderRadius = 12;
        _txtPassword.Cursor = Cursors.IBeam;
        _txtPassword.CustomizableEdges = customizableEdges3;
        _txtPassword.DefaultText = "";
        _txtPassword.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
        _txtPassword.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
        _txtPassword.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
        _txtPassword.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
        _txtPassword.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
        _txtPassword.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
        _txtPassword.ForeColor = Color.Black;
        _txtPassword.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
        _txtPassword.Location = new Point(20, 143);
        _txtPassword.Name = "_txtPassword";
        _txtPassword.PasswordChar = '●';
        _txtPassword.PlaceholderText = "";
        _txtPassword.SelectedText = "";
        _txtPassword.ShadowDecoration.CustomizableEdges = customizableEdges4;
        _txtPassword.Size = new Size(212, 36);
        _txtPassword.TabIndex = 1;
        // 
        // _txtPasswordConfirm
        // 
        _txtPasswordConfirm.BorderRadius = 12;
        _txtPasswordConfirm.Cursor = Cursors.IBeam;
        _txtPasswordConfirm.CustomizableEdges = customizableEdges5;
        _txtPasswordConfirm.DefaultText = "";
        _txtPasswordConfirm.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
        _txtPasswordConfirm.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
        _txtPasswordConfirm.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
        _txtPasswordConfirm.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
        _txtPasswordConfirm.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
        _txtPasswordConfirm.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
        _txtPasswordConfirm.ForeColor = Color.Black;
        _txtPasswordConfirm.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
        _txtPasswordConfirm.Location = new Point(20, 198);
        _txtPasswordConfirm.Name = "_txtPasswordConfirm";
        _txtPasswordConfirm.PasswordChar = '●';
        _txtPasswordConfirm.PlaceholderText = "";
        _txtPasswordConfirm.SelectedText = "";
        _txtPasswordConfirm.ShadowDecoration.CustomizableEdges = customizableEdges6;
        _txtPasswordConfirm.Size = new Size(212, 36);
        _txtPasswordConfirm.TabIndex = 2;
        // 
        // _txtFirstName
        // 
        _txtFirstName.BorderRadius = 12;
        _txtFirstName.Cursor = Cursors.IBeam;
        _txtFirstName.CustomizableEdges = customizableEdges7;
        _txtFirstName.DefaultText = "";
        _txtFirstName.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
        _txtFirstName.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
        _txtFirstName.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
        _txtFirstName.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
        _txtFirstName.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
        _txtFirstName.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
        _txtFirstName.ForeColor = Color.Black;
        _txtFirstName.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
        _txtFirstName.Location = new Point(248, 83);
        _txtFirstName.Name = "_txtFirstName";
        _txtFirstName.PlaceholderText = "";
        _txtFirstName.SelectedText = "";
        _txtFirstName.ShadowDecoration.CustomizableEdges = customizableEdges8;
        _txtFirstName.Size = new Size(212, 36);
        _txtFirstName.TabIndex = 3;
        // 
        // _txtLastName
        // 
        _txtLastName.BorderRadius = 12;
        _txtLastName.Cursor = Cursors.IBeam;
        _txtLastName.CustomizableEdges = customizableEdges9;
        _txtLastName.DefaultText = "";
        _txtLastName.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
        _txtLastName.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
        _txtLastName.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
        _txtLastName.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
        _txtLastName.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
        _txtLastName.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
        _txtLastName.ForeColor = Color.Black;
        _txtLastName.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
        _txtLastName.Location = new Point(248, 143);
        _txtLastName.Name = "_txtLastName";
        _txtLastName.PlaceholderText = "";
        _txtLastName.SelectedText = "";
        _txtLastName.ShadowDecoration.CustomizableEdges = customizableEdges10;
        _txtLastName.Size = new Size(212, 36);
        _txtLastName.TabIndex = 4;
        // 
        // _txtEmail
        // 
        _txtEmail.BorderRadius = 12;
        _txtEmail.Cursor = Cursors.IBeam;
        _txtEmail.CustomizableEdges = customizableEdges11;
        _txtEmail.DefaultText = "";
        _txtEmail.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
        _txtEmail.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
        _txtEmail.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
        _txtEmail.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
        _txtEmail.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
        _txtEmail.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
        _txtEmail.ForeColor = Color.Black;
        _txtEmail.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
        _txtEmail.Location = new Point(248, 198);
        _txtEmail.Name = "_txtEmail";
        _txtEmail.PlaceholderText = "";
        _txtEmail.SelectedText = "";
        _txtEmail.ShadowDecoration.CustomizableEdges = customizableEdges12;
        _txtEmail.Size = new Size(212, 36);
        _txtEmail.TabIndex = 5;
        // 
        // _txtPhone
        // 
        _txtPhone.BorderRadius = 12;
        _txtPhone.Cursor = Cursors.IBeam;
        _txtPhone.CustomizableEdges = customizableEdges13;
        _txtPhone.DefaultText = "";
        _txtPhone.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
        _txtPhone.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
        _txtPhone.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
        _txtPhone.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
        _txtPhone.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
        _txtPhone.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
        _txtPhone.ForeColor = Color.Black;
        _txtPhone.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
        _txtPhone.Location = new Point(20, 259);
        _txtPhone.Name = "_txtPhone";
        _txtPhone.PlaceholderText = "";
        _txtPhone.SelectedText = "";
        _txtPhone.ShadowDecoration.CustomizableEdges = customizableEdges14;
        _txtPhone.Size = new Size(212, 36);
        _txtPhone.TabIndex = 6;
        // 
        // _btnRegister
        // 
        _btnRegister.BorderRadius = 5;
        _btnRegister.CustomizableEdges = customizableEdges15;
        _btnRegister.DisabledState.BorderColor = Color.DarkGray;
        _btnRegister.DisabledState.CustomBorderColor = Color.DarkGray;
        _btnRegister.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
        _btnRegister.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
        _btnRegister.FillColor = Color.FromArgb(0, 0, 192);
        _btnRegister.Font = new Font("Segoe UI", 9F);
        _btnRegister.ForeColor = Color.White;
        _btnRegister.Location = new Point(248, 259);
        _btnRegister.Name = "_btnRegister";
        _btnRegister.ShadowDecoration.CustomizableEdges = customizableEdges16;
        _btnRegister.Size = new Size(212, 40);
        _btnRegister.TabIndex = 7;
        _btnRegister.Text = "Зарегистрироваться";
        _btnRegister.Click += _btnRegister_Click;
        // 
        // _btnCancel
        // 
        _btnCancel.BorderRadius = 5;
        _btnCancel.CustomizableEdges = customizableEdges17;
        _btnCancel.DisabledState.BorderColor = Color.DarkGray;
        _btnCancel.DisabledState.CustomBorderColor = Color.DarkGray;
        _btnCancel.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
        _btnCancel.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
        _btnCancel.FillColor = Color.FromArgb(0, 0, 192);
        _btnCancel.Font = new Font("Segoe UI", 9F);
        _btnCancel.ForeColor = Color.White;
        _btnCancel.Location = new Point(248, 305);
        _btnCancel.Name = "_btnCancel";
        _btnCancel.ShadowDecoration.CustomizableEdges = customizableEdges18;
        _btnCancel.Size = new Size(212, 40);
        _btnCancel.TabIndex = 8;
        _btnCancel.Text = "Отмена";
        _btnCancel.Click += _btnCancel_Click;
        // 
        // _lblLogin
        // 
        _lblLogin.BackColor = Color.Transparent;
        _lblLogin.Font = new Font("Segoe UI", 9F);
        _lblLogin.ForeColor = Color.Black;
        _lblLogin.Location = new Point(20, 65);
        _lblLogin.Name = "_lblLogin";
        _lblLogin.Size = new Size(40, 17);
        _lblLogin.TabIndex = 9;
        _lblLogin.Text = "Логин:";
        // 
        // _lblPassword
        // 
        _lblPassword.BackColor = Color.Transparent;
        _lblPassword.Font = new Font("Segoe UI", 9F);
        _lblPassword.ForeColor = Color.Black;
        _lblPassword.Location = new Point(20, 123);
        _lblPassword.Name = "_lblPassword";
        _lblPassword.Size = new Size(48, 17);
        _lblPassword.TabIndex = 10;
        _lblPassword.Text = "Пароль:";
        // 
        // _lblPasswordConfirm
        // 
        _lblPasswordConfirm.BackColor = Color.Transparent;
        _lblPasswordConfirm.Font = new Font("Segoe UI", 9F);
        _lblPasswordConfirm.ForeColor = Color.Black;
        _lblPasswordConfirm.Location = new Point(20, 180);
        _lblPasswordConfirm.Name = "_lblPasswordConfirm";
        _lblPasswordConfirm.Size = new Size(119, 17);
        _lblPasswordConfirm.TabIndex = 11;
        _lblPasswordConfirm.Text = "Подтвердите пароль:";
        // 
        // _lblFirstName
        // 
        _lblFirstName.BackColor = Color.Transparent;
        _lblFirstName.Font = new Font("Segoe UI", 9F);
        _lblFirstName.ForeColor = Color.Black;
        _lblFirstName.Location = new Point(248, 65);
        _lblFirstName.Name = "_lblFirstName";
        _lblFirstName.Size = new Size(30, 17);
        _lblFirstName.TabIndex = 12;
        _lblFirstName.Text = "Имя:";
        // 
        // _lblLastName
        // 
        _lblLastName.BackColor = Color.Transparent;
        _lblLastName.Font = new Font("Segoe UI", 9F);
        _lblLastName.ForeColor = Color.Black;
        _lblLastName.Location = new Point(248, 123);
        _lblLastName.Name = "_lblLastName";
        _lblLastName.Size = new Size(57, 17);
        _lblLastName.TabIndex = 13;
        _lblLastName.Text = "Фамилия:";
        // 
        // _lblEmail
        // 
        _lblEmail.BackColor = Color.Transparent;
        _lblEmail.Font = new Font("Segoe UI", 9F);
        _lblEmail.ForeColor = Color.Black;
        _lblEmail.Location = new Point(248, 180);
        _lblEmail.Name = "_lblEmail";
        _lblEmail.Size = new Size(35, 17);
        _lblEmail.TabIndex = 14;
        _lblEmail.Text = "Email:";
        // 
        // _lblPhone
        // 
        _lblPhone.BackColor = Color.Transparent;
        _lblPhone.Font = new Font("Segoe UI", 9F);
        _lblPhone.ForeColor = Color.Black;
        _lblPhone.Location = new Point(20, 236);
        _lblPhone.Name = "_lblPhone";
        _lblPhone.Size = new Size(54, 17);
        _lblPhone.TabIndex = 15;
        _lblPhone.Text = "Телефон:";
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
        guna2ControlBox1.CustomizableEdges = customizableEdges19;
        guna2ControlBox1.FillColor = Color.FromArgb(0, 0, 64);
        guna2ControlBox1.IconColor = Color.White;
        guna2ControlBox1.Location = new Point(434, 4);
        guna2ControlBox1.Margin = new Padding(3, 2, 3, 2);
        guna2ControlBox1.Name = "guna2ControlBox1";
        guna2ControlBox1.ShadowDecoration.CustomizableEdges = customizableEdges20;
        guna2ControlBox1.Size = new Size(35, 30);
        guna2ControlBox1.TabIndex = 21;
        guna2ControlBox1.Click += _btnCancel_Click;
        // 
        // guna2ControlBox2
        // 
        guna2ControlBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        guna2ControlBox2.Animated = true;
        guna2ControlBox2.Cursor = Cursors.Hand;
        guna2ControlBox2.CustomizableEdges = customizableEdges21;
        guna2ControlBox2.FillColor = Color.FromArgb(0, 0, 64);
        guna2ControlBox2.IconColor = Color.White;
        guna2ControlBox2.Location = new Point(667, 5);
        guna2ControlBox2.Margin = new Padding(3, 2, 3, 2);
        guna2ControlBox2.Name = "guna2ControlBox2";
        guna2ControlBox2.ShadowDecoration.CustomizableEdges = customizableEdges22;
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
        label3.Size = new Size(96, 20);
        label3.TabIndex = 17;
        label3.Text = "Регистрация";
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
        // FormRegister
        // 
        AllowDrop = true;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        ClientSize = new Size(472, 370);
        Controls.Add(panel2);
        Controls.Add(_lblPhone);
        Controls.Add(_lblEmail);
        Controls.Add(_lblLastName);
        Controls.Add(_lblFirstName);
        Controls.Add(_lblPasswordConfirm);
        Controls.Add(_lblPassword);
        Controls.Add(_lblLogin);
        Controls.Add(_btnCancel);
        Controls.Add(_btnRegister);
        Controls.Add(_txtPhone);
        Controls.Add(_txtEmail);
        Controls.Add(_txtLastName);
        Controls.Add(_txtFirstName);
        Controls.Add(_txtPasswordConfirm);
        Controls.Add(_txtPassword);
        Controls.Add(_txtLogin);
        Font = new Font("Segoe UI", 9F);
        FormBorderStyle = FormBorderStyle.None;
        Icon = (Icon)resources.GetObject("$this.Icon");
        Margin = new Padding(4);
        Name = "FormRegister";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Регистрация";
        FormClosing += FormRegister_FormClosing;
        panel2.ResumeLayout(false);
        panel2.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    private Guna.UI2.WinForms.Guna2TextBox _txtLogin;
    private Guna.UI2.WinForms.Guna2TextBox _txtPassword;
    private Guna.UI2.WinForms.Guna2TextBox _txtPasswordConfirm;
    private Guna.UI2.WinForms.Guna2TextBox _txtFirstName;
    private Guna.UI2.WinForms.Guna2TextBox _txtLastName;
    private Guna.UI2.WinForms.Guna2TextBox _txtEmail;
    private Guna.UI2.WinForms.Guna2TextBox _txtPhone;
    private Guna.UI2.WinForms.Guna2Button _btnRegister;
    private Guna.UI2.WinForms.Guna2Button _btnCancel;
    private Guna.UI2.WinForms.Guna2HtmlLabel _lblLogin;
    private Guna.UI2.WinForms.Guna2HtmlLabel _lblPassword;
    private Guna.UI2.WinForms.Guna2HtmlLabel _lblPasswordConfirm;
    private Guna.UI2.WinForms.Guna2HtmlLabel _lblFirstName;
    private Guna.UI2.WinForms.Guna2HtmlLabel _lblLastName;
    private Guna.UI2.WinForms.Guna2HtmlLabel _lblEmail;
    private Guna.UI2.WinForms.Guna2HtmlLabel _lblPhone;
    private Panel panel2;
    private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox2;
    private Label label3;
    private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
    private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
    private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
} 
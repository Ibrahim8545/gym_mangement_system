namespace gym_management_system
{
    partial class Login_form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login_form));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.textUsername = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.bunifuElipse3 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.textPassword = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.show_pass_btn = new System.Windows.Forms.PictureBox();
            this.hide_pass_btn = new System.Windows.Forms.PictureBox();
            this.btnLogin = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.lab_login_error = new System.Windows.Forms.Label();
            this.lab_pass_err = new System.Windows.Forms.Label();
            this.lab_username_err = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.show_pass_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hide_pass_btn)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 50;
            this.bunifuElipse1.TargetControl = this;
            // 
            // bunifuElipse2
            // 
            this.bunifuElipse2.ElipseRadius = 35;
            this.bunifuElipse2.TargetControl = this.textUsername;
            // 
            // textUsername
            // 
            this.textUsername.Location = new System.Drawing.Point(533, 259);
            this.textUsername.Name = "textUsername";
            this.textUsername.Size = new System.Drawing.Size(321, 70);
            this.textUsername.StateActive.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.textUsername.StateActive.Border.Color1 = System.Drawing.Color.Transparent;
            this.textUsername.StateActive.Border.Color2 = System.Drawing.Color.Transparent;
            this.textUsername.StateActive.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.textUsername.StateActive.Border.Width = -2;
            this.textUsername.StateActive.Content.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(71)))), ((int)(((byte)(78)))));
            this.textUsername.StateActive.Content.Font = new System.Drawing.Font("Gilroy-SemiBold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textUsername.StateActive.Content.Padding = new System.Windows.Forms.Padding(-1, 12, -1, 13);
            this.textUsername.StateNormal.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.textUsername.TabIndex = 6;
            this.textUsername.Text = "Username";
            this.textUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textUsername.Enter += new System.EventHandler(this.textUsername_Enter);
            this.textUsername.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Enter_Key);
            this.textUsername.Leave += new System.EventHandler(this.textUsername_Leave);
            // 
            // bunifuElipse3
            // 
            this.bunifuElipse3.ElipseRadius = 35;
            this.bunifuElipse3.TargetControl = this.textPassword;
            // 
            // textPassword
            // 
            this.textPassword.Location = new System.Drawing.Point(533, 359);
            this.textPassword.Name = "textPassword";
            this.textPassword.Size = new System.Drawing.Size(321, 70);
            this.textPassword.StateActive.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.textPassword.StateActive.Border.Color1 = System.Drawing.Color.Transparent;
            this.textPassword.StateActive.Border.Color2 = System.Drawing.Color.Transparent;
            this.textPassword.StateActive.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.textPassword.StateActive.Border.Width = -2;
            this.textPassword.StateActive.Content.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(71)))), ((int)(((byte)(78)))));
            this.textPassword.StateActive.Content.Font = new System.Drawing.Font("Gilroy-SemiBold", 18F);
            this.textPassword.StateActive.Content.Padding = new System.Windows.Forms.Padding(-1, 12, -1, 13);
            this.textPassword.StateNormal.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.textPassword.TabIndex = 7;
            this.textPassword.Text = "Password";
            this.textPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textPassword.TextAlignChanged += new System.EventHandler(this.textPassword_TextAlignChanged);
            this.textPassword.Enter += new System.EventHandler(this.textPassword_Enter);
            this.textPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Enter_Key);
            this.textPassword.Leave += new System.EventHandler(this.textPassword_Leave);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textPassword);
            this.panel1.Controls.Add(this.show_pass_btn);
            this.panel1.Controls.Add(this.textUsername);
            this.panel1.Controls.Add(this.hide_pass_btn);
            this.panel1.Controls.Add(this.btnLogin);
            this.panel1.Controls.Add(this.lab_login_error);
            this.panel1.Controls.Add(this.lab_pass_err);
            this.panel1.Controls.Add(this.lab_username_err);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(971, 631);
            this.panel1.TabIndex = 0;
            // 
            // show_pass_btn
            // 
            this.show_pass_btn.BackColor = System.Drawing.Color.Transparent;
            this.show_pass_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.show_pass_btn.Image = global::gym_management_system.Properties.Resources.eye_2;
            this.show_pass_btn.Location = new System.Drawing.Point(848, 373);
            this.show_pass_btn.Name = "show_pass_btn";
            this.show_pass_btn.Size = new System.Drawing.Size(68, 43);
            this.show_pass_btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.show_pass_btn.TabIndex = 35;
            this.show_pass_btn.TabStop = false;
            this.show_pass_btn.Visible = false;
            this.show_pass_btn.Click += new System.EventHandler(this.show_pass_btn_Click);
            // 
            // hide_pass_btn
            // 
            this.hide_pass_btn.BackColor = System.Drawing.Color.Transparent;
            this.hide_pass_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hide_pass_btn.Image = global::gym_management_system.Properties.Resources.eye_crossed_1;
            this.hide_pass_btn.Location = new System.Drawing.Point(848, 373);
            this.hide_pass_btn.Name = "hide_pass_btn";
            this.hide_pass_btn.Size = new System.Drawing.Size(68, 43);
            this.hide_pass_btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.hide_pass_btn.TabIndex = 36;
            this.hide_pass_btn.TabStop = false;
            this.hide_pass_btn.Visible = false;
            this.hide_pass_btn.Click += new System.EventHandler(this.hide_pass_btn_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.AllowAnimations = true;
            this.btnLogin.AllowMouseEffects = true;
            this.btnLogin.AllowToggling = true;
            this.btnLogin.AnimationSpeed = 200;
            this.btnLogin.AutoGenerateColors = false;
            this.btnLogin.AutoRoundBorders = false;
            this.btnLogin.AutoSizeLeftIcon = true;
            this.btnLogin.AutoSizeRightIcon = true;
            this.btnLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnLogin.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(115)))), ((int)(((byte)(120)))), ((int)(((byte)(255)))));
            this.btnLogin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLogin.BackgroundImage")));
            this.btnLogin.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnLogin.ButtonText = "Login";
            this.btnLogin.ButtonTextMarginLeft = 0;
            this.btnLogin.ColorContrastOnClick = 45;
            this.btnLogin.ColorContrastOnHover = 45;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btnLogin.CustomizableEdges = borderEdges1;
            this.btnLogin.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnLogin.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnLogin.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnLogin.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnLogin.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnLogin.Font = new System.Drawing.Font("Gilroy-SemiBold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(120)))), ((int)(((byte)(255)))));
            this.btnLogin.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogin.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnLogin.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnLogin.IconMarginLeft = 11;
            this.btnLogin.IconPadding = 10;
            this.btnLogin.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLogin.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnLogin.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnLogin.IconSize = 25;
            this.btnLogin.IdleBorderColor = System.Drawing.Color.Empty;
            this.btnLogin.IdleBorderRadius = 30;
            this.btnLogin.IdleBorderThickness = 1;
            this.btnLogin.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(115)))), ((int)(((byte)(120)))), ((int)(((byte)(255)))));
            this.btnLogin.IdleIconLeftImage = null;
            this.btnLogin.IdleIconRightImage = null;
            this.btnLogin.IndicateFocus = false;
            this.btnLogin.Location = new System.Drawing.Point(609, 476);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnLogin.OnDisabledState.BorderRadius = 30;
            this.btnLogin.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnLogin.OnDisabledState.BorderThickness = 1;
            this.btnLogin.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnLogin.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnLogin.OnDisabledState.IconLeftImage = null;
            this.btnLogin.OnDisabledState.IconRightImage = null;
            this.btnLogin.onHoverState.BorderColor = System.Drawing.Color.Empty;
            this.btnLogin.onHoverState.BorderRadius = 30;
            this.btnLogin.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnLogin.onHoverState.BorderThickness = 1;
            this.btnLogin.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(115)))), ((int)(((byte)(120)))), ((int)(((byte)(255)))));
            this.btnLogin.onHoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(120)))), ((int)(((byte)(255)))));
            this.btnLogin.onHoverState.IconLeftImage = null;
            this.btnLogin.onHoverState.IconRightImage = null;
            this.btnLogin.OnIdleState.BorderColor = System.Drawing.Color.Empty;
            this.btnLogin.OnIdleState.BorderRadius = 30;
            this.btnLogin.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnLogin.OnIdleState.BorderThickness = 1;
            this.btnLogin.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(115)))), ((int)(((byte)(120)))), ((int)(((byte)(255)))));
            this.btnLogin.OnIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(120)))), ((int)(((byte)(255)))));
            this.btnLogin.OnIdleState.IconLeftImage = null;
            this.btnLogin.OnIdleState.IconRightImage = null;
            this.btnLogin.OnPressedState.BorderColor = System.Drawing.Color.Empty;
            this.btnLogin.OnPressedState.BorderRadius = 30;
            this.btnLogin.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnLogin.OnPressedState.BorderThickness = 1;
            this.btnLogin.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(115)))), ((int)(((byte)(120)))), ((int)(((byte)(255)))));
            this.btnLogin.OnPressedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(120)))), ((int)(((byte)(255)))));
            this.btnLogin.OnPressedState.IconLeftImage = null;
            this.btnLogin.OnPressedState.IconRightImage = null;
            this.btnLogin.Size = new System.Drawing.Size(163, 71);
            this.btnLogin.TabIndex = 34;
            this.btnLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnLogin.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnLogin.TextMarginLeft = 0;
            this.btnLogin.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnLogin.UseDefaultRadiusAndThickness = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lab_login_error
            // 
            this.lab_login_error.AutoSize = true;
            this.lab_login_error.Font = new System.Drawing.Font("Ubuntu", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_login_error.ForeColor = System.Drawing.Color.IndianRed;
            this.lab_login_error.Location = new System.Drawing.Point(574, 547);
            this.lab_login_error.Name = "lab_login_error";
            this.lab_login_error.Size = new System.Drawing.Size(0, 26);
            this.lab_login_error.TabIndex = 33;
            // 
            // lab_pass_err
            // 
            this.lab_pass_err.AutoSize = true;
            this.lab_pass_err.BackColor = System.Drawing.Color.Transparent;
            this.lab_pass_err.Font = new System.Drawing.Font("Ubuntu", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_pass_err.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.lab_pass_err.Location = new System.Drawing.Point(545, 435);
            this.lab_pass_err.Name = "lab_pass_err";
            this.lab_pass_err.Size = new System.Drawing.Size(0, 27);
            this.lab_pass_err.TabIndex = 32;
            // 
            // lab_username_err
            // 
            this.lab_username_err.AutoSize = true;
            this.lab_username_err.BackColor = System.Drawing.Color.Transparent;
            this.lab_username_err.Font = new System.Drawing.Font("Ubuntu", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_username_err.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.lab_username_err.Location = new System.Drawing.Point(545, 329);
            this.lab_username_err.Name = "lab_username_err";
            this.lab_username_err.Size = new System.Drawing.Size(0, 27);
            this.lab_username_err.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Gilroy-Bold", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(558, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(273, 69);
            this.label1.TabIndex = 37;
            this.label1.Text = "Welcome";
            // 
            // Login_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(971, 631);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Gilroy-UltraLight", 7.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Enter_Key);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.show_pass_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hide_pass_btn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox textUsername;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox textPassword;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse3;
        private System.Windows.Forms.Label lab_login_error;
        private System.Windows.Forms.Label lab_pass_err;
        private System.Windows.Forms.Label lab_username_err;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnLogin;
        private System.Windows.Forms.PictureBox show_pass_btn;
        private System.Windows.Forms.PictureBox hide_pass_btn;
        private System.Windows.Forms.Label label1;
    }
}


namespace gym_management_system
{
    partial class Members
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Members));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            this.panelMemberView = new System.Windows.Forms.Panel();
            this.MemberData = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Age = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Brithday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdd = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.textSearch = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.labelsh = new System.Windows.Forms.Label();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.backgroundWorkergetMember = new System.ComponentModel.BackgroundWorker();
            this.panelconnectionError = new System.Windows.Forms.Panel();
            this.btnLogin = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panelloading = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.backgroundWorkerMemberFilter = new System.ComponentModel.BackgroundWorker();
            this.panelMemberView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MemberData)).BeginInit();
            this.panelconnectionError.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panelloading.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMemberView
            // 
            this.panelMemberView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMemberView.Controls.Add(this.MemberData);
            this.panelMemberView.Controls.Add(this.btnAdd);
            this.panelMemberView.Controls.Add(this.textSearch);
            this.panelMemberView.Location = new System.Drawing.Point(0, 136);
            this.panelMemberView.Name = "panelMemberView";
            this.panelMemberView.Size = new System.Drawing.Size(2113, 1044);
            this.panelMemberView.TabIndex = 0;
            this.panelMemberView.Visible = false;
            // 
            // MemberData
            // 
            this.MemberData.AllowUserToAddRows = false;
            this.MemberData.AllowUserToDeleteRows = false;
            this.MemberData.AllowUserToResizeColumns = false;
            this.MemberData.AllowUserToResizeRows = false;
            this.MemberData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MemberData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MemberData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.MemberData.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.MemberData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MemberData.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.MemberData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(72)))), ((int)(((byte)(153)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Gilroy-Bold", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(253)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(72)))), ((int)(((byte)(153)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(253)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.MemberData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.MemberData.ColumnHeadersHeight = 55;
            this.MemberData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.MName,
            this.Gender,
            this.Age,
            this.Brithday,
            this.Email,
            this.Phone});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Gilroy-Regular", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(253)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(120)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.MemberData.DefaultCellStyle = dataGridViewCellStyle2;
            this.MemberData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.MemberData.EnableHeadersVisualStyles = false;
            this.MemberData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(26)))));
            this.MemberData.Location = new System.Drawing.Point(109, 118);
            this.MemberData.Margin = new System.Windows.Forms.Padding(2, 8, 38, 40);
            this.MemberData.MultiSelect = false;
            this.MemberData.Name = "MemberData";
            this.MemberData.ReadOnly = true;
            this.MemberData.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.MemberData.RowHeadersVisible = false;
            this.MemberData.RowHeadersWidth = 82;
            this.MemberData.RowTemplate.Height = 45;
            this.MemberData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.MemberData.Size = new System.Drawing.Size(1912, 877);
            this.MemberData.TabIndex = 36;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.MinimumWidth = 8;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // MName
            // 
            this.MName.DataPropertyName = "Name";
            this.MName.HeaderText = "Name";
            this.MName.MinimumWidth = 8;
            this.MName.Name = "MName";
            this.MName.ReadOnly = true;
            // 
            // Gender
            // 
            this.Gender.DataPropertyName = "Gender";
            this.Gender.HeaderText = "Gender";
            this.Gender.MinimumWidth = 8;
            this.Gender.Name = "Gender";
            this.Gender.ReadOnly = true;
            // 
            // Age
            // 
            this.Age.DataPropertyName = "Age";
            this.Age.HeaderText = "Age";
            this.Age.MinimumWidth = 8;
            this.Age.Name = "Age";
            this.Age.ReadOnly = true;
            // 
            // Brithday
            // 
            this.Brithday.DataPropertyName = "BrithDay";
            this.Brithday.HeaderText = "Brithday";
            this.Brithday.MinimumWidth = 8;
            this.Brithday.Name = "Brithday";
            this.Brithday.ReadOnly = true;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.MinimumWidth = 8;
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            // 
            // Phone
            // 
            this.Phone.DataPropertyName = "PhoneNumber";
            this.Phone.HeaderText = "Phone";
            this.Phone.MinimumWidth = 8;
            this.Phone.Name = "Phone";
            this.Phone.ReadOnly = true;
            // 
            // btnAdd
            // 
            this.btnAdd.AllowAnimations = true;
            this.btnAdd.AllowMouseEffects = true;
            this.btnAdd.AllowToggling = true;
            this.btnAdd.AnimationSpeed = 200;
            this.btnAdd.AutoGenerateColors = false;
            this.btnAdd.AutoRoundBorders = false;
            this.btnAdd.AutoSizeLeftIcon = true;
            this.btnAdd.AutoSizeRightIcon = true;
            this.btnAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnAdd.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(115)))), ((int)(((byte)(120)))), ((int)(((byte)(255)))));
            this.btnAdd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAdd.BackgroundImage")));
            this.btnAdd.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnAdd.ButtonText = "Add";
            this.btnAdd.ButtonTextMarginLeft = 0;
            this.btnAdd.ColorContrastOnClick = 45;
            this.btnAdd.ColorContrastOnHover = 45;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btnAdd.CustomizableEdges = borderEdges1;
            this.btnAdd.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAdd.DisabledBorderColor = System.Drawing.Color.Transparent;
            this.btnAdd.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(115)))), ((int)(((byte)(120)))), ((int)(((byte)(255)))));
            this.btnAdd.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(120)))), ((int)(((byte)(255)))));
            this.btnAdd.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnAdd.Font = new System.Drawing.Font("Gilroy-SemiBold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(120)))), ((int)(((byte)(255)))));
            this.btnAdd.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnAdd.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnAdd.IconMarginLeft = 11;
            this.btnAdd.IconPadding = 10;
            this.btnAdd.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnAdd.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnAdd.IconSize = 25;
            this.btnAdd.IdleBorderColor = System.Drawing.Color.Empty;
            this.btnAdd.IdleBorderRadius = 30;
            this.btnAdd.IdleBorderThickness = 1;
            this.btnAdd.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(115)))), ((int)(((byte)(120)))), ((int)(((byte)(255)))));
            this.btnAdd.IdleIconLeftImage = null;
            this.btnAdd.IdleIconRightImage = null;
            this.btnAdd.IndicateFocus = false;
            this.btnAdd.Location = new System.Drawing.Point(583, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.OnDisabledState.BorderColor = System.Drawing.Color.Transparent;
            this.btnAdd.OnDisabledState.BorderRadius = 30;
            this.btnAdd.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnAdd.OnDisabledState.BorderThickness = 1;
            this.btnAdd.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(115)))), ((int)(((byte)(120)))), ((int)(((byte)(255)))));
            this.btnAdd.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(120)))), ((int)(((byte)(255)))));
            this.btnAdd.OnDisabledState.IconLeftImage = null;
            this.btnAdd.OnDisabledState.IconRightImage = null;
            this.btnAdd.onHoverState.BorderColor = System.Drawing.Color.Empty;
            this.btnAdd.onHoverState.BorderRadius = 30;
            this.btnAdd.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnAdd.onHoverState.BorderThickness = 1;
            this.btnAdd.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(115)))), ((int)(((byte)(120)))), ((int)(((byte)(255)))));
            this.btnAdd.onHoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(120)))), ((int)(((byte)(255)))));
            this.btnAdd.onHoverState.IconLeftImage = null;
            this.btnAdd.onHoverState.IconRightImage = null;
            this.btnAdd.OnIdleState.BorderColor = System.Drawing.Color.Empty;
            this.btnAdd.OnIdleState.BorderRadius = 30;
            this.btnAdd.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnAdd.OnIdleState.BorderThickness = 1;
            this.btnAdd.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(115)))), ((int)(((byte)(120)))), ((int)(((byte)(255)))));
            this.btnAdd.OnIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(120)))), ((int)(((byte)(255)))));
            this.btnAdd.OnIdleState.IconLeftImage = null;
            this.btnAdd.OnIdleState.IconRightImage = null;
            this.btnAdd.OnPressedState.BorderColor = System.Drawing.Color.Empty;
            this.btnAdd.OnPressedState.BorderRadius = 30;
            this.btnAdd.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnAdd.OnPressedState.BorderThickness = 1;
            this.btnAdd.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(115)))), ((int)(((byte)(120)))), ((int)(((byte)(255)))));
            this.btnAdd.OnPressedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(120)))), ((int)(((byte)(255)))));
            this.btnAdd.OnPressedState.IconLeftImage = null;
            this.btnAdd.OnPressedState.IconRightImage = null;
            this.btnAdd.Size = new System.Drawing.Size(163, 71);
            this.btnAdd.TabIndex = 35;
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAdd.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnAdd.TextMarginLeft = 0;
            this.btnAdd.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnAdd.UseDefaultRadiusAndThickness = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // textSearch
            // 
            this.textSearch.Location = new System.Drawing.Point(81, 12);
            this.textSearch.Name = "textSearch";
            this.textSearch.Size = new System.Drawing.Size(460, 70);
            this.textSearch.StateActive.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(26)))));
            this.textSearch.StateActive.Border.Color1 = System.Drawing.Color.Transparent;
            this.textSearch.StateActive.Border.Color2 = System.Drawing.Color.Transparent;
            this.textSearch.StateActive.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.textSearch.StateActive.Border.Width = -2;
            this.textSearch.StateActive.Content.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(71)))), ((int)(((byte)(78)))));
            this.textSearch.StateActive.Content.Font = new System.Drawing.Font("Gilroy-SemiBold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textSearch.StateActive.Content.Padding = new System.Windows.Forms.Padding(15, 12, -1, 13);
            this.textSearch.StateDisabled.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(26)))));
            this.textSearch.StateDisabled.Border.Color1 = System.Drawing.Color.Transparent;
            this.textSearch.StateDisabled.Border.Color2 = System.Drawing.Color.Transparent;
            this.textSearch.StateDisabled.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.textSearch.StateDisabled.Border.Width = -2;
            this.textSearch.StateDisabled.Content.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(71)))), ((int)(((byte)(78)))));
            this.textSearch.StateDisabled.Content.Font = new System.Drawing.Font("Gilroy-SemiBold", 18F);
            this.textSearch.StateDisabled.Content.Padding = new System.Windows.Forms.Padding(15, 12, -1, 13);
            this.textSearch.StateNormal.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(26)))));
            this.textSearch.StateNormal.Content.Padding = new System.Windows.Forms.Padding(15, 12, -1, 13);
            this.textSearch.TabIndex = 3;
            this.textSearch.Text = "Search";
            this.textSearch.TextChanged += new System.EventHandler(this.textSearch_TextChanged);
            this.textSearch.Enter += new System.EventHandler(this.textSearch_Enter);
            this.textSearch.Leave += new System.EventHandler(this.textSearch_Leave);
            // 
            // labelsh
            // 
            this.labelsh.AutoSize = true;
            this.labelsh.Font = new System.Drawing.Font("Gilroy-Bold", 45F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelsh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(253)))));
            this.labelsh.Location = new System.Drawing.Point(12, 14);
            this.labelsh.Name = "labelsh";
            this.labelsh.Size = new System.Drawing.Size(430, 112);
            this.labelsh.TabIndex = 1;
            this.labelsh.Text = "Members";
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 50;
            this.bunifuElipse1.TargetControl = this.MemberData;
            // 
            // bunifuElipse2
            // 
            this.bunifuElipse2.ElipseRadius = 50;
            this.bunifuElipse2.TargetControl = this.textSearch;
            // 
            // backgroundWorkergetMember
            // 
            this.backgroundWorkergetMember.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkergetMember_DoWork);
            this.backgroundWorkergetMember.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkergetMember_RunWorkerCompleted);
            // 
            // panelconnectionError
            // 
            this.panelconnectionError.Controls.Add(this.btnLogin);
            this.panelconnectionError.Controls.Add(this.label1);
            this.panelconnectionError.Controls.Add(this.pictureBox2);
            this.panelconnectionError.Location = new System.Drawing.Point(776, 567);
            this.panelconnectionError.Name = "panelconnectionError";
            this.panelconnectionError.Size = new System.Drawing.Size(528, 321);
            this.panelconnectionError.TabIndex = 3;
            this.panelconnectionError.Visible = false;
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
            this.btnLogin.ButtonText = "Refresh";
            this.btnLogin.ButtonTextMarginLeft = 0;
            this.btnLogin.ColorContrastOnClick = 45;
            this.btnLogin.ColorContrastOnHover = 45;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.btnLogin.CustomizableEdges = borderEdges2;
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
            this.btnLogin.Location = new System.Drawing.Point(184, 236);
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
            this.btnLogin.TabIndex = 35;
            this.btnLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnLogin.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnLogin.TextMarginLeft = 0;
            this.btnLogin.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnLogin.UseDefaultRadiusAndThickness = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Gilroy-SemiBold", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(71)))), ((int)(((byte)(78)))));
            this.label1.Location = new System.Drawing.Point(91, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(354, 39);
            this.label1.TabIndex = 1;
            this.label1.Text = "Check your connection";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::gym_management_system.Properties.Resources.wifi_slash_2;
            this.pictureBox2.Location = new System.Drawing.Point(128, 9);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(270, 177);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // panelloading
            // 
            this.panelloading.Controls.Add(this.pictureBox1);
            this.panelloading.Location = new System.Drawing.Point(691, 536);
            this.panelloading.Name = "panelloading";
            this.panelloading.Size = new System.Drawing.Size(730, 331);
            this.panelloading.TabIndex = 4;
            this.panelloading.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::gym_management_system.Properties.Resources._154039234778Fitness_Center;
            this.pictureBox1.Location = new System.Drawing.Point(57, -31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(627, 362);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // backgroundWorkerMemberFilter
            // 
            this.backgroundWorkerMemberFilter.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerMemberFilter_DoWork);
            this.backgroundWorkerMemberFilter.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerMemberFilter_RunWorkerCompleted);
            // 
            // Members
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(2113, 1180);
            this.Controls.Add(this.panelloading);
            this.Controls.Add(this.panelconnectionError);
            this.Controls.Add(this.panelMemberView);
            this.Controls.Add(this.labelsh);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Members";
            this.Text = "Members";
            this.panelMemberView.ResumeLayout(false);
            this.panelMemberView.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MemberData)).EndInit();
            this.panelconnectionError.ResumeLayout(false);
            this.panelconnectionError.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panelloading.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelMemberView;
        private System.Windows.Forms.Label labelsh;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox textSearch;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private System.ComponentModel.BackgroundWorker backgroundWorkergetMember;
        private System.Windows.Forms.Panel panelconnectionError;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panelloading;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorkerMemberFilter;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnAdd;
        private System.Windows.Forms.DataGridView MemberData;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn MName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn Age;
        private System.Windows.Forms.DataGridViewTextBoxColumn Brithday;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
    }
}
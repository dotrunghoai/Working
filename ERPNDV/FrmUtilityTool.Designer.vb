<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmUtilityTool
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.bttConnect = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPathEntity = New System.Windows.Forms.TextBox()
        Me.bttPathEntity = New System.Windows.Forms.Button()
        Me.bttGenerate = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtServer = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtUserId = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDatabase = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ckoVB = New System.Windows.Forms.CheckBox()
        Me.ckoCSharp = New System.Windows.Forms.CheckBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tabUpdate = New System.Windows.Forms.TabPage()
        Me.GridControlUD = New DevExpress.XtraGrid.GridControl()
        Me.GridViewUD = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.bttUpdate = New System.Windows.Forms.Button()
        Me.bttSaveUpdate = New System.Windows.Forms.Button()
        Me.txtDestination = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.bttServer = New System.Windows.Forms.Button()
        Me.txtBuildFolder = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.bttBuild = New System.Windows.Forms.Button()
        Me.tabGenerateDB = New System.Windows.Forms.TabPage()
        Me.GridControlTB = New DevExpress.XtraGrid.GridControl()
        Me.GridViewTB = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.bttSavePath = New System.Windows.Forms.Button()
        Me.txtPathStore = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.bttPathStore = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ckoStore = New System.Windows.Forms.CheckBox()
        Me.ckoTableName = New System.Windows.Forms.CheckBox()
        Me.ckoTableClass = New System.Windows.Forms.CheckBox()
        Me.tabEncryptPassword = New System.Windows.Forms.TabPage()
        Me.bttDecryption = New System.Windows.Forms.Button()
        Me.bttEncryption = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtResult = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtInput = New System.Windows.Forms.TextBox()
        Me.Admin = New System.Windows.Forms.TabPage()
        Me.GridControlS = New DevExpress.XtraGrid.GridControl()
        Me.GridViewS = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.AutoCopy = New System.Windows.Forms.TabPage()
        Me.txtLastCopy = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.txthours = New DevExpress.XtraEditors.TextEdit()
        Me.txtNextCopy = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.ckoAutoCopy = New DevExpress.XtraEditors.CheckEdit()
        Me.txtStatusBK = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.bttCopy = New DevExpress.XtraEditors.SimpleButton()
        Me.bttDestinationBK = New DevExpress.XtraEditors.SimpleButton()
        Me.bttSource = New DevExpress.XtraEditors.SimpleButton()
        Me.txtDestinationBK = New DevExpress.XtraEditors.TextEdit()
        Me.txtSourceBK = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TimerCopyFile = New System.Windows.Forms.Timer(Me.components)
        Me.mnuShowAll = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tabUpdate.SuspendLayout()
        CType(Me.GridControlUD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewUD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabGenerateDB.SuspendLayout()
        CType(Me.GridControlTB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewTB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.tabEncryptPassword.SuspendLayout()
        Me.Admin.SuspendLayout()
        CType(Me.GridControlS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.AutoCopy.SuspendLayout()
        CType(Me.txtLastCopy.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txthours.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNextCopy.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ckoAutoCopy.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtStatusBK.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDestinationBK.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSourceBK.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'bttConnect
        '
        Me.bttConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bttConnect.ForeColor = System.Drawing.Color.Blue
        Me.bttConnect.Location = New System.Drawing.Point(127, 149)
        Me.bttConnect.Name = "bttConnect"
        Me.bttConnect.Size = New System.Drawing.Size(75, 23)
        Me.bttConnect.TabIndex = 4
        Me.bttConnect.Text = "Connect"
        Me.bttConnect.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Entity Class"
        '
        'txtPathEntity
        '
        Me.txtPathEntity.Location = New System.Drawing.Point(119, 17)
        Me.txtPathEntity.Name = "txtPathEntity"
        Me.txtPathEntity.Size = New System.Drawing.Size(312, 20)
        Me.txtPathEntity.TabIndex = 0
        '
        'bttPathEntity
        '
        Me.bttPathEntity.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bttPathEntity.Location = New System.Drawing.Point(437, 15)
        Me.bttPathEntity.Name = "bttPathEntity"
        Me.bttPathEntity.Size = New System.Drawing.Size(43, 23)
        Me.bttPathEntity.TabIndex = 1
        Me.bttPathEntity.Text = "..."
        Me.bttPathEntity.UseVisualStyleBackColor = True
        '
        'bttGenerate
        '
        Me.bttGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bttGenerate.ForeColor = System.Drawing.Color.Blue
        Me.bttGenerate.Location = New System.Drawing.Point(151, 378)
        Me.bttGenerate.Name = "bttGenerate"
        Me.bttGenerate.Size = New System.Drawing.Size(75, 23)
        Me.bttGenerate.TabIndex = 3
        Me.bttGenerate.Text = "Generate"
        Me.bttGenerate.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(27, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Server"
        '
        'txtServer
        '
        Me.txtServer.Location = New System.Drawing.Point(90, 19)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.Size = New System.Drawing.Size(206, 20)
        Me.txtServer.TabIndex = 0
        Me.txtServer.Text = "10.153.1.7"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtPassword)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtUserId)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtDatabase)
        Me.GroupBox1.Controls.Add(Me.bttConnect)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtServer)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(24, 83)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(322, 181)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Server"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(90, 118)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(206, 20)
        Me.txtPassword.TabIndex = 3
        Me.txtPassword.Text = "P@ssw0rd"
        Me.txtPassword.UseSystemPasswordChar = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(27, 118)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Password"
        '
        'txtUserId
        '
        Me.txtUserId.Location = New System.Drawing.Point(90, 85)
        Me.txtUserId.Name = "txtUserId"
        Me.txtUserId.Size = New System.Drawing.Size(206, 20)
        Me.txtUserId.TabIndex = 2
        Me.txtUserId.Text = "sa"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(27, 85)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "UserID"
        '
        'txtDatabase
        '
        Me.txtDatabase.Location = New System.Drawing.Point(90, 52)
        Me.txtDatabase.Name = "txtDatabase"
        Me.txtDatabase.Size = New System.Drawing.Size(206, 20)
        Me.txtDatabase.TabIndex = 1
        Me.txtDatabase.Text = "NDVERP"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(27, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Database"
        '
        'ckoVB
        '
        Me.ckoVB.AutoSize = True
        Me.ckoVB.Checked = True
        Me.ckoVB.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckoVB.Location = New System.Drawing.Point(30, 16)
        Me.ckoVB.Name = "ckoVB"
        Me.ckoVB.Size = New System.Drawing.Size(58, 17)
        Me.ckoVB.TabIndex = 8
        Me.ckoVB.Text = "VB.net"
        Me.ckoVB.UseVisualStyleBackColor = True
        '
        'ckoCSharp
        '
        Me.ckoCSharp.AutoSize = True
        Me.ckoCSharp.Location = New System.Drawing.Point(127, 16)
        Me.ckoCSharp.Name = "ckoCSharp"
        Me.ckoCSharp.Size = New System.Drawing.Size(58, 17)
        Me.ckoCSharp.TabIndex = 9
        Me.ckoCSharp.Text = "C#.net"
        Me.ckoCSharp.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tabUpdate)
        Me.TabControl1.Controls.Add(Me.tabGenerateDB)
        Me.TabControl1.Controls.Add(Me.tabEncryptPassword)
        Me.TabControl1.Controls.Add(Me.Admin)
        Me.TabControl1.Controls.Add(Me.AutoCopy)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(869, 553)
        Me.TabControl1.TabIndex = 10
        '
        'tabUpdate
        '
        Me.tabUpdate.BackColor = System.Drawing.Color.WhiteSmoke
        Me.tabUpdate.Controls.Add(Me.GridControlUD)
        Me.tabUpdate.Controls.Add(Me.bttUpdate)
        Me.tabUpdate.Controls.Add(Me.bttSaveUpdate)
        Me.tabUpdate.Controls.Add(Me.txtDestination)
        Me.tabUpdate.Controls.Add(Me.Label9)
        Me.tabUpdate.Controls.Add(Me.bttServer)
        Me.tabUpdate.Controls.Add(Me.txtBuildFolder)
        Me.tabUpdate.Controls.Add(Me.Label10)
        Me.tabUpdate.Controls.Add(Me.bttBuild)
        Me.tabUpdate.Location = New System.Drawing.Point(4, 22)
        Me.tabUpdate.Name = "tabUpdate"
        Me.tabUpdate.Padding = New System.Windows.Forms.Padding(3)
        Me.tabUpdate.Size = New System.Drawing.Size(861, 527)
        Me.tabUpdate.TabIndex = 2
        Me.tabUpdate.Text = "Update"
        '
        'GridControlUD
        '
        Me.GridControlUD.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GridControlUD.Location = New System.Drawing.Point(8, 67)
        Me.GridControlUD.MainView = Me.GridViewUD
        Me.GridControlUD.Name = "GridControlUD"
        Me.GridControlUD.Size = New System.Drawing.Size(733, 452)
        Me.GridControlUD.TabIndex = 24
        Me.GridControlUD.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewUD})
        '
        'GridViewUD
        '
        Me.GridViewUD.GridControl = Me.GridControlUD
        Me.GridViewUD.Name = "GridViewUD"
        Me.GridViewUD.OptionsBehavior.Editable = False
        Me.GridViewUD.OptionsFind.AlwaysVisible = True
        Me.GridViewUD.OptionsView.ShowFooter = True
        Me.GridViewUD.OptionsView.ShowGroupPanel = False
        '
        'bttUpdate
        '
        Me.bttUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bttUpdate.ForeColor = System.Drawing.Color.Blue
        Me.bttUpdate.Location = New System.Drawing.Point(630, 15)
        Me.bttUpdate.Name = "bttUpdate"
        Me.bttUpdate.Size = New System.Drawing.Size(111, 46)
        Me.bttUpdate.TabIndex = 23
        Me.bttUpdate.Text = "Update Now..."
        Me.bttUpdate.UseVisualStyleBackColor = True
        '
        'bttSaveUpdate
        '
        Me.bttSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bttSaveUpdate.ForeColor = System.Drawing.Color.Blue
        Me.bttSaveUpdate.Location = New System.Drawing.Point(513, 15)
        Me.bttSaveUpdate.Name = "bttSaveUpdate"
        Me.bttSaveUpdate.Size = New System.Drawing.Size(111, 46)
        Me.bttSaveUpdate.TabIndex = 22
        Me.bttSaveUpdate.Text = "Save Path"
        Me.bttSaveUpdate.UseVisualStyleBackColor = True
        '
        'txtDestination
        '
        Me.txtDestination.Location = New System.Drawing.Point(76, 41)
        Me.txtDestination.Name = "txtDestination"
        Me.txtDestination.Size = New System.Drawing.Size(385, 20)
        Me.txtDestination.TabIndex = 19
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(8, 44)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(38, 13)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Server"
        '
        'bttServer
        '
        Me.bttServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bttServer.Location = New System.Drawing.Point(467, 39)
        Me.bttServer.Name = "bttServer"
        Me.bttServer.Size = New System.Drawing.Size(40, 23)
        Me.bttServer.TabIndex = 20
        Me.bttServer.Text = "..."
        Me.bttServer.UseVisualStyleBackColor = True
        '
        'txtBuildFolder
        '
        Me.txtBuildFolder.Location = New System.Drawing.Point(76, 15)
        Me.txtBuildFolder.Name = "txtBuildFolder"
        Me.txtBuildFolder.Size = New System.Drawing.Size(385, 20)
        Me.txtBuildFolder.TabIndex = 16
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(8, 18)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(62, 13)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "Build Folder"
        '
        'bttBuild
        '
        Me.bttBuild.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bttBuild.Location = New System.Drawing.Point(467, 13)
        Me.bttBuild.Name = "bttBuild"
        Me.bttBuild.Size = New System.Drawing.Size(40, 23)
        Me.bttBuild.TabIndex = 18
        Me.bttBuild.Text = "..."
        Me.bttBuild.UseVisualStyleBackColor = True
        '
        'tabGenerateDB
        '
        Me.tabGenerateDB.BackColor = System.Drawing.Color.WhiteSmoke
        Me.tabGenerateDB.Controls.Add(Me.GridControlTB)
        Me.tabGenerateDB.Controls.Add(Me.bttSavePath)
        Me.tabGenerateDB.Controls.Add(Me.txtPathStore)
        Me.tabGenerateDB.Controls.Add(Me.Label8)
        Me.tabGenerateDB.Controls.Add(Me.bttPathStore)
        Me.tabGenerateDB.Controls.Add(Me.GroupBox3)
        Me.tabGenerateDB.Controls.Add(Me.GroupBox2)
        Me.tabGenerateDB.Controls.Add(Me.txtPathEntity)
        Me.tabGenerateDB.Controls.Add(Me.Label1)
        Me.tabGenerateDB.Controls.Add(Me.bttPathEntity)
        Me.tabGenerateDB.Controls.Add(Me.bttGenerate)
        Me.tabGenerateDB.Controls.Add(Me.GroupBox1)
        Me.tabGenerateDB.Location = New System.Drawing.Point(4, 22)
        Me.tabGenerateDB.Name = "tabGenerateDB"
        Me.tabGenerateDB.Padding = New System.Windows.Forms.Padding(3)
        Me.tabGenerateDB.Size = New System.Drawing.Size(861, 527)
        Me.tabGenerateDB.TabIndex = 0
        Me.tabGenerateDB.Text = "Gernerate DB"
        '
        'GridControlTB
        '
        Me.GridControlTB.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GridControlTB.Location = New System.Drawing.Point(352, 83)
        Me.GridControlTB.MainView = Me.GridViewTB
        Me.GridControlTB.Name = "GridControlTB"
        Me.GridControlTB.Size = New System.Drawing.Size(501, 436)
        Me.GridControlTB.TabIndex = 25
        Me.GridControlTB.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewTB})
        '
        'GridViewTB
        '
        Me.GridViewTB.GridControl = Me.GridControlTB
        Me.GridViewTB.Name = "GridViewTB"
        Me.GridViewTB.OptionsBehavior.Editable = False
        Me.GridViewTB.OptionsFind.AlwaysVisible = True
        Me.GridViewTB.OptionsView.ShowFooter = True
        Me.GridViewTB.OptionsView.ShowGroupPanel = False
        '
        'bttSavePath
        '
        Me.bttSavePath.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bttSavePath.ForeColor = System.Drawing.Color.Blue
        Me.bttSavePath.Location = New System.Drawing.Point(486, 17)
        Me.bttSavePath.Name = "bttSavePath"
        Me.bttSavePath.Size = New System.Drawing.Size(111, 46)
        Me.bttSavePath.TabIndex = 15
        Me.bttSavePath.Text = "Save Path"
        Me.bttSavePath.UseVisualStyleBackColor = True
        '
        'txtPathStore
        '
        Me.txtPathStore.Location = New System.Drawing.Point(119, 43)
        Me.txtPathStore.Name = "txtPathStore"
        Me.txtPathStore.Size = New System.Drawing.Size(312, 20)
        Me.txtPathStore.TabIndex = 12
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(21, 46)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(92, 13)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Store/TableName"
        '
        'bttPathStore
        '
        Me.bttPathStore.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bttPathStore.Location = New System.Drawing.Point(437, 41)
        Me.bttPathStore.Name = "bttPathStore"
        Me.bttPathStore.Size = New System.Drawing.Size(43, 23)
        Me.bttPathStore.TabIndex = 13
        Me.bttPathStore.Text = "..."
        Me.bttPathStore.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ckoCSharp)
        Me.GroupBox3.Controls.Add(Me.ckoVB)
        Me.GroupBox3.Location = New System.Drawing.Point(24, 270)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(322, 39)
        Me.GroupBox3.TabIndex = 11
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Language"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ckoStore)
        Me.GroupBox2.Controls.Add(Me.ckoTableName)
        Me.GroupBox2.Controls.Add(Me.ckoTableClass)
        Me.GroupBox2.Location = New System.Drawing.Point(24, 315)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(322, 39)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Type"
        '
        'ckoStore
        '
        Me.ckoStore.AutoSize = True
        Me.ckoStore.Location = New System.Drawing.Point(215, 16)
        Me.ckoStore.Name = "ckoStore"
        Me.ckoStore.Size = New System.Drawing.Size(107, 17)
        Me.ckoStore.TabIndex = 2
        Me.ckoStore.Text = "Store procedures"
        Me.ckoStore.UseVisualStyleBackColor = True
        '
        'ckoTableName
        '
        Me.ckoTableName.AutoSize = True
        Me.ckoTableName.Location = New System.Drawing.Point(127, 16)
        Me.ckoTableName.Name = "ckoTableName"
        Me.ckoTableName.Size = New System.Drawing.Size(81, 17)
        Me.ckoTableName.TabIndex = 1
        Me.ckoTableName.Text = "TableName"
        Me.ckoTableName.UseVisualStyleBackColor = True
        '
        'ckoTableClass
        '
        Me.ckoTableClass.AutoSize = True
        Me.ckoTableClass.Checked = True
        Me.ckoTableClass.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckoTableClass.Location = New System.Drawing.Point(30, 16)
        Me.ckoTableClass.Name = "ckoTableClass"
        Me.ckoTableClass.Size = New System.Drawing.Size(78, 17)
        Me.ckoTableClass.TabIndex = 0
        Me.ckoTableClass.Text = "TableClass"
        Me.ckoTableClass.UseVisualStyleBackColor = True
        '
        'tabEncryptPassword
        '
        Me.tabEncryptPassword.BackColor = System.Drawing.Color.WhiteSmoke
        Me.tabEncryptPassword.Controls.Add(Me.bttDecryption)
        Me.tabEncryptPassword.Controls.Add(Me.bttEncryption)
        Me.tabEncryptPassword.Controls.Add(Me.Label7)
        Me.tabEncryptPassword.Controls.Add(Me.txtResult)
        Me.tabEncryptPassword.Controls.Add(Me.Label6)
        Me.tabEncryptPassword.Controls.Add(Me.txtInput)
        Me.tabEncryptPassword.Location = New System.Drawing.Point(4, 22)
        Me.tabEncryptPassword.Name = "tabEncryptPassword"
        Me.tabEncryptPassword.Padding = New System.Windows.Forms.Padding(3)
        Me.tabEncryptPassword.Size = New System.Drawing.Size(861, 527)
        Me.tabEncryptPassword.TabIndex = 1
        Me.tabEncryptPassword.Text = "Encrypt Password"
        '
        'bttDecryption
        '
        Me.bttDecryption.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bttDecryption.ForeColor = System.Drawing.Color.Blue
        Me.bttDecryption.Location = New System.Drawing.Point(143, 106)
        Me.bttDecryption.Name = "bttDecryption"
        Me.bttDecryption.Size = New System.Drawing.Size(75, 23)
        Me.bttDecryption.TabIndex = 5
        Me.bttDecryption.Text = "Decryption"
        Me.bttDecryption.UseVisualStyleBackColor = True
        '
        'bttEncryption
        '
        Me.bttEncryption.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bttEncryption.ForeColor = System.Drawing.Color.Blue
        Me.bttEncryption.Location = New System.Drawing.Point(62, 106)
        Me.bttEncryption.Name = "bttEncryption"
        Me.bttEncryption.Size = New System.Drawing.Size(75, 23)
        Me.bttEncryption.TabIndex = 4
        Me.bttEncryption.Text = "Encryption"
        Me.bttEncryption.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(62, 67)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 13)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Result text"
        '
        'txtResult
        '
        Me.txtResult.Location = New System.Drawing.Point(62, 80)
        Me.txtResult.Name = "txtResult"
        Me.txtResult.Size = New System.Drawing.Size(429, 20)
        Me.txtResult.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(62, 34)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Input text"
        '
        'txtInput
        '
        Me.txtInput.Location = New System.Drawing.Point(62, 47)
        Me.txtInput.Name = "txtInput"
        Me.txtInput.Size = New System.Drawing.Size(429, 20)
        Me.txtInput.TabIndex = 0
        '
        'Admin
        '
        Me.Admin.Controls.Add(Me.mnuShowAll)
        Me.Admin.Controls.Add(Me.GridControlS)
        Me.Admin.Location = New System.Drawing.Point(4, 22)
        Me.Admin.Name = "Admin"
        Me.Admin.Padding = New System.Windows.Forms.Padding(3)
        Me.Admin.Size = New System.Drawing.Size(861, 527)
        Me.Admin.TabIndex = 3
        Me.Admin.Text = "Server List"
        Me.Admin.UseVisualStyleBackColor = True
        '
        'GridControlS
        '
        Me.GridControlS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControlS.Location = New System.Drawing.Point(3, 3)
        Me.GridControlS.MainView = Me.GridViewS
        Me.GridControlS.Name = "GridControlS"
        Me.GridControlS.Size = New System.Drawing.Size(855, 521)
        Me.GridControlS.TabIndex = 26
        Me.GridControlS.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewS})
        '
        'GridViewS
        '
        Me.GridViewS.GridControl = Me.GridControlS
        Me.GridViewS.Name = "GridViewS"
        Me.GridViewS.OptionsBehavior.Editable = False
        Me.GridViewS.OptionsFind.AlwaysVisible = True
        Me.GridViewS.OptionsView.ShowFooter = True
        Me.GridViewS.OptionsView.ShowGroupPanel = False
        '
        'AutoCopy
        '
        Me.AutoCopy.BackColor = System.Drawing.Color.WhiteSmoke
        Me.AutoCopy.Controls.Add(Me.txtLastCopy)
        Me.AutoCopy.Controls.Add(Me.LabelControl6)
        Me.AutoCopy.Controls.Add(Me.LabelControl5)
        Me.AutoCopy.Controls.Add(Me.txthours)
        Me.AutoCopy.Controls.Add(Me.txtNextCopy)
        Me.AutoCopy.Controls.Add(Me.LabelControl4)
        Me.AutoCopy.Controls.Add(Me.ckoAutoCopy)
        Me.AutoCopy.Controls.Add(Me.txtStatusBK)
        Me.AutoCopy.Controls.Add(Me.LabelControl3)
        Me.AutoCopy.Controls.Add(Me.bttCopy)
        Me.AutoCopy.Controls.Add(Me.bttDestinationBK)
        Me.AutoCopy.Controls.Add(Me.bttSource)
        Me.AutoCopy.Controls.Add(Me.txtDestinationBK)
        Me.AutoCopy.Controls.Add(Me.txtSourceBK)
        Me.AutoCopy.Controls.Add(Me.LabelControl2)
        Me.AutoCopy.Controls.Add(Me.LabelControl1)
        Me.AutoCopy.Location = New System.Drawing.Point(4, 22)
        Me.AutoCopy.Name = "AutoCopy"
        Me.AutoCopy.Padding = New System.Windows.Forms.Padding(3)
        Me.AutoCopy.Size = New System.Drawing.Size(861, 527)
        Me.AutoCopy.TabIndex = 4
        Me.AutoCopy.Text = "AutoCopyBackupFile"
        '
        'txtLastCopy
        '
        Me.txtLastCopy.Location = New System.Drawing.Point(81, 104)
        Me.txtLastCopy.Name = "txtLastCopy"
        Me.txtLastCopy.Properties.ReadOnly = True
        Me.txtLastCopy.Size = New System.Drawing.Size(346, 20)
        Me.txtLastCopy.TabIndex = 15
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(25, 108)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(46, 13)
        Me.LabelControl6.TabIndex = 14
        Me.LabelControl6.Text = "Last copy"
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(292, 159)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(28, 13)
        Me.LabelControl5.TabIndex = 13
        Me.LabelControl5.Text = "Hours"
        '
        'txthours
        '
        Me.txthours.Location = New System.Drawing.Point(200, 156)
        Me.txthours.Name = "txthours"
        Me.txthours.Size = New System.Drawing.Size(86, 20)
        Me.txthours.TabIndex = 12
        '
        'txtNextCopy
        '
        Me.txtNextCopy.Location = New System.Drawing.Point(81, 130)
        Me.txtNextCopy.Name = "txtNextCopy"
        Me.txtNextCopy.Properties.ReadOnly = True
        Me.txtNextCopy.Size = New System.Drawing.Size(346, 20)
        Me.txtNextCopy.TabIndex = 11
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(25, 134)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(49, 13)
        Me.LabelControl4.TabIndex = 10
        Me.LabelControl4.Text = "Next copy"
        '
        'ckoAutoCopy
        '
        Me.ckoAutoCopy.Location = New System.Drawing.Point(119, 156)
        Me.ckoAutoCopy.Name = "ckoAutoCopy"
        Me.ckoAutoCopy.Properties.Caption = "AutoCopy"
        Me.ckoAutoCopy.Size = New System.Drawing.Size(75, 20)
        Me.ckoAutoCopy.TabIndex = 9
        '
        'txtStatusBK
        '
        Me.txtStatusBK.Location = New System.Drawing.Point(81, 70)
        Me.txtStatusBK.Name = "txtStatusBK"
        Me.txtStatusBK.Properties.ReadOnly = True
        Me.txtStatusBK.Size = New System.Drawing.Size(346, 20)
        Me.txtStatusBK.TabIndex = 8
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(25, 74)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(35, 13)
        Me.LabelControl3.TabIndex = 7
        Me.LabelControl3.Text = "Status:"
        '
        'bttCopy
        '
        Me.bttCopy.Location = New System.Drawing.Point(514, 28)
        Me.bttCopy.Name = "bttCopy"
        Me.bttCopy.Size = New System.Drawing.Size(97, 46)
        Me.bttCopy.TabIndex = 6
        Me.bttCopy.Text = "CopyNow"
        '
        'bttDestinationBK
        '
        Me.bttDestinationBK.Location = New System.Drawing.Point(433, 51)
        Me.bttDestinationBK.Name = "bttDestinationBK"
        Me.bttDestinationBK.Size = New System.Drawing.Size(75, 23)
        Me.bttDestinationBK.TabIndex = 5
        Me.bttDestinationBK.Text = "..."
        '
        'bttSource
        '
        Me.bttSource.Location = New System.Drawing.Point(433, 28)
        Me.bttSource.Name = "bttSource"
        Me.bttSource.Size = New System.Drawing.Size(75, 23)
        Me.bttSource.TabIndex = 4
        Me.bttSource.Text = "..."
        '
        'txtDestinationBK
        '
        Me.txtDestinationBK.Location = New System.Drawing.Point(81, 50)
        Me.txtDestinationBK.Name = "txtDestinationBK"
        Me.txtDestinationBK.Size = New System.Drawing.Size(346, 20)
        Me.txtDestinationBK.TabIndex = 3
        '
        'txtSourceBK
        '
        Me.txtSourceBK.Location = New System.Drawing.Point(81, 30)
        Me.txtSourceBK.Name = "txtSourceBK"
        Me.txtSourceBK.Size = New System.Drawing.Size(346, 20)
        Me.txtSourceBK.TabIndex = 2
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(25, 32)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(33, 13)
        Me.LabelControl2.TabIndex = 1
        Me.LabelControl2.Text = "Source"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(25, 53)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(50, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Distination"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "Lib"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Library"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 300
        '
        'TimerCopyFile
        '
        Me.TimerCopyFile.Interval = 1000
        '
        'mnuShowAll
        '
        Me.mnuShowAll.Location = New System.Drawing.Point(497, 16)
        Me.mnuShowAll.Name = "mnuShowAll"
        Me.mnuShowAll.Size = New System.Drawing.Size(75, 23)
        Me.mnuShowAll.TabIndex = 11
        Me.mnuShowAll.Text = "ShowAll"
        '
        'FrmUtilityTool
        '
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(869, 553)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "FrmUtilityTool"
        Me.Tag = "0009"
        Me.Text = "Utility Tool"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.tabUpdate.ResumeLayout(False)
        Me.tabUpdate.PerformLayout()
        CType(Me.GridControlUD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewUD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabGenerateDB.ResumeLayout(False)
        Me.tabGenerateDB.PerformLayout()
        CType(Me.GridControlTB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewTB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.tabEncryptPassword.ResumeLayout(False)
        Me.tabEncryptPassword.PerformLayout()
        Me.Admin.ResumeLayout(False)
        CType(Me.GridControlS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.AutoCopy.ResumeLayout(False)
        Me.AutoCopy.PerformLayout()
        CType(Me.txtLastCopy.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txthours.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNextCopy.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ckoAutoCopy.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtStatusBK.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDestinationBK.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSourceBK.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents bttConnect As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPathEntity As System.Windows.Forms.TextBox
    Friend WithEvents bttPathEntity As System.Windows.Forms.Button
    Friend WithEvents bttGenerate As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtServer As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtUserId As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDatabase As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ckoVB As System.Windows.Forms.CheckBox
    Friend WithEvents ckoCSharp As System.Windows.Forms.CheckBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabGenerateDB As System.Windows.Forms.TabPage
    Friend WithEvents tabEncryptPassword As System.Windows.Forms.TabPage
    Friend WithEvents bttEncryption As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtResult As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtInput As System.Windows.Forms.TextBox
    Friend WithEvents bttDecryption As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ckoStore As System.Windows.Forms.CheckBox
    Friend WithEvents ckoTableName As System.Windows.Forms.CheckBox
    Friend WithEvents ckoTableClass As System.Windows.Forms.CheckBox
    Friend WithEvents txtPathStore As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents bttPathStore As System.Windows.Forms.Button
    Friend WithEvents bttSavePath As System.Windows.Forms.Button
    Friend WithEvents tabUpdate As System.Windows.Forms.TabPage
    Friend WithEvents bttSaveUpdate As System.Windows.Forms.Button
    Friend WithEvents txtDestination As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents bttServer As System.Windows.Forms.Button
    Friend WithEvents txtBuildFolder As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents bttBuild As System.Windows.Forms.Button
    Friend WithEvents bttUpdate As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Admin As TabPage
    Friend WithEvents GridControlUD As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewUD As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridControlTB As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewTB As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridControlS As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewS As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents AutoCopy As TabPage
    Friend WithEvents bttDestinationBK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents bttSource As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtDestinationBK As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtSourceBK As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents bttCopy As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtStatusBK As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ckoAutoCopy As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txthours As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtNextCopy As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TimerCopyFile As Timer
    Friend WithEvents txtLastCopy As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents mnuShowAll As DevExpress.XtraEditors.SimpleButton
End Class

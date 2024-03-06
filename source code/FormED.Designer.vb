<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormED
    Inherits System.Windows.Forms.Form

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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.tbDesc = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.dgInput = New System.Windows.Forms.DataGridView()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewComboBoxColumn1 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DataGridViewComboBoxColumn3 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnMean = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StdDev = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.tsbAddIndVar = New System.Windows.Forms.ToolStripButton()
        Me.tsbRemoveIndVar = New System.Windows.Forms.ToolStripButton()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgOutput = New System.Windows.Forms.DataGridView()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewComboBoxColumn2 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DataGridViewComboBoxColumn4 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ts1 = New System.Windows.Forms.ToolStrip()
        Me.tsbAddDepVar = New System.Windows.Forms.ToolStripButton()
        Me.tsbRemoveDepVar = New System.Windows.Forms.ToolStripButton()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.tbNumberOfExperiments = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnGenerateData = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.gridData = New unvell.ReoGrid.ReoGridControl()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.gridResults = New unvell.ReoGrid.ReoGridControl()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnRun = New System.Windows.Forms.Button()
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripButton()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog2 = New System.Windows.Forms.SaveFileDialog()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        CType(Me.dgInput, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgOutput, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ts1.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.ToolStrip3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 25)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(855, 497)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.tbDesc)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.tbName)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(847, 471)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Information"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'tbDesc
        '
        Me.tbDesc.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbDesc.Location = New System.Drawing.Point(141, 99)
        Me.tbDesc.Multiline = True
        Me.tbDesc.Name = "tbDesc"
        Me.tbDesc.Size = New System.Drawing.Size(656, 264)
        Me.tbDesc.TabIndex = 6
        Me.tbDesc.Text = "ExperimentDescription"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(34, 102)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Description"
        '
        'tbName
        '
        Me.tbName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbName.Location = New System.Drawing.Point(141, 35)
        Me.tbName.Name = "tbName"
        Me.tbName.Size = New System.Drawing.Size(656, 20)
        Me.tbName.TabIndex = 4
        Me.tbName.Text = "ExperimentName"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(34, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Name"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox10)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(847, 471)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Independent Variables"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.dgInput)
        Me.GroupBox10.Controls.Add(Me.ToolStrip2)
        Me.GroupBox10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox10.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(841, 465)
        Me.GroupBox10.TabIndex = 17
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "Add/Remove Variables"
        '
        'dgInput
        '
        Me.dgInput.AllowUserToAddRows = False
        Me.dgInput.AllowUserToDeleteRows = False
        Me.dgInput.AllowUserToResizeRows = False
        Me.dgInput.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgInput.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgInput.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgInput.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgInput.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgInput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgInput.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column3, Me.DataGridViewComboBoxColumn1, Me.DataGridViewComboBoxColumn3, Me.Column6, Me.Column7, Me.Column1, Me.Column2, Me.ColumnMean, Me.StdDev, Me.Column4, Me.DataGridViewTextBoxColumn5})
        Me.dgInput.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgInput.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgInput.Location = New System.Drawing.Point(3, 41)
        Me.dgInput.Name = "dgInput"
        Me.dgInput.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgInput.Size = New System.Drawing.Size(835, 421)
        Me.dgInput.TabIndex = 1
        '
        'Column3
        '
        Me.Column3.FillWeight = 30.0!
        Me.Column3.HeaderText = "Name"
        Me.Column3.MinimumWidth = 60
        Me.Column3.Name = "Column3"
        '
        'DataGridViewComboBoxColumn1
        '
        Me.DataGridViewComboBoxColumn1.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.DataGridViewComboBoxColumn1.FillWeight = 30.0!
        Me.DataGridViewComboBoxColumn1.HeaderText = "Object"
        Me.DataGridViewComboBoxColumn1.MinimumWidth = 100
        Me.DataGridViewComboBoxColumn1.Name = "DataGridViewComboBoxColumn1"
        Me.DataGridViewComboBoxColumn1.Sorted = True
        '
        'DataGridViewComboBoxColumn3
        '
        Me.DataGridViewComboBoxColumn3.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.DataGridViewComboBoxColumn3.DropDownWidth = 400
        Me.DataGridViewComboBoxColumn3.FillWeight = 60.0!
        Me.DataGridViewComboBoxColumn3.HeaderText = "Property"
        Me.DataGridViewComboBoxColumn3.MinimumWidth = 150
        Me.DataGridViewComboBoxColumn3.Name = "DataGridViewComboBoxColumn3"
        '
        'Column6
        '
        Me.Column6.FalseValue = "False"
        Me.Column6.FillWeight = 10.0!
        Me.Column6.HeaderText = "Discrete"
        Me.Column6.IndeterminateValue = "False"
        Me.Column6.MinimumWidth = 25
        Me.Column6.Name = "Column6"
        Me.Column6.TrueValue = "True"
        '
        'Column7
        '
        DataGridViewCellStyle2.NullValue = "1"
        Me.Column7.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column7.FillWeight = 15.0!
        Me.Column7.HeaderText = "Step"
        Me.Column7.Name = "Column7"
        '
        'Column1
        '
        Me.Column1.FillWeight = 20.0!
        Me.Column1.HeaderText = "Min"
        Me.Column1.MinimumWidth = 50
        Me.Column1.Name = "Column1"
        '
        'Column2
        '
        Me.Column2.FillWeight = 20.0!
        Me.Column2.HeaderText = "Max"
        Me.Column2.MinimumWidth = 50
        Me.Column2.Name = "Column2"
        '
        'ColumnMean
        '
        Me.ColumnMean.FillWeight = 20.0!
        Me.ColumnMean.HeaderText = "Mean"
        Me.ColumnMean.MinimumWidth = 50
        Me.ColumnMean.Name = "ColumnMean"
        '
        'StdDev
        '
        Me.StdDev.FillWeight = 20.0!
        Me.StdDev.HeaderText = "StdDev"
        Me.StdDev.MinimumWidth = 50
        Me.StdDev.Name = "StdDev"
        '
        'Column4
        '
        Me.Column4.FillWeight = 15.0!
        Me.Column4.HeaderText = "Trust Level"
        Me.Column4.MinimumWidth = 25
        Me.Column4.Name = "Column4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.FillWeight = 15.0!
        Me.DataGridViewTextBoxColumn5.HeaderText = "Unit"
        Me.DataGridViewTextBoxColumn5.MinimumWidth = 50
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ToolStrip2
        '
        Me.ToolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbAddIndVar, Me.tsbRemoveIndVar})
        Me.ToolStrip2.Location = New System.Drawing.Point(3, 16)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(835, 25)
        Me.ToolStrip2.TabIndex = 0
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'tsbAddIndVar
        '
        Me.tsbAddIndVar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbAddIndVar.Image = Global.DWSIM.Extensions.ExperimentDesigner.My.Resources.Resources.add_40px
        Me.tsbAddIndVar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAddIndVar.Name = "tsbAddIndVar"
        Me.tsbAddIndVar.Size = New System.Drawing.Size(23, 22)
        Me.tsbAddIndVar.ToolTipText = "Add"
        '
        'tsbRemoveIndVar
        '
        Me.tsbRemoveIndVar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbRemoveIndVar.Image = Global.DWSIM.Extensions.ExperimentDesigner.My.Resources.Resources.minus_40px
        Me.tsbRemoveIndVar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRemoveIndVar.Name = "tsbRemoveIndVar"
        Me.tsbRemoveIndVar.Size = New System.Drawing.Size(23, 22)
        Me.tsbRemoveIndVar.Text = "ToolStripButton2"
        Me.tsbRemoveIndVar.ToolTipText = "Remove"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.GroupBox1)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(847, 471)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Dependent Variables"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgOutput)
        Me.GroupBox1.Controls.Add(Me.ts1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(841, 465)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Add/Remove Variables"
        '
        'dgOutput
        '
        Me.dgOutput.AllowUserToAddRows = False
        Me.dgOutput.AllowUserToDeleteRows = False
        Me.dgOutput.AllowUserToResizeRows = False
        Me.dgOutput.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgOutput.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgOutput.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgOutput.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgOutput.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgOutput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgOutput.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column5, Me.DataGridViewComboBoxColumn2, Me.DataGridViewComboBoxColumn4, Me.DataGridViewTextBoxColumn3})
        Me.dgOutput.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgOutput.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgOutput.Location = New System.Drawing.Point(3, 41)
        Me.dgOutput.Name = "dgOutput"
        Me.dgOutput.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgOutput.Size = New System.Drawing.Size(835, 421)
        Me.dgOutput.TabIndex = 1
        '
        'Column5
        '
        Me.Column5.FillWeight = 30.0!
        Me.Column5.HeaderText = "Name"
        Me.Column5.Name = "Column5"
        '
        'DataGridViewComboBoxColumn2
        '
        Me.DataGridViewComboBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewComboBoxColumn2.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.DataGridViewComboBoxColumn2.FillWeight = 30.0!
        Me.DataGridViewComboBoxColumn2.HeaderText = "Object"
        Me.DataGridViewComboBoxColumn2.Name = "DataGridViewComboBoxColumn2"
        Me.DataGridViewComboBoxColumn2.Sorted = True
        '
        'DataGridViewComboBoxColumn4
        '
        Me.DataGridViewComboBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewComboBoxColumn4.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.DataGridViewComboBoxColumn4.DropDownWidth = 400
        Me.DataGridViewComboBoxColumn4.FillWeight = 60.0!
        Me.DataGridViewComboBoxColumn4.HeaderText = "Property"
        Me.DataGridViewComboBoxColumn4.Name = "DataGridViewComboBoxColumn4"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn3.FillWeight = 15.0!
        Me.DataGridViewTextBoxColumn3.HeaderText = "Unit"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ts1
        '
        Me.ts1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ts1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbAddDepVar, Me.tsbRemoveDepVar})
        Me.ts1.Location = New System.Drawing.Point(3, 16)
        Me.ts1.Name = "ts1"
        Me.ts1.Size = New System.Drawing.Size(835, 25)
        Me.ts1.TabIndex = 0
        Me.ts1.Text = "ToolStrip1"
        '
        'tsbAddDepVar
        '
        Me.tsbAddDepVar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbAddDepVar.Image = Global.DWSIM.Extensions.ExperimentDesigner.My.Resources.Resources.add_40px
        Me.tsbAddDepVar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAddDepVar.Name = "tsbAddDepVar"
        Me.tsbAddDepVar.Size = New System.Drawing.Size(23, 22)
        Me.tsbAddDepVar.ToolTipText = "Add"
        '
        'tsbRemoveDepVar
        '
        Me.tsbRemoveDepVar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbRemoveDepVar.Image = Global.DWSIM.Extensions.ExperimentDesigner.My.Resources.Resources.minus_40px
        Me.tsbRemoveDepVar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRemoveDepVar.Name = "tsbRemoveDepVar"
        Me.tsbRemoveDepVar.Size = New System.Drawing.Size(23, 22)
        Me.tsbRemoveDepVar.Text = "tsbRemoveDepVar"
        Me.tsbRemoveDepVar.ToolTipText = "Remove"
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.GroupBox3)
        Me.TabPage4.Controls.Add(Me.GroupBox2)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(847, 471)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Generated Data"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.tbNumberOfExperiments)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.btnGenerateData)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 6)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(831, 71)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Options"
        '
        'tbNumberOfExperiments
        '
        Me.tbNumberOfExperiments.Location = New System.Drawing.Point(147, 26)
        Me.tbNumberOfExperiments.Name = "tbNumberOfExperiments"
        Me.tbNumberOfExperiments.Size = New System.Drawing.Size(100, 20)
        Me.tbNumberOfExperiments.TabIndex = 2
        Me.tbNumberOfExperiments.Text = "1000"
        Me.tbNumberOfExperiments.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Number of Experiments"
        '
        'btnGenerateData
        '
        Me.btnGenerateData.Location = New System.Drawing.Point(253, 24)
        Me.btnGenerateData.Name = "btnGenerateData"
        Me.btnGenerateData.Size = New System.Drawing.Size(223, 23)
        Me.btnGenerateData.TabIndex = 0
        Me.btnGenerateData.Text = "Generate Data"
        Me.btnGenerateData.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.gridData)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 83)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(831, 378)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Data"
        '
        'gridData
        '
        Me.gridData.BackColor = System.Drawing.Color.White
        Me.gridData.ColumnHeaderContextMenuStrip = Nothing
        Me.gridData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridData.LeadHeaderContextMenuStrip = Nothing
        Me.gridData.Location = New System.Drawing.Point(3, 16)
        Me.gridData.Name = "gridData"
        Me.gridData.RowHeaderContextMenuStrip = Nothing
        Me.gridData.Script = Nothing
        Me.gridData.SheetTabContextMenuStrip = Nothing
        Me.gridData.SheetTabNewButtonVisible = False
        Me.gridData.SheetTabVisible = False
        Me.gridData.SheetTabWidth = 60
        Me.gridData.ShowScrollEndSpacing = True
        Me.gridData.Size = New System.Drawing.Size(825, 359)
        Me.gridData.TabIndex = 1
        Me.gridData.Text = "ReoGridControl1"
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.GroupBox5)
        Me.TabPage5.Controls.Add(Me.GroupBox4)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(847, 471)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Experiments"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.Controls.Add(Me.gridResults)
        Me.GroupBox5.Location = New System.Drawing.Point(6, 92)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(831, 364)
        Me.GroupBox5.TabIndex = 3
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Output"
        '
        'gridResults
        '
        Me.gridResults.BackColor = System.Drawing.Color.White
        Me.gridResults.ColumnHeaderContextMenuStrip = Nothing
        Me.gridResults.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridResults.LeadHeaderContextMenuStrip = Nothing
        Me.gridResults.Location = New System.Drawing.Point(3, 16)
        Me.gridResults.Name = "gridResults"
        Me.gridResults.RowHeaderContextMenuStrip = Nothing
        Me.gridResults.Script = Nothing
        Me.gridResults.SheetTabContextMenuStrip = Nothing
        Me.gridResults.SheetTabNewButtonVisible = False
        Me.gridResults.SheetTabVisible = False
        Me.gridResults.SheetTabWidth = 60
        Me.gridResults.ShowScrollEndSpacing = True
        Me.gridResults.Size = New System.Drawing.Size(825, 345)
        Me.gridResults.TabIndex = 1
        Me.gridResults.Text = "ReoGridControl1"
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.Button1)
        Me.GroupBox4.Controls.Add(Me.btnRun)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(831, 80)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Experiment Controls"
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(560, 30)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(251, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Export Output to Excel"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnRun
        '
        Me.btnRun.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRun.Location = New System.Drawing.Point(25, 30)
        Me.btnRun.Name = "btnRun"
        Me.btnRun.Size = New System.Drawing.Size(517, 23)
        Me.btnRun.TabIndex = 1
        Me.btnRun.Text = "Start Experiments"
        Me.btnRun.UseVisualStyleBackColor = True
        '
        'ToolStrip3
        '
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton5, Me.ToolStripButton6})
        Me.ToolStrip3.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.Size = New System.Drawing.Size(855, 25)
        Me.ToolStrip3.TabIndex = 1
        Me.ToolStrip3.Text = "ToolStrip3"
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.Image = Global.DWSIM.Extensions.ExperimentDesigner.My.Resources.Resources.icons8_import
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(90, 22)
        Me.ToolStripButton5.Text = "Import Data"
        '
        'ToolStripButton6
        '
        Me.ToolStripButton6.Image = Global.DWSIM.Extensions.ExperimentDesigner.My.Resources.Resources.icons8_export
        Me.ToolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.ToolStripButton6.Size = New System.Drawing.Size(88, 22)
        Me.ToolStripButton6.Text = "Export Data"
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.Filter = "JSON files|*.json"
        Me.SaveFileDialog1.Title = "Export Experiment to File"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        Me.OpenFileDialog1.Filter = "JSON files|*.json"
        Me.OpenFileDialog1.Title = "Import Experiment from File"
        '
        'SaveFileDialog2
        '
        Me.SaveFileDialog2.Filter = "Excel files|*.xlsx"
        Me.SaveFileDialog2.Title = "Export Data to Excel"
        '
        'FormED
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(855, 522)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.ToolStrip3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "FormED"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Experiment Designer"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        CType(Me.dgInput, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgOutput, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ts1.ResumeLayout(False)
        Me.ts1.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.TabPage5.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TabControl1 As Windows.Forms.TabControl
    Friend WithEvents TabPage1 As Windows.Forms.TabPage
    Friend WithEvents TabPage2 As Windows.Forms.TabPage
    Public WithEvents GroupBox10 As Windows.Forms.GroupBox
    Public WithEvents dgInput As Windows.Forms.DataGridView
    Public WithEvents ToolStrip2 As Windows.Forms.ToolStrip
    Public WithEvents tsbAddIndVar As Windows.Forms.ToolStripButton
    Public WithEvents tsbRemoveIndVar As Windows.Forms.ToolStripButton
    Friend WithEvents TabPage3 As Windows.Forms.TabPage
    Friend WithEvents TabPage4 As Windows.Forms.TabPage
    Friend WithEvents TabPage5 As Windows.Forms.TabPage
    Public WithEvents GroupBox1 As Windows.Forms.GroupBox
    Public WithEvents dgOutput As Windows.Forms.DataGridView
    Public WithEvents ts1 As Windows.Forms.ToolStrip
    Public WithEvents tsbAddDepVar As Windows.Forms.ToolStripButton
    Public WithEvents tsbRemoveDepVar As Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox3 As Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As Windows.Forms.GroupBox
    Friend WithEvents gridData As unvell.ReoGrid.ReoGridControl
    Friend WithEvents ToolStrip3 As Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton5 As Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton6 As Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox5 As Windows.Forms.GroupBox
    Friend WithEvents gridResults As unvell.ReoGrid.ReoGridControl
    Friend WithEvents GroupBox4 As Windows.Forms.GroupBox
    Friend WithEvents tbNumberOfExperiments As Windows.Forms.TextBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents btnGenerateData As Windows.Forms.Button
    Friend WithEvents btnRun As Windows.Forms.Button
    Friend WithEvents tbDesc As Windows.Forms.TextBox
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents tbName As Windows.Forms.TextBox
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Column5 As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn2 As Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn4 As Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn1 As Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn3 As Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Column6 As Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column7 As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnMean As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StdDev As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SaveFileDialog1 As Windows.Forms.SaveFileDialog
    Friend WithEvents OpenFileDialog1 As Windows.Forms.OpenFileDialog
    Friend WithEvents Button1 As Windows.Forms.Button
    Friend WithEvents SaveFileDialog2 As Windows.Forms.SaveFileDialog
End Class

Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms
Imports DWSIM.ExtensionMethods
Imports DWSIM.GlobalSettings
Imports DWSIM.Interfaces
Imports DWSIM.SharedClasses.SystemsOfUnits
Imports Python.Runtime
Imports unvell.ReoGrid
Imports cv = DWSIM.SharedClasses.SystemsOfUnits.Converter

Public Class FormED

    Public Flowsheet As IFlowsheet
    Public nf As String
    Public su As Units

    Public cbio, cbip, cboo, cbop As DataGridViewComboBoxCell

    Public Property CurrentExperiment As New Experiment

    Private Sub FormED_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ChangeDefaultFont()

        su = Flowsheet.FlowsheetOptions.SelectedUnitSystem
        nf = Flowsheet.FlowsheetOptions.NumberFormat

        cbio = New DataGridViewComboBoxCell
        cbio.Sorted = True
        cbio.MaxDropDownItems = 10

        cboo = New DataGridViewComboBoxCell
        cboo.Sorted = True
        cboo.MaxDropDownItems = 10

        For Each obj In Flowsheet.SimulationObjects.Values
            cbio.Items.Add(obj.GraphicObject.Tag)
            cboo.Items.Add(obj.GraphicObject.Tag)
        Next

        cbip = New DataGridViewComboBoxCell
        cbip.MaxDropDownItems = 10

        cbop = New DataGridViewComboBoxCell
        cbop.MaxDropDownItems = 10
        With Me.dgInput
            .Columns(1).CellTemplate = cbio
            .Columns(2).CellTemplate = cbip
        End With

        With Me.dgOutput
            .Columns(1).CellTemplate = cboo
            .Columns(2).CellTemplate = cbop
        End With

        gridData.Worksheets(0).SetScale(Settings.DpiScale)

        gridResults.Worksheets(0).SetScale(Settings.DpiScale)

        AddHandler dgInput.EditingControlShowing, AddressOf Me.dgInput_EditingControlShowing

        AddHandler dgOutput.EditingControlShowing, AddressOf Me.dgOutput_EditingControlShowing

    End Sub

    Public Sub LoadDataFromExperiment()

        tbName.Text = CurrentExperiment.Name
        tbDesc.Text = CurrentExperiment.Description
        tbNumberOfExperiments.Text = CurrentExperiment.NumberOfExperiments

        dgInput.Rows.Clear()
        For Each var In CurrentExperiment.InputVars
            dgInput.Rows.Add(var.Name, "", "", var.Discrete, var.DiscreteStep,
                            var.MinValue, var.MaxValue, var.MeanValue, var.StdDev, var.TrustLevel, var.Units)
            dgInput.Rows(dgInput.Rows.Count - 1).Cells(1).Value = Flowsheet.SimulationObjects(var.ObjectID).GraphicObject.Tag
            dgInput.Rows(dgInput.Rows.Count - 1).Cells(2).Value = Flowsheet.GetTranslatedString(var.PropertyID)
        Next

        dgOutput.Rows.Clear()
        For Each var In CurrentExperiment.OutputVars
            dgOutput.Rows.Add(var.Name, "", "", var.Units)
            dgOutput.Rows(dgOutput.Rows.Count - 1).Cells(1).Value = Flowsheet.SimulationObjects(var.ObjectID).GraphicObject.Tag
            dgOutput.Rows(dgOutput.Rows.Count - 1).Cells(2).Value = Flowsheet.GetTranslatedString(var.PropertyID)
        Next

        gridData.Worksheets(0).SetCols(CurrentExperiment.InputVars.Count)
        gridData.Worksheets(0).SetRows(CurrentExperiment.NumberOfExperiments)

        For i = 0 To CurrentExperiment.InputVars.Count - 1
            gridData.Worksheets(0).ColumnHeaders.Item(i).Text = CurrentExperiment.InputVars(i).Name
        Next

        gridData.Worksheets(0).SetRangeStyles(0, 0,
                                              CurrentExperiment.NumberOfExperiments,
                                              CurrentExperiment.InputVars.Count,
                                           New unvell.ReoGrid.WorksheetRangeStyle() With {
                                           .Flag = unvell.ReoGrid.PlainStyleFlag.FontSize + unvell.ReoGrid.PlainStyleFlag.FontName,
                                           .FontName = SystemFonts.MessageBoxFont.Name, .FontSize = SystemFonts.MessageBoxFont.Size})

        gridData.Worksheets(0).SetRangeDataFormat(0, 0,
                                              CurrentExperiment.NumberOfExperiments,
                                              CurrentExperiment.InputVars.Count,
                                              unvell.ReoGrid.DataFormat.CellDataFormatFlag.Number,
                                               New unvell.ReoGrid.DataFormat.NumberDataFormatter.NumberFormatArgs() With
                                                {
                                                .DecimalPlaces = 4,
                                                .NegativeStyle = unvell.ReoGrid.DataFormat.NumberDataFormatter.NumberNegativeStyle.Minus,
                                                .UseSeparator = False
                                                })

        gridResults.Worksheets(0).SetRangeStyles(0, 0,
                                                  CurrentExperiment.NumberOfExperiments + 1,
                                                  CurrentExperiment.InputVars.Count + CurrentExperiment.OutputVars.Count + 2,
                                               New unvell.ReoGrid.WorksheetRangeStyle() With {
                                               .Flag = unvell.ReoGrid.PlainStyleFlag.FontSize + unvell.ReoGrid.PlainStyleFlag.FontName,
                                               .FontName = SystemFonts.MessageBoxFont.Name, .FontSize = SystemFonts.MessageBoxFont.Size})

        gridResults.Worksheets(0).SetRangeDataFormat(1, 1,
                                                  CurrentExperiment.NumberOfExperiments + 1,
                                                  CurrentExperiment.InputVars.Count + CurrentExperiment.OutputVars.Count,
                                                  unvell.ReoGrid.DataFormat.CellDataFormatFlag.Number,
                                                   New unvell.ReoGrid.DataFormat.NumberDataFormatter.NumberFormatArgs() With
                                                    {
                                                    .DecimalPlaces = 4,
                                                    .NegativeStyle = unvell.ReoGrid.DataFormat.NumberDataFormatter.NumberNegativeStyle.Minus,
                                                    .UseSeparator = False
                                                    })

        gridResults.Worksheets(0).SetRangeDataFormat(0, 0,
                                                  CurrentExperiment.NumberOfExperiments + 1,
                                                  1,
                                                  unvell.ReoGrid.DataFormat.CellDataFormatFlag.Number,
                                                   New unvell.ReoGrid.DataFormat.NumberDataFormatter.NumberFormatArgs() With
                                                    {
                                                    .DecimalPlaces = 0,
                                                    .NegativeStyle = unvell.ReoGrid.DataFormat.NumberDataFormatter.NumberNegativeStyle.Minus,
                                                    .UseSeparator = False
                                                    })

        gridResults.Worksheets(0).SetRangeStyles(0, 0,
                                                  CurrentExperiment.NumberOfExperiments + 1,
                                                  CurrentExperiment.InputVars.Count + CurrentExperiment.OutputVars.Count + 1,
                                                  New WorksheetRangeStyle With {
                                                        .Flag = PlainStyleFlag.Padding,
                                                        .Padding = New PaddingValue(2, 2, 5, 5)
                                                    })
        gridResults.Worksheets(0).EnableSettings(WorksheetSettings.Edit_AutoExpandColumnWidth)

        For i = 0 To CurrentExperiment.NumberOfExperiments - 1
            For j = 0 To CurrentExperiment.InputVars.Count - 1
                Try
                    gridData.Worksheets(0).Cells(i, j).Data = CurrentExperiment.ExperimentData(i)(j)
                Catch ex As Exception
                End Try
            Next
        Next

        gridResults.Worksheets(0).Cells(0, 0).Data = "Experiment"
        For i = 0 To CurrentExperiment.InputVars.Count - 1
            gridResults.Worksheets(0).Cells(0, i + 1).Data = CurrentExperiment.InputVars(i).Name
        Next
        For i = 0 To CurrentExperiment.OutputVars.Count - 1
            gridResults.Worksheets(0).Cells(0, CurrentExperiment.InputVars.Count + i + 1).Data = CurrentExperiment.OutputVars(i).Name
        Next
        For i = 1 To CurrentExperiment.NumberOfExperiments
            gridResults.Worksheets(0).Cells(i, 0).Data = i
        Next

        For i = 0 To CurrentExperiment.NumberOfExperiments - 1
            For jj = 0 To CurrentExperiment.InputVars.Count - 1
                gridResults.Worksheets(0).Cells(i + 1, jj + 1).Data = CurrentExperiment.ExperimentData(i)(jj)
            Next
            For jj = CurrentExperiment.InputVars.Count To CurrentExperiment.InputVars.Count + CurrentExperiment.OutputVars.Count - 1
                gridResults.Worksheets(0).Cells(i + 1, jj + 1).Data = CurrentExperiment.ExperimentData(i)(jj)
            Next
        Next

    End Sub

    Private Sub dgInput_EditingControlShowing(ByVal sender As Object, ByVal e As DataGridViewEditingControlShowingEventArgs)
        If (e.Control.GetType = GetType(DataGridViewComboBoxEditingControl)) Then
            Dim cmb As ComboBox = CType(e.Control, ComboBox)
            RemoveHandler DirectCast(sender, DataGridView).EditingControlShowing, AddressOf cmb_SelectionChangeCommitted
            AddHandler cmb.SelectionChangeCommitted, AddressOf cmb_SelectionChangeCommitted
            SendKeys.Send("{F4}")
        End If
    End Sub

    Private Sub dgOutput_EditingControlShowing(ByVal sender As Object, ByVal e As DataGridViewEditingControlShowingEventArgs)
        If (e.Control.GetType = GetType(DataGridViewComboBoxEditingControl)) Then
            Dim cmb As ComboBox = CType(e.Control, ComboBox)
            RemoveHandler DirectCast(sender, DataGridView).EditingControlShowing, AddressOf cmb_SelectionChangeCommitted2
            AddHandler cmb.SelectionChangeCommitted, AddressOf cmb_SelectionChangeCommitted2
            SendKeys.Send("{F4}")
        End If
    End Sub

    Private Sub cmb_SelectionChangeCommitted(ByVal sender As Object, ByVal e As EventArgs)
        dgInput.CurrentCell.Value = CType(sender, DataGridViewComboBoxEditingControl).EditingControlFormattedValue
    End Sub

    Private Sub cmb_SelectionChangeCommitted2(ByVal sender As Object, ByVal e As EventArgs)
        dgOutput.CurrentCell.Value = CType(sender, DataGridViewComboBoxEditingControl).EditingControlFormattedValue
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles tbName.TextChanged

        CurrentExperiment.Name = tbName.Text

    End Sub

    Private Sub tbDesc_TextChanged(sender As Object, e As EventArgs) Handles tbDesc.TextChanged

        CurrentExperiment.Description = tbDesc.Text

    End Sub

    Private Sub dgInput_CellValueChanged(sender As Object, e As Windows.Forms.DataGridViewCellEventArgs) Handles dgInput.CellValueChanged
        If e.RowIndex >= 0 Then
            Select Case e.ColumnIndex
                Case 1
                    Dim cbc As DataGridViewComboBoxCell = dgInput.Rows(e.RowIndex).Cells(e.ColumnIndex + 1)
                    cbc.Items.Clear()
                    With cbc.Items
                        If dgInput.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString <> "" Then
                            Dim props As String()
                            props = ReturnProperties(dgInput.Rows(e.RowIndex).Cells(1).Value, False)
                            For Each prop As String In props
                                .Add(Flowsheet.GetTranslatedString1(prop))
                            Next
                        End If
                    End With
                    cbc.Sorted = True
                Case 2
                    If Not dgInput.Rows(e.RowIndex).Cells(e.ColumnIndex).Value Is Nothing Then
                        Dim tbc0 As DataGridViewTextBoxCell = dgInput.Rows(e.RowIndex).Cells(10)
                        tbc0.Value = ""
                        Dim props As String() = ReturnProperties(dgInput.Rows(e.RowIndex).Cells(1).Value, True)
                        For Each prop As String In props
                            If Flowsheet.GetTranslatedString1(prop) = dgInput.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString Then
                                Dim obj = ReturnObject(dgInput.Rows(e.RowIndex).Cells(1).Value)
                                tbc0.Value = obj.GetPropertyUnit(prop, su)
                                Exit For
                            End If
                        Next
                    End If
            End Select
        End If
    End Sub

    Private Sub tsbAddIndVar_Click(sender As Object, e As EventArgs) Handles tsbAddIndVar.Click
        dgInput.Rows.Add()
    End Sub

    Private Sub tsbRemoveIndVar_Click(sender As Object, e As EventArgs) Handles tsbRemoveIndVar.Click
        If MessageBox.Show("Confirm?", "DWSIM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            If dgInput.SelectedRows.Count > 0 Then
                For i As Integer = 0 To dgInput.SelectedRows.Count - 1
                    dgInput.Rows.Remove(dgInput.SelectedRows(0))
                Next
            ElseIf dgInput.RowCount = 1 Then
                dgInput.Rows.RemoveAt(0)
            End If
        End If
    End Sub

    Private Sub dgOutput_CellValueChanged(sender As Object, e As Windows.Forms.DataGridViewCellEventArgs) Handles dgOutput.CellValueChanged
        If e.RowIndex >= 0 Then
            Select Case e.ColumnIndex
                Case 1
                    Dim cbc As DataGridViewComboBoxCell = dgOutput.Rows(e.RowIndex).Cells(e.ColumnIndex + 1)
                    cbc.Items.Clear()
                    With cbc.Items
                        If dgOutput.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString <> "" Then
                            Dim props As String()
                            props = ReturnProperties(dgOutput.Rows(e.RowIndex).Cells(1).Value, True)
                            For Each prop As String In props
                                .Add(Flowsheet.GetTranslatedString1(prop))
                            Next
                        End If
                    End With
                    cbc.Sorted = True
                Case 2
                    If Not dgOutput.Rows(e.RowIndex).Cells(e.ColumnIndex).Value Is Nothing Then
                        Dim tbc0 As DataGridViewTextBoxCell = dgOutput.Rows(e.RowIndex).Cells(3)
                        tbc0.Value = ""
                        Dim props As String() = ReturnProperties(dgOutput.Rows(e.RowIndex).Cells(1).Value, True)
                        For Each prop As String In props
                            If Flowsheet.GetTranslatedString1(prop) = dgOutput.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString Then
                                Dim obj = ReturnObject(dgOutput.Rows(e.RowIndex).Cells(1).Value)
                                tbc0.Value = obj.GetPropertyUnit(prop, su)
                                Exit For
                            End If
                        Next
                    End If
            End Select
        End If
    End Sub

    Private Sub tsbAddDepVar_Click(sender As Object, e As EventArgs) Handles tsbAddDepVar.Click
        dgOutput.Rows.Add()
    End Sub

    Private Sub tsbRemoveDepVar_Click(sender As Object, e As EventArgs) Handles tsbRemoveDepVar.Click
        If MessageBox.Show("Confirm?", "DWSIM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            If dgOutput.SelectedRows.Count > 0 Then
                For i As Integer = 0 To dgOutput.SelectedRows.Count - 1
                    dgOutput.Rows.Remove(dgOutput.SelectedRows(0))
                Next
            ElseIf dgOutput.RowCount = 1 Then
                dgOutput.Rows.RemoveAt(0)
            End If
        End If
    End Sub

    Public Sub ReadData()

        CurrentExperiment.InputVars.Clear()

        Dim i = 1
        For Each row As DataGridViewRow In dgInput.Rows
            Try
                Dim variable As New InputVariable
                variable.Name = row.Cells(0).Value
                variable.ObjectID = ReturnObject(row.Cells(1).Value).Name
                variable.PropertyID = ReturnPropertyID(ReturnObject(row.Cells(1).Value).Name, row.Cells(2).Value)
                variable.Discrete = Boolean.Parse(row.Cells(3).Value)
                If row.Cells(4).Value IsNot Nothing Then variable.DiscreteStep = Convert.ToDouble(row.Cells(4).Value)
                If row.Cells(5).Value IsNot Nothing Then variable.MinValue = Convert.ToDouble(row.Cells(5).Value)
                If row.Cells(6).Value IsNot Nothing Then variable.MaxValue = Convert.ToDouble(row.Cells(6).Value)
                If row.Cells(7).Value IsNot Nothing Then variable.MeanValue = Convert.ToDouble(row.Cells(7).Value)
                If row.Cells(8).Value IsNot Nothing Then variable.StdDev = Convert.ToDouble(row.Cells(8).Value)
                If row.Cells(9).Value IsNot Nothing Then variable.TrustLevel = Convert.ToDouble(row.Cells(9).Value)
                variable.Units = row.Cells(10).Value
                CurrentExperiment.InputVars.Add(variable)
            Catch ex As Exception
                MessageBox.Show(String.Format("Error parsing input variable row {0}, please check input data [{1}].", i, ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
            i += 1
        Next

        CurrentExperiment.OutputVars.Clear()

        i = 1
        For Each row As DataGridViewRow In dgOutput.Rows
            Try
                Dim variable As New OutputVariable With {
                .Name = row.Cells(0).Value,
                .ObjectID = ReturnObject(row.Cells(1).Value).Name,
                .PropertyID = ReturnPropertyID(ReturnObject(row.Cells(1).Value).Name, row.Cells(2).Value),
                .Units = row.Cells(3).Value
                }
                CurrentExperiment.OutputVars.Add(variable)
            Catch ex As Exception
                MessageBox.Show(String.Format("Error parsing input variable row {0}, please check input data [{1}].", i, ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
            i += 1
        Next

        CurrentExperiment.NumberOfExperiments = tbNumberOfExperiments.Text

    End Sub

    Private Sub btnGenerateData_Click(sender As Object, e As EventArgs) Handles btnGenerateData.Click

        ReadData()

        Settings.InitializePythonEnvironment()

        Using Py.GIL

            Dim sys As Object = Py.Import("sys")
            Dim libpath = Path.Combine(Path.GetDirectoryName(Reflection.Assembly.GetExecutingAssembly().Location), "ed_app", "DOE_APP")
            sys.path.append(libpath)

            Dim doe As Object = Py.Import("DOE")
            Dim np As Object = Py.Import("numpy")
            Dim pd As Object = Py.Import("pandas")

            For Each iv In CurrentExperiment.InputVars

                If iv.DiscreteStep Is Nothing Then iv.DiscreteStep = 1.0
                If iv.TrustLevel Is Nothing Then iv.TrustLevel = 0.95
                If iv.Discrete Is Nothing Then iv.Discrete = False

                If Not iv.Discrete Then

                    If iv.MeanValue.HasValue Then

                        If iv.StdDev Is Nothing Then
                            iv.StdDev = doe.estimate_std(iv.MaxValue, iv.MinValue, iv.TrustLevel)
                        End If

                        'estimate min and max values

                        Dim r1 = doe.estimate_min_max(iv.MeanValue, iv.StdDev, iv.TrustLevel)

                        iv.MinValue = Convert.ToDouble(r1(0).ToString())
                        iv.MaxValue = Convert.ToDouble(r1(1).ToString())

                    ElseIf iv.MaxValue.HasValue And iv.MinValue.HasValue Then

                        'estimate mean and stddev values

                        Dim val = np.mean(New Double() {iv.MaxValue, iv.MinValue}.ToPython())

                        iv.MeanValue = Convert.ToDouble(val.ToString())

                        val = doe.estimate_std(iv.MaxValue, iv.MinValue, iv.TrustLevel)

                        iv.StdDev = Convert.ToDouble(val.ToString())

                    End If

                Else

                    iv.MeanValue = 0.0
                    iv.StdDev = 1.0

                End If

            Next

            Dim names = CurrentExperiment.InputVars.Select(Function(v) v.Name).ToArray()
            Dim types = CurrentExperiment.InputVars.Select(Function(v) If(v.Discrete, "Discrete", "Continuous")).ToArray()
            Dim maxes = CurrentExperiment.InputVars.Select(Function(v) v.MaxValue).ToArray()
            Dim mins = CurrentExperiment.InputVars.Select(Function(v) v.MinValue).ToArray()
            Dim means = CurrentExperiment.InputVars.Select(Function(v) v.MeanValue).ToArray()
            Dim stddevs = CurrentExperiment.InputVars.Select(Function(v) v.StdDev).ToArray()
            Dim segments = CurrentExperiment.InputVars.Select(Function(v) (v.MaxValue - v.MinValue) / v.DiscreteStep).ToArray()
            Dim steps = CurrentExperiment.InputVars.Select(Function(v) v.DiscreteStep).ToArray()
            Dim tlevels = CurrentExperiment.InputVars.Select(Function(v) v.TrustLevel).ToArray()

            Dim data As New PyDict()
            data("Variable Name") = names.ToPython()
            data("Mean") = means.ToPython()
            data("Standard Deviation") = stddevs.ToPython()
            data("Max") = maxes.ToPython()
            data("Min") = mins.ToPython()
            data("Step (If Variable is Discrete)") = steps.ToPython()
            data("Variable Type") = types.ToPython()
            data("Segmentos") = segments.ToPython()
            data("Trust Level") = tlevels.ToPython()

            Dim df = pd.DataFrame.from_dict(data)

            'df.to_excel("DOE_PD.xlsx")

            Dim result = doe.LatinHypercube(df, CurrentExperiment.NumberOfExperiments.ToPython())

            Console.WriteLine(result)

            'result.to_excel("DOE_OUT.xlsx")

            Dim edata(CurrentExperiment.NumberOfExperiments - 1)() As Double
            For i = 0 To edata.Count - 1
                Array.Resize(edata(i), CurrentExperiment.InputVars.Count + CurrentExperiment.OutputVars.Count)
            Next

            Dim output = result.to_dict(orient:="index")

            For i = 1 To CurrentExperiment.NumberOfExperiments
                For j = 0 To CurrentExperiment.InputVars.Count - 1
                    Dim list1 = output(i)
                    Dim value1 = list1(names(j))
                    edata(i - 1)(j) = value1.ToString().ToDoubleFromInvariant()
                Next
            Next

            CurrentExperiment.ExperimentData = edata

            gridData.Worksheets(0).SetCols(CurrentExperiment.InputVars.Count)
            gridData.Worksheets(0).SetRows(CurrentExperiment.NumberOfExperiments)

            For i = 0 To CurrentExperiment.InputVars.Count - 1
                gridData.Worksheets(0).ColumnHeaders.Item(i).Text = names(i)
            Next

            gridData.Worksheets(0).SetRangeStyles(0, 0,
                                                  CurrentExperiment.NumberOfExperiments,
                                                  CurrentExperiment.InputVars.Count,
                                               New unvell.ReoGrid.WorksheetRangeStyle() With {
                                               .Flag = unvell.ReoGrid.PlainStyleFlag.FontSize + unvell.ReoGrid.PlainStyleFlag.FontName,
                                               .FontName = SystemFonts.MessageBoxFont.Name, .FontSize = SystemFonts.MessageBoxFont.Size})

            gridData.Worksheets(0).SetRangeDataFormat(0, 0,
                                                  CurrentExperiment.NumberOfExperiments,
                                                  CurrentExperiment.InputVars.Count,
                                                  unvell.ReoGrid.DataFormat.CellDataFormatFlag.Number,
                                                   New unvell.ReoGrid.DataFormat.NumberDataFormatter.NumberFormatArgs() With
                                                    {
                                                    .DecimalPlaces = 4,
                                                    .NegativeStyle = unvell.ReoGrid.DataFormat.NumberDataFormatter.NumberNegativeStyle.Minus,
                                                    .UseSeparator = False
                                                    })
            gridData.Worksheets(0).SetRangeStyles(0, 0,
                                                  CurrentExperiment.NumberOfExperiments,
                                                  CurrentExperiment.InputVars.Count, New WorksheetRangeStyle With {
                .Flag = PlainStyleFlag.HorizontalAlign,
                .HAlign = ReoGridHorAlign.Right
            })
            gridData.Worksheets(0).SetRangeStyles(0, 0,
                                                  CurrentExperiment.NumberOfExperiments,
                                                  CurrentExperiment.InputVars.Count, New WorksheetRangeStyle With {
                .Flag = PlainStyleFlag.VerticalAlign,
                .VAlign = ReoGridVerAlign.Middle
            })
            gridData.Worksheets(0).SetRangeStyles(0, 0,
                                                  CurrentExperiment.NumberOfExperiments,
                                                  CurrentExperiment.InputVars.Count, New WorksheetRangeStyle With {
                .Flag = PlainStyleFlag.Padding,
                .Padding = New PaddingValue(2, 2, 5, 5)
            })
            gridData.Worksheets(0).EnableSettings(WorksheetSettings.Edit_AutoExpandColumnWidth)

            For i = 0 To CurrentExperiment.NumberOfExperiments - 1
                For j = 0 To CurrentExperiment.InputVars.Count - 1
                    gridData.Worksheets(0).Cells(i, j).Data = edata(i)(j)
                Next
            Next

        End Using

    End Sub

    Private Sub btnRun_Click(sender As Object, e As EventArgs) Handles btnRun.Click

        gridResults.Worksheets(0).SetCols(CurrentExperiment.InputVars.Count + CurrentExperiment.OutputVars.Count + 1)
        gridResults.Worksheets(0).SetRows(CurrentExperiment.NumberOfExperiments + 1)

        gridResults.Worksheets(0).Cells(0, 0).Data = "Experiment"
        For i = 0 To CurrentExperiment.InputVars.Count - 1
            gridResults.Worksheets(0).Cells(0, i + 1).Data = CurrentExperiment.InputVars(i).Name
        Next
        For i = 0 To CurrentExperiment.OutputVars.Count - 1
            gridResults.Worksheets(0).Cells(0, CurrentExperiment.InputVars.Count + i + 1).Data = CurrentExperiment.OutputVars(i).Name
        Next
        For i = 1 To CurrentExperiment.NumberOfExperiments
            gridResults.Worksheets(0).Cells(i, 0).Data = i
        Next

        gridResults.Worksheets(0).SetRangeStyles(0, 0,
                                                  CurrentExperiment.NumberOfExperiments + 1,
                                                  CurrentExperiment.InputVars.Count + CurrentExperiment.OutputVars.Count + 1,
                                               New unvell.ReoGrid.WorksheetRangeStyle() With {
                                               .Flag = unvell.ReoGrid.PlainStyleFlag.FontSize + unvell.ReoGrid.PlainStyleFlag.FontName,
                                               .FontName = SystemFonts.MessageBoxFont.Name, .FontSize = SystemFonts.MessageBoxFont.Size})

        gridResults.Worksheets(0).SetRangeDataFormat(1, 1,
                                                  CurrentExperiment.NumberOfExperiments,
                                                  CurrentExperiment.InputVars.Count + CurrentExperiment.OutputVars.Count,
                                                  unvell.ReoGrid.DataFormat.CellDataFormatFlag.Number,
                                                   New unvell.ReoGrid.DataFormat.NumberDataFormatter.NumberFormatArgs() With
                                                    {
                                                    .DecimalPlaces = 4,
                                                    .NegativeStyle = unvell.ReoGrid.DataFormat.NumberDataFormatter.NumberNegativeStyle.Minus,
                                                    .UseSeparator = False
                                                    })

        gridResults.Worksheets(0).SetRangeDataFormat(0, 0,
                                                  CurrentExperiment.NumberOfExperiments + 1,
                                                  1,
                                                  unvell.ReoGrid.DataFormat.CellDataFormatFlag.Number,
                                                   New unvell.ReoGrid.DataFormat.NumberDataFormatter.NumberFormatArgs() With
                                                    {
                                                    .DecimalPlaces = 0,
                                                    .NegativeStyle = unvell.ReoGrid.DataFormat.NumberDataFormatter.NumberNegativeStyle.Minus,
                                                    .UseSeparator = False
                                                    })

        gridResults.Worksheets(0).SetRangeStyles(0, 0,
                                                  CurrentExperiment.NumberOfExperiments + 1,
                                                  CurrentExperiment.InputVars.Count + CurrentExperiment.OutputVars.Count + 1,
                                                  New WorksheetRangeStyle With {
                                                        .Flag = PlainStyleFlag.Padding,
                                                        .Padding = New PaddingValue(2, 2, 5, 5)
                                                    })
        gridResults.Worksheets(0).EnableSettings(WorksheetSettings.Edit_AutoExpandColumnWidth)

        Flowsheet.SupressMessages = True

        Dim j As Integer

        Dim data = CurrentExperiment.ExperimentData

        Dim fw As New WaitForm()

        Dim cancel As Boolean = False

        Settings.TaskCancellationTokenSource = New Threading.CancellationTokenSource()

        AddHandler fw.btnCancel.Click, Sub()
                                           Settings.TaskCancellationTokenSource.Cancel()
                                           cancel = True
                                       End Sub

        fw.ChangeDefaultFont()
        fw.Show()

        For i = 0 To CurrentExperiment.NumberOfExperiments - 1

            If cancel Then Exit For

            j = 0
            For Each iv In CurrentExperiment.InputVars
                Flowsheet.SimulationObjects(iv.ObjectID).SetPropertyValue(iv.PropertyID, data(i)(j).ConvertToSI(iv.Units))
                j += 1
            Next

            Application.DoEvents()

            fw.lblMessage.Text = String.Format("running experiment {0} of {1}...", i + 1, CurrentExperiment.NumberOfExperiments)

            Dim ii = i

            Dim t As New Task(Of List(Of Exception))(Function()
                                                         Return FlowsheetSolver.FlowsheetSolver.SolveFlowsheet(Flowsheet, 1, Settings.TaskCancellationTokenSource)
                                                     End Function,
                                    Settings.TaskCancellationTokenSource.Token)

            t.ContinueWith(Sub(tres)

                               If tres.Exception Is Nothing AndAlso tres.Result.Count = 0 Then

                                   Dim jj = CurrentExperiment.InputVars.Count
                                   For Each ov In CurrentExperiment.OutputVars
                                       data(ii)(jj) = Convert.ToDouble(Flowsheet.SimulationObjects(ov.ObjectID).GetPropertyValue(ov.PropertyID)).ConvertFromSI(ov.Units)
                                       jj += 1
                                   Next

                               Else

                                   Dim jj = CurrentExperiment.InputVars.Count
                                   For Each ov In CurrentExperiment.OutputVars
                                       data(ii)(jj) = Double.NaN
                                       jj += 1
                                   Next

                               End If

                               UIThread(Sub()

                                            For jj = 0 To CurrentExperiment.InputVars.Count - 1
                                                gridResults.Worksheets(0).Cells(ii + 1, jj + 1).Data = data(ii)(jj)
                                            Next
                                            For jj = CurrentExperiment.InputVars.Count To CurrentExperiment.InputVars.Count + CurrentExperiment.OutputVars.Count - 1
                                                gridResults.Worksheets(0).Cells(ii + 1, jj + 1).Data = data(ii)(jj)
                                            Next

                                        End Sub)

                           End Sub)

            Try
                t.Start()
                t.Wait()
            Catch ex As Exception
            End Try

        Next

        fw.Close()

        Flowsheet.SupressMessages = False

        gridResults.Worksheets(0).EnableSettings(WorksheetSettings.Edit_AutoExpandColumnWidth)

        For j = 0 To CurrentExperiment.InputVars.Count + CurrentExperiment.OutputVars.Count - 1
            gridResults.Worksheets(0).AutoFitColumnWidth(j)
        Next

    End Sub

    Public Function ToList(pythonlist As Object) As List(Of Double)

        Using Py.GIL

            Dim list As New List(Of Double)

            For i As Integer = 0 To pythonlist.Length - 1
                list.Add(pythonlist(i).ToString().ToDoubleFromInvariant())
            Next

            Return list

        End Using

    End Function

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then

            Dim experiment = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Experiment)(File.ReadAllText(OpenFileDialog1.FileName))

            CurrentExperiment = experiment

            LoadDataFromExperiment()

            MessageBox.Show("Import OK!", "Experiment Designer", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click

        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then

            ReadData()

            Dim data = Newtonsoft.Json.JsonConvert.SerializeObject(CurrentExperiment, Newtonsoft.Json.Formatting.Indented)

            File.WriteAllText(SaveFileDialog1.FileName, data)

            MessageBox.Show("Export OK!", "Experiment Designer", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If SaveFileDialog2.ShowDialog() = DialogResult.OK Then

            gridResults.Save(SaveFileDialog2.FileName, IO.FileFormat.Excel2007)

            MessageBox.Show("Export OK!", "Experiment Designer", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub

    Private Function ReturnObject(ByVal objectTAG As String) As ISimulationObject

        For Each obj In Flowsheet.SimulationObjects.Values
            If objectTAG = obj.GraphicObject.Tag Then
                Return obj
                Exit Function
            End If
        Next

        Return Nothing

    End Function

    Private Function ReturnPropertyID(ByVal objectID As String, ByVal propTAG As String) As String

        Dim props As String() = Flowsheet.SimulationObjects(objectID).GetProperties(Enums.PropertyType.ALL)
        For Each prop As String In props
            If Flowsheet.GetTranslatedString1(prop) = propTAG Then
                Return prop
            End If
        Next

        Return Nothing

    End Function

    Private Function ReturnProperties(ByVal objectTAG As String, ByVal dependent As Boolean) As String()

        For Each obj In Flowsheet.SimulationObjects.Values
            If objectTAG = obj.GraphicObject.Tag Then
                If dependent Then
                    Return obj.GetProperties(Enums.PropertyType.ALL)
                Else
                    Return obj.GetProperties(Enums.PropertyType.WR)
                End If
                Exit Function
            End If
        Next

        Return Nothing

    End Function

    Private Sub FormED_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        If MessageBox.Show("Confirm Exit?", "Experiment Designer", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            e.Cancel = True
        End If

    End Sub

End Class
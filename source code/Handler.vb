
Imports System.Drawing
Imports DWSIM.Interfaces
Imports DWSIM.Interfaces.Enums

Public Class Handler

    Implements Interfaces.IExtenderCollection

    Public ReadOnly Property ID As String = "EDHANDLER" Implements IExtenderCollection.ID

    Public ReadOnly Property Description As String = "" Implements IExtenderCollection.Description

    Public ReadOnly Property DisplayText As String = "" Implements IExtenderCollection.DisplayText

    Public ReadOnly Property Category As ExtenderCategory = ExtenderCategory.Optimization Implements IExtenderCollection.Category

    Public ReadOnly Property Level As ExtenderLevel = ExtenderLevel.FlowsheetWindow Implements IExtenderCollection.Level

    Public ReadOnly Property Collection As List(Of IExtender) Implements IExtenderCollection.Collection

    Sub New()
        Collection = New List(Of IExtender)
        Collection.Add(New ExpDesigner())
    End Sub

End Class


Public Class ExpDesigner

    Implements IExtender, IExtender3

    Private mainform As FormMain

    Public Flowsheet As IFlowsheet

    Private ExperimentDesignerForm As FormED

    Public ReadOnly Property ID As String = "EXPERIMENT_DESIGNER" Implements IExtender.ID

    Public ReadOnly Property DisplayText As String = "Experiment Designer" Implements IExtender.DisplayText

    Public ReadOnly Property DisplayImage As Bitmap = My.Resources.alcohol_burner_48px Implements IExtender.DisplayImage

    Public ReadOnly Property InsertAtPosition As Integer = -1 Implements IExtender.InsertAtPosition

    Public Sub SetMainWindow(mainwindow As System.Windows.Forms.Form) Implements IExtender.SetMainWindow

        mainform = mainwindow

    End Sub

    Public Sub SetFlowsheet(form As IFlowsheet) Implements IExtender.SetFlowsheet

        Flowsheet = form

    End Sub

    Public Sub Run() Implements IExtender.Run

        ExperimentDesignerForm = New FormED With {.Flowsheet = Flowsheet}
        ExperimentDesignerForm.Show(Flowsheet)

    End Sub

    Public Sub ReleaseResources() Implements IExtender3.ReleaseResources

        Flowsheet = Nothing
        ExperimentDesignerForm = Nothing
        mainform = Nothing

    End Sub

End Class


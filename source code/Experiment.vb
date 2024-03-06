Public Class Experiment

    Public Property Name As String = ""

    Public Property Description As String = ""

    Public Property NumberOfExperiments As Integer = 1000

    Public Property InputVars As New List(Of InputVariable)

    Public Property OutputVars As New List(Of OutputVariable)

    Public Property ExperimentData As Double()()

End Class

Public Class InputVariable

    Public Property Name As String = ""

    Public Property ObjectID As String = ""

    Public Property PropertyID As String = ""

    Public Property Units As String = ""

    Public Property Discrete As Boolean? = False

    Public Property DiscreteStep As Double? = Nothing

    Public Property MinValue As Double? = Nothing

    Public Property MaxValue As Double? = Nothing

    Public Property MeanValue As Double? = Nothing

    Public Property StdDev As Double? = Nothing

    Public Property TrustLevel As Double? = Nothing

End Class

Public Class OutputVariable

    Public Property Name As String = ""

    Public Property ObjectID As String = ""

    Public Property PropertyID As String = ""

    Public Property Units As String = ""

End Class
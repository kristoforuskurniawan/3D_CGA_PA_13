Public Class TPoint
    Public X, Y, Z As Double   'Store the x,y and z coord of this vertex as well as its index number
    Public w As Integer

    Public Sub New()
        X = 0
        Y = 0
        Z = 0
        w = 0
    End Sub

    Public Sub New(x As Double, y As Double, z As Double)
        SetPoint(x, y, z)
    End Sub

    Public Sub SetPoint(a As Double, b As Double, c As Double)
        X = a
        Y = b
        Z = c
        w = 1
    End Sub
End Class


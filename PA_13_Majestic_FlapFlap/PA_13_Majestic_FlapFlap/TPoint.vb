Public Class TPoint
    Public X, Y, Z As Double   'Store the x,y and z coord of this vertex
    Public W As Integer

    Public Sub New()
        X = 0
        Y = 0
        Z = 0
        W = 1
    End Sub

    Public Sub New(x As Double, y As Double, z As Double)
        SetPoint(x, y, z)
    End Sub

    Public Sub SetPoint(a As Double, b As Double, c As Double)
        X = a
        Y = b
        Z = c
        W = 1
    End Sub
End Class


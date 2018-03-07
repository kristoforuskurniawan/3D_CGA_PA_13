Public Class TPoint
    Public X, Y, Z As Double   'Store the x,y and z coord of this vertex as well as its index number
    Public PointIndex, w As Integer
    Public Sub SetPoint(a As Double, b As Double, c As Double, d As Integer)
        X = a
        Y = b
        Z = c
        w = 1
        PointIndex = d
    End Sub
End Class


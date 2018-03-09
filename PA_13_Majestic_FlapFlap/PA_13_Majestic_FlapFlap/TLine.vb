Public Class TLine
    Public PointA, PointB As Integer

    Public Sub New()
        PointA = -1
        PointB = -1
    End Sub

    Public Sub New(x As Integer, y As Integer)
        SetEdges(x, y)
    End Sub

    Public Sub SetEdges(a As Integer, b As Integer)
        PointA = a
        PointB = b
    End Sub
End Class

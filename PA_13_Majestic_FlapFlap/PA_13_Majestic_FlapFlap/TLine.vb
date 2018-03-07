Public Class TLine
    Public PointA, PointB As Integer
    Public LineIndex As Integer 'To make polygon indexing easier, use the line index

    Public Sub SetEdge(a As Integer, b As Integer, c As Integer)
        PointA = a
        PointB = b
        LineIndex = c
    End Sub
End Class

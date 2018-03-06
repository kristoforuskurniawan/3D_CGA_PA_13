Public Class TPolygon 'This case the polygon is triangle. The reason why we use triangle mesh is to make it possible to draw diagonal line (like in the wing)
    Public Line(3) As TLine 'Triangle polygon mesh has three edges for each

    Public Sub New()
        For i = 0 To 3
            Line(i) = New TLine()
        Next
    End Sub

    Public Sub New(Line() As TLine)
        For i = 0 To 3
            Me.Line(i) = Line(i)
        Next
    End Sub

End Class

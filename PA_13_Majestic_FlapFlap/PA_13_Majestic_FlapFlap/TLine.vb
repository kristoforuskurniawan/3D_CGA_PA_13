Public Class TLine
    Public Points(2) As TPoint 'One line consists of two points

    Public Sub New()
        Points(0) = New TPoint()
        Points(1) = New TPoint()
    End Sub
End Class

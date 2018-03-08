Public Class TPolygon 'Use Triangle meshes here
    Public Triangle(3) As TLine

    Public Sub New()
        Triangle(0) = New TLine()
        Triangle(1) = New TLine()
        Triangle(2) = New TLine()
        'Quadruple(3) = New TLine()
    End Sub
End Class

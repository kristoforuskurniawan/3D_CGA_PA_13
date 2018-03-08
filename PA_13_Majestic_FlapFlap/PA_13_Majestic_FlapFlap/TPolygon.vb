Public Class TPolygon 'Use quadraple meshes here
    Public Quadruple(4) As TLine

    Public Sub New()
        Quadruple(0) = New TLine()
        Quadruple(1) = New TLine()
        Quadruple(2) = New TLine()
        Quadruple(3) = New TLine()
    End Sub
End Class

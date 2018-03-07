Public Class TPolygon 'Use quadraple meshes here
    'Public EdgesIndexList As List(Of Integer) 'Polygon is a collection of index of edges used to make that polygon
    'Public PolygonIndex As Integer 'Store the index of this polygon to be used on polygon mesh (surface)
    Public Quadraple(4) As TLine

    Public Sub New()
        Quadraple(0) = New TLine()
        Quadraple(1) = New TLine()
        Quadraple(2) = New TLine()
        Quadraple(3) = New TLine()
    End Sub
End Class

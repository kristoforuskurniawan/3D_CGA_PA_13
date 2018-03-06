Public Class TPolygon 'Use triangle meshes here
    'Public EdgesIndexList As List(Of Integer) 'Polygon is a collection of index of edges used to make that polygon
    'Public PolygonIndex As Integer 'Store the index of this polygon to be used on polygon mesh (surface)
    Public Triangle(3) As TLine

    Public Sub New()
        Triangle(0) = New TLine()
        Triangle(1) = New TLine()
        Triangle(2) = New TLine()
    End Sub
End Class

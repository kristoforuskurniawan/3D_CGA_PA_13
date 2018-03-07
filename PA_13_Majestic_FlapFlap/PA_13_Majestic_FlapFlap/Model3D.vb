Public Class Model3D
    Public EdgesIndexList As List(Of Integer) 'Polygon is a collection of index of edges used to make that polygon
    Public PolygonIndex As Integer 'Store the index of this polygon to be used on polygon mesh (surface)

    Public Sub New()
        EdgesIndexList = New List(Of Integer)
    End Sub

End Class

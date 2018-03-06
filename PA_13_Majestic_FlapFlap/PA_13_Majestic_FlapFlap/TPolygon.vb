Public Class TPolygon 'This case the polygon is triangle. The reason why we use triangle mesh is to make it possible to draw diagonal line (like in the wing)
    Public Line(3) As TLine
    'Public EdgesIndexList As List(Of Integer) 'Polygon is a collection of index of edges used to make that polygon
    'Public PolygonIndex As Integer 'Store the index of this polygon to be used on polygon mesh (surface)
End Class

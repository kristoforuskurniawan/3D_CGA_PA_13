Public Class Model3D
    Public Vertices As List(Of TPoint)
    Public Edges As List(Of TLine) 'list of edges

    Public PolygonIndex As Integer 'Store the index of this polygon to be used on polygon mesh (surface)

    Public Sub New()
        Vertices = New List(Of TPoint)
        Edges = New List(Of TLine)
    End Sub

    Public Sub Copy3DObject(Target_Vertices As List(Of TPoint), Target_Edges As List(Of TLine))
        Vertices.AddRange(Target_Vertices)
        Edges.AddRange(Target_Edges)
    End Sub

End Class

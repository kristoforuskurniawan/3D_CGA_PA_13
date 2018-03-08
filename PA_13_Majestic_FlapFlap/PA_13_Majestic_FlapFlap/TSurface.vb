Public Class TSurface 'Surface is made of polygon mesh (triangle mesh)
    Public TriangleSurfaceMesh(256) As TPolygon

    Public Sub New() 'Default uses 256 Triangles
        For i = 0 To 255
            TriangleSurfaceMesh(i) = New TPolygon()
        Next
    End Sub

    Public Sub New(ByVal NumberOfTriangle As Integer) 'Defined number of meshes
        For i = 0 To NumberOfTriangle
            TriangleSurfaceMesh(i) = New TPolygon()
        Next
    End Sub

End Class

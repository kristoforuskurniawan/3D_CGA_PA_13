Public Class PolygonMesh_Cuboid 'each 
    Public Cuboid(6) As TSurface

    Public Sub New()
        For i = 0 To 5
            Cuboid(i) = New TSurface()
        Next
    End Sub
End Class

Public Class TElement3DObject
    Public Child As TList3DObject
    Public Nxt As TElement3DObject
    Public Obj As Model3D
    Public Rotation_Axis As Integer
    Public Rotation_Angle As Double
    Public Transform As Matrix4x4

    Public Sub New()
        Child = Nothing
        Nxt = Nothing
        Obj = Nothing
        Rotation_Axis = Nothing
        Rotation_Angle = Nothing
        Transform = Nothing
    End Sub

End Class

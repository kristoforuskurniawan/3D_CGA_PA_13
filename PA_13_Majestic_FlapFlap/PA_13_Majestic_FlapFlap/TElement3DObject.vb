Public Class TElement3DObject
    Public Child As TList3DObject
    Public Nxt As TElement3DObject
    Public Obj As Model3D
    Public Rotation_Axis As Integer
    Public Rotation_Angle As Double
    Public Transform As Matrix4x4

    Public Sub New()
        Child = Nil
        Nxt = Nil
        Obj = Nil
        Rotation_Axis = 0
        Rotation_Angle = 0
        Transform = New Matrix4x4
    End Sub


End Class

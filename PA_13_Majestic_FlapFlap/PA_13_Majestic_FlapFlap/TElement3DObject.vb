Public Class TElement3DObject
    Public label As String
    Public Child As TList3DObject
    Public Nxt As TElement3DObject
    Public Obj As Model3D
    Public Rotation_Axis As Integer
    Public Rotation_Angle As Double
    Public ScaleX As Integer
    Public ScaleY As Integer
    Public Transform As Matrix4x4

    Public Sub New()
        label = "nil"
        Child = Nil
        Nxt = Nil
        Obj = Nil
        Rotation_Axis = 0
        Rotation_Angle = 0
        ScaleX = 1
        ScaleY = 1
        Transform = New Matrix4x4
    End Sub
End Class

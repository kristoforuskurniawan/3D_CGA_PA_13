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

    Public Sub New(ByRef target As TElement3DObject)
        Child = target.Child
        Nxt = target.Nxt
        Obj = target.Obj
        Rotation_Axis = target.Rotation_Axis
        Rotation_Angle = target.Rotation_Angle
        ScaleX = target.ScaleX
        ScaleY = target.ScaleY
        Transform = target.Transform
    End Sub

    Public Sub New(RotAxis As Integer, RotAng As Integer, SclX As Integer, SclY As Integer, Transform As Matrix4x4)
        Child = Nil
        Nxt = Nil
        Obj = Nil
        Rotation_Axis = RotAxis
        Rotation_Angle = RotAng
        ScaleX = SclX
        ScaleY = SclY
        Transform = New Matrix4x4
    End Sub

    Public Function Insertion(Elmt As TElement3DObject, Rotation_Axis As Integer, Rotation_Angle As Double, ScaleX As Integer, ScaleY As Integer, Transform As Matrix4x4) As TElement3DObject
        If Elmt Is Nil Then
            Elmt = New TElement3DObject(Rotation_Axis, Rotation_Angle, ScaleX, ScaleY, Transform) 'Ini buat insertion object di linked listnya
        End If
        Return Elmt
    End Function

End Class

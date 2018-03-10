Public Class TList3DObject
    Public First As TElement3DObject

    Public Sub New()
        First = Nil
    End Sub

    Public Sub New(Target As TElement3DObject)
        First = Target
    End Sub

End Class

Public Class TPoint
    Public X, Y, Z, W As Integer 'Store the x,y and z coord of this vertex as well as its index number

    Public Sub New()
        X = 0
        Y = 0
        Z = 0
        W = 1
    End Sub

    Public Sub New(ByVal X As Integer, ByVal Y As Integer, ByVal Z As Integer)
        Me.X = X
        Me.Y = Y
        Me.Z = Z
        W = 1
    End Sub

End Class

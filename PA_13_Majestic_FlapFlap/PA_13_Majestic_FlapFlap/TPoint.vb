Public Class TPoint
    Public X, Y, Z, W As Single 'Store the x,y and z coord of this vertex as well as its index number + w for perspective
    'Public PointIndex As Integer = -1

    Public Sub New()
        X = 0
        Y = 0
        Z = 0
        W = 1
        '   Me.PointIndex = 0
    End Sub

    Public Sub New(X As Single, Y As Single, Z As Single)
        Me.X = X
        Me.Y = Y
        Me.Z = Z
        W = 1
        '  Me.PointIndex = 0
    End Sub

    Public Sub SetCoordinates(ByVal X As Single, ByVal Y As Single, ByVal Z As Single) 'Method to set coordinates
        Me.X = X
        Me.Y = Y
        Me.Z = Z
    End Sub
End Class

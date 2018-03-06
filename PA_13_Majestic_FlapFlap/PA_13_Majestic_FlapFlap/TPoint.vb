Public Class TPoint
    Public X, Y, Z, W As Integer 'Store the x,y and z coord of this vertex as well as its index number + w for perspective
    'Public PointIndex As Integer = -1

    Public Sub New()
        X = 0
        Y = 0
        Z = 0
        W = 1
        '   Me.PointIndex = 0
    End Sub

    Public Sub New(X As Integer, Y As Integer, Z As Integer)
        Me.X = X
        Me.Y = Y
        Me.Z = Z
        W = 1
        '  Me.PointIndex = 0
    End Sub

    Public Sub SetCoordinates(ByVal X As Integer, ByVal Y As Integer, ByVal Z As Integer) 'Method to set coordinates
        Me.X = X
        Me.Y = Y
        Me.Z = Z
    End Sub
End Class

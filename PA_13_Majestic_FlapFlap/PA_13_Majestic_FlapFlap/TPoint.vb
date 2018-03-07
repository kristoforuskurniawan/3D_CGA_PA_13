Public Class TPoint
    Public X, Y, Z As Double 'Store the x,y and z coord of this vertex as well as its index number
    Public W As Integer

    Public Sub New()
        X = 0.00
        Y = 0.00
        Z = 0.00
        W = 1
    End Sub

    Public Sub New(ByVal X As Double, ByVal Y As Double, ByVal Z As Double)
        Me.X = X
        Me.Y = Y
        Me.Z = Z
        W = 1
    End Sub

    Public Sub SetCoordinates(ByVal X As Double, ByVal Y As Double, ByVal Z As Double, ByVal W As Integer)
        Me.X = X
        Me.Y = Y
        Me.Z = Z
        Me.W = W
    End Sub

End Class

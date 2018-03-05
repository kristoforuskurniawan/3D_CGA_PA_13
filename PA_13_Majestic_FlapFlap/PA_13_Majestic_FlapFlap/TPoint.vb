Public Class TPoint

    Public X, Y, Z As Integer 'Store the x,y and z coord of this vertex as well as its index number
    Public NextPoint As TPoint
    Public PointIndex As Integer = -1

    Public Sub New()
        Me.X = 0
        Me.Y = 0
        Me.Z = 0
        Me.PointIndex = 0
        Me.NextPoint = Nothing
    End Sub

    Public Sub New(X As Integer, Y As Integer, Z As Integer)
        Me.X = X
        Me.Y = Y
        Me.Z = Z
        Me.PointIndex = 0
        Me.NextPoint = Nothing
    End Sub

    Public Sub SetCoordinates(ByVal X As Integer, ByVal Y As Integer, ByVal Z As Integer) 'Method to set coordinates
        Me.X = X
        Me.Y = Y
        Me.Z = Z
    End Sub

    'Public Function Insert(ByRef InsertedPoint As TPoint, ByVal X As Integer, ByVal Y As Integer, ByVal Z As Integer) As TPoint 'Method to insert new point
    '    If (InsertedPoint Is Nothing) Then
    '        InsertedPoint = New TPoint()
    '        InsertedPoint.PointIndex = 1
    '        InsertedPoint.SetCoordinates(X, Y, Z)
    '    Else
    '        InsertedPoint.PointIndex = InsertedPoint.PointIndex + 1
    '        Insert(InsertedPoint.NextPoint, X, Y, Z)
    '    End If
    '    Return InsertedPoint
    'End Function

End Class

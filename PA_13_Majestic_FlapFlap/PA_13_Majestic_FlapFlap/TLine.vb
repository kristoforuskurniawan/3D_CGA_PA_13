Public Class TLine ' Line is a pair of points
    Public Points(2) As TPoint

    Public Sub New() 'Default constructor
        Points(0) = New TPoint()
        Points(1) = New TPoint()
    End Sub

    Public Sub New(ByRef Point1 As TPoint, ByRef Point2 As TPoint) 'Overload constructor 1
        Points(0) = Point1
        Points(1) = Point2
    End Sub

    Public Sub New(ByRef Points() As TPoint) 'Overload constructor 2
        Me.Points(0) = Points(0)
        Me.Points(1) = Points(1)
    End Sub

    Public Sub SetPoints(ByRef Point1 As TPoint, ByRef Point2 As TPoint)
        Points(0) = Point1
        Points(1) = Point2
    End Sub

End Class

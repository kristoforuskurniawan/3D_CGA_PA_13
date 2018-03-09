Public Class Matrix4x4
    Public Mat(4, 4) As Double
    Public nxt As Matrix4x4

    Public Sub New()
        IdentityMat()
        nxt = Nothing
    End Sub

    Public Sub ScaleMat(x As Double, y As Double, z As Double)
        Mat(0, 0) = x
        Mat(1, 1) = y
        Mat(2, 2) = z
    End Sub

    Public Sub MultiplyMatrix4x4(Mat2(,) As Double)
        Dim temp(4, 4) As Double
        For i As Integer = 0 To 3
            For j As Integer = 0 To 3
                temp(i, j) = Mat(i, 0) * Mat2(0, j) + Mat(i, 1) * Mat2(1, j) + Mat(i, 2) * Mat2(2, j) + Mat(i, 3) * Mat2(2, j)
            Next
        Next
        Mat = temp
    End Sub

    Public Sub TransMat(x As Double, y As Double, z As Double)
        Mat(3, 0) = x
        Mat(3, 1) = y
        Mat(3, 2) = z
    End Sub

    Public Sub ShearMat(x As Double, y As Double)
        Mat(2, 0) = x
        Mat(2, 1) = y
    End Sub

    Public Sub RotateX(x As Double, y As Double)

    End Sub

    Public Sub RotateY(x As Double, y As Double)

    End Sub

    Public Sub RotateZ(x As Double, y As Double)

    End Sub

    Public Sub IdentityMat()
        For i As Integer = 0 To 3
            For j As Integer = 0 To 3
                If i = j Then
                    Mat(i, j) = 1
                Else
                    Mat(i, j) = 0
                End If
            Next
        Next
    End Sub
End Class

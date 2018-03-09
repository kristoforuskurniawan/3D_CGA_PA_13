Public Class Matrix4x4
    Public Mat(4, 4) As Double

    Public Sub New()
        IdentityMat()
    End Sub

    Public Sub ScaleMat(x As Double, y As Double, z As Double)
        Dim temp As New Matrix4x4
        temp.Mat(0, 0) = x
        temp.Mat(1, 1) = y
        temp.Mat(2, 2) = z
        MultiplyMatrix4x4(temp)
    End Sub

    Public Sub TranslateMat(x As Double, y As Double, z As Double)
        Dim temp As New Matrix4x4
        temp.Mat(3, 0) = x
        temp.Mat(3, 1) = y
        temp.Mat(3, 2) = z
        MultiplyMatrix4x4(temp)
    End Sub

    Public Sub T1(x As Double, y As Double, z As Double, x1 As Double, y2 As Double, z3 As Double)
        Dim temp As New Matrix4x4
        temp.Mat(0, 0) = x
        temp.Mat(1, 1) = y
        temp.Mat(2, 2) = z
        temp.Mat(3, 0) = x1
        temp.Mat(3, 1) = y2
        temp.Mat(3, 2) = z3
        MultiplyMatrix4x4(temp)
    End Sub

    Public Sub AxoProjection(omega As Double, tetha As Double)
        Dim temp As New Matrix4x4
        temp.Mat(0, 0) = CosTetha(omega)
        temp.Mat(0, 1) = SinTetha(omega) * SinTetha(tetha)
        temp.Mat(1, 1) = CosTetha(tetha)
        temp.Mat(2, 0) = SinTetha(omega)
        temp.Mat(2, 1) = -CosTetha(omega) * SinTetha(tetha)
        temp.Mat(2, 2) = 0
        MultiplyMatrix4x4(temp)
    End Sub

    Public Sub ObliqueProjection(omega As Double, alpha As Double)
        Dim temp As New Matrix4x4
        temp.Mat(2, 0) = CotTetha(omega) * CosTetha(alpha)
        temp.Mat(2, 1) = CotTetha(omega) * SinTetha(alpha)
        temp.Mat(2, 2) = 0
        MultiplyMatrix4x4(temp)
    End Sub

    Public Sub ShearMat(x As Double, y As Double)
        Dim temp As New Matrix4x4
        temp.Mat(2, 0) = x
        temp.Mat(2, 1) = y
        MultiplyMatrix4x4(temp)
    End Sub

    Public Sub OnePointProjection(c As Double)
        Dim temp As New Matrix4x4
        temp.Mat(2, 0) = 0.5
        temp.Mat(2, 1) = 0.5
        temp.Mat(2, 2) = 0
        '     temp.Mat(2, 3) = (-1 / c)
        MultiplyMatrix4x4(temp)
    End Sub

    Public Sub Rotation(axis As Integer, angle As Double)
        Dim temp As New Matrix4x4
        If axis = 1 Then
            temp.RotateX(angle)
        ElseIf axis = 2 Then
            temp.RotateY(angle)
        ElseIf axis = 3 Then
            temp.RotateZ(angle)
        Else
            'identity
        End If
        MultiplyMatrix4x4(temp)
    End Sub

    Public Sub RotateX(x As Double)
        Dim temp As New Matrix4x4
        temp.Mat(1, 1) = CosTetha(x)
        temp.Mat(1, 2) = SinTetha(x)
        temp.Mat(2, 1) = -SinTetha(x)
        temp.Mat(2, 2) = CosTetha(x)
        MultiplyMatrix4x4(temp)
    End Sub

    Public Sub RotateY(x As Double)
        Dim temp As New Matrix4x4
        temp.Mat(0, 0) = CosTetha(x)
        temp.Mat(0, 2) = -SinTetha(x)
        temp.Mat(2, 0) = SinTetha(x)
        temp.Mat(2, 2) = CosTetha(x)
        MultiplyMatrix4x4(temp)
    End Sub

    Public Sub RotateZ(x As Double)
        Dim temp As New Matrix4x4
        temp.Mat(0, 0) = CosTetha(x)
        temp.Mat(0, 1) = SinTetha(x)
        temp.Mat(1, 0) = -SinTetha(x)
        temp.Mat(1, 1) = CosTetha(x)
        MultiplyMatrix4x4(temp)
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

    Public Sub MultiplyMatrix4x4(M2 As Matrix4x4) 'Multiply to ownself
        Dim temp(4, 4) As Double
        For j = 0 To 3
            For i = 0 To 3
                temp(j, i) = Mat(j, 0) * M2.Mat(0, i) + Mat(j, 1) * M2.Mat(1, i) + Mat(j, 2) * M2.Mat(2, i) + Mat(j, 3) * M2.Mat(3, i)
            Next
        Next
        Mat = temp
    End Sub
End Class

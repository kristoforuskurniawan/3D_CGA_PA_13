Module Main

    Structure TVector
        Dim x, y, z As Double
    End Structure

    Structure UVN
        Dim u, v, n As TVector
    End Structure



    Sub SetVector(ByRef V As TVector, x As Double, y As Double, z As Double)
        V.x = x
        V.y = y
        V.z = z
    End Sub

    Sub SetUVN(ByRef UVN As UVN, U As TVector, V As TVector, N As TVector)
        UVN.u = U
        UVN.v = V
        UVN.n = N
    End Sub

    Function dot(A As TVector, B As TVector)
        Dim temp As Double
        temp = (A.x * B.x) + (A.y * B.y) + (A.z * B.z)
        Return temp
    End Function

    'Function MultiplyMat(point As TPoint, M(,) As Double) As TPoint
    ' Dim result As TPoint
    'Dim w As Single
    'w = (point.X * M(0, 3) + point.Y * M(1, 3) + point.Z * M(2, 3) + point.w * M(3, 3))
    'result.X = (point.X * M(0, 0) + point.Y * M(1, 0) + point.Z * M(2, 0) + point.w * M(3, 0)) / w
    'result.Y = (point.X * M(0, 1) + point.Y * M(1, 1) + point.Z * M(2, 1) + point.w * M(3, 1)) / w
    'result.Z = (point.X * M(0, 2) + point.Y * M(1, 2) + point.Z * M(2, 2) + point.w * M(3, 2)) / w
    'result.w = 1
    'Return result
    ' End Function

    Function MultiplyMat(A(,) As Double, B(,) As Double)
        Dim temp(3, 3) As Double

        For j = 0 To 3
            For i = 0 To 3
                temp(j, i) = A(j, 0) * B(0, i) + A(j, 1) * B(1, i) + A(j, 2) * B(2, i) + A(j, 3) * B(3, i)
            Next
        Next
        Return temp
    End Function
End Module

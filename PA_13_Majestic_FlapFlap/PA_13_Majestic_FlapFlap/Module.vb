Module Main
    Public Const PI As Double = 3.1415926535897931
    Public Const Sin45 As Double = 0.70710678118654757
    Public Const Cos30 As Double = 0.8660254037844386
    Public Const DegToRad As Double = PI / 180

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


    Function MultiplyPointMat(P As TPoint, M(,) As Double) As TPoint
        Dim temp As TPoint
        Dim vp As Double
        vp = P.X * M(0, 3) + P.Y * M(1, 3) + P.Z * M(2, 3) + P.w * M(3, 3)
        temp.X = (P.X * M(0, 0) + P.Y * M(1, 0) + P.Z * M(2, 0) + P.w * M(3, 0)) / vp
        temp.Y = (P.X * M(0, 1) + P.Y * M(1, 1) + P.Z * M(2, 1) + P.w * M(3, 1)) / vp
        temp.Z = (P.X * M(0, 2) + P.Y * M(1, 2) + P.Z * M(2, 2) + P.w * M(3, 2)) / vp
        temp.w = 1
        Return temp
    End Function

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

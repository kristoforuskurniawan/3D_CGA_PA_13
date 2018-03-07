Public Class Form1

    Dim PointList(100) As TPoint
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub MainCanvas_MouseOver(sender As Object, e As MouseEventArgs) Handles MainCanvas.MouseMove
        CoordinatesLabel.Text = "Coordinates: X = " + e.X.ToString() + ", Y = " + e.Y.ToString()
    End Sub

    Private Sub declare_all_object()
        Dim temp As New TPoint
        'Foot A
        temp.SetPoint(0, 0, 0, 0)
        temp.SetPoint(0, 0, 0, 1)
        temp.SetPoint(0, 0, 0, 2)
        temp.SetPoint(0, 0, 0, 3)
        temp.SetPoint(0, 0, 0, 4)
        temp.SetPoint(0, 0, 0, 5)
        temp.SetPoint(0, 0, 0, 6)
        temp.SetPoint(0, 0, 0, 7)
        'Foot B
        temp.SetPoint(0, 0, 0, 8)
        temp.SetPoint(0, 0, 0, 9)
        temp.SetPoint(0, 0, 0, 10)
        temp.SetPoint(0, 0, 0, 11)
        temp.SetPoint(0, 0, 0, 12)
        temp.SetPoint(0, 0, 0, 13)
        temp.SetPoint(0, 0, 0, 14)
        temp.SetPoint(0, 0, 0, 15)
        'Leg A
        temp.SetPoint(0, 0, 0, 16)
        temp.SetPoint(0, 0, 0, 17)
        temp.SetPoint(0, 0, 0, 18)
        temp.SetPoint(0, 0, 0, 19)
        temp.SetPoint(0, 0, 0, 20)
        temp.SetPoint(0, 0, 0, 21)
        temp.SetPoint(0, 0, 0, 22)
        temp.SetPoint(0, 0, 0, 23)
        'Leg B
        temp.SetPoint(0, 0, 0, 24)
        temp.SetPoint(0, 0, 0, 25)
        temp.SetPoint(0, 0, 0, 26)
        temp.SetPoint(0, 0, 0, 27)
        temp.SetPoint(0, 0, 0, 28)
        temp.SetPoint(0, 0, 0, 29)
        temp.SetPoint(0, 0, 0, 30)
        temp.SetPoint(0, 0, 0, 31)
        'Torso
        temp.SetPoint(0, 0, 0, 32)
        temp.SetPoint(0, 0, 0, 33)
        temp.SetPoint(0, 0, 0, 34)
        temp.SetPoint(0, 0, 0, 35)
        temp.SetPoint(0, 0, 0, 36)
        temp.SetPoint(0, 0, 0, 37)
        temp.SetPoint(0, 0, 0, 38)
        temp.SetPoint(0, 0, 0, 39)
        'Upper Wing A
        temp.SetPoint(0, 0, 0, 40)
        temp.SetPoint(0, 0, 0, 41)
        temp.SetPoint(0, 0, 0, 42)
        temp.SetPoint(0, 0, 0, 43)
        temp.SetPoint(0, 0, 0, 44)
        temp.SetPoint(0, 0, 0, 45)
        temp.SetPoint(0, 0, 0, 46)
        temp.SetPoint(0, 0, 0, 47)
        'Upper Wing B
        temp.SetPoint(0, 0, 0, 48)
        temp.SetPoint(0, 0, 0, 49)
        temp.SetPoint(0, 0, 0, 50)
        temp.SetPoint(0, 0, 0, 51)
        temp.SetPoint(0, 0, 0, 52)
        temp.SetPoint(0, 0, 0, 53)
        temp.SetPoint(0, 0, 0, 54)
        temp.SetPoint(0, 0, 0, 55)
        'Lower Wing A
        temp.SetPoint(0, 0, 0, 56)
        temp.SetPoint(0, 0, 0, 57)
        temp.SetPoint(0, 0, 0, 58)
        temp.SetPoint(0, 0, 0, 59)
        temp.SetPoint(0, 0, 0, 60)
        temp.SetPoint(0, 0, 0, 61)
        temp.SetPoint(0, 0, 0, 62)
        temp.SetPoint(0, 0, 0, 63)
        'Lower Wing B
        temp.SetPoint(0, 0, 0, 64)
        temp.SetPoint(0, 0, 0, 65)
        temp.SetPoint(0, 0, 0, 66)
        temp.SetPoint(0, 0, 0, 67)
        temp.SetPoint(0, 0, 0, 68)
        temp.SetPoint(0, 0, 0, 69)
        temp.SetPoint(0, 0, 0, 70)
        temp.SetPoint(0, 0, 0, 71)
        'Neck
        temp.SetPoint(0, 0, 0, 72)
        temp.SetPoint(0, 0, 0, 73)
        temp.SetPoint(0, 0, 0, 74)
        temp.SetPoint(0, 0, 0, 75)
        temp.SetPoint(0, 0, 0, 76)
        temp.SetPoint(0, 0, 0, 77)
        temp.SetPoint(0, 0, 0, 78)
        temp.SetPoint(0, 0, 0, 79)
        'Head
        temp.SetPoint(0, 0, 0, 80)
        temp.SetPoint(0, 0, 0, 81)
        temp.SetPoint(0, 0, 0, 82)
        temp.SetPoint(0, 0, 0, 83)
        temp.SetPoint(0, 0, 0, 84)
        temp.SetPoint(0, 0, 0, 85)
        temp.SetPoint(0, 0, 0, 86)
        temp.SetPoint(0, 0, 0, 87)
        'Beak
        temp.SetPoint(0, 0, 0, 88)
        temp.SetPoint(0, 0, 0, 89)
        temp.SetPoint(0, 0, 0, 90)
        temp.SetPoint(0, 0, 0, 91)
        temp.SetPoint(0, 0, 0, 92)
        temp.SetPoint(0, 0, 0, 93)
        temp.SetPoint(0, 0, 0, 94)
        temp.SetPoint(0, 0, 0, 95)

    End Sub




    Function MultiplyMat(point As TPoint, M(,) As Double) As TPoint
        Dim result As TPoint
        Dim w As Single
        w = (point.X * M(0, 3) + point.Y * M(1, 3) + point.Z * M(2, 3) + point.w * M(3, 3))
        result.X = (point.X * M(0, 0) + point.Y * M(1, 0) + point.Z * M(2, 0) + point.w * M(3, 0)) / w
        result.Y = (point.X * M(0, 1) + point.Y * M(1, 1) + point.Z * M(2, 1) + point.w * M(3, 1)) / w
        result.Z = (point.X * M(0, 2) + point.Y * M(1, 2) + point.Z * M(2, 2) + point.w * M(3, 2)) / w
        result.w = 1
        Return result
    End Function

    Private Sub Projection()
        'P' = P Wt Vt St
        'P => object
        'P'=> projection
        Dim Wt(4, 4) As Double 'World
        FillRow(0, 1, 0, 0, 0, Wt)
        FillRow(1, 0, 1, 0, 0, Wt)
        FillRow(2, 0, 0, 1, 0, Wt)
        FillRow(3, 0, 0, 0, 1, Wt)
        Dim Vt(4, 4) As Double 'Vt
        FillRow(0, 1, 0, 0, 0, Vt)
        FillRow(1, 0, 1, 0, 0, Vt)
        FillRow(2, 0, 0, 1, 0, Vt)
        FillRow(3, 0, 0, 0, 1, Vt)
        Dim St(4, 4) As Double 'St
        FillRow(0, 50, 0, 0, 300, St)
        FillRow(1, 0, -50, 0, 180, St)
        FillRow(2, 0, 0, 0, 0, St)
        FillRow(3, 0, 0, 0, 1, St)

    End Sub

    Private Sub FillRow(row As Integer, x As Double, y As Double, z As Double, w As Double, ByRef M(,) As Double)
        M(row, 0) = x
        M(row, 1) = y
        M(row, 2) = z
        M(row, 3) = w
    End Sub

End Class

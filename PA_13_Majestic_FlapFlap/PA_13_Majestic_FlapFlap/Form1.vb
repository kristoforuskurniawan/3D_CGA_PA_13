Public Class Form1

    'Gimana kalau deklarasi object di Form1 cukup punya Cuboid aja? Sisanya di dalam class cuboid

    Private BitmapCanvas As Bitmap
    Private G As Graphics
    Private Vertices As TPoint
    Private Edges As TLine
    Private TriMesh As TPolygon
    Private CubeSurface As TSurface
    Private Cuboid As PolygonMesh_Cuboid
    Private M(,), Wt(,), Vt(,), St(,), TrMat(,), ViewScreen(,) As Double

    Private Test_CubePoint(8) As TPoint
    Private Test_CubeLine(12) As TLine
    Private Zc As Double = -10.0 'Vanishing Point

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Vertices = New TPoint()
        Edges = New TLine()
        TriMesh = New TPolygon()
        CubeSurface = New TSurface()
        Cuboid = New PolygonMesh_Cuboid()

        BitmapCanvas = New Bitmap(MainCanvas.Width, MainCanvas.Height)
        G = CreateGraphics()
        G = Graphics.FromImage(BitmapCanvas)
        MainCanvas.Image = BitmapCanvas

        M = New Double(4, 4) {}
        Wt = New Double(4, 4) {}
        Vt = New Double(4, 4) {}
        St = New Double(4, 4) {}
        TrMat = New Double(4, 4) {}
        ViewScreen = New Double(4, 4) {}

        InitProjection()

        For i = 0 To 7
            Test_CubePoint(i) = New TPoint()
        Next

        For i = 0 To 11
            Test_CubeLine(i) = New TLine() 'Inside the class TLine, all TPoint are already instantiated (objectnya udah dibuat)
        Next
        InitCube()
        DrawCube()
    End Sub

    Private Sub MainCanvas_MouseOver(sender As Object, e As MouseEventArgs) Handles MainCanvas.MouseMove
        CoordinatesLabel.Text = "Coordinates: X = " + e.X.ToString() + ", Y = " + e.Y.ToString()
    End Sub

    Private Sub InitCube()

        Test_CubePoint(0).SetCoordinates(-10, -10, -10, 1)
        Test_CubePoint(1).SetCoordinates(-10, -10, 10, 1)
        Test_CubePoint(2).SetCoordinates(-10, 10, 10, 1)
        Test_CubePoint(3).SetCoordinates(-10, 10, -10, 1)
        Test_CubePoint(4).SetCoordinates(10, -10, -10, 1)
        Test_CubePoint(5).SetCoordinates(10, -10, 10, 1)
        Test_CubePoint(6).SetCoordinates(10, 10, -10, 1)
        Test_CubePoint(7).SetCoordinates(10, 10, 10, 1)

        Test_CubeLine(0).Points(0) = Test_CubePoint(0)
        Test_CubeLine(0).Points(1) = Test_CubePoint(1)
        Test_CubeLine(1).Points(0) = Test_CubePoint(2)
        Test_CubeLine(1).Points(1) = Test_CubePoint(3)
        Test_CubeLine(2).Points(0) = Test_CubePoint(4)
        Test_CubeLine(2).Points(1) = Test_CubePoint(5)
        Test_CubeLine(3).Points(0) = Test_CubePoint(6)
        Test_CubeLine(3).Points(1) = Test_CubePoint(7)
        Test_CubeLine(4).Points(0) = Test_CubePoint(0)
        Test_CubeLine(4).Points(1) = Test_CubePoint(4)
        Test_CubeLine(5).Points(0) = Test_CubePoint(0)
        Test_CubeLine(5).Points(1) = Test_CubePoint(1)
        Test_CubeLine(6).Points(0) = Test_CubePoint(5)
        Test_CubeLine(6).Points(1) = Test_CubePoint(2)
        Test_CubeLine(7).Points(0) = Test_CubePoint(7)
        Test_CubeLine(7).Points(1) = Test_CubePoint(3)
        Test_CubeLine(8).Points(0) = Test_CubePoint(6)
        Test_CubeLine(8).Points(1) = Test_CubePoint(0)
        Test_CubeLine(9).Points(0) = Test_CubePoint(2)
        Test_CubeLine(9).Points(1) = Test_CubePoint(0)
        Test_CubeLine(10).Points(0) = Test_CubePoint(0)
        Test_CubeLine(10).Points(1) = Test_CubePoint(0)
        Test_CubeLine(11).Points(0) = Test_CubePoint(0)
        Test_CubeLine(11).Points(1) = Test_CubePoint(0)

        'temp.SetPoint(0, 0, 0, 32)
        'temp.SetPoint(0, 0, 0, 33)
        'temp.SetPoint(0, 0, 0, 34)
        'temp.SetPoint(0, 0, 0, 35)
        'temp.SetPoint(0, 0, 0, 36)
        'temp.SetPoint(0, 0, 0, 37)
        'temp.SetPoint(0, 0, 0, 38)
        'temp.SetPoint(0, 0, 0, 39)

        'Dim Current As Integer = 32

        'For i = 0 To 11 'Initialize cube coordinate to be like above's example
        '    If Current Mod 2 = 0 Then '32, 34, 36 etc
        '        Test_CubeLine(i).Points(0).SetCoordinates(0, 0, 0, Current)
        '    Else
        '        Test_CubeLine(i).Points(1).SetCoordinates(0, 0, 0, Current)
        '    End If
        '    Current += 1
        'Next

        'For i = 0 To 11
        '    MessageBox.Show("Point 1 x: " & Test_CubeLine(i).Points(0).X & vbNewLine &
        '                    "Point 1 y: " & Test_CubeLine(i).Points(0).Y & vbNewLine &
        '                    "Point 2 x: " & Test_CubeLine(i).Points(1).X & vbNewLine &
        '                    "Point 2 y: " & Test_CubeLine(i).Points(1).Y & vbNewLine)
        'Next

    End Sub

    Private Sub declare_all_object()

    End Sub

    Private Sub MainCanvas_Click(sender As Object, e As EventArgs) Handles MainCanvas.Click

    End Sub

    'Private Sub Perspective(x As Double, y As Double, z As Double)
    '    If x = 0 Then
    '        x = 0
    '    Else
    '        x = 1.0 / x
    '    End If
    '    If y = 0 Then
    '        y = 0
    '    Else
    '        y = 1.0 / y
    '    End If
    '    If z = 0 Then
    '        z = 0
    '    Else
    '        z = 1.0 / z
    '    End If
    '    SetColMat(Trans, 0, 1, 0, 0, 0)
    '    SetColMat(Trans, 1, 0, 1, 0, 0)
    '    SetColMat(Trans, 2, 0, 0, 1, 0)
    '    SetColMat(Trans, 3, x, y, z, 1)
    'End Sub

    'Sub InitCube()
    '    SetPoint(V(0), -1, -1, 1)
    '    SetPoint(V(1), 1, -1, 1)
    '    SetPoint(V(2), 1, 1, 1)
    '    SetPoint(V(3), -1, 1, 1)
    '    SetPoint(V(4), -1, -1, -1)
    '    SetPoint(V(5), 1, -1, -1)
    '    SetPoint(V(6), 1, 1, -1)
    '    SetPoint(V(7), -1, 1, -1)
    'End Sub

    Private Sub DrawCube()
        Dim j As Integer
        Dim x1, y1, x2, y2 As Single

        For j = 0 To 11
            x1 = Test_CubeLine(j).Points(0).X
            y1 = Test_CubeLine(j).Points(0).Y
            x2 = Test_CubeLine(j).Points(1).X
            y2 = Test_CubeLine(j).Points(1).Y
            G.DrawLine(Pens.Black, x1, y1, x2, y2)
        Next
        MainCanvas.Image = BitmapCanvas
    End Sub

    Private Sub DrawChickenButton_Click(sender As Object, e As EventArgs) Handles DrawChickenButton.Click
        Dim Result As New TPoint()

        DrawCube()
    End Sub

    Function MultiplyMat(point As TPoint, M(,) As Double) As TPoint
        Dim Result As New TPoint()
        Dim W As Single
        W = (point.X * M(0, 3) + point.Y * M(1, 3) + point.Z * M(2, 3) + point.W * M(3, 3))
        Result.X = (point.X * M(0, 0) + point.Y * M(1, 0) + point.Z * M(2, 0) + point.W * M(3, 0)) / W
        Result.Y = (point.X * M(0, 1) + point.Y * M(1, 1) + point.Z * M(2, 1) + point.W * M(3, 1)) / W
        Result.Z = (point.X * M(0, 2) + point.Y * M(1, 2) + point.Z * M(2, 2) + point.W * M(3, 2)) / W
        Result.W = 1
        Return Result
    End Function

    Private Sub InitProjection()
        ' P' = P.Wt.Vt.St
        ' P -> object
        ' P'-> projection

        'Wt (Wolrd)
        FillRow(0, 1, 0, 0, 0, Wt)
        FillRow(1, 0, 1, 0, 0, Wt)
        FillRow(2, 0, 0, 1, 0, Wt)
        FillRow(3, 0, 0, 0, 1, Wt)

        'Vt (View) -> Use projection matrix
        FillRow(0, 1, 0, 0, 0, Vt)
        FillRow(1, 0, 1, 0, 0, Vt)
        FillRow(2, 0, 0, 0, -1 / Zc, Vt)
        FillRow(3, 3, 0, 0, 1, Vt)

        'St (Screen)
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

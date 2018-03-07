Public Class Form1

    'Gimana kalau deklarasi object di Form1 cukup punya Cuboid aja? Sisanya di dalam class cuboid

    Private BitmapCanvas As Bitmap
    Private G As Graphics
    Private Vertices As TPoint
    Private Edges As TLine
    Private TriMesh As TPolygon
    Private CubeSurface As TSurface
    Private Cuboid As PolygonMesh_Cuboid
    Private M(,), Wt(,), Vt(,), St(,) As Double

    'Private Test_CubePoint As TPoint
    Private Test_CubeLine(12) As TLine

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

        'Test_CubePoint = New List(Of TPoint)
        Test_CubeLine = New TLine(11) {}
    End Sub

    Private Sub MainCanvas_MouseOver(sender As Object, e As MouseEventArgs) Handles MainCanvas.MouseMove
        CoordinatesLabel.Text = "Coordinates: X = " + e.X.ToString() + ", Y = " + e.Y.ToString()
    End Sub

    Private Sub InitCube()

        For i = 0 To 11
            Test_CubeLine(i).Points = New TPoint(2) {} 'Initialize array of TPoint
        Next



    End Sub

    Private Sub declare_all_object()

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

    'Sub DrawCube()
    '    Dim i, j As Integer
    '    For j = 0 To 3
    '        G.DrawLine(Pens.Red, VS(Edge(j).p1).x, VS(Edge(j).p1).y, VS(Edge(j).p2).x, VS(Edge(j).p2).y)
    '    Next
    '    For i = 4 To 11
    '        G.DrawLine(Pens.Black, VS(Edge(i).p1).x, VS(Edge(i).p1).y, VS(Edge(i).p2).x, VS(Edge(i).p2).y)
    '    Next
    '    MainCanvas.Image = BitmapCanvas
    'End Sub

    Private Sub DrawChickenButton_Click(sender As Object, e As EventArgs) Handles DrawChickenButton.Click
        'DrawCube()
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

    Private Sub Projection()
        ' P' = P.Wt.Vt.St
        ' P -> object
        ' P'-> projection

        'World
        FillRow(0, 1, 0, 0, 0, Wt)
        FillRow(1, 0, 1, 0, 0, Wt)
        FillRow(2, 0, 0, 1, 0, Wt)
        FillRow(3, 0, 0, 0, 1, Wt)

        'Vt
        FillRow(0, 1, 0, 0, 0, Vt)
        FillRow(1, 0, 1, 0, 0, Vt)
        FillRow(2, 0, 0, 0, 0, Vt)
        FillRow(3, 0, 0, 0, 1, Vt)

        'St
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

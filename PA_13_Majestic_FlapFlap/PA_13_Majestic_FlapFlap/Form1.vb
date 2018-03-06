Public Class Form1

    Private BitmapCanvas As Bitmap
    Private G As Graphics
    Private Vertices As TPoint
    Private Edges As TLine
    Private TriMesh As TPolygon
    Private CubeSurface As TSurface
    Private Cuboid As PolygonMesh_Cuboid
    Private M(,), Wt(,), Vt(,), St(,) As Double

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
    End Sub

    Private Sub MainCanvas_MouseOver(sender As Object, e As MouseEventArgs) Handles MainCanvas.MouseMove
        CoordinatesLabel.Text = "Coordinates: X = " + e.X.ToString() + ", Y = " + e.Y.ToString()
    End Sub

    Private Sub InitChicken()

    End Sub

    Private Sub declare_all_object()

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
        Dim Wt(4, 4) As Double 'World
        FillRow(0, 1, 0, 0, 0, Wt)
        FillRow(1, 0, 1, 0, 0, Wt)
        FillRow(2, 0, 0, 1, 0, Wt)
        FillRow(3, 0, 0, 0, 1, Wt)
        Dim Vt(4, 4) As Double 'Vt
        FillRow(0, 1, 0, 0, 0, Vt)
        FillRow(1, 0, 1, 0, 0, Vt)
        FillRow(2, 0, 0, 0, 0, Vt)
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

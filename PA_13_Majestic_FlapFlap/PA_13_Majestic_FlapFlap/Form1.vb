Public Class Form1

    Private bitmapCanvas As Bitmap
    Private graphics As Graphics
    'Private Vertices As TPoint = Nothing
    'Private Edges As TLine = Nothing
    'Private Polygon As TPolygon = Nothing
    'Private Cuboid_Surface As TSurface = Nothing
    'Private Cuboid As PolygonMesh_Cuboid = Nothing

    Private CubeVertices As List(Of Point) 'Pakai built-in List(Of T) biar ga ribet. Fok off class
    Private CubeEdges As List(Of Integer) 'Index of CubeVertices
    Private Poly As List(Of Integer) 'Index of CubeEdges
    Private Surface As List(Of Integer) 'Index of Poly
    Private CuboidShape As List(Of Integer) 'Index of Surface

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Vertices = Nothing
        'Edges = Nothing
        'Polygon = Nothing
        'Cuboid_Surface = Nothing
        'Cuboid = Nothing

        bitmapCanvas = New Bitmap(MainCanvas.Width, MainCanvas.Height)
        graphics = CreateGraphics()
        graphics = Graphics.FromImage(bitmapCanvas)
        MainCanvas.Image = bitmapCanvas

        CubeVertices = New List(Of Point)
        CubeEdges = New List(Of Integer)
        Poly = New List(Of Integer)
        Surface = New List(Of Integer)
        CuboidShape = New List(Of Integer)

    End Sub

    Private Sub MainCanvas_MouseOver(sender As Object, e As MouseEventArgs) Handles MainCanvas.MouseMove
        CoordinatesLabel.Text = "Coordinates: X = " + e.X.ToString() + ", Y = " + e.Y.ToString()
    End Sub

    Private Sub MatrixMultiplication_4x4(Matrix_A()()()() As Integer, Matrix_B()()()() As Integer) 'Is this required or is there any built-in library for 4x4 multiplication matrix?

    End Sub

    Private Sub MainCanvas_Click(sender As Object, e As MouseEventArgs) Handles MainCanvas.Click
        CubeVertices.Add(New Point(e.X, e.Y))
        graphics.DrawEllipse(Pens.Black, e.X, e.Y, 10, 10)
        MainCanvas.Image = bitmapCanvas
        'For i = 0 To CubeVertices.Count - 1
        '    MessageBox.Show(CubeVertices(i).X & ", " & CubeVertices(i).Y)
        'Next
        'Vertices = Insert(Vertices, e.X, e.Y, 0)
        'While (Vertices IsNot Nothing)
        '    MessageBox.Show(Vertices.X & " with index " & Vertices.PointIndex.ToString())
        '    Vertices = Vertices.NextPoint
        'End While
    End Sub
End Class
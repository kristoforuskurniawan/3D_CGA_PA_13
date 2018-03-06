Public Class Form1

    Private bitmapCanvas As Bitmap
    Private graphics As Graphics
    Private Vertices As List(Of TPoint)
    Private Edges As List(Of TLine)
    Private Polygon As List(Of TPolygon)
    Private Cuboid_Surface As TSurface
    Private Cuboid As PolygonMesh_Cuboid
    Private ProjectionMatrix()() As Integer
    Private PerspectiveProjection()() As Integer

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Vertices = Nothing
        Edges = Nothing
        Polygon = Nothing
        Cuboid_Surface = Nothing
        Cuboid = Nothing

        InitProjectionMatrix(ProjectionMatrix)

        bitmapCanvas = New Bitmap(MainCanvas.Width, MainCanvas.Height)
        graphics = CreateGraphics()
        graphics = Graphics.FromImage(bitmapCanvas)
        MainCanvas.Image = bitmapCanvas

    End Sub

    Private Sub InitProjectionMatrix(ByRef pm()() As Integer)
        For i = 0 To 4 'Initialize projection matrix
            For j = 0 To 4
                If j = i And j <> 2 Then
                    pm(i)(j) = 1
                Else
                    pm(i)(j) = 0
                End If
            Next
        Next
    End Sub

    Private Sub InitPerspectiveMatrix(ByRef persM()() As Integer)
        For i = 0 To 4
            For j = 0 To 4
                If j = 3 And i = 2 Then
                    'persM(i)(j) = This is the -1/Zc
                ElseIf j = i Then
                    persM(i)(j) = 1
                Else
                    persM(i)(j) = 0
                End If
            Next
        Next
    End Sub

    Private Sub MainCanvas_MouseOver(sender As Object, e As MouseEventArgs) Handles MainCanvas.MouseMove
        CoordinatesLabel.Text = "Coordinates: X = " + e.X.ToString() + ", Y = " + e.Y.ToString()
    End Sub

    Private Sub MatrixMultiplication_4x4(Matrix_A()()()() As Integer, Matrix_B()()()() As Integer) 'Is this required or is there any built-in library for 4x4 multiplication matrix?

    End Sub

    Private Sub DrawCube(ByRef VerticesList As List(Of Point), ByRef EdgesList As List(Of Integer))

    End Sub

    Private Sub MainCanvas_Click(sender As Object, e As MouseEventArgs) Handles MainCanvas.Click

    End Sub
End Class
Public Class Form1
    Private bitmapCanvas As Bitmap
    Private graphics As Graphics
    Private Vertices As List(Of TPoint) 'So that it can store multiple points
    Private Edges As List(Of TLine) 'Helps to store multiple edges -> How do I store index of Vertices here to reduce redundancy?
    Private Polygon As List(Of TPolygon)
    Private Cuboid_Surface As TSurface
    Private Cuboid As PolygonMesh_Cuboid
    Private ProjectionMatrix(,) As Integer
    Private PerspectiveProjection(,) As Integer

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Vertices = New List(Of TPoint)
        Edges = New List(Of TLine)
        Polygon = New List(Of TPolygon)
        Cuboid_Surface = New TSurface
        Cuboid = New PolygonMesh_Cuboid

        ProjectionMatrix = New Integer(4, 4) {} 'Yes this is a weird way to declare 2D Array xD
        PerspectiveProjection = New Integer(4, 4) {}
        InitProjectionMatrix(ProjectionMatrix)
        InitPerspectiveMatrix(PerspectiveProjection)

        bitmapCanvas = New Bitmap(MainCanvas.Width, MainCanvas.Height)
        graphics = CreateGraphics()
        graphics = Graphics.FromImage(bitmapCanvas)
        MainCanvas.Image = bitmapCanvas
    End Sub

    Private Sub InitProjectionMatrix(ByRef pm(,) As Integer) 'Initialize projection matrix that is to convert 3D coordinate system into 2D coordinate system
        For i = 0 To 4
            For j = 0 To 4
                If j = i And j <> 2 Then
                    pm(i, j) = 1
                Else
                    pm(i, j) = 0
                End If
            Next
        Next
    End Sub

    Private Sub InitPerspectiveMatrix(ByRef persM(,) As Integer) 'Initialize perspective matrix
        For i = 0 To 4
            For j = 0 To 4
                If j = 3 And i = 2 Then
                    persM(i, j) = -1
                ElseIf j = i Then
                    persM(i, j) = 1
                Else
                    persM(i, j) = 0
                End If
            Next
        Next
    End Sub

    Private Sub MainCanvas_MouseOver(sender As Object, e As MouseEventArgs) Handles MainCanvas.MouseMove
        CoordinatesLabel.Text = "Coordinates: X = " + e.X.ToString() + ", Y = " + e.Y.ToString()
    End Sub

    Private Sub MatrixMultiplication_4x4(Matrix_A()() As Integer, Matrix_B()() As Integer) 'Is this required or is there any built-in library for 4x4 multiplication matrix?
        For i = 0 To 4
            For j = 0 To 4

            Next
        Next
    End Sub

    Private Sub DrawCube(ByRef EdgesList As List(Of TLine)) 'Drawing is edge processing?
        'For i = 0 To EdgesList.Count - 1
        '    For j = 0 To 2
        '        MessageBox.Show(EdgesList(i).Points(j).X)
        '    Next
        'Next
    End Sub

    Private Sub MainCanvas_Click(sender As Object, e As MouseEventArgs) Handles MainCanvas.Click
        Cuboid.CuboidSurfaces(0).PolygonMesh(0).Line(0).Points(0).X = 0
    End Sub
End Class
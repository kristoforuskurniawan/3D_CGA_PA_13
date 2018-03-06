Public Class Form1

    ''' <summary>
    ''' P' = P.Wt.Vt.St, where:
    '''     P = 3D representation of object
    '''     P' = 2D view of object
    '''     Wt = Transformations required to put the object on the world scene(OCS to WCS)
    '''     Vt = Transformations required to view the object (WCS to VCS)
    '''     St = Transformations required to display the object on the screen (VCS to SCS)
    ''' </summary>

    Private bitmapCanvas As Bitmap
    Private graphics As Graphics
    Private Vertices As List(Of TPoint) 'So that it can store multiple points
    Private Edges As List(Of TLine) 'Helps to store multiple edges -> How do I store index of Vertices here to reduce redundancy?
    Private Polygon As List(Of TPolygon)
    Private Cuboid_Surface As TSurface
    Private Cuboid As PolygonMesh_Cuboid
    Private PR2_ProjectionMatrix(,) As Integer
    Private PR1_PerspectiveProjection(,) As Integer
    Private Vt(,) As Integer

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Vertices = New List(Of TPoint)
        Edges = New List(Of TLine)
        Polygon = New List(Of TPolygon)
        Cuboid_Surface = New TSurface
        Cuboid = New PolygonMesh_Cuboid

        PR2_ProjectionMatrix = New Integer(4, 4) {} 'Yes this is a weird way to declare 2D Array xD
        PR1_PerspectiveProjection = New Integer(4, 4) {}
        InitProjectionMatrix(PR2_ProjectionMatrix)
        InitPerspectiveMatrix(PR1_PerspectiveProjection)

        bitmapCanvas = New Bitmap(MainCanvas.Width, MainCanvas.Height)
        graphics = CreateGraphics()
        graphics = Graphics.FromImage(bitmapCanvas)
        MainCanvas.Image = bitmapCanvas
    End Sub

    Private Sub InitProjectionMatrix(ByRef pm(,) As Integer) 'Initialize projection matrix that is to convert 3D coordinate system into 2D coordinate system

        '1 0 0 0
        '0 1 0 0
        '0 0 0 0
        '0 0 0 1

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

        '1 0 0 0
        '0 1 0 0
        '0 0 1 -1/Zc
        '0 0 0 1

        For i = 0 To 4
            For j = 0 To 4
                If j = 3 And i = 2 Then
                    persM(i, j) = -1 'Zc hasn't included yet
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

    Private Sub MatrixMultiplication_4x4(ByRef Matrix_A(,) As Integer, ByRef Matrix_B(,) As Integer, ByRef OutputMatrix(,) As Integer) 'Is this required or is there any built-in library for 4x4 multiplication matrix?
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

    End Sub
End Class
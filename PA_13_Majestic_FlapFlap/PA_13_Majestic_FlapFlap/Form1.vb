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
    Private PR2_ProjectionMatrix(,), PR1_PerspectiveProjection(,), Vt(,) As Single

    Public Const PI As Double = 3.1415926535897931
    Public Const Sin45 As Double = 0.70710678118654757
    Public Const Cos30 As Double = 0.8660254037844386
    Public Const DegToRad As Double = PI / 180

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Vertices = New List(Of TPoint)
        Edges = New List(Of TLine)
        Polygon = New List(Of TPolygon)
        Cuboid_Surface = New TSurface
        Cuboid = New PolygonMesh_Cuboid

        PR2_ProjectionMatrix = New Single(4, 4) {}
        PR1_PerspectiveProjection = New Single(4, 4) {}
        InitProjectionMatrix(PR2_ProjectionMatrix)
        InitPerspectiveMatrix(PR1_PerspectiveProjection)

        bitmapCanvas = New Bitmap(MainCanvas.Width, MainCanvas.Height)
        graphics = CreateGraphics()
        graphics = Graphics.FromImage(bitmapCanvas)
        MainCanvas.Image = bitmapCanvas
    End Sub

    Private Sub InitProjectionMatrix(ByRef pm(,) As Single) 'Initialize projection matrix that is to convert 3D coordinate system into 2D coordinate system

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

    Private Sub InitPerspectiveMatrix(ByRef persM(,) As Single) 'Initialize perspective matrix

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

    'Private Function MatrixMultiplication_4x4(ByRef Point As TPoint, ByRef Matrix_B(,) As Single) As TPoint 'Is this required or is there any built-in library for 4x4 multiplication matrix?

    '    Return Point
    'End Function

    'Function MultiplyMat(P As TPoint, M(,) As Single) As TPoint 'Matrix multiplication function.
    '    Dim tmp As TPoint
    '    Dim w As Single
    '    w = (P.X * M(0, 3) + P.Y * M(1, 3) + P.Z * M(2, 3) + P.W * M(3, 3))
    '    tmp.X = (P.X * M(0, 0) + P.Y * M(1, 0) + P.Z * M(2, 0) + P.W * M(3, 0)) / w
    '    tmp.Y = (P.X * M(0, 1) + P.Y * M(1, 1) + P.Z * M(2, 1) + P.W * M(3, 1)) / w
    '    tmp.Z = (P.X * M(0, 2) + P.Y * M(1, 2) + P.Z * M(2, 2) + P.W * M(3, 2)) / w
    '    tmp.W = 1
    '    Return tmp
    'End Function

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
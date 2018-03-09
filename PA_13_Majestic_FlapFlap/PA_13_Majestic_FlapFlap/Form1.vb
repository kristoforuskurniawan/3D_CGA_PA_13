Public Class Form1
    Dim bit As Bitmap
    Dim g As Graphics
    Dim blackPen As Pen
    Dim VerticesList(32) As TPoint
    Dim EdgeList(48) As TLine
    Dim ObjectList(4) As Model3D
    Dim Wt(4, 4), Vt(4, 4), St(4, 4) As Double
    Dim Scale(4, 4), Translate(4, 4), RotateZ(4, 4), ShearX(4, 4), ShearY(4, 4) As Double

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        blackPen = New Pen(Color.Black, 1)
        bit = New Bitmap(MainCanvas.Width, MainCanvas.Height)
        EdgeList = New TLine(48) {}
        g = Graphics.FromImage(bit)
        drawChicken()
    End Sub

    Public Sub SetPoint(ByRef obj As TPoint, a As Double, b As Double, c As Double, d As Integer)
        obj = New TPoint
        obj.X = a
        obj.Y = b
        obj.Z = c
        obj.w = 1
        obj.PointIndex = d
    End Sub

    Public Sub drawChicken()
        drawTorso()
        drawNeck()
        drawHead()
        drawBeak()
        drawLowerWings()
    End Sub

    Public Sub drawTorso()
        declare_all_object()
        Projection()
        MultiMat()
        DrawCube()
    End Sub

    Public Sub drawNeck()
        declare_all_object()
        ScalingNeck()
        RotateAroundZNeck()
        TranslatingNeck()
        Projection()
        getNeck()
        DrawCube()
    End Sub

    Public Sub drawHead()
        declare_all_object()
        ScalingHead()
        TranslatingHead()
        Projection()
        getHead()
        DrawCube()
    End Sub

    Public Sub drawBeak()
        declare_all_object()
        ScalingBeak()
        TranslatingBeak()
        Projection()
        getBeak()
        DrawCube()
    End Sub

    Public Sub drawLowerWings()
        declare_all_object()
        ShearLowerWings()
        ScalingLowerWings()
        TranslatingLowerWings()
        Projection()
        getLowerWings()
        DrawCube()
    End Sub

    Public Sub drawUpperWings() 'Still created
        declare_all_object()
        'ScalingUpperWings()
        'TranslatingUpperWings()
        Projection()
        'getUpperWings()
        DrawCube()
    End Sub

    Public Sub DrawCube()
        Dim a, b, c, d As Single
        For i As Integer = 0 To 11
            a = VerticesList(EdgeList(i).PointA).X
            b = VerticesList(EdgeList(i).PointA).Y
            c = VerticesList(EdgeList(i).PointB).X
            d = VerticesList(EdgeList(i).PointB).Y
            g.DrawLine(blackPen, a, b, c, d)
        Next
        MainCanvas.Image = bit
    End Sub

    Public Sub MultiMat()
        For i As Integer = 0 To 7
            VerticesList(i) = MultiplyMat(VerticesList(i), Wt)
            VerticesList(i) = MultiplyMat(VerticesList(i), Vt)
            VerticesList(i) = MultiplyMat(VerticesList(i), St)
        Next
    End Sub

    Public Sub ScalingNeck()
        FillRow(0, 1.5, 0, 0, 0, Scale)
        FillRow(1, 0, 0.5, 0, 0, Scale)
        FillRow(2, 0, 0, 0.5, 0, Scale)
        FillRow(3, 0, 0, 0, 1, Scale)
    End Sub

    Public Sub ScalingHead()
        FillRow(0, 0.5, 0, 0, 0, Scale)
        FillRow(1, 0, 0.5, 0, 0, Scale)
        FillRow(2, 0, 0, 0.5, 0, Scale)
        FillRow(3, 0, 0, 0, 1, Scale)
    End Sub

    Public Sub ScalingBeak()
        FillRow(0, 0.5, 0, 0, 0, Scale)
        FillRow(1, 0, 0.25, 0, 0, Scale)
        FillRow(2, 0, 0, 0.25, 0, Scale)
        FillRow(3, 0, 0, 0, 1, Scale)
    End Sub

    Public Sub ScalingLowerWings()
        FillRow(0, 0.75, 0, 0, 0, Scale)
        FillRow(1, 0, 0.5, 0, 0, Scale)
        FillRow(2, 0, 0, 0.5, 0, Scale)
        FillRow(3, 0, 0, 0, 1, Scale)
    End Sub

    Public Sub ShearUpperWings()
        FillRow(0, 1, Cos45, 0, 0, ShearX)
        FillRow(1, 0, 1, 0, 0, ShearX)
        FillRow(2, 0, 0, 1, 0, ShearX)
        FillRow(3, 0, 0, 0, 1, ShearX)
    End Sub

    Public Sub ShearLowerWings()
        FillRow(0, 1, -Cos45, 0, 0, ShearX)
        FillRow(1, 0, 1, 0, 0, ShearX)
        FillRow(2, 0, 0, 1, 0, ShearX)
        FillRow(3, 0, 0, 0, 1, ShearX)
    End Sub

    Public Sub TranslatingNeck()
        FillRow(0, 1, 0, 0, 0, Translate)
        FillRow(1, 0, 1, 0, 0, Translate)
        FillRow(2, 0, 0, 1, 0, Translate)
        FillRow(3, 2, 2, 0, 1, Translate)
    End Sub

    Public Sub TranslatingHead()
        FillRow(0, 1, 0, 0, 0, Translate)
        FillRow(1, 0, 1, 0, 0, Translate)
        FillRow(2, 0, 0, 1, 0, Translate)
        FillRow(3, 3.5, 3.5, 0, 1, Translate)
    End Sub

    Public Sub TranslatingBeak()
        FillRow(0, 1, 0, 0, 0, Translate)
        FillRow(1, 0, 1, 0, 0, Translate)
        FillRow(2, 0, 0, 1, 0, Translate)
        FillRow(3, 4.75, 3.75, -0.5, 1, Translate)
    End Sub

    Public Sub TranslatingLowerWings() ' Sayap kayanya di shear deh.
        FillRow(0, 1, 0, 0, 0, Translate)
        FillRow(1, 0, 1, 0, 0, Translate)
        FillRow(2, 0, 0, 1, 0, Translate)
        FillRow(3, -3, 1, 1.75, 1, Translate)
    End Sub

    Public Sub RotateAroundZNeck()
        FillRow(0, Cos45, Sin45, 0, 0, RotateZ)
        FillRow(1, -Sin45, Cos45, 0, 0, RotateZ)
        FillRow(2, 0, 0, 1, 0, RotateZ)
        FillRow(3, 0, 0, 0, 1, RotateZ)
    End Sub

    Public Sub RotateAroundZLowerWings()
        FillRow(0, Cos45 + Cos45, Sin45 + Sin45, 0, 0, RotateZ)
        FillRow(1, -Sin45 - Sin45, Cos45 + Cos45, 0, 0, RotateZ)
        FillRow(2, 0, 0, 1, 0, RotateZ)
        FillRow(3, 0, 0, 0, 1, RotateZ)
    End Sub

    Public Sub getNeck()
        For i As Integer = 0 To 7
            VerticesList(i) = MultiplyMat(VerticesList(i), Scale)
            VerticesList(i) = MultiplyMat(VerticesList(i), RotateZ)
            VerticesList(i) = MultiplyMat(VerticesList(i), Translate)
            VerticesList(i) = MultiplyMat(VerticesList(i), Wt)
            VerticesList(i) = MultiplyMat(VerticesList(i), Vt)
            VerticesList(i) = MultiplyMat(VerticesList(i), St)
        Next
    End Sub

    Public Sub getHead()
        For i As Integer = 0 To 7
            VerticesList(i) = MultiplyMat(VerticesList(i), Scale)
            VerticesList(i) = MultiplyMat(VerticesList(i), Translate)
            VerticesList(i) = MultiplyMat(VerticesList(i), Wt)
            VerticesList(i) = MultiplyMat(VerticesList(i), Vt)
            VerticesList(i) = MultiplyMat(VerticesList(i), St)
        Next
    End Sub

    Public Sub getBeak()
        For i As Integer = 0 To 7
            VerticesList(i) = MultiplyMat(VerticesList(i), Scale)
            VerticesList(i) = MultiplyMat(VerticesList(i), Translate)
            VerticesList(i) = MultiplyMat(VerticesList(i), Wt)
            VerticesList(i) = MultiplyMat(VerticesList(i), Vt)
            VerticesList(i) = MultiplyMat(VerticesList(i), St)
        Next
    End Sub

    Public Sub getLowerWings()
        For i As Integer = 0 To 7
            VerticesList(i) = MultiplyMat(VerticesList(i), ShearX) 'Ini shear udah bisa. Masih ngaco tapi xD
            VerticesList(i) = MultiplyMat(VerticesList(i), Scale)
            'VerticesList(i) = MultiplyMat(VerticesList(i), RotateZ)
            VerticesList(i) = MultiplyMat(VerticesList(i), Translate)
            VerticesList(i) = MultiplyMat(VerticesList(i), Wt)
            VerticesList(i) = MultiplyMat(VerticesList(i), Vt)
            VerticesList(i) = MultiplyMat(VerticesList(i), St)
        Next
    End Sub

    Public Sub SetEdges(ByRef obj As TLine, a As Integer, b As Integer, c As Integer)
        obj = New TLine
        obj.PointA = a
        obj.PointB = b
        obj.LineIndex = c
    End Sub

    Private Sub MainCanvas_MouseOver(sender As Object, e As MouseEventArgs) Handles MainCanvas.MouseMove
        CoordinatesLabel.Text = "Coordinates: X = " + e.X.ToString() + ", Y = " + e.Y.ToString()
    End Sub

    Private Sub declare_all_object()
        'Init cube
        SetPoint(VerticesList(0), -1, -1, 1, 0)
        SetPoint(VerticesList(1), 1, -1, 1, 1)
        SetPoint(VerticesList(2), 1, 1, 1, 2)
        SetPoint(VerticesList(3), -1, 1, 1, 3)
        SetPoint(VerticesList(4), -1, -1, -1, 4)
        SetPoint(VerticesList(5), 1, -1, -1, 5)
        SetPoint(VerticesList(6), 1, 1, -1, 6)
        SetPoint(VerticesList(7), -1, 1, -1, 7)

        'init edge
        SetEdges(EdgeList(0), 0, 1, 0)
        SetEdges(EdgeList(1), 1, 2, 1)
        SetEdges(EdgeList(2), 2, 3, 2)
        SetEdges(EdgeList(3), 3, 0, 3)
        SetEdges(EdgeList(4), 4, 5, 4)
        SetEdges(EdgeList(5), 5, 6, 5)
        SetEdges(EdgeList(6), 6, 7, 6)
        SetEdges(EdgeList(7), 7, 4, 7)
        SetEdges(EdgeList(8), 0, 4, 8)
        SetEdges(EdgeList(9), 1, 5, 9)
        SetEdges(EdgeList(10), 2, 6, 10)
        SetEdges(EdgeList(11), 3, 7, 11)

        'Declare Object
        'Object A
        ObjectList(0) = New Model3D()
        ObjectList(0).EdgesIndexList.Add(EdgeList(0).LineIndex)
        ObjectList(0).EdgesIndexList.Add(EdgeList(1).LineIndex)
        ObjectList(0).EdgesIndexList.Add(EdgeList(2).LineIndex)
        ObjectList(0).EdgesIndexList.Add(EdgeList(3).LineIndex)
        ObjectList(0).EdgesIndexList.Add(EdgeList(4).LineIndex)
        ObjectList(0).EdgesIndexList.Add(EdgeList(5).LineIndex)
        ObjectList(0).EdgesIndexList.Add(EdgeList(6).LineIndex)
        ObjectList(0).EdgesIndexList.Add(EdgeList(7).LineIndex)
        'Object B

        'Object C

        'Object D
    End Sub

    Private Sub Projection()
        'P' = P Wt Vt St
        'P => object
        'P'=> projection
        'World
        FillRow(0, 1, 0, 0, 0, Wt)
        FillRow(1, 0, 1, 0, 0, Wt)
        FillRow(2, 0, 0, 1, 0, Wt)
        FillRow(3, 0, 0, 0, 1, Wt)
        'Vt
        FillRow(0, 1, 0, 0, 0, Vt)
        FillRow(1, 0, 1, 0, 0, Vt)
        FillRow(2, 0.5, 0.5, 0, 0, Vt)
        FillRow(3, 0, 0, 0, 1, Vt)
        'St
        FillRow(0, 20, 0, 0, 0, St)
        FillRow(1, 0, -20, 0, 0, St)
        FillRow(2, 0, 0, 0, 0, St)
        FillRow(3, 300, 200, 0, 1, St)
    End Sub

    Private Sub FillRow(row As Integer, x As Double, y As Double, z As Double, w As Double, ByRef M(,) As Double)
        M(row, 0) = x
        M(row, 1) = y
        M(row, 2) = z
        M(row, 3) = w
    End Sub

    Private Sub btnChicken01_Click(sender As Object, e As EventArgs) Handles btnChicken01.Click

    End Sub
End Class

Public Class Form1
    Dim bit As Bitmap
    Dim g As Graphics
    Dim blackPen As Pen
    Dim VerticesList(32) As TPoint
    Dim EdgeList(48) As TLine
    Dim ObjectList(4) As Model3D
    Dim Wt(4, 4), Vt(4, 4), St(4, 4) As Double

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        blackPen = New Pen(Color.Black, 5)
        bit = New Bitmap(MainCanvas.Width, MainCanvas.Height)
        g = Graphics.FromImage(bit)
        declare_all_object()
        Projection()
        MultiMat()
        MsgBox(VerticesList(0).X)
        MsgBox(VerticesList(0).Y)
    End Sub

    Public Sub SetPoint(ByRef obj As TPoint, a As Double, b As Double, c As Double, d As Integer)
        obj = New TPoint
        obj.X = a
        obj.Y = b
        obj.Z = c
        obj.w = 1
        obj.PointIndex = d
    End Sub

    Public Sub DrawCube()
        g.Clear(Color.White)
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

        'Vertices
        'Object A => Head and Torso
        SetPoint(VerticesList(0), -1, -1, 1, 0)
        SetPoint(VerticesList(1), 1, -1, 1, 1)
        SetPoint(VerticesList(2), 1, 1, 1, 2)
        SetPoint(VerticesList(3), -1, 1, 1, 3)
        SetPoint(VerticesList(4), -1, -1, -1, 4)
        SetPoint(VerticesList(5), 1, -1, -1, 5)
        SetPoint(VerticesList(6), 1, 1, -1, 6)
        SetPoint(VerticesList(7), -1, 1, -1, 7)
        ''Object B => Leg and Neck
        'SetPoint(VerticesList(8), 0, 0, 0, 8)
        'SetPoint(VerticesList(9), 0, 0, 0, 9)
        'SetPoint(VerticesList(10), 0, 0, 0, 10)
        'SetPoint(VerticesList(11), 0, 0, 0, 11)
        'SetPoint(VerticesList(12), 0, 0, 0, 12)
        'SetPoint(VerticesList(13), 0, 0, 0, 13)
        'SetPoint(VerticesList(14), 0, 0, 0, 14)
        'SetPoint(VerticesList(15), 0, 0, 0, 15)
        ''Object C => Foot and Beak
        'SetPoint(VerticesList(16), 0, 0, 0, 16)
        'SetPoint(VerticesList(17), 0, 0, 0, 17)
        'SetPoint(VerticesList(18), 0, 0, 0, 18)
        'SetPoint(VerticesList(19), 0, 0, 0, 19)
        'SetPoint(VerticesList(20), 0, 0, 0, 20)
        'SetPoint(VerticesList(21), 0, 0, 0, 21)
        'SetPoint(VerticesList(22), 0, 0, 0, 22)
        'SetPoint(VerticesList(23), 0, 0, 0, 23)
        ''Object D => Wing
        'SetPoint(VerticesList(24), 0, 0, 0, 24)
        'SetPoint(VerticesList(25), 0, 0, 0, 25)
        'SetPoint(VerticesList(26), 0, 0, 0, 26)
        'SetPoint(VerticesList(27), 0, 0, 0, 27)
        'SetPoint(VerticesList(28), 0, 0, 0, 28)
        'SetPoint(VerticesList(29), 0, 0, 0, 29)
        'SetPoint(VerticesList(30), 0, 0, 0, 30)
        'SetPoint(VerticesList(31), 0, 0, 0, 31)

        'SetEdges( EdgeList
        'Object A
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
        'Object B
        'SetEdges(EdgeList(0), 0, 1, 0)
        'SetEdges(EdgeList(0), 0, 1, 0)
        'SetEdges(EdgeList(0), 0, 1, 0)
        'SetEdges(EdgeList(0), 0, 1, 0)
        'SetEdges(EdgeList(0), 0, 1, 0)
        'SetEdges(EdgeList(0), 0, 1, 0)
        'SetEdges(EdgeList(0), 0, 1, 0)
        'SetEdges(EdgeList(0), 0, 1, 0)
        'SetEdges(EdgeList(0), 0, 1, 0)
        'SetEdges(EdgeList(0), 0, 1, 0)
        'SetEdges(EdgeList(0), 0, 1, 0)
        'SetEdges(EdgeList(0), 0, 1, 0)
        ''Object C
        'SetEdges(EdgeList(0), 0, 1, 0)
        'SetEdges(EdgeList(0), 0, 1, 0)
        'SetEdges(EdgeList(0), 0, 1, 0)
        'SetEdges(EdgeList(0), 0, 1, 0)
        'SetEdges(EdgeList(0), 0, 1, 0)
        'SetEdges(EdgeList(0), 0, 1, 0)
        'SetEdges(EdgeList(0), 0, 1, 0)
        'SetEdges(EdgeList(0), 0, 1, 0)
        'SetEdges(EdgeList(0), 0, 1, 0)
        'SetEdges(EdgeList(0), 0, 1, 0)
        'SetEdges(EdgeList(0), 0, 1, 0)
        'SetEdges(EdgeList(0), 0, 1, 0)
        ''Object D
        'SetEdges(EdgeList(0), 0, 1, 0)
        'SetEdges(EdgeList(0), 0, 1, 0)
        'SetEdges(EdgeList(0), 0, 1, 0)
        'SetEdges(EdgeList(0), 0, 1, 0)
        'SetEdges(EdgeList(0), 0, 1, 0)
        'SetEdges(EdgeList(0), 0, 1, 0)
        'SetEdges(EdgeList(0), 0, 1, 0)
        'SetEdges(EdgeList(0), 0, 1, 0)
        'SetEdges(EdgeList(0), 0, 1, 0)
        'SetEdges(EdgeList(0), 0, 1, 0)
        'SetEdges(EdgeList(0), 0, 1, 0)
        'SetEdges(EdgeList(0), 0, 1, 0)
        'SetEdges(EdgeList(0), 0, 1, 0)

        'Declare Object
        'Object A
        ObjectList(0) = New Model3D
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
        FillRow(2, Cos30, Sin45, 0, 0, Vt)
        FillRow(3, 0, 0, 0, 1, Vt)
        'St
        FillRow(0, 45, 0, 0, 0, St)
        FillRow(1, 0, -45, 0, 0, St)
        FillRow(2, 0, 0, 0, 0, St)
        FillRow(3, 300, 180, 0, 1, St)

    End Sub

    Private Sub FillRow(row As Integer, x As Double, y As Double, z As Double, w As Double, ByRef M(,) As Double)
        M(row, 0) = x
        M(row, 1) = y
        M(row, 2) = z
        M(row, 3) = w
    End Sub

    Private Sub btnChicken01_Click(sender As Object, e As EventArgs) Handles btnChicken01.Click
        DrawCube()
        'MsgBox(ObjectList(0).EdgesIndexList(2))
    End Sub
End Class

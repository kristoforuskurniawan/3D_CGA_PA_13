Public Class Form1

    Dim VerticesList(32) As TPoint
    Dim EdgeList(48) As TLine
    Dim ObjectsList(4) As Model3D
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        declare_all_object(VerticesList, EdgeList, ObjectsList)

    End Sub

    Private Sub MainCanvas_MouseOver(sender As Object, e As MouseEventArgs) Handles MainCanvas.MouseMove
        CoordinatesLabel.Text = "Coordinates: X = " + e.X.ToString() + ", Y = " + e.Y.ToString()
    End Sub

    Private Sub declare_all_object(ByRef points() As TPoint, ByRef edges() As TLine, ByRef objects() As Model3D)
        'Vertices
        'Object A => Head and Torso
        points(0).SetPoint(-1, -1, 1, 0)
        points(1).SetPoint(1, -1, 1, 1)
        points(2).SetPoint(1, 1, 1, 2)
        points(3).SetPoint(-1, 1, 1, 3)
        points(4).SetPoint(-1, -1, -1, 4)
        points(5).SetPoint(1, -1, -1, 5)
        points(6).SetPoint(1, 1, -1, 6)
        points(7).SetPoint(-1, 1, -1, 7)
        'Object B => Leg and Neck
        points(8).SetPoint(0, 0, 0, 8)
        points(9).SetPoint(0, 0, 0, 9)
        points(10).SetPoint(0, 0, 0, 10)
        points(11).SetPoint(0, 0, 0, 11)
        points(12).SetPoint(0, 0, 0, 12)
        points(13).SetPoint(0, 0, 0, 13)
        points(14).SetPoint(0, 0, 0, 14)
        points(15).SetPoint(0, 0, 0, 15)
        'Object C => Foot and Beak
        points(16).SetPoint(0, 0, 0, 16)
        points(17).SetPoint(0, 0, 0, 17)
        points(18).SetPoint(0, 0, 0, 18)
        points(19).SetPoint(0, 0, 0, 19)
        points(20).SetPoint(0, 0, 0, 20)
        points(21).SetPoint(0, 0, 0, 21)
        points(22).SetPoint(0, 0, 0, 22)
        points(23).SetPoint(0, 0, 0, 23)
        'Object D => Wing
        points(24).SetPoint(0, 0, 0, 24)
        points(25).SetPoint(0, 0, 0, 25)
        points(26).SetPoint(0, 0, 0, 26)
        points(27).SetPoint(0, 0, 0, 27)
        points(28).SetPoint(0, 0, 0, 28)
        points(29).SetPoint(0, 0, 0, 29)
        points(30).SetPoint(0, 0, 0, 30)
        points(31).SetPoint(0, 0, 0, 31)

        'Edges
        'Object A
        edges(0).SetEdge(0, 1, 0)
        edges(0).SetEdge(1, 2, 1)
        edges(0).SetEdge(2, 3, 2)
        edges(0).SetEdge(3, 4, 3)
        edges(0).SetEdge(4, 5, 4)
        edges(0).SetEdge(5, 6, 5)
        edges(0).SetEdge(6, 7, 6)
        edges(0).SetEdge(7, 8, 7)
        edges(0).SetEdge(8, 9, 8)
        edges(0).SetEdge(9, 10, 9)
        edges(0).SetEdge(10, 11, 10)
        edges(0).SetEdge(11, 0, 11)
        'Object B
        edges(0).SetEdge(0, 1, 0)
        edges(0).SetEdge(0, 1, 0)
        edges(0).SetEdge(0, 1, 0)
        edges(0).SetEdge(0, 1, 0)
        edges(0).SetEdge(0, 1, 0)
        edges(0).SetEdge(0, 1, 0)
        edges(0).SetEdge(0, 1, 0)
        edges(0).SetEdge(0, 1, 0)
        edges(0).SetEdge(0, 1, 0)
        edges(0).SetEdge(0, 1, 0)
        edges(0).SetEdge(0, 1, 0)
        edges(0).SetEdge(0, 1, 0)
        'Object C
        edges(0).SetEdge(0, 1, 0)
        edges(0).SetEdge(0, 1, 0)
        edges(0).SetEdge(0, 1, 0)
        edges(0).SetEdge(0, 1, 0)
        edges(0).SetEdge(0, 1, 0)
        edges(0).SetEdge(0, 1, 0)
        edges(0).SetEdge(0, 1, 0)
        edges(0).SetEdge(0, 1, 0)
        edges(0).SetEdge(0, 1, 0)
        edges(0).SetEdge(0, 1, 0)
        edges(0).SetEdge(0, 1, 0)
        edges(0).SetEdge(0, 1, 0)
        'Object D
        edges(0).SetEdge(0, 1, 0)
        edges(0).SetEdge(0, 1, 0)
        edges(0).SetEdge(0, 1, 0)
        edges(0).SetEdge(0, 1, 0)
        edges(0).SetEdge(0, 1, 0)
        edges(0).SetEdge(0, 1, 0)
        edges(0).SetEdge(0, 1, 0)
        edges(0).SetEdge(0, 1, 0)
        edges(0).SetEdge(0, 1, 0)
        edges(0).SetEdge(0, 1, 0)
        edges(0).SetEdge(0, 1, 0)
        edges(0).SetEdge(0, 1, 0)
        edges(0).SetEdge(0, 1, 0)

        'Declare Object
        'Object A
        objects(0).EdgesIndexList.Add(0)
        objects(0).EdgesIndexList.Add(1)
        objects(0).EdgesIndexList.Add(2)
        objects(0).EdgesIndexList.Add(3)
        objects(0).EdgesIndexList.Add(4)
        objects(0).EdgesIndexList.Add(5)
        objects(0).EdgesIndexList.Add(6)
        objects(0).EdgesIndexList.Add(7)
        'Object B

        'Object C

        'Object D
    End Sub




    Function MultiplyMat(point As TPoint, M(,) As Double) As TPoint
        Dim result As TPoint
        Dim w As Single
        w = (point.X * M(0, 3) + point.Y * M(1, 3) + point.Z * M(2, 3) + point.w * M(3, 3))
        result.X = (point.X * M(0, 0) + point.Y * M(1, 0) + point.Z * M(2, 0) + point.w * M(3, 0)) / w
        result.Y = (point.X * M(0, 1) + point.Y * M(1, 1) + point.Z * M(2, 1) + point.w * M(3, 1)) / w
        result.Z = (point.X * M(0, 2) + point.Y * M(1, 2) + point.Z * M(2, 2) + point.w * M(3, 2)) / w
        result.w = 1
        Return result
    End Function

    Private Sub Projection()
        'P' = P Wt Vt St
        'P => object
        'P'=> projection
        Dim Wt(4, 4) As Double 'World
        FillRow(0, 1, 0, 0, 0, Wt)
        FillRow(1, 0, 1, 0, 0, Wt)
        FillRow(2, 0, 0, 1, 0, Wt)
        FillRow(3, 0, 0, 0, 1, Wt)
        Dim Vt(4, 4) As Double 'Vt
        FillRow(0, 1, 0, 0, 0, Vt)
        FillRow(1, 0, 1, 0, 0, Vt)
        FillRow(2, 0, 0, 1, 0, Vt)
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

    Private Sub btnChicken01_Click(sender As Object, e As EventArgs) Handles btnChicken01.Click
        MsgBox(objects(0).EdgesIndexList(2))
    End Sub
End Class

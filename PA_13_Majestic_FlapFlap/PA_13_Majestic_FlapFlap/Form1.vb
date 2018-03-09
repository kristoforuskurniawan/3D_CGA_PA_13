Public Class Form1
    Dim bit As Bitmap
    Dim g As Graphics
    Dim blackPen As Pen
    Dim VerticesList As List(Of TPoint)
    Dim EdgeList As List(Of TLine)
    Dim Object3D As Model3D
    Dim PV(4, 4), Vt(4, 4), St(4, 4) As Double
    Dim HTree As TList3DObject
    Dim Scaling(4, 4), Translate(4, 4), RotateZ(4, 4), ShearX(4, 4), ShearY(4, 4) As Double

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        blackPen = New Pen(Color.Black, 1)
        bit = New Bitmap(MainCanvas.Width, MainCanvas.Height)
        HTree = New TList3DObject
        EdgeList = New List(Of TLine)
        VerticesList = New List(Of TPoint)
        Object3D = New Model3D
        g = Graphics.FromImage(bit)
        declare_all_object()
        Projection()
        DrawCube()
        MsgBox(Object3D.Vertices(7).X)
    End Sub

    Public Sub SetVertices(x As Double, y As Double, z As Double)
        Dim temp As New TPoint(x, y, z)
        VerticesList.Add(temp)
    End Sub

    Public Sub SetEdges(x As Integer, y As Integer)
        Dim temp As New TLine(x, y)
        EdgeList.Add(temp)
    End Sub

    Public Sub DrawCube()
        For i As Integer = 0 To 7
            Object3D.Vertices(i) = MultiplyMat(Object3D.Vertices(i), PV)
        Next
        Dim a, b, c, d As Single
        For i As Integer = 0 To Object3D.Edges.Count - 1
            a = Object3D.Vertices(Object3D.Edges(i).PointA).X
            b = Object3D.Vertices(Object3D.Edges(i).PointA).Y
            c = Object3D.Vertices(Object3D.Edges(i).PointB).X
            d = Object3D.Vertices(Object3D.Edges(i).PointB).Y
            g.DrawLine(blackPen, a, b, c, d)
        Next
        MainCanvas.Image = bit
    End Sub

    Public Sub CreationOfChicken()
        'Declaration of Chicken in Hierarchical Model
        'Must start from the child
        'still doesn't have transform matrix

        Dim left_foot As New TElement3DObject
        left_foot.Rotation_Angle = RotationAxis.none
        left_foot.Rotation_Axis = 0
        left_foot.Child = Nothing
        left_foot.Nxt = Nothing

        Dim LeftFoot As New TList3DObject(left_foot)

        Dim right_foot As New TElement3DObject
        right_foot.Rotation_Angle = RotationAxis.none
        right_foot.Rotation_Axis = 0
        right_foot.Child = Nothing
        right_foot.Nxt = Nothing

        Dim RightFoot As New TList3DObject(right_foot)

        Dim left_lower_wing As New TElement3DObject
        left_lower_wing.Rotation_Angle = RotationAxis.none
        left_lower_wing.Rotation_Axis = 0
        left_lower_wing.Child = Nothing
        left_lower_wing.Nxt = Nothing

        Dim LeftWing As New TList3DObject(left_lower_wing)

        Dim right_lower_wing As New TElement3DObject
        right_lower_wing.Rotation_Angle = RotationAxis.none
        right_lower_wing.Rotation_Axis = 0
        right_lower_wing.Child = Nothing
        right_lower_wing.Nxt = Nothing

        Dim RightWing As New TList3DObject(right_lower_wing)

        Dim beak As New TElement3DObject
        beak.Rotation_Angle = RotationAxis.none
        beak.Rotation_Axis = 0
        beak.Child = Nothing
        beak.Nxt = Nothing

        Dim MainBeak As New TList3DObject(beak)

        Dim head As New TElement3DObject
        head.Rotation_Angle = RotationAxis.none
        head.Rotation_Axis = 0
        head.Child = MainBeak
        head.Nxt = Nothing

        Dim MainHead As New TList3DObject(head)

        Dim neck As New TElement3DObject
        neck.Rotation_Angle = RotationAxis.none
        neck.Rotation_Axis = 0
        neck.Child = MainHead
        neck.Nxt = Nothing

        Dim right_upper_wing As New TElement3DObject
        right_upper_wing.Rotation_Angle = RotationAxis.none
        right_upper_wing.Rotation_Axis = 0
        right_upper_wing.Child = RightWing
        right_upper_wing.Nxt = neck

        Dim left_upper_wing As New TElement3DObject
        left_upper_wing.Rotation_Angle = RotationAxis.none
        left_upper_wing.Rotation_Axis = 0
        left_upper_wing.Child = LeftWing
        left_upper_wing.Nxt = right_upper_wing

        Dim right_leg As New TElement3DObject
        right_leg.Rotation_Angle = RotationAxis.none
        right_leg.Rotation_Axis = 0
        right_leg.Child = RightFoot
        right_leg.Nxt = left_upper_wing

        Dim left_leg As New TElement3DObject
        left_leg.Rotation_Angle = RotationAxis.none
        left_leg.Rotation_Axis = 0
        left_leg.Child = LeftFoot
        left_leg.Nxt = right_leg

        Dim AfterTorso As New TList3DObject(left_leg)

        Dim torso As New TElement3DObject
        torso.Rotation_Angle = RotationAxis.none
        torso.Rotation_Axis = 0
        torso.Child = AfterTorso
        torso.Nxt = Nothing

        Dim MainTorso As New TList3DObject(torso)

        Dim Chicken As New TElement3DObject
        Chicken.Rotation_Angle = RotationAxis.none
        Chicken.Rotation_Axis = 0
        Chicken.Child = MainTorso
        Chicken.Nxt = Nothing

        'Root of Tree
        HTree.First = Chicken

    End Sub

    Public Sub getTorso()
        For i As Integer = 0 To 7
            'VerticesList(i) = MultiplyMat(VerticesList(i), Wt)
            VerticesList(i) = MultiplyMat(VerticesList(i), Vt)
            VerticesList(i) = MultiplyMat(VerticesList(i), St)
        Next
    End Sub

    Public Sub ScalingNeck()
        FillRow(0, 1, 0, 0, 0, Scaling)
        FillRow(1, 0, 0.5, 0, 0, Scaling)
        FillRow(2, 0, 0, 0.5, 0, Scaling)
        FillRow(3, 0, 0, 0, 1, Scaling)
    End Sub

    Public Sub ScalingHead()
        FillRow(0, 0.5, 0, 0, 0, Scaling)
        FillRow(1, 0, 0.5, 0, 0, Scaling)
        FillRow(2, 0, 0, 0.5, 0, Scaling)
        FillRow(3, 0, 0, 0, 1, Scaling)
    End Sub

    Public Sub ScalingBeak()
        FillRow(0, 0.5, 0, 0, 0, Scaling)
        FillRow(1, 0, 0.25, 0, 0, Scaling)
        FillRow(2, 0, 0, 0.25, 0, Scaling)
        FillRow(3, 0, 0, 0, 1, Scaling)
    End Sub

    Public Sub ScalingUpperWings()
        FillRow(0, 1, 0, 0, 0, Scaling)
        FillRow(1, 0, 0.5, 0, 0, Scaling)
        FillRow(2, 0, 0, 0.5, 0, Scaling)
        FillRow(3, 0, 0, 0, 1, Scaling)
    End Sub

    Public Sub ShearUpperWings()
        FillRow(0, 1, Cos45, 0, 0, ShearX)
        FillRow(1, 0, 1, 0, 0, ShearX)
        FillRow(2, 0, 0, 1, 0, ShearX)
        FillRow(3, 0, 0, 0, 1, ShearX)
    End Sub

    Public Sub ShearLowerWings()
        FillRow(0, 1, Cos45, 0, 0, ShearX)
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

    Public Sub TranslatingUpperWings() ' Sayap kayanya di shear deh.
        FillRow(0, 1, 0, 0, 0, Translate)
        FillRow(1, 0, 1, 0, 0, Translate)
        FillRow(2, 0, 0, 1, 0, Translate)
        FillRow(3, -2, 0, 1.75, 1, Translate)
    End Sub

    Public Sub RotateAroundZNeck()
        FillRow(0, Cos45, Sin45, 0, 0, RotateZ)
        FillRow(1, -Sin45, Cos45, 0, 0, RotateZ)
        FillRow(2, 0, 0, 1, 0, RotateZ)
        FillRow(3, 0, 0, 0, 1, RotateZ)
    End Sub

    Public Sub RotateAroundZUpperWings()
        FillRow(0, Cos45, Sin45, 0, 0, RotateZ)
        FillRow(1, -Sin45, Cos45, 0, 0, RotateZ)
        FillRow(2, 0, 0, 1, 0, RotateZ)
        FillRow(3, 0, 0, 0, 1, RotateZ)
    End Sub

    Public Sub getNeck()
        For i As Integer = 0 To 7
            VerticesList(i) = MultiplyMat(VerticesList(i), Scaling)
            VerticesList(i) = MultiplyMat(VerticesList(i), RotateZ)
            VerticesList(i) = MultiplyMat(VerticesList(i), Translate)
            'VerticesList(i) = MultiplyMat(VerticesList(i), Wt)
            VerticesList(i) = MultiplyMat(VerticesList(i), Vt)
            VerticesList(i) = MultiplyMat(VerticesList(i), St)
        Next
    End Sub

    Public Sub getHead()
        For i As Integer = 0 To 7
            VerticesList(i) = MultiplyMat(VerticesList(i), Scaling)
            VerticesList(i) = MultiplyMat(VerticesList(i), Translate)
            'VerticesList(i) = MultiplyMat(VerticesList(i), Wt)
            VerticesList(i) = MultiplyMat(VerticesList(i), Vt)
            VerticesList(i) = MultiplyMat(VerticesList(i), St)
        Next
    End Sub

    Public Sub getBeak()
        For i As Integer = 0 To 7
            VerticesList(i) = MultiplyMat(VerticesList(i), Scaling)
            VerticesList(i) = MultiplyMat(VerticesList(i), Translate)
            'VerticesList(i) = MultiplyMat(VerticesList(i), Wt)
            VerticesList(i) = MultiplyMat(VerticesList(i), Vt)
            VerticesList(i) = MultiplyMat(VerticesList(i), St)
        Next
    End Sub

    Public Sub getUpperWings()
        For i As Integer = 0 To 7
            VerticesList(i) = MultiplyMat(VerticesList(i), ShearX) 'Ini shear udah bisa.
            VerticesList(i) = MultiplyMat(VerticesList(i), RotateZ)
            VerticesList(i) = MultiplyMat(VerticesList(i), Scaling)
            VerticesList(i) = MultiplyMat(VerticesList(i), Translate)
            'VerticesList(i) = MultiplyMat(VerticesList(i), Wt)
            VerticesList(i) = MultiplyMat(VerticesList(i), Vt)
            VerticesList(i) = MultiplyMat(VerticesList(i), St)
        Next
    End Sub



    Private Sub MainCanvas_MouseOver(sender As Object, e As MouseEventArgs) Handles MainCanvas.MouseMove
        CoordinatesLabel.Text = "Coordinates: X = " + e.X.ToString() + ", Y = " + e.Y.ToString()
    End Sub

    Private Sub declare_all_object()
        'Init cube
        SetVertices(-1, -1, 1)
        SetVertices(1, -1, 1)
        SetVertices(1, 1, 1)
        SetVertices(-1, 1, 1)
        SetVertices(-1, -1, -1)
        SetVertices(1, -1, -1)
        SetVertices(1, 1, -1)
        SetVertices(-1, 1, -1)

        'init edge
        SetEdges(0, 1)
        SetEdges(1, 2)
        SetEdges(2, 3)
        SetEdges(3, 0)
        SetEdges(4, 5)
        SetEdges(5, 6)
        SetEdges(6, 7)
        SetEdges(7, 4)
        SetEdges(0, 4)
        SetEdges(1, 5)
        SetEdges(2, 6)
        SetEdges(3, 7)

        'Declare Object
        'Object A
        Object3D = New Model3D()
        Object3D.Copy3DObject(VerticesList, EdgeList)
        'Object B

        'Object C

        'Object D
    End Sub

    Private Sub Projection()
        'P' = P Wt Vt St
        'P => object
        'P'=> projection
        'Vt
        FillRow(0, 1, 0, 0, 0, Vt)
        FillRow(1, 0, 1, 0, 0, Vt)
        FillRow(2, 0, 0, 0, -1 / 3, Vt)
        FillRow(3, 0, 0, 0, 1, Vt)
        'St
        FillRow(0, 20, 0, 0, 0, St)
        FillRow(1, 0, -20, 0, 0, St)
        FillRow(2, 0, 0, 0, 0, St)
        FillRow(3, 300, 200, 0, 1, St)
        'PV
        PV = MultiplyMat(Vt, St)
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

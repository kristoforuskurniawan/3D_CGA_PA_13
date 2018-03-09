Public Class Form1
    Dim FirstChicken As Boolean
    Dim bit As Bitmap
    Dim g As Graphics
    Dim blackPen As Pen
    Dim VerticesList As List(Of TPoint)
    Dim EdgeList As List(Of TLine)
    Dim Object3D As Model3D 'boring cube
    Dim PV As New Matrix4x4 'won't be changed
    Dim HTree As TList3DObject
    Dim nStack As Stack(Of Matrix4x4)
    Dim Scaling(4, 4), Translate(4, 4), RotateZ(4, 4), ShearX(4, 4), ShearY(4, 4) As Double

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FirstChicken = True
        nStack = New Stack(Of Matrix4x4)
        blackPen = New Pen(Color.Black, 1)
        bit = New Bitmap(MainCanvas.Width, MainCanvas.Height)
        HTree = New TList3DObject
        EdgeList = New List(Of TLine)
        VerticesList = New List(Of TPoint)
        Object3D = New Model3D
        g = Graphics.FromImage(bit)
        declare_all_object()
        Projection()
        'DrawCube(Object3D, PV)
        'MsgBox(Object3D.Vertices(7).X)
        CreationOfChicken()
        TranverseTree(HTree.First)
    End Sub

    Public Sub SetVertices(x As Double, y As Double, z As Double)
        Dim temp As New TPoint(x, y, z)
        VerticesList.Add(temp)
    End Sub

    Public Sub SetEdges(x As Integer, y As Integer)
        Dim temp As New TLine(x, y)
        EdgeList.Add(temp)
    End Sub

    Public Sub DrawCube(obj As Model3D, M As Matrix4x4)
        For i As Integer = 0 To 7
            obj.Vertices(i) = MultiplyMat(obj.Vertices(i), M)
        Next
        Dim a, b, c, d As Single
        For i As Integer = 0 To obj.Edges.Count - 1
            a = obj.Vertices(obj.Edges(i).PointA).X
            b = obj.Vertices(obj.Edges(i).PointA).Y
            c = obj.Vertices(obj.Edges(i).PointB).X
            d = obj.Vertices(obj.Edges(i).PointB).Y
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
        left_foot.Obj = New Model3D(Object3D)
        left_foot.Transform.TranslateMat(0, 1, 0)

        Dim LeftFoot As New TList3DObject(left_foot)

        Dim right_foot As New TElement3DObject
        right_foot.Rotation_Angle = RotationAxis.none
        right_foot.Rotation_Axis = 0
        right_foot.Child = Nothing
        right_foot.Nxt = Nothing
        right_foot.Obj = New Model3D(Object3D)
        right_foot.Transform.TranslateMat(1, -1, 0)

        Dim RightFoot As New TList3DObject(right_foot)

        Dim left_lower_wing As New TElement3DObject
        left_lower_wing.Rotation_Angle = RotationAxis.none
        left_lower_wing.Rotation_Axis = 0
        left_lower_wing.Child = Nothing
        left_lower_wing.Nxt = Nothing
        left_lower_wing.Obj = New Model3D(Object3D)
        left_lower_wing.Transform.TranslateMat(2, 1, 0)

        Dim LeftWing As New TList3DObject(left_lower_wing)

        Dim right_lower_wing As New TElement3DObject
        right_lower_wing.Rotation_Angle = RotationAxis.none
        right_lower_wing.Rotation_Axis = 0
        right_lower_wing.Child = Nothing
        right_lower_wing.Nxt = Nothing
        right_lower_wing.Obj = New Model3D(Object3D)
        right_lower_wing.Transform.TranslateMat(3, 2, 0)

        Dim RightWing As New TList3DObject(right_lower_wing)

        Dim beak As New TElement3DObject
        beak.Rotation_Angle = RotationAxis.none
        beak.Rotation_Axis = 0
        beak.Child = Nothing
        beak.Nxt = Nothing
        beak.Obj = New Model3D(Object3D)
        beak.Transform.TranslateMat(4, 0, 0)

        Dim MainBeak As New TList3DObject(beak)

        Dim head As New TElement3DObject
        head.Rotation_Angle = RotationAxis.none
        head.Rotation_Axis = 0
        head.Child = MainBeak
        head.Nxt = Nothing
        head.Obj = New Model3D(Object3D)
        head.Transform.TranslateMat(5, 2, 0)

        Dim MainHead As New TList3DObject(head)

        Dim neck As New TElement3DObject
        neck.Rotation_Angle = RotationAxis.none
        neck.Rotation_Axis = 0
        neck.Child = MainHead
        neck.Nxt = Nothing
        neck.Obj = New Model3D(Object3D)
        neck.Transform.TranslateMat(6, 2, 0)


        Dim right_upper_wing As New TElement3DObject
        right_upper_wing.Rotation_Angle = RotationAxis.none
        right_upper_wing.Rotation_Axis = 0
        right_upper_wing.Child = RightWing
        right_upper_wing.Nxt = neck
        right_upper_wing.Obj = New Model3D(Object3D)
        right_upper_wing.Transform.TranslateMat(7, 2, 0)

        Dim left_upper_wing As New TElement3DObject
        left_upper_wing.Rotation_Angle = RotationAxis.none
        left_upper_wing.Rotation_Axis = 0
        left_upper_wing.Child = LeftWing
        left_upper_wing.Nxt = right_upper_wing
        left_upper_wing.Obj = New Model3D(Object3D)
        left_upper_wing.Transform.TranslateMat(8, 4, 0)

        Dim right_leg As New TElement3DObject
        right_leg.Rotation_Angle = RotationAxis.none
        right_leg.Rotation_Axis = 0
        right_leg.Child = RightFoot
        right_leg.Nxt = left_upper_wing
        right_leg.Obj = New Model3D(Object3D)
        right_leg.Transform.TranslateMat(9, 2, 0)

        Dim left_leg As New TElement3DObject
        left_leg.Rotation_Angle = RotationAxis.none
        left_leg.Rotation_Axis = 0
        left_leg.Child = LeftFoot
        left_leg.Nxt = right_leg
        left_leg.Obj = New Model3D(Object3D)
        left_leg.Transform.TranslateMat(10, 2, 0)

        Dim AfterTorso As New TList3DObject(left_leg)

        Dim torso As New TElement3DObject
        torso.Rotation_Angle = RotationAxis.none
        torso.Rotation_Axis = 0
        torso.Child = AfterTorso
        torso.Nxt = Nothing
        torso.Obj = New Model3D(Object3D)
        torso.Transform.TranslateMat(-5, 2, 0)


        Dim MainTorso As New TList3DObject(torso)

        Dim Chicken As New TElement3DObject
        Chicken.Rotation_Angle = RotationAxis.none
        Chicken.Rotation_Axis = 0
        Chicken.Child = MainTorso
        Chicken.Nxt = Nothing
        Chicken.Obj = Nothing
        Chicken.Transform.MultiplyMatrix4x4(PV)

        'Root of Tree
        HTree.First = Chicken

    End Sub

    Public Sub TranverseTree(HObject As TElement3DObject)
        If HObject Is Nothing Then
            Return
        End If
        Dim top, temp As New Matrix4x4
        If nStack.Any Then
            top = nStack.Peek
        End If
        temp.Rotation(HObject.Rotation_Axis, HObject.Rotation_Angle)
        temp.MultiplyMatrix4x4(HObject.Transform)
        temp.MultiplyMatrix4x4(top)
        nStack.Push(temp)
        If Not HObject.Child Is Nothing Then
            TranverseTree(HObject.Child.First)
        End If
        top = nStack.Pop
        If Not (HObject.Obj Is Nothing) Then
            DrawFromTree(HObject.Obj, top)
            'MsgBox("draw")
        End If
        TranverseTree(HObject.Nxt)
    End Sub

    Public Sub DrawFromTree(Obj As Model3D, topofstack As Matrix4x4)

        DrawCube(Obj, topofstack)
    End Sub
    'Public Sub getTorso()
    '    For i As Integer = 0 To 7
    '        'VerticesList(i) = MultiplyMat(VerticesList(i), Wt)
    '        VerticesList(i) = MultiplyMat(VerticesList(i), Vt)
    '        VerticesList(i) = MultiplyMat(VerticesList(i), St)
    '    Next
    'End Sub

    'Public Sub ScalingNeck()
    '    FillRow(0, 1, 0, 0, 0, Scaling)
    '    FillRow(1, 0, 0.5, 0, 0, Scaling)
    '    FillRow(2, 0, 0, 0.5, 0, Scaling)
    '    FillRow(3, 0, 0, 0, 1, Scaling)
    'End Sub

    'Public Sub ScalingHead()
    '    FillRow(0, 0.5, 0, 0, 0, Scaling)
    '    FillRow(1, 0, 0.5, 0, 0, Scaling)
    '    FillRow(2, 0, 0, 0.5, 0, Scaling)
    '    FillRow(3, 0, 0, 0, 1, Scaling)
    'End Sub

    'Public Sub ScalingBeak()
    '    FillRow(0, 0.5, 0, 0, 0, Scaling)
    '    FillRow(1, 0, 0.25, 0, 0, Scaling)
    '    FillRow(2, 0, 0, 0.25, 0, Scaling)
    '    FillRow(3, 0, 0, 0, 1, Scaling)
    'End Sub

    'Public Sub ScalingUpperWings()
    '    FillRow(0, 1, 0, 0, 0, Scaling)
    '    FillRow(1, 0, 0.5, 0, 0, Scaling)
    '    FillRow(2, 0, 0, 0.5, 0, Scaling)
    '    FillRow(3, 0, 0, 0, 1, Scaling)
    'End Sub

    'Public Sub ShearUpperWings()
    '    FillRow(0, 1, Cos45, 0, 0, ShearX)
    '    FillRow(1, 0, 1, 0, 0, ShearX)
    '    FillRow(2, 0, 0, 1, 0, ShearX)
    '    FillRow(3, 0, 0, 0, 1, ShearX)
    'End Sub

    'Public Sub ShearLowerWings()
    '    FillRow(0, 1, Cos45, 0, 0, ShearX)
    '    FillRow(1, 0, 1, 0, 0, ShearX)
    '    FillRow(2, 0, 0, 1, 0, ShearX)
    '    FillRow(3, 0, 0, 0, 1, ShearX)
    'End Sub

    'Public Sub TranslatingNeck()
    '    FillRow(0, 1, 0, 0, 0, Translate)
    '    FillRow(1, 0, 1, 0, 0, Translate)
    '    FillRow(2, 0, 0, 1, 0, Translate)
    '    FillRow(3, 2, 2, 0, 1, Translate)
    'End Sub

    'Public Sub TranslatingHead()
    '    FillRow(0, 1, 0, 0, 0, Translate)
    '    FillRow(1, 0, 1, 0, 0, Translate)
    '    FillRow(2, 0, 0, 1, 0, Translate)
    '    FillRow(3, 3.5, 3.5, 0, 1, Translate)
    'End Sub

    'Public Sub TranslatingBeak()
    '    FillRow(0, 1, 0, 0, 0, Translate)
    '    FillRow(1, 0, 1, 0, 0, Translate)
    '    FillRow(2, 0, 0, 1, 0, Translate)
    '    FillRow(3, 4.75, 3.75, -0.5, 1, Translate)
    'End Sub

    'Public Sub TranslatingUpperWings() ' Sayap kayanya di shear deh.
    '    FillRow(0, 1, 0, 0, 0, Translate)
    '    FillRow(1, 0, 1, 0, 0, Translate)
    '    FillRow(2, 0, 0, 1, 0, Translate)
    '    FillRow(3, -2, 0, 1.75, 1, Translate)
    'End Sub

    'Public Sub RotateAroundZNeck()
    '    FillRow(0, Cos45, Sin45, 0, 0, RotateZ)
    '    FillRow(1, -Sin45, Cos45, 0, 0, RotateZ)
    '    FillRow(2, 0, 0, 1, 0, RotateZ)
    '    FillRow(3, 0, 0, 0, 1, RotateZ)
    'End Sub

    'Public Sub RotateAroundZUpperWings()
    '    FillRow(0, Cos45, Sin45, 0, 0, RotateZ)
    '    FillRow(1, -Sin45, Cos45, 0, 0, RotateZ)
    '    FillRow(2, 0, 0, 1, 0, RotateZ)
    '    FillRow(3, 0, 0, 0, 1, RotateZ)
    'End Sub

    'Public Sub getNeck()
    '    For i As Integer = 0 To 7
    '        VerticesList(i) = MultiplyMat(VerticesList(i), Scaling)
    '        VerticesList(i) = MultiplyMat(VerticesList(i), RotateZ)
    '        VerticesList(i) = MultiplyMat(VerticesList(i), Translate)
    '        'VerticesList(i) = MultiplyMat(VerticesList(i), Wt)
    '        VerticesList(i) = MultiplyMat(VerticesList(i), Vt)
    '        VerticesList(i) = MultiplyMat(VerticesList(i), St)
    '    Next
    'End Sub

    'Public Sub getHead()
    '    For i As Integer = 0 To 7
    '        VerticesList(i) = MultiplyMat(VerticesList(i), Scaling)
    '        VerticesList(i) = MultiplyMat(VerticesList(i), Translate)
    '        'VerticesList(i) = MultiplyMat(VerticesList(i), Wt)
    '        VerticesList(i) = MultiplyMat(VerticesList(i), Vt)
    '        VerticesList(i) = MultiplyMat(VerticesList(i), St)
    '    Next
    'End Sub

    'Public Sub getBeak()
    '    For i As Integer = 0 To 7
    '        VerticesList(i) = MultiplyMat(VerticesList(i), Scaling)
    '        VerticesList(i) = MultiplyMat(VerticesList(i), Translate)
    '        'VerticesList(i) = MultiplyMat(VerticesList(i), Wt)
    '        VerticesList(i) = MultiplyMat(VerticesList(i), Vt)
    '        VerticesList(i) = MultiplyMat(VerticesList(i), St)
    '    Next
    'End Sub

    'Public Sub getUpperWings()
    '    For i As Integer = 0 To 7
    '        VerticesList(i) = MultiplyMat(VerticesList(i), ShearX) 'Ini shear udah bisa.
    '        VerticesList(i) = MultiplyMat(VerticesList(i), RotateZ)
    '        VerticesList(i) = MultiplyMat(VerticesList(i), Scaling)
    '        VerticesList(i) = MultiplyMat(VerticesList(i), Translate)
    '        'VerticesList(i) = MultiplyMat(VerticesList(i), Wt)
    '        VerticesList(i) = MultiplyMat(VerticesList(i), Vt)
    '        VerticesList(i) = MultiplyMat(VerticesList(i), St)
    '    Next
    'End Sub



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

        'Declare Boring Cube
        Object3D = New Model3D()
        Object3D.Copy3DObject(VerticesList, EdgeList)
    End Sub

    Private Sub Projection()
        'PV = P Wt Vt St
        'P => object
        'PV=> projection
        Dim Vt, St As New Matrix4x4
        PV = New Matrix4x4
        'Vt.ObliqueProjection(45, -30)
        'Vt.RotateY(23)
        Vt.OnePointProjection(4) ' Zc = 3
        'Vt => View
        'FillRow(0, 1, 0, 0, 0, Vt)
        'FillRow(1, 0, 1, 0, 0, Vt)
        'FillRow(2, 0, 0, 0, -1 / 3, Vt)
        'FillRow(3, 0, 0, 0, 1, Vt)
        ' St.T1(20, -20, 1, 300, 200, 0)
        St.ScaleMat(20, -20, 0) ' scale
        St.TranslateMat(200, 300, 0) 'translate
        'St => Screen
        'FillRow(0, 20, 0, 0, 0, St)
        'FillRow(1, 0, -20, 0, 0, St)
        'FillRow(2, 0, 0, 0, 0, St)
        'FillRow(3, 300, 200, 0, 1, St)
        PV.Mat = MultiplyMat4x4(Vt, St)

    End Sub

    'Private Sub FillRow(row As Integer, x As Double, y As Double, z As Double, w As Double, ByRef M(,) As Double)
    '    M(row, 0) = x
    '    M(row, 1) = y
    '    M(row, 2) = z
    '    M(row, 3) = w
    'End Sub

    Private Sub ChangeControl(sender As Object, e As EventArgs) Handles btnChicken.Click
        FirstChicken = Not FirstChicken
    End Sub
End Class

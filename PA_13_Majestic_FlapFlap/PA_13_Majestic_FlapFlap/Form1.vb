Public Class Form1
    Dim FirstChicken, WalkMode, FlyMode, RotateMode As Boolean
    Dim bit As Bitmap
    Dim g As Graphics
    Dim blackPen As Pen
    Dim VerticesList As List(Of TPoint)
    Dim EdgeList As List(Of TLine)
    Dim Object3D As Model3D 'boring cube
    Dim PV As New Matrix4x4 'won't be changed
    Dim HTree As TList3DObject
    Dim nStack As Stack(Of Matrix4x4)
    Dim rotation, addition As Double
    Dim newTorsoPosition, firstTorsoPosition As TPoint

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rotation = 0
        addition = 5
        WalkMode = False
        FlyMode = True
        RotateMode = False
        FirstChicken = True
        newTorsoPosition = New TPoint()
        firstTorsoPosition = New TPoint()
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
        CreationOfChicken()
        TranverseTree(HTree.First)

    End Sub

    Private Sub WalkRadioButton_Click(sender As Object, e As EventArgs) Handles WalkRadioButton.CheckedChanged
        WalkMode = True
        FlyMode = False
        RotateMode = False
    End Sub

    Private Sub FlyRadioButton_Click(sender As Object, e As EventArgs) Handles FlyRadioButton.CheckedChanged
        WalkMode = False
        FlyMode = True
        RotateMode = False
    End Sub

    Private Sub RotateRadioButton_Click(sender As Object, e As EventArgs) Handles RotateRadioButton.CheckedChanged
        WalkMode = False
        FlyMode = False
        RotateMode = True
    End Sub

    Private Sub SetVertices(x As Double, y As Double, z As Double)
        Dim temp As New TPoint(x, y, z)
        VerticesList.Add(temp)
    End Sub

    Private Sub SetEdges(x As Integer, y As Integer)
        Dim temp As New TLine(x, y)
        EdgeList.Add(temp)
    End Sub

    Private Sub DrawCube(obj As Model3D, M As Matrix4x4)
        Dim temp As New List(Of TPoint)
        temp.AddRange(obj.Vertices)
        For i As Integer = 0 To 7
            temp(i) = MultiplyMat(temp(i), M)
        Next

        Dim a, b, c, d As Single

        For i As Integer = 0 To obj.Edges.Count - 1
            a = temp(obj.Edges(i).PointA).X
            b = temp(obj.Edges(i).PointA).Y
            c = temp(obj.Edges(i).PointB).X
            d = temp(obj.Edges(i).PointB).Y
            g.DrawLine(blackPen, a, b, c, d)
        Next
        MainCanvas.Image = bit
    End Sub

    Private Sub CreationOfChicken()
        'Declaration of Chicken in Hierarchical Model
        'Must start from the child

        Dim left_foot As New TElement3DObject
        left_foot.label = "leftfoot"
        left_foot.Rotation_Axis = RotationAxis.none
        left_foot.Rotation_Angle = 0
        left_foot.Child = Nothing
        left_foot.Nxt = Nothing
        left_foot.Obj = New Model3D(Object3D)
        left_foot.Transform.TranslateMat(0.2, -2.6, 0)
        left_foot.Transform.ScaleMat(1.2, 0.6, 1)

        Dim LeftFoot As New TList3DObject(left_foot)

        Dim right_foot As New TElement3DObject
        right_foot.label = "rightfoot"
        right_foot.Rotation_Axis = RotationAxis.none
        right_foot.Rotation_Angle = 0
        right_foot.Child = Nothing
        right_foot.Nxt = Nothing
        right_foot.Obj = New Model3D(Object3D)
        right_foot.Transform.TranslateMat(-0.2, -2.6, 0)
        right_foot.Transform.ScaleMat(1.2, 0.6, 1)

        Dim RightFoot As New TList3DObject(right_foot)

        Dim left_lower_wing As New TElement3DObject
        left_lower_wing.label = "leftlowerwing"
        left_lower_wing.Rotation_Axis = RotationAxis.none
        left_lower_wing.Rotation_Angle = 0
        left_lower_wing.Child = Nothing
        left_lower_wing.Nxt = Nothing
        left_lower_wing.Obj = New Model3D(Object3D)
        left_lower_wing.Transform.TranslateMat(0, 2, -2)
        left_lower_wing.Transform.ShearMat(0, 2)
        Dim LeftWing As New TList3DObject(left_lower_wing)

        Dim right_lower_wing As New TElement3DObject
        right_lower_wing.label = "rightlowerwing"
        right_lower_wing.Rotation_Axis = RotationAxis.none
        right_lower_wing.Rotation_Angle = 0
        right_lower_wing.Child = Nothing
        right_lower_wing.Nxt = Nothing
        right_lower_wing.Obj = New Model3D(Object3D)
        right_lower_wing.Transform.TranslateMat(0, 2, -2)
        right_lower_wing.Transform.ShearMat(0, 2)

        Dim RightWing As New TList3DObject(right_lower_wing)

        Dim beak As New TElement3DObject
        beak.label = "beak"
        beak.Rotation_Axis = RotationAxis.none
        beak.Rotation_Angle = 0
        beak.Child = Nothing
        beak.Nxt = Nothing
        beak.Obj = New Model3D(Object3D)
        beak.Transform.TranslateMat(0, 0, 2)
        beak.Transform.ScaleMat(0.5, 0.5, 1)

        Dim MainBeak As New TList3DObject(beak)

        Dim head As New TElement3DObject
        head.label = "head"
        head.Rotation_Axis = RotationAxis.none
        head.Rotation_Angle = 0
        head.Child = MainBeak
        head.Nxt = Nothing
        head.Obj = New Model3D(Object3D)
        head.Transform.TranslateMat(0, 2.45, 0)
        head.Transform.ScaleMat(2, 0.7, 1)

        Dim MainHead As New TList3DObject(head)

        Dim neck As New TElement3DObject
        neck.label = "neck"
        neck.Rotation_Axis = RotationAxis.none
        neck.Rotation_Angle = 0
        neck.Child = MainHead
        neck.Nxt = Nothing
        neck.Obj = New Model3D(Object3D)
        neck.Transform.TranslateMat(0, 3, 0)
        neck.Transform.ScaleMat(0.3, 0.5, 0.3)


        Dim right_upper_wing As New TElement3DObject
        right_upper_wing.label = "rightuppperwing"
        right_upper_wing.Rotation_Axis = RotationAxis.none
        right_upper_wing.Rotation_Angle = 0
        right_upper_wing.Child = RightWing
        right_upper_wing.Nxt = neck
        right_upper_wing.Obj = New Model3D(Object3D)
        right_upper_wing.Transform.TranslateMat(-3, 3.5, 0)
        right_upper_wing.Transform.ScaleMat(0.35, 0.2, 0.5)
        right_upper_wing.Transform.ShearMat(0.75, 0)

        Dim left_upper_wing As New TElement3DObject
        left_upper_wing.label = "leftupperwing"
        left_upper_wing.Rotation_Axis = RotationAxis.none
        left_upper_wing.Rotation_Angle = 0
        left_upper_wing.Child = LeftWing
        left_upper_wing.Nxt = right_upper_wing
        left_upper_wing.Obj = New Model3D(Object3D)
        left_upper_wing.Transform.TranslateMat(3, 3.5, 0)
        left_upper_wing.Transform.ScaleMat(0.35, 0.2, 0.5)
        left_upper_wing.Transform.ShearMat(-0.75, 0) 'w bingung yg shear

        Dim right_leg As New TElement3DObject
        right_leg.label = "rightleg"
        right_leg.Rotation_Axis = RotationAxis.none
        right_leg.Rotation_Angle = 0
        right_leg.Child = RightFoot
        right_leg.Nxt = left_upper_wing
        right_leg.Obj = New Model3D(Object3D)
        right_leg.Transform.TranslateMat(-1.25, -3.05, 0)
        right_leg.Transform.ScaleMat(0.3, 0.5, 0.3)

        Dim left_leg As New TElement3DObject
        left_leg.label = "leftleg"
        left_leg.Rotation_Axis = RotationAxis.none
        left_leg.Rotation_Angle = 0
        left_leg.Child = LeftFoot
        left_leg.Nxt = right_leg
        left_leg.Obj = New Model3D(Object3D)
        left_leg.Transform.TranslateMat(1.25, -3.05, 0)
        left_leg.Transform.ScaleMat(0.3, 0.5, 0.3)

        Dim AfterTorso As New TList3DObject(left_leg)

        Dim torso As New TElement3DObject
        torso.label = "torso"
        torso.Rotation_Axis = RotationAxis.y
        torso.Rotation_Angle = 0
        torso.Child = AfterTorso
        torso.Nxt = Nothing
        torso.Obj = New Model3D(Object3D)
        torso.Transform.TranslateMat(0, 0, 0)
        torso.Transform.RotateX(45)
        torso.Transform.RotateY(45)

        Dim MainTorso As New TList3DObject(torso)

        Dim Chicken As New TElement3DObject
        Chicken.label = "chicken1"
        Chicken.Rotation_Axis = RotationAxis.none
        Chicken.Rotation_Angle = 0
        Chicken.Child = MainTorso
        Chicken.Nxt = Nothing
        Chicken.Obj = Nothing
        Chicken.Transform.MultiplyMatrix4x4(PV)

        'Root of Tree
        HTree.First = New TElement3DObject(Chicken)

    End Sub

    Private Sub TranverseTree(HObject As TElement3DObject)
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
        End If
        TranverseTree(HObject.Nxt)
    End Sub

    Private Sub TranverseChange(HObject As TElement3DObject, target As String, value As Double)
        If HObject Is Nothing Then
            Return
        End If

        If String.Equals(target, HObject.label) Then
            ChangeRotation(HObject, value)
        End If

        If Not HObject.Child Is Nothing Then
            TranverseChange(HObject.Child.First, target, value)
        End If
        TranverseChange(HObject.Nxt, target, value)

    End Sub

    Private Sub ChangeRotation(ByRef target As TElement3DObject, value As Double)
        target.Rotation_Angle = value

    End Sub

    Private Sub DrawFromTree(Obj As Model3D, topofstack As Matrix4x4)
        DrawCube(Obj, topofstack)
    End Sub

    Private Sub Process(E As TElement3DObject) 'From Mr. Edo
        Dim M As New Matrix4x4
        Dim T As New Matrix4x4

        While E IsNot Nil
            T = MultiplyMat4x4(E.Transform, nStack.Peek)
            nStack.Push(T)
            Process(E.Child.First)
            nStack.Pop()
            If E.Obj IsNot Nil Then
                DrawCube(E.Obj, M)
            End If
            E = E.Nxt
        End While
    End Sub

    Private Sub MainCanvas_MouseOver(sender As Object, e As MouseEventArgs) Handles MainCanvas.MouseMove
        CoordinatesLabel.Text = "Coordinates: X = " + e.X.ToString() + ", Y = " + e.Y.ToString()
    End Sub

    Private Sub MainCanvas_Click(sender As Object, e As MouseEventArgs) Handles MainCanvas.Click
        newTorsoPosition = New TPoint(e.X, e.Y, 0)
        If TimerAnimation.Enabled Then
            TimerAnimation.Enabled = False
        Else
            TimerAnimation.Enabled = True
        End If
        DestPoint.Text = "Destination Point: X = " + newTorsoPosition.X.ToString() + ", Y = " + newTorsoPosition.Y.ToString()
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
        'Vt => View
        Vt.RotateY(45)
        Vt.RotateZ(45)
        Vt.OnePointProjection(4) ' Zc = 3
        'St => Screen
        ' St.T1(20, -20, 1, 300, 200, 0)
        St.ScaleMat(25, -25, 1) ' scale
        St.TranslateMat(300, 250, 0) 'translate Ini ternyata posisi awalnya ._. Kirain HTree.First.Child.First.Transformation diganti-ganti isinya sampai hasil perkaliannya = e.X & e.Y
        firstTorsoPosition = New TPoint(300, 250, 0)
        PV.Mat = MultiplyMat4x4(Vt, St)
    End Sub

    Private Sub ChangeControl(sender As Object, e As EventArgs) Handles btnChange.Click
        FirstChicken = Not FirstChicken
        '        TimerAnimation.Enabled = Not TimerAnimation.Enabled
        TurnBodyAnimation.Enabled = True
    End Sub

    Dim bodyTurned As Integer = 0

    Dim turnLeft As Boolean = False 'Determine the first torso position
    Dim turnRight As Boolean = False
    'Dim turnTopRight As Boolean = False
    'Dim turnTopLeft As Boolean = False
    'Dim turnBotRight As Boolean = False
    'Dim turnBotLeft As Boolean = False

    Private Sub TurnBodyAnimation_Tick(sender As Object, e As EventArgs) Handles TurnBodyAnimation.Tick
        'If turnLeft Then
        '    rotation += addition
        'ElseIf turnRight Then
        '    rotation -= addition
        'End If
        'If Math.Abs(rotation) = 180 Then
        '    addition = 0
        'End If
        rotation += addition
        g.Clear(Color.White)
        HTree.First.Transform.RotateY(rotation)
        TranverseChange(HTree.First, "torso", rotation)
        TranverseTree(HTree.First)
    End Sub

    Private Sub TimerAnimation_Tick(sender As Object, e As EventArgs) Handles TimerAnimation.Tick
        If WalkMode Then 'Not yet completed (- body turned)
            If firstTorsoPosition.X = newTorsoPosition.X And firstTorsoPosition.Y = newTorsoPosition.Y Then
                TimerAnimation.Enabled = False
            End If
            Dim x, y As Integer
            If firstTorsoPosition.X > newTorsoPosition.X And firstTorsoPosition.Y > newTorsoPosition.Y Then
                turnLeft = True
                If bodyTurned = 0 And turnLeft Then
                    TurnBodyAnimation.Enabled = True
                    x = -1
                    y = -1
                End If
            ElseIf firstTorsoPosition.X > newTorsoPosition.X And firstTorsoPosition.Y < newTorsoPosition.Y Then
                turnLeft = True
                If bodyTurned = 0 And turnLeft Then
                    TurnBodyAnimation.Enabled = True
                    x = -1
                    y = 1
                End If
            ElseIf firstTorsoPosition.X < newTorsoPosition.X And firstTorsoPosition.Y > newTorsoPosition.Y Then
                turnRight = True
                If bodyTurned = 0 And turnRight Then
                    TurnBodyAnimation.Enabled = True
                    x = 1
                    y = -1
                End If
            ElseIf firstTorsoPosition.X < newTorsoPosition.X And firstTorsoPosition.Y < newTorsoPosition.Y Then
                turnRight = True
                If bodyTurned = 0 And turnRight Then
                    TurnBodyAnimation.Enabled = True
                    x = 1
                    y = 1
                End If
            ElseIf firstTorsoPosition.X = newTorsoPosition.X And firstTorsoPosition.Y < newTorsoPosition.Y Then
                x = 0
                y = 1
            ElseIf firstTorsoPosition.X = newTorsoPosition.X And firstTorsoPosition.Y > newTorsoPosition.Y Then
                x = 0
                y = -1
            ElseIf firstTorsoPosition.X > newTorsoPosition.X And firstTorsoPosition.Y = newTorsoPosition.Y Then
                turnLeft = True
                If bodyTurned = 0 And turnLeft Then
                    TurnBodyAnimation.Enabled = True
                    x = -1
                    y = 0
                End If
            ElseIf firstTorsoPosition.X < newTorsoPosition.X And firstTorsoPosition.Y = newTorsoPosition.Y Then
                turnRight = True
                If bodyTurned = 0 And turnRight Then
                    TurnBodyAnimation.Enabled = True
                    x = 1
                    y = 0
                End If
            End If
            firstTorsoPosition.X += x
            firstTorsoPosition.Y += y
            ChickPos.Text = "Chicken: X = " + firstTorsoPosition.X.ToString() + ", Y = " + firstTorsoPosition.Y.ToString()
            HTree.First.Transform.TranslateMat(x, y, 0)
            g.Clear(Color.White)
            TranverseChange(HTree.First, "torso", rotation)
            TranverseTree(HTree.First)
        ElseIf FlyMode Then

        ElseIf RotateMode Then 'Only to test
            rotation += addition
            If rotation >= Round Or rotation <= -Round Then
                addition = -addition
            End If
            g.Clear(Color.White)
            TranverseChange(HTree.First, "torso", rotation)
            TranverseTree(HTree.First)
        End If
    End Sub
End Class

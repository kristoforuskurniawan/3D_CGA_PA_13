Public Class Form1
    Dim FirstChicken, WalkMode, FlyMode, RotateMode, IsAscend, IsDescend As Boolean 'movement type
    Dim bit As Bitmap 'manipulate the screen
    Dim g As Graphics ' to draw
    Dim blackPen As Pen ' for chicken's color
    Dim VerticesList As List(Of TPoint)
    Dim EdgeList As List(Of TLine)
    Dim Object3D As Model3D 'boring cube
    Dim PV, InversePV As New Matrix4x4 'won't be changed
    Dim HTree As TList3DObject
    Dim nStack As Stack(Of Matrix4x4)
    Dim rotation, addition As Double
    Dim DestinationTarget, OriginPosition As TPoint
    Dim targetpos As TPoint
    Dim headposition, beakposition As New Matrix4x4 'to get the degree of rotation between the chicken's front and destination 
    Dim WingRotation, LegRotation, FlyPosition, wingaddition, legaddition, heightChange, descendSpeed As Double
    Dim dx, dy, vx, vy, dirx, diry, theta, cotTheta As Double
    Dim bodyTurned As Integer = 0
    Dim clockwise, counterClockwise As Boolean
    Dim currentTheta As Integer = 0
    Dim v As Integer

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WingRotation = 0
        LegRotation = 0
        FlyPosition = 0
        v = 5
        dy = 0
        dx = 0
        vx = 0
        vy = 0
        'theta = 1
        cotTheta = Math.Atan(theta) * 180 / Math.PI
        rotation = 0
        addition = 1
        wingaddition = 5
        legaddition = 5
        heightChange = 0.2
        IsAscend = True
        IsDescend = False
        WalkMode = False
        FlyMode = True
        RotateMode = False
        FirstChicken = True
        DestinationTarget = New TPoint()
        OriginPosition = New TPoint()
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
        left_foot.Rotation_Axis = RotationAxis.x
        left_foot.Rotation_Angle = 0
        left_foot.Child = Nothing
        left_foot.Nxt = Nothing
        left_foot.Obj = New Model3D(Object3D)
        left_foot.Transform.TranslateMat(0.2, -2.6, 0)
        left_foot.Transform.ScaleMat(1.2, 0.6, 1)

        Dim LeftFoot As New TList3DObject(left_foot)

        Dim right_foot As New TElement3DObject
        right_foot.label = "rightfoot"
        right_foot.Rotation_Axis = RotationAxis.x
        right_foot.Rotation_Angle = 0
        right_foot.Child = Nothing
        right_foot.Nxt = Nothing
        right_foot.Obj = New Model3D(Object3D)
        right_foot.Transform.TranslateMat(-0.2, -2.6, 0)
        right_foot.Transform.ScaleMat(1.2, 0.6, 1)

        Dim RightFoot As New TList3DObject(right_foot)

        Dim left_lower_wing As New TElement3DObject
        left_lower_wing.label = "leftlowerwing"
        left_lower_wing.Rotation_Axis = RotationAxis.z
        left_lower_wing.Rotation_Angle = 0
        left_lower_wing.Child = Nothing
        left_lower_wing.Nxt = Nothing
        left_lower_wing.Obj = New Model3D(Object3D)
        left_lower_wing.Transform.TranslateMat(1, 0, 0)
        left_lower_wing.Transform.RotateZ(-30)
        'left_lower_wing.Transform.ShearMat(0, 2)
        left_lower_wing.Transform.ScaleMat(2.5, 1, 1)

        Dim LeftWing As New TList3DObject(left_lower_wing)

        Dim right_lower_wing As New TElement3DObject
        right_lower_wing.label = "rightlowerwing"
        right_lower_wing.Rotation_Axis = RotationAxis.z
        right_lower_wing.Rotation_Angle = 0
        right_lower_wing.Child = Nothing
        right_lower_wing.Nxt = Nothing
        right_lower_wing.Obj = New Model3D(Object3D)
        right_lower_wing.Transform.TranslateMat(-1, 0, 0)
        right_lower_wing.Transform.RotateZ(30)
        'right_lower_wing.Transform.ShearMat(0, 2)
        right_lower_wing.Transform.ScaleMat(2.5, 1, 1)

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
        head.Rotation_Axis = RotationAxis.y
        head.Rotation_Angle = 0
        head.Child = MainBeak
        head.Nxt = Nothing
        head.Obj = New Model3D(Object3D)
        head.Transform.TranslateMat(0, 2.45, 0)
        head.Transform.ScaleMat(2, 0.7, 1)

        Dim MainHead As New TList3DObject(head)

        Dim neck As New TElement3DObject
        neck.label = "neck"
        neck.Rotation_Axis = RotationAxis.y
        neck.Rotation_Angle = 0
        neck.Child = MainHead
        neck.Nxt = Nothing
        neck.Obj = New Model3D(Object3D)
        neck.Transform.TranslateMat(0, 3, 0)
        neck.Transform.ScaleMat(0.3, 0.5, 0.3)


        Dim right_upper_wing As New TElement3DObject
        right_upper_wing.label = "rightupperwing"
        right_upper_wing.Rotation_Axis = RotationAxis.z
        right_upper_wing.Rotation_Angle = 0
        right_upper_wing.Child = RightWing
        right_upper_wing.Nxt = neck
        right_upper_wing.Obj = New Model3D(Object3D)
        right_upper_wing.Transform.TranslateMat(-3, 3.5, 0)
        right_upper_wing.Transform.ScaleMat(0.4, 0.2, 0.5)
        'right_upper_wing.Transform.ShearMat(0.25, 0)

        Dim left_upper_wing As New TElement3DObject
        left_upper_wing.label = "leftupperwing"
        left_upper_wing.Rotation_Axis = RotationAxis.z
        left_upper_wing.Rotation_Angle = 0
        left_upper_wing.Child = LeftWing
        left_upper_wing.Nxt = right_upper_wing
        left_upper_wing.Obj = New Model3D(Object3D)
        left_upper_wing.Transform.TranslateMat(3, 3.5, 0)
        left_upper_wing.Transform.ScaleMat(0.4, 0.2, 0.5)
        'left_upper_wing.Transform.ShearMat(-0.25, 0) 'w bingung yg shear

        Dim right_leg As New TElement3DObject
        right_leg.label = "rightleg"
        right_leg.Rotation_Axis = RotationAxis.x
        right_leg.Rotation_Angle = 0
        right_leg.Child = RightFoot
        right_leg.Nxt = left_upper_wing
        right_leg.Obj = New Model3D(Object3D)
        right_leg.Transform.TranslateMat(-1.25, -3.05, 0)
        right_leg.Transform.ScaleMat(0.3, 0.5, 0.3)

        Dim left_leg As New TElement3DObject
        left_leg.label = "leftleg"
        left_leg.Rotation_Axis = RotationAxis.x
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
        torso.Transform.ScaleMat(0.5, 0.5, 0.5)
        torso.Transform.RotateY(90)

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

        If String.Equals("head", HObject.label) Then
            headposition.CopyMatrix(HObject.Transform)
            'MsgBox(headposition.Mat(0, 0))
        ElseIf String.Equals("beak", HObject) Then
            beakposition.CopyMatrix(HObject.Transform)
        End If

        If String.Equals(target, HObject.label) Then
            ChangeRotation(HObject, value)
            Return
        End If

        If Not HObject.Child Is Nothing Then
            TranverseChange(HObject.Child.First, target, value)
        End If
        TranverseChange(HObject.Nxt, target, value)

    End Sub

    Private Sub FlapFlap() 'Animation of wing
        WingRotation += wingaddition
        If WingRotation >= 45 Then
            wingaddition = -wingaddition
        ElseIf WingRotation <= -45 Then
            wingaddition = -wingaddition
        End If

        TranverseChange(HTree.First, "leftupperwing", WingRotation)
        TranverseChange(HTree.First, "rightupperwing", -WingRotation)
    End Sub

    Private Sub WalkingChicken() ' Animation of chicken's leg
        LegRotation += legaddition
        If LegRotation >= 45 Then
            legaddition = -legaddition
        ElseIf LegRotation <= -45 Then
            legaddition = -legaddition
        End If

        TranverseChange(HTree.First, "leftleg", LegRotation)
        TranverseChange(HTree.First, "rightleg", -LegRotation)
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

        DestinationTarget = New TPoint(e.X, e.Y, e.Y)
        OriginPosition = New TPoint()
        Dim CurrentPosition As New Matrix4x4
        CurrentPosition.MultiplyMatrix4x4(HTree.First.Child.First.Transform)
        CurrentPosition.MultiplyMatrix4x4(HTree.First.Transform)
        OriginPosition = MultiplyMat(OriginPosition, CurrentPosition)
        addition = 1
        GetDegreeForRotation()
        TimerAnimation.Enabled = True
        DestPoint.Text = "Destination Point: X = " + DestinationTarget.X.ToString() + ", Z = " + DestinationTarget.Z.ToString()
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
        Dim Vt, St, InVt, InSt As New Matrix4x4
        PV = New Matrix4x4
        'Vt => View
        'Vt.RotateY(45)
        'Vt.RotateZ(45)
        Vt.OnePointProjection(10) ' Zc = 3
        'St => Screen
        ' St.T1(20, -20, 1, 300, 200, 0)
        St.ScaleMat(25, -25, 1) ' scale
        St.TranslateMat(300, 250, 0) 'translate Ini ternyata posisi awalnya ._. Kirain HTree.First.Child.First.Transformation diganti-ganti isinya sampai hasil perkaliannya = e.X & e.Y
        InVt.OnePointProjection(-10)
        InSt.ScaleMat(0.04, -0.04, 1)
        InSt.TranslateMat(-12, 10, 0)

        PV.Mat = MultiplyMat4x4(Vt, St)
        InversePV.Mat = MultiplyMat4x4(InSt, InVt)

    End Sub

    Private Function GetWCSPosition() As TPoint
        'Get the WCS of the selected destination point
        Dim WCS As New TPoint
        WCS = MultiplyMat(DestinationTarget, InversePV)
        Return WCS
    End Function

    Private Sub TurnBodyAnimation_Tick(sender As Object, e As EventArgs) Handles TurnBodyAnimation.Tick 'Last edited here
        If clockwise Then
            rotation += addition
            If Math.Abs(rotation) = theta Then
                addition = 0
            End If
        ElseIf counterClockwise Then
            rotation -= addition
            If Math.Abs(rotation) = theta Then
                addition = 0
            End If
        End If

        rotationTxt.Text = "Rotation: " + rotation.ToString()
        g.Clear(Color.White)
        TranverseChange(HTree.First, "torso", rotation)
        TranverseTree(HTree.First)
    End Sub

    Private Sub AscendOrDescend(ByVal heightChange As Double) 'OK sekarang ini work.... Panggil di FlyMode tinggal ubah boolean IsAscend sama IsDescend sesuai yang dibutuhin
        If IsAscend And IsDescend = False Then 'Ascend
            'flyaddition = 0
            FlyPosition += heightChange
            'OriginPosition.Y += heightChange
            g.Clear(Color.White)
            HTree.First.Child.First.Transform.TranslateMat(0, heightChange, 0)
            TranverseTree(HTree.First)
            If (FlyPosition > 5) Then
                IsAscend = False
                IsDescend = True
                FlyPosition = 0
            End If
            'Descend(descendSpeed)
            'ElseIf FlyPosition <= 0 Then
            '    flyaddition = -flyaddition
        ElseIf IsDescend Then 'Descend
            FlyPosition -= heightChange
            'OriginPosition.Y -= heightChange
            g.Clear(Color.White)
            HTree.First.Child.First.Transform.TranslateMat(0, -heightChange, 0)
            TranverseTree(HTree.First)
            If FlyPosition < -5 Then
                IsAscend = True
                IsDescend = False
                FlyPosition = 0
            End If
        End If
    End Sub

    Private Sub DescendOnly()
        g.Clear(Color.White)
        HTree.First.Child.First.Transform.TranslateMat(0, -heightChange, 0)
        TranverseTree(HTree.First)
        'If (HTree.First.Ob) Then
    End Sub

    Private Sub FlyingChicken()
        FlapFlap()
        If OriginPosition.X = DestinationTarget.X And OriginPosition.Y = DestinationTarget.Z Then
            TimerAnimation.Enabled = False
        End If
        If currentTheta < theta Then
            clockwise = True
            counterClockwise = False
            TurnBodyAnimation.Enabled = True
            currentTheta = theta
        ElseIf currentTheta > theta Then
            'Console.WriteLine(currentTheta)
            'Console.WriteLine(theta)
            clockwise = False
            counterClockwise = True
            TurnBodyAnimation.Enabled = True
            currentTheta = theta
        End If
        If addition = 0 Then
            AscendOrDescend(heightChange)
            If DestinationTarget.Z > OriginPosition.Y And Math.Floor(DestinationTarget.Z) - Math.Floor(OriginPosition.Y) < v Then
                ' MessageBox.Show("Test")
                AscendAndDescend(heightChange)
                TimerAnimation.Enabled = False
                ' ElseIf Math.Floor(DestinationTarget.Z) + Math.Floor(OriginPosition.Y) < v Then
                '    TimerAnimation.Enabled = False
            Else
                dirx = Math.Cos(theta * Math.PI / 180)
                diry = Math.Sin(theta * Math.PI / 180)
                '  Console.WriteLine(dirx)
                '  Console.WriteLine(diry)
                vx = v * dirx
                vy = v * diry
                '    Console.WriteLine(vx)
                '   Console.WriteLine(vy)
                OriginPosition.X += vx
                OriginPosition.Y += vy

                ChickPos.Text = "Chicken: X = " + OriginPosition.X.ToString() + ", Y = 0" + ", Z = " + (OriginPosition.Y).ToString()
                HTree.First.Child.First.Transform.TranslateMat(vx / 50, 0, -(vy / 50))
                g.Clear(Color.White)
                TranverseChange(HTree.First, "torso", rotation)
                TranverseTree(HTree.First)
            End If
        End If
    End Sub

    Private Sub GetDegreeForRotation()
        theta = GetAngle360(OriginPosition.X, OriginPosition.Y, DestinationTarget.X, DestinationTarget.Y)
        theta = Math.Floor(theta)
        angleTxt.Text = "Angle: " + theta.ToString()
        '  Console.WriteLine(theta)
    End Sub

    Private Function GetAngle(cx As Double, cy As Double, ex As Double, ey As Double)
        dy = DestinationTarget.Y - OriginPosition.Y
        dx = DestinationTarget.X - OriginPosition.X
        Dim temp As Double
        temp = Math.Atan2(dy, dx) ' range (-PI, PI]
        temp *= 180 / Math.PI ' rads To degs, range (-180, 180]
        Return temp
    End Function

    Private Function GetAngle360(cx As Double, cy As Double, ex As Double, ey As Double)
        Dim temp As Double
        temp = GetAngle(cx, cy, ex, ey) ' range (-180, 180]
        If temp < 0 Then temp = 360 + temp ' range [0, 360)
        Return temp
    End Function

    Private Sub TimerAnimation_Tick(sender As Object, e As EventArgs) Handles TimerAnimation.Tick
        Dim x, z As Integer
        If (OriginPosition.X = DestinationTarget.X And (OriginPosition.Y = DestinationTarget.Y Or OriginPosition.Z = DestinationTarget.Z)) Then 'Biar berhenti ayamnya masih belum jalan pas tapi.
            TimerAnimation.Enabled = False
        End If

        If WalkMode Then
            If OriginPosition.X = DestinationTarget.X And OriginPosition.Y = DestinationTarget.Z Then
                TimerAnimation.Enabled = False
            End If
            If currentTheta < theta Then
                clockwise = True
                counterClockwise = False
                TurnBodyAnimation.Enabled = True
                currentTheta = theta
            ElseIf currentTheta > theta Then
                'Console.WriteLine(currentTheta)
                'Console.WriteLine(theta)
                clockwise = False
                counterClockwise = True
                TurnBodyAnimation.Enabled = True
                currentTheta = theta
            End If
            If addition = 0 Then
                '  Console.WriteLine(Math.Abs(Math.Floor(OriginPosition.Y)))
                ' Console.WriteLine(Math.Floor((1.75 * DestinationTarget.Z)))
                Console.WriteLine(Math.Floor(OriginPosition.Y))
                'OriginPosition.Y = 250
                ' Console.WriteLine(Math.Abs(Math.Floor(1.75 * DestinationTarget.Z) - Math.Floor(OriginPosition.Y)))
                If DestinationTarget.Z > OriginPosition.Y And Math.Floor(DestinationTarget.Z) - Math.Floor(OriginPosition.Y) < v Then
                    ' MessageBox.Show("Test")
                    TimerAnimation.Enabled = False
                    ' ElseIf Math.Floor(DestinationTarget.Z) + Math.Floor(OriginPosition.Y) < v Then
                    '    TimerAnimation.Enabled = False
                Else
                    dirx = Math.Cos(theta * Math.PI / 180)
                    diry = Math.Sin(theta * Math.PI / 180)
                    '  Console.WriteLine(dirx)
                    '  Console.WriteLine(diry)
                    vx = v * dirx
                    vy = v * diry
                    '    Console.WriteLine(vx)
                    '   Console.WriteLine(vy)
                    OriginPosition.X += vx
                    OriginPosition.Y += vy

                    ChickPos.Text = "Chicken: X = " + OriginPosition.X.ToString() + ", Y = 0" + ", Z = " + (OriginPosition.Y).ToString()
                    WalkingChicken()
                    HTree.First.Child.First.Transform.TranslateMat(vx / 50, 0, -(vy / 50))
                    g.Clear(Color.White)
                    TranverseChange(HTree.First, "torso", rotation)
                    TranverseTree(HTree.First)
                End If
            End If
        ElseIf FlyMode Then
            'TurnBodyAnimation.Enabled = True
            If OriginPosition.X = DestinationTarget.X And OriginPosition.Y = DestinationTarget.Z Then
                TimerAnimation.Enabled = False
            End If
            If currentTheta < theta Then
                clockwise = True
                counterClockwise = False
                TurnBodyAnimation.Enabled = True
                currentTheta = theta
            ElseIf currentTheta > theta Then
                'Console.WriteLine(currentTheta)
                'Console.WriteLine(theta)
                clockwise = False
                counterClockwise = True
                TurnBodyAnimation.Enabled = True
                currentTheta = theta
            End If
            FlyingChicken()
        ElseIf RotateMode Then 'Only to test
            TimerAnimation.Interval = 1 'Let's dance
            rotation += addition
            If rotation >= 360 Or rotation <= 0 Then
                TimerAnimation.Enabled = False
                TurnBodyAnimation.Enabled = False
            End If
            If rotation >= Round Or rotation <= -Round Then
                'addition = -addition
            End If
            g.Clear(Color.White)
            TranverseChange(HTree.First, "torso", rotation)
            TranverseTree(HTree.First)
        End If
    End Sub

End Class

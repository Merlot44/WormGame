Public Class WNDMain
    Public WelcomeWormBoxes() As Integer = {23, 24, 25, 26, 36, 46}
    Public WormBoxes() As Boolean = {
    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
    0, 0, 1, 1, 1, 0, 0, 0, 0, 0,
    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
    0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
    Public OrangeBoxes() As Boolean = {
    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
    0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
    Public WormHistory As Integer() = {43, 44, 45}
    Public Sound As Boolean = True
    Public Time As Integer = 0
    Public Points As Integer = 0
    Public Direction As String = “Right”
    Public OldDirection As String = “Right”
    Public Mode As String = "Normal"
    Public ActiveBox As Integer = 45
    Public ActiveOrange As Integer = 47
    Public FirstGame As Boolean = True
    Private Sub PBXSound_MouseHover(sender As Object, e As EventArgs) Handles PBXSound.MouseHover
        ' Check the Sound variable
        Select Case Sound
            Case True
                ' Change the sound icon to it`s hovered counterpart
                PBXSound.BackgroundImage = My.Resources.Unmute_Hover
            Case False
                ' Change the sound icon to it`s hovered counterpart
                PBXSound.BackgroundImage = My.Resources.Mute_Hover
        End Select
        ' Change the cursor to a hand
        PBXSound.Cursor = Cursors.Hand
    End Sub
    Private Sub PBXSound_MouseLeave(sender As Object, e As EventArgs) Handles PBXSound.MouseLeave
        ' Check the Sound variable
        Select Case Sound
            Case True
                ' Change the sound icon to it`s normal counterpart
                PBXSound.BackgroundImage = My.Resources.Unmute
            Case False
                ' Change the sound icon to it`s normal counterpart
                PBXSound.BackgroundImage = My.Resources.Mute
        End Select
    End Sub
    Private Sub WNDMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' Randomize Rnd() function
        Randomize()
        ' Iterate through every box number in the WelcomeWormBoxes array
        For Box As Integer = 0 To (WelcomeWormBoxes.Length() - 1)
            ' Check if it's less than the last box of the array
            If Box < (WelcomeWormBoxes.Length() - 1) Then
                ' Set the colour of the box to brown
                Me.Controls("Box" & CStr(WelcomeWormBoxes(Box))).BackColor = Color.FromArgb(185, 105, 0)
            Else
                ' Set the colour of the box to transparent
                Me.Controls("Box" & CStr(WelcomeWormBoxes(Box))).BackColor = Color.Transparent
                ' Set the background image of the box to the down-facing worm face
                Me.Controls("Box" & CStr(WelcomeWormBoxes(Box))).BackgroundImage = My.Resources.Face_Down
            End If
            ' Show the box
            Me.Controls("Box" & CStr(WelcomeWormBoxes(Box))).Visible = True
        Next
    End Sub
    Private Sub PBXSound_Click(sender As Object, e As EventArgs) Handles PBXSound.Click
        ' Invert the Sound variable
        Sound = Not Sound
        ' Check the Sound variable
        Select Case Sound
            Case True
                ' Play a click sound
                My.Computer.Audio.Play(My.Resources.Click, AudioPlayMode.Background)
                ' Change the background image of the sound icon to the hovered counterpart of the green icon
                PBXSound.BackgroundImage = My.Resources.Unmute_Hover
            Case False
                ' Stop all audio
                My.Computer.Audio.Stop()
                ' Change the background image of the sound icon to the hovered counterpart of the red icon
                PBXSound.BackgroundImage = My.Resources.Mute_Hover
        End Select
    End Sub
    Private Sub BTNInstructions_Click(sender As Object, e As EventArgs) Handles BTNInstructions.Click
        ' Hide unused controls
        LBLWelcome.Visible = False
        BTNStart.Visible = False
        BTNInstructions.Visible = False
        ' Iterate through every box number in the WelcomeWormBoxes array
        For Box As Integer = 0 To (WelcomeWormBoxes.Length() - 1)
            ' Hide the box
            Me.Controls("Box" & CStr(WelcomeWormBoxes(Box))).Visible = False
        Next
        ' Mode the start button to the bottom of the screen
        BTNStart.Location = New Point(147, 485)
        ' Show new controls
        BTNStart.Visible = True
        LBLInstructionsIntro.Visible = True
        LBLInstructions.Visible = True
    End Sub
    Private Sub BTNStart_Click(sender As Object, e As EventArgs) Handles BTNStart.Click
        ' Hide unused controls
        LBLWelcome.Visible = False
        LBLInstructionsIntro.Visible = False
        LBLInstructions.Visible = False
        BTNStart.Visible = False
        BTNInstructions.Visible = False
        ' Reset variables
        Time = 0
        Points = 0
        Direction = "Right"
        ' Iterate through every box number in the WelcomeWormBoxes array
        For Box As Integer = 0 To (WelcomeWormBoxes.Length() - 1)
            ' Hide the box
            Me.Controls("Box" & CStr(WelcomeWormBoxes(Box))).Visible = False
        Next
        'Show new elements
        LBLSelectMode.Visible = True
        BTNNormal.Visible = True
        BTNAdvanced.Visible = True
        PBXNormal.Visible = True
        PBXAdvanced.Visible = True
    End Sub
    Private Sub BTNNormal_Click(sender As Object, e As EventArgs) Handles BTNNormal.Click
        ' Hide unused controls
        LBLSelectMode.Visible = False
        BTNNormal.Visible = False
        BTNAdvanced.Visible = False
        PBXNormal.Visible = False
        PBXAdvanced.Visible = False
        ' Change the Mode variable to "Normal"
        Mode = "Normal"
        ' Change background image to the game background
        BackgroundImage = My.Resources.Play
        ' Iterate through every box number in the WormBoxes array
        For Box As Integer = 1 To WormBoxes.Length()
            ' Check the status of the box
            If Box = ActiveBox Then
                ' Change the colour of the box to green
                Me.Controls("Box" & CStr(Box)).BackColor = Color.FromArgb(147, 196, 125)
                ' Change the background image of the box to the right-facing worm face
                Me.Controls("Box" & CStr(Box)).BackgroundImage = My.Resources.Face_Right
            ElseIf WormBoxes(Box - 1) = False Then
                ' Change the colour of the box to green
                Me.Controls("Box" & CStr(Box)).BackColor = Color.FromArgb(147, 196, 125)
                ' Remove the background image of the box
                Me.Controls("Box" & CStr(Box)).BackgroundImage = Nothing
            ElseIf WormBoxes(Box - 1) = True Then
                ' Change the colour of the box to brown
                Me.Controls("Box" & CStr(Box)).BackColor = Color.FromArgb(185, 105, 0)
                ' Remove the background image of the box
                Me.Controls("Box" & CStr(Box)).BackgroundImage = Nothing
            End If
            ' Show the box
            Me.Controls("Box" & CStr(Box)).Visible = True
        Next
        ' Change the colour of the box to green
        Me.Controls("Box" & CStr(ActiveOrange)).BackColor = Color.FromArgb(147, 196, 125)
        ' Change the background image of the active orange box to an orange
        Me.Controls("Box" & CStr(ActiveOrange)).BackgroundImage = My.Resources.Orange
        ' Choose another box for the next orange
        ActiveOrange = Fix(Rnd() * 100)
        ' Make sure the active orange box isn't on the worm or a pre-existing orange
        While OrangeBoxes(ActiveOrange - 1) = True Or WormBoxes(ActiveOrange - 1) = True
            ' Choose another box for the next orange
            ActiveOrange = Fix(Rnd() * 100)
        End While
        ' Change the status of the active orange box in the OrangeBoxes array
        OrangeBoxes(ActiveOrange) = True
        ' Change the colour of the box to green
        Me.Controls("Box" & CStr(ActiveOrange)).BackColor = Color.FromArgb(147, 196, 125)
        ' Change the background image of the active orange box to an orange
        Me.Controls("Box" & CStr(ActiveOrange)).BackgroundImage = My.Resources.Orange
        ' Choose another box for the next orange
        ActiveOrange = Fix(Rnd() * 100)
        ' Make sure the active orange box isn't on the worm or a pre-existing orange
        While OrangeBoxes(ActiveOrange) = True Or WormBoxes(ActiveOrange) = True
            ' Choose another box for the next orange
            ActiveOrange = Fix(Rnd() * 100)
        End While
        ' Change the status of the active orange box in the OrangeBoxes array
        OrangeBoxes(ActiveOrange) = True
        ' Change the colour of the box to green
        Me.Controls("Box" & CStr(ActiveOrange)).BackColor = Color.FromArgb(147, 196, 125)
        ' Change the background image of the active orange box to an orange
        Me.Controls("Box" & CStr(ActiveOrange)).BackgroundImage = My.Resources.Orange
        ' Show new controls
        PBXPoints.Visible = True
        LBLPoints.Visible = True
        LBLTime.Visible = True
        LBLArrows.Visible = True
    End Sub

    Private Sub BTNAdvanced_Click(sender As Object, e As EventArgs) Handles BTNAdvanced.Click
        ' Hide unused controls
        LBLSelectMode.Visible = False
        BTNNormal.Visible = False
        BTNAdvanced.Visible = False
        PBXNormal.Visible = False
        PBXAdvanced.Visible = False
        ' Change the Mode variable to "Advanced"
        Mode = "Advanced"
        ' Change background image to the game background
        BackgroundImage = My.Resources.Play
        ' Iterate through every box number in the WormBoxes array
        For Box As Integer = 1 To WormBoxes.Length()
            ' Check the status of the box
            If Box = ActiveBox Then
                ' Change the colour of the box to green
                Me.Controls("Box" & CStr(Box)).BackColor = Color.FromArgb(147, 196, 125)
                ' Change the background image of the box to the right-facing worm face
                Me.Controls("Box" & CStr(Box)).BackgroundImage = My.Resources.Face_Right
            ElseIf WormBoxes(Box - 1) = False Then
                ' Change the colour of the box to green
                Me.Controls("Box" & CStr(Box)).BackColor = Color.FromArgb(147, 196, 125)
                ' Remove the background image of the box
                Me.Controls("Box" & CStr(Box)).BackgroundImage = Nothing
            ElseIf WormBoxes(Box - 1) = True Then
                ' Change the colour of the box to brown
                Me.Controls("Box" & CStr(Box)).BackColor = Color.FromArgb(185, 105, 0)
                ' Remove the background image of the box
                Me.Controls("Box" & CStr(Box)).BackgroundImage = Nothing
            End If
            ' Show the box
            Me.Controls("Box" & CStr(Box)).Visible = True
        Next
        ' Change the colour of the box to green
        Me.Controls("Box" & CStr(ActiveOrange)).BackColor = Color.FromArgb(147, 196, 125)
        ' Change the background image of the active orange box to an orange
        Me.Controls("Box" & CStr(ActiveOrange)).BackgroundImage = My.Resources.Orange
        ' Show new controls
        PBXPoints.Visible = True
        LBLPoints.Visible = True
        LBLTime.Visible = True
        LBLArrows.Visible = True
    End Sub
    Private Sub WNDMain_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        ' Check what key got pressed
        Select Case e.KeyValue
            Case Keys.Up
                ' Check if it's the first game
                If FirstGame = True Then
                    ' Hide unused controls
                    LBLArrows.Visible = False
                    ' Enable the timers
                    TMRTime.Enabled = True
                    TMRGame.Enabled = True
                End If
                ' Set the old direction to the current direction
                OldDirection = Direction
                ' Set the current direction to the new direction
                Direction = "Up"
            Case Keys.Right
                ' Check if it's the first game
                If FirstGame = True Then
                    ' Hide unused controls
                    LBLArrows.Visible = False
                    ' Enable the timers
                    TMRTime.Enabled = True
                    TMRGame.Enabled = True
                End If
                ' Set the old direction to the current direction
                OldDirection = Direction
                ' Set the current direction to the new direction
                Direction = "Right"
            Case Keys.Down
                ' Check if it's the first game
                If FirstGame = True Then
                    ' Hide unused controls
                    LBLArrows.Visible = False
                    ' Enable the timers
                    TMRTime.Enabled = True
                    TMRGame.Enabled = True
                End If
                ' Set the old direction to the current direction
                OldDirection = Direction
                ' Set the current direction to the new direction
                Direction = "Down"
            Case Keys.Left
                ' Check if it's the first game
                If FirstGame = True Then
                    ' Hide unused controls
                    LBLArrows.Visible = False
                    ' Enable the timers
                    TMRTime.Enabled = True
                    TMRGame.Enabled = True
                End If
                ' Set the old direction to the current direction
                OldDirection = Direction
                ' Set the current direction to the new direction
                Direction = "Left"
        End Select
    End Sub
    Private Sub TMRGame_Tick(sender As Object, e As EventArgs) Handles TMRGame.Tick
        ' Check the direction
        If Direction = "Up" And Not (OldDirection = "Down") Then
            ' Check if the box is inside the play area
            If (ActiveBox - 10) > 0 Then
                ' Check if the box is used by the worm
                If WormBoxes(ActiveBox - 10) = False Then
                    ' Change the status of the new box
                    WormBoxes(ActiveBox - 10) = True
                    ' Check if the worm caught an orange
                    If OrangeBoxes(ActiveBox = 10) = False Then
                        ' Change the colour of the first box of the WormHistory array to green
                        Me.Controls("Box" & CStr(WormHistory(0))).BackColor = Color.FromArgb(147, 196, 125)
                        ' Set the status of the WormBoxes array
                        WormBoxes(WormHistory(0)) = False
                        ' Shift the WormHistory array by one box to the left
                        For Box As Integer = 0 To (WormHistory.Length() - 2)
                            WormHistory(Box) = WormHistory(Box + 1)
                        Next
                        ' Change the last box of the WormHistory array to the new box
                        WormHistory(WormHistory.Length() - 1) = (ActiveBox - 10)
                    Else
                        ' Choose another box for the next orange
                        ActiveOrange = Fix(Rnd() * 100)
                        ' Make sure the active orange box isn't on the worm or a pre-existing orange
                        While OrangeBoxes(ActiveOrange - 1) = True Or WormBoxes(ActiveOrange - 1) = True
                            ' Choose another box for the next orange
                            ActiveOrange = Fix(Rnd() * 100)
                        End While
                        ' Change the status of the active orange box in the OrangeBoxes array
                        OrangeBoxes(ActiveOrange) = True
                        ' Change the colour of the box to green
                        Me.Controls("Box" & CStr(ActiveOrange)).BackColor = Color.FromArgb(147, 196, 125)
                        ' Change the background image of the active orange box to an orange
                        Me.Controls("Box" & CStr(ActiveOrange)).BackgroundImage = My.Resources.Orange
                        ' Add the new box to the WormHistory array
                        WormHistory(WormHistory.Length()) = (ActiveBox - 10)
                    End If
                    ' Change the back colour of the active box to brown
                    Me.Controls("Box" & CStr(ActiveBox)).BackColor = Color.FromArgb(185, 105, 0)
                    ' Remove the background image of the active box
                    Me.Controls("Box" & CStr(ActiveBox)).BackgroundImage = Nothing
                    ' Change the backround image of the new box to the up-facing worm face
                    Me.Controls("Box" & CStr(ActiveBox - 10)).BackgroundImage = My.Resources.Face_Up
                    ' Change ActiveBox to the new box
                    ActiveBox = (ActiveBox - 10)
                Else
                    '-----------------------Game Over-----------------------
                End If
            Else
                '-----------------------Game Over-----------------------
            End If
        End If
    End Sub
End Class

Public Class WNDMain
    ' Define variables
    Public WelcomeWormBoxes() As Integer = {23, 24, 25, 26, 36, 46}
    Public GameOverWormBoxes() As Integer = {13, 14, 15, 16, 26, 36}
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
    Public Time As Integer = 0
    Public Points As Integer = 0
    Public Direction As String = “Right”
    Public OldDirection As String = “Right”
    Public Mode As String = "Hard"
    Public ActiveBox As Integer = 45
    Public ActiveOrange As Integer = 47
    ' Define flags
    Public Sound As Boolean = True
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
        ' Check sound status
        If Sound = True Then
            ' Play a click sound
            My.Computer.Audio.Play(My.Resources.Click, AudioPlayMode.Background)
        End If
        ' Hide unused controls
        LBLWelcome.Visible = False
        BTNStart.Visible = False
        BTNInstructions.Visible = False
        ' Iterate through every box number in the WelcomeWormBoxes array
        For Box = 0 To WelcomeWormBoxes.Length - 1
            ' Hide the box
            Controls("Box" & WelcomeWormBoxes(Box)).Visible = False
        Next
        ' Mode the start button to the bottom of the screen
        BTNStart.Location = New Point(147, 485)
        ' Show new controls
        BTNStart.Visible = True
        LBLInstructionsIntro.Visible = True
        LBLInstructions.Visible = True
    End Sub
    Private Sub BTNStart_Click(sender As Object, e As EventArgs) Handles BTNStart.Click
        ' Check sound status
        If Sound = True Then
            ' Play a click sound
            My.Computer.Audio.Play(My.Resources.Click, AudioPlayMode.Background)
        End If
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
        BTNEasy.Visible = True
        BTNHard.Visible = True
        PBXEasy.Visible = True
        PBXHard.Visible = True
    End Sub
    Private Sub BTNEasy_Click(sender As Object, e As EventArgs) Handles BTNEasy.Click
        ' Check sound status
        If Sound = True Then
            ' Play a click sound
            My.Computer.Audio.Play(My.Resources.Click, AudioPlayMode.Background)
        End If
        ' Hide unused controls
        LBLSelectMode.Visible = False
        BTNEasy.Visible = False
        BTNHard.Visible = False
        PBXEasy.Visible = False
        PBXHard.Visible = False
        ' Change the Mode variable to "Easy"
        Mode = "Easy"
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
        ' Change the status of the active orange box in the OrangeBoxes array
        OrangeBoxes(ActiveOrange - 1) = True
        ' Change the colour of the box to green
        Me.Controls("Box" & CStr(ActiveOrange)).BackColor = Color.FromArgb(147, 196, 125)
        ' Change the background image of the active orange box to an orange
        Me.Controls("Box" & CStr(ActiveOrange)).BackgroundImage = My.Resources.Orange
        ' Choose another box for the next orange
        ActiveOrange = Int(Rnd() * 100) + 1
        ' Make sure the active orange box isn't on the worm or a pre-existing orange
        While OrangeBoxes(ActiveOrange - 1) = True Or WormBoxes(ActiveOrange - 1) = True
            ' Choose another box for the next orange
            ActiveOrange = Int(Rnd() * 100) + 1
        End While
        ' Change the status of the active orange box in the OrangeBoxes array
        OrangeBoxes(ActiveOrange - 1) = True
        ' Change the colour of the box to green
        Me.Controls("Box" & CStr(ActiveOrange)).BackColor = Color.FromArgb(147, 196, 125)
        ' Change the background image of the active orange box to an orange
        Me.Controls("Box" & CStr(ActiveOrange)).BackgroundImage = My.Resources.Orange
        ' Choose another box for the next orange
        ActiveOrange = Int(Rnd() * 100) + 1
        ' Make sure the active orange box isn't on the worm or a pre-existing orange
        While OrangeBoxes(ActiveOrange - 1) = True Or WormBoxes(ActiveOrange - 1) = True
            ' Choose another box for the next orange
            ActiveOrange = Int(Rnd() * 100) + 1
        End While
        ' Change the status of the active orange box in the OrangeBoxes array
        OrangeBoxes(ActiveOrange - 1) = True
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

    Private Sub BTNHard_Click(sender As Object, e As EventArgs) Handles BTNHard.Click
        ' Check sound status
        If Sound = True Then
            ' Play a click sound
            My.Computer.Audio.Play(My.Resources.Click, AudioPlayMode.Background)
        End If
        ' Hide unused controls
        LBLSelectMode.Visible = False
        BTNEasy.Visible = False
        BTNHard.Visible = False
        PBXEasy.Visible = False
        PBXHard.Visible = False
        ' Change the Mode variable to "Hard"
        Mode = "Hard"
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
        ' Change the status of the active orange box in the OrangeBoxes array
        OrangeBoxes(ActiveOrange - 1) = True
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
                If WormBoxes((ActiveBox - 10) - 1) = False Or ((ActiveBox - 10) - 1) = WormHistory(0) Then
                    ' Change the status of the new box
                    WormBoxes((ActiveBox - 10) - 1) = True
                    ' Check if the worm caught an orange
                    If OrangeBoxes((ActiveBox - 10) - 1) = False Then
                        ' Change the colour of the first box of the WormHistory array to green
                        Me.Controls("Box" & CStr(WormHistory(0))).BackColor = Color.FromArgb(147, 196, 125)
                        ' Set the status of the WormBoxes array
                        WormBoxes(WormHistory(0) - 1) = False
                        ' Shift the WormHistory array by one box to the left
                        For Box As Integer = 0 To (WormHistory.Length() - 2)
                            WormHistory(Box) = WormHistory(Box + 1)
                        Next
                        ' Change the last box of the WormHistory array to the new box
                        WormHistory(WormHistory.Length() - 1) = (ActiveBox - 10)
                    Else
                        ' Choose another box for the next orange
                        ActiveOrange = Int(Rnd() * 100) + 1
                        ' Make sure the active orange box isn't on the worm or a pre-existing orange
                        While OrangeBoxes(ActiveOrange - 1) = True Or WormBoxes(ActiveOrange - 1) = True
                            ' Choose another box for the next orange
                            ActiveOrange = Int(Rnd() * 100) + 1
                        End While
                        ' Change the status of the active worm box in the OrangeBoxes array
                        OrangeBoxes((ActiveBox - 10) - 1) = False
                        ' Change the status of the active orange box in the OrangeBoxes array
                        OrangeBoxes(ActiveOrange - 1) = True
                        ' Change the colour of the box to green
                        Me.Controls("Box" & CStr(ActiveOrange)).BackColor = Color.FromArgb(147, 196, 125)
                        ' Change the background image of the active orange box to an orange
                        Me.Controls("Box" & CStr(ActiveOrange)).BackgroundImage = My.Resources.Orange
                        ' Resize the WormHistory array
                        ReDim Preserve WormHistory(WormHistory.Length)
                        ' Add the new box to the WormHistory array
                        WormHistory(WormHistory.Length() - 1) = (ActiveBox - 10)
                        ' Increment the number of points
                        Points += 1
                        ' Update the points label
                        LBLPoints.Text = ": " + CStr(Points)
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
                    ' Disable timers
                    TMRGame.Enabled = False
                    TMRTime.Enabled = False
                    ' Sleep for half of a second
                    Application.DoEvents()
                    Threading.Thread.Sleep(500)
                    ' Iterate through every box number in the WormBoxes array
                    For Box As Integer = 1 To WormBoxes.Length()
                        ' Hide the box
                        Me.Controls("Box" & CStr(Box)).Visible = False
                        ' Remove the background image of the box
                        Me.Controls("Box" & CStr(Box)).BackgroundImage = Nothing
                    Next
                    ' Change the background image to the empty image
                    BackgroundImage = My.Resources.Empty
                    ' Iterate through every box number in the GameOverWormBoxes array
                    For Box As Integer = 0 To (GameOverWormBoxes.Length() - 1)
                        ' Check if it's less than the last box of the array
                        If Box < (GameOverWormBoxes.Length() - 1) Then
                            ' Set the colour of the box to brown
                            Me.Controls("Box" & CStr(GameOverWormBoxes(Box))).BackColor = Color.FromArgb(185, 105, 0)
                        Else
                            ' Set the colour of the box to transparent
                            Me.Controls("Box" & CStr(GameOverWormBoxes(Box))).BackColor = Color.Transparent
                            ' Set the background image of the box to the sad worm face
                            Me.Controls("Box" & CStr(GameOverWormBoxes(Box))).BackgroundImage = My.Resources.Face_Sad
                        End If
                        ' Show the box
                        Me.Controls("Box" & CStr(GameOverWormBoxes(Box))).Visible = True
                    Next
                    ' Show new controls
                    LBLGameOver.Visible = True
                    BTNRestart.Visible = True
                End If
            Else
                ' Disable timers
                TMRGame.Enabled = False
                TMRTime.Enabled = False
                ' Sleep for half of a second
                Application.DoEvents()
                Threading.Thread.Sleep(500)
                ' Iterate through every box number in the WormBoxes array
                For Box As Integer = 1 To WormBoxes.Length()
                    ' Hide the box
                    Me.Controls("Box" & CStr(Box)).Visible = False
                    ' Remove the background image from the box
                    Me.Controls("Box" & CStr(Box)).BackgroundImage = Nothing
                    ' Set the back colour ofthe box to green
                    Me.Controls("Box" & CStr(Box)).BackColor = Color.FromArgb(147, 196, 125)
                Next
                ' Change the background image to the empty image
                BackgroundImage = My.Resources.Empty
                ' Iterate through every box number in the GameOverWormBoxes array
                For Box As Integer = 0 To (GameOverWormBoxes.Length() - 1)
                    ' Check if it's less than the last box of the array
                    If Box < (GameOverWormBoxes.Length() - 1) Then
                        ' Set the colour of the box to brown
                        Me.Controls("Box" & CStr(GameOverWormBoxes(Box))).BackColor = Color.FromArgb(185, 105, 0)
                    Else
                        ' Set the colour of the box to transparent
                        Me.Controls("Box" & CStr(GameOverWormBoxes(Box))).BackColor = Color.Transparent
                        ' Set the background image of the box to the sad worm face
                        Me.Controls("Box" & CStr(GameOverWormBoxes(Box))).BackgroundImage = My.Resources.Face_Sad
                    End If
                    ' Show the box
                    Me.Controls("Box" & CStr(GameOverWormBoxes(Box))).Visible = True
                Next
                ' Show new controls
                LBLGameOver.Visible = True
                BTNRestart.Visible = True
            End If
        ElseIf Direction = "Right" And Not (OldDirection = "Left") Then
            ' Check if the box is inside the play area
            If (ActiveBox + 1) <= (Math.Ceiling(ActiveBox / 10) * 10) Then
                ' Check if the box is used by the worm
                If WormBoxes((ActiveBox + 1) - 1) = False Or ((ActiveBox + 1) - 1) = WormHistory(0) Then
                    ' Change the status of the new box
                    WormBoxes((ActiveBox + 1) - 1) = True
                    ' Check if the worm caught an orange
                    If OrangeBoxes((ActiveBox + 1) - 1) = False Then
                        ' Change the colour of the first box of the WormHistory array to green
                        Me.Controls("Box" & CStr(WormHistory(0))).BackColor = Color.FromArgb(147, 196, 125)
                        ' Set the status of the WormBoxes array
                        WormBoxes(WormHistory(0) - 1) = False
                        ' Shift the WormHistory array by one box to the left
                        For Box As Integer = 0 To (WormHistory.Length() - 2)
                            WormHistory(Box) = WormHistory(Box + 1)
                        Next
                        ' Change the last box of the WormHistory array to the new box
                        WormHistory(WormHistory.Length() - 1) = (ActiveBox + 1)
                    Else
                        ' Choose another box for the next orange
                        ActiveOrange = Int(Rnd() * 100) + 1
                        ' Make sure the active orange box isn't on the worm or a pre-existing orange
                        While OrangeBoxes(ActiveOrange - 1) = True Or WormBoxes(ActiveOrange - 1) = True
                            ' Choose another box for the next orange
                            ActiveOrange = Int(Rnd() * 100) + 1
                        End While
                        ' Change the status of the active worm box in the OrangeBoxes array
                        OrangeBoxes((ActiveBox + 1) - 1) = False
                        ' Change the status of the active orange box in the OrangeBoxes array
                        OrangeBoxes(ActiveOrange - 1) = True
                        ' Change the colour of the box to green
                        Me.Controls("Box" & CStr(ActiveOrange)).BackColor = Color.FromArgb(147, 196, 125)
                        ' Change the background image of the active orange box to an orange
                        Me.Controls("Box" & CStr(ActiveOrange)).BackgroundImage = My.Resources.Orange
                        ' Resize the WormHistory array
                        ReDim Preserve WormHistory(WormHistory.Length)
                        ' Add the new box to the WormHistory array
                        WormHistory(WormHistory.Length() - 1) = (ActiveBox + 1)
                        ' Increment the number of points
                        Points += 1
                        ' Update the points label
                        LBLPoints.Text = ": " + CStr(Points)
                    End If
                    ' Change the back colour of the active box to brown
                    Me.Controls("Box" & CStr(ActiveBox)).BackColor = Color.FromArgb(185, 105, 0)
                    ' Remove the background image of the active box
                    Me.Controls("Box" & CStr(ActiveBox)).BackgroundImage = Nothing
                    ' Change the backround image of the new box to the right-facing worm face
                    Me.Controls("Box" & CStr(ActiveBox + 1)).BackgroundImage = My.Resources.Face_Right
                    ' Change ActiveBox to the new box
                    ActiveBox = (ActiveBox + 1)
                Else
                    ' Disable timers
                    TMRGame.Enabled = False
                    TMRTime.Enabled = False
                    ' Sleep for half of a second
                    Application.DoEvents()
                    Threading.Thread.Sleep(500)
                    ' Iterate through every box number in the WormBoxes array
                    For Box As Integer = 1 To WormBoxes.Length()
                        ' Hide the box
                        Me.Controls("Box" & CStr(Box)).Visible = False
                        ' Remove the background image of the box
                        Me.Controls("Box" & CStr(Box)).BackgroundImage = Nothing
                    Next
                    ' Change the background image to the empty image
                    BackgroundImage = My.Resources.Empty
                    ' Iterate through every box number in the GameOverWormBoxes array
                    For Box As Integer = 0 To (GameOverWormBoxes.Length() - 1)
                        ' Check if it's less than the last box of the array
                        If Box < (GameOverWormBoxes.Length() - 1) Then
                            ' Set the colour of the box to brown
                            Me.Controls("Box" & CStr(GameOverWormBoxes(Box))).BackColor = Color.FromArgb(185, 105, 0)
                        Else
                            ' Set the colour of the box to transparent
                            Me.Controls("Box" & CStr(GameOverWormBoxes(Box))).BackColor = Color.Transparent
                            ' Set the background image of the box to the sad worm face
                            Me.Controls("Box" & CStr(GameOverWormBoxes(Box))).BackgroundImage = My.Resources.Face_Sad
                        End If
                        ' Show the box
                        Me.Controls("Box" & CStr(GameOverWormBoxes(Box))).Visible = True
                    Next
                    ' Show new controls
                    LBLGameOver.Visible = True
                    BTNRestart.Visible = True
                End If
            Else
                ' Disable timers
                TMRGame.Enabled = False
                TMRTime.Enabled = False
                ' Sleep for half of a second
                Application.DoEvents()
                Threading.Thread.Sleep(500)
                ' Iterate through every box number in the WormBoxes array
                For Box As Integer = 1 To WormBoxes.Length()
                    ' Hide the box
                    Me.Controls("Box" & CStr(Box)).Visible = False
                    ' Remove the background image from the box
                    Me.Controls("Box" & CStr(Box)).BackgroundImage = Nothing
                    ' Set the back colour ofthe box to green
                    Me.Controls("Box" & CStr(Box)).BackColor = Color.FromArgb(147, 196, 125)
                Next
                ' Change the background image to the empty image
                BackgroundImage = My.Resources.Empty
                ' Iterate through every box number in the GameOverWormBoxes array
                For Box As Integer = 0 To (GameOverWormBoxes.Length() - 1)
                    ' Check if it's less than the last box of the array
                    If Box < (GameOverWormBoxes.Length() - 1) Then
                        ' Set the colour of the box to brown
                        Me.Controls("Box" & CStr(GameOverWormBoxes(Box))).BackColor = Color.FromArgb(185, 105, 0)
                    Else
                        ' Set the colour of the box to transparent
                        Me.Controls("Box" & CStr(GameOverWormBoxes(Box))).BackColor = Color.Transparent
                        ' Set the background image of the box to the sad worm face
                        Me.Controls("Box" & CStr(GameOverWormBoxes(Box))).BackgroundImage = My.Resources.Face_Sad
                    End If
                    ' Show the box
                    Me.Controls("Box" & CStr(GameOverWormBoxes(Box))).Visible = True
                Next
                ' Show new controls
                LBLGameOver.Visible = True
                BTNRestart.Visible = True
            End If
        ElseIf Direction = "Down" And Not (OldDirection = "Up") Then
            ' Check if the box is inside the play area
            If (ActiveBox + 10) < WormBoxes.Length Then
                ' Check if the box is used by the worm
                If WormBoxes((ActiveBox + 10) - 1) = False Or ((ActiveBox + 10) - 1) = WormHistory(0) Then
                    ' Change the status of the new box
                    WormBoxes((ActiveBox + 10) - 1) = True
                    ' Check if the worm caught an orange
                    If OrangeBoxes((ActiveBox + 10) - 1) = False Then
                        ' Change the colour of the first box of the WormHistory array to green
                        Me.Controls("Box" & CStr(WormHistory(0))).BackColor = Color.FromArgb(147, 196, 125)
                        ' Set the status of the WormBoxes array
                        WormBoxes(WormHistory(0) - 1) = False
                        ' Shift the WormHistory array by one box to the left
                        For Box As Integer = 0 To (WormHistory.Length() - 2)
                            WormHistory(Box) = WormHistory(Box + 1)
                        Next
                        ' Change the last box of the WormHistory array to the new box
                        WormHistory(WormHistory.Length() - 1) = (ActiveBox + 10)
                    Else
                        ' Choose another box for the next orange
                        ActiveOrange = Int(Rnd() * 100) + 1
                        ' Make sure the active orange box isn't on the worm or a pre-existing orange
                        While OrangeBoxes(ActiveOrange - 1) = True Or WormBoxes(ActiveOrange - 1) = True
                            ' Choose another box for the next orange
                            ActiveOrange = Int(Rnd() * 100) + 1
                        End While
                        ' Change the status of the active worm box in the OrangeBoxes array
                        OrangeBoxes((ActiveBox + 10) - 1) = False
                        ' Change the status of the active orange box in the OrangeBoxes array
                        OrangeBoxes(ActiveOrange - 1) = True
                        ' Change the colour of the box to green
                        Me.Controls("Box" & CStr(ActiveOrange)).BackColor = Color.FromArgb(147, 196, 125)
                        ' Change the background image of the active orange box to an orange
                        Me.Controls("Box" & CStr(ActiveOrange)).BackgroundImage = My.Resources.Orange
                        ' Resize the WormHistory array
                        ReDim Preserve WormHistory(WormHistory.Length)
                        ' Add the new box to the WormHistory array
                        WormHistory(WormHistory.Length() - 1) = (ActiveBox + 10)
                        ' Increment the number of points
                        Points += 1
                        ' Update the points label
                        LBLPoints.Text = ": " + CStr(Points)
                    End If
                    ' Change the back colour of the active box to brown
                    Me.Controls("Box" & CStr(ActiveBox)).BackColor = Color.FromArgb(185, 105, 0)
                    ' Remove the background image of the active box
                    Me.Controls("Box" & CStr(ActiveBox)).BackgroundImage = Nothing
                    ' Change the backround image of the new box to the Down-facing worm face
                    Me.Controls("Box" & CStr(ActiveBox + 10)).BackgroundImage = My.Resources.Face_Down
                    ' Change ActiveBox to the new box
                    ActiveBox = (ActiveBox + 10)
                Else
                    ' Disable timers
                    TMRGame.Enabled = False
                    TMRTime.Enabled = False
                    ' Sleep for half of a second
                    Application.DoEvents()
                    Threading.Thread.Sleep(500)
                    ' Iterate through every box number in the WormBoxes array
                    For Box As Integer = 1 To WormBoxes.Length()
                        ' Hide the box
                        Me.Controls("Box" & CStr(Box)).Visible = False
                        ' Remove the background image of the box
                        Me.Controls("Box" & CStr(Box)).BackgroundImage = Nothing
                    Next
                    ' Change the background image to the empty image
                    BackgroundImage = My.Resources.Empty
                    ' Iterate through every box number in the GameOverWormBoxes array
                    For Box As Integer = 0 To (GameOverWormBoxes.Length() - 1)
                        ' Check if it's less than the last box of the array
                        If Box < (GameOverWormBoxes.Length() - 1) Then
                            ' Set the colour of the box to brown
                            Me.Controls("Box" & CStr(GameOverWormBoxes(Box))).BackColor = Color.FromArgb(185, 105, 0)
                        Else
                            ' Set the colour of the box to transparent
                            Me.Controls("Box" & CStr(GameOverWormBoxes(Box))).BackColor = Color.Transparent
                            ' Set the background image of the box to the sad worm face
                            Me.Controls("Box" & CStr(GameOverWormBoxes(Box))).BackgroundImage = My.Resources.Face_Sad
                        End If
                        ' Show the box
                        Me.Controls("Box" & CStr(GameOverWormBoxes(Box))).Visible = True
                    Next
                    ' Show new controls
                    LBLGameOver.Visible = True
                    BTNRestart.Visible = True
                End If
            Else
                ' Disable timers
                TMRGame.Enabled = False
                TMRTime.Enabled = False
                ' Sleep for half of a second
                Application.DoEvents()
                Threading.Thread.Sleep(500)
                ' Iterate through every box number in the WormBoxes array
                For Box As Integer = 1 To WormBoxes.Length()
                    ' Hide the box
                    Me.Controls("Box" & CStr(Box)).Visible = False
                    ' Remove the background image from the box
                    Me.Controls("Box" & CStr(Box)).BackgroundImage = Nothing
                    ' Set the back colour ofthe box to green
                    Me.Controls("Box" & CStr(Box)).BackColor = Color.FromArgb(147, 196, 125)
                Next
                ' Change the background image to the empty image
                BackgroundImage = My.Resources.Empty
                ' Iterate through every box number in the GameOverWormBoxes array
                For Box As Integer = 0 To (GameOverWormBoxes.Length() - 1)
                    ' Check if it's less than the last box of the array
                    If Box < (GameOverWormBoxes.Length() - 1) Then
                        ' Set the colour of the box to brown
                        Me.Controls("Box" & CStr(GameOverWormBoxes(Box))).BackColor = Color.FromArgb(185, 105, 0)
                    Else
                        ' Set the colour of the box to transparent
                        Me.Controls("Box" & CStr(GameOverWormBoxes(Box))).BackColor = Color.Transparent
                        ' Set the background image of the box to the sad worm face
                        Me.Controls("Box" & CStr(GameOverWormBoxes(Box))).BackgroundImage = My.Resources.Face_Sad
                    End If
                    ' Show the box
                    Me.Controls("Box" & CStr(GameOverWormBoxes(Box))).Visible = True
                Next
                ' Show new controls
                LBLGameOver.Visible = True
                BTNRestart.Visible = True
            End If
        ElseIf Direction = "Left" And Not (OldDirection = "Right") Then
            ' Check if the box is inside the play area
            If (ActiveBox - 1) > (Math.Floor((ActiveBox - 1) / 10) * 10) Then
                ' Check if the box is used by the worm
                If WormBoxes((ActiveBox - 1) - 1) = False Or ((ActiveBox - 1) - 1) = WormHistory(0) Then
                    ' Change the status of the new box
                    WormBoxes((ActiveBox - 1) - 1) = True
                    ' Check if the worm caught an orange
                    If OrangeBoxes((ActiveBox - 1) - 1) = False Then
                        ' Change the colour of the first box of the WormHistory array to green
                        Me.Controls("Box" & CStr(WormHistory(0))).BackColor = Color.FromArgb(147, 196, 125)
                        ' Set the status of the WormBoxes array
                        WormBoxes(WormHistory(0) - 1) = False
                        ' Shift the WormHistory array by one box to the left
                        For Box As Integer = 0 To (WormHistory.Length() - 2)
                            WormHistory(Box) = WormHistory(Box + 1)
                        Next
                        ' Change the last box of the WormHistory array to the new box
                        WormHistory(WormHistory.Length() - 1) = (ActiveBox - 1)
                    Else
                        ' Choose another box for the next orange
                        ActiveOrange = Int(Rnd() * 100) + 1
                        ' Make sure the active orange box isn't on the worm or a pre-existing orange
                        While OrangeBoxes(ActiveOrange - 1) = True Or WormBoxes(ActiveOrange - 1) = True
                            ' Choose another box for the next orange
                            ActiveOrange = Int(Rnd() * 100) + 1
                        End While
                        ' Change the status of the active worm box in the OrangeBoxes array
                        OrangeBoxes((ActiveBox - 1) - 1) = False
                        ' Change the status of the active orange box in the OrangeBoxes array
                        OrangeBoxes(ActiveOrange - 1) = True
                        ' Change the colour of the box to green
                        Me.Controls("Box" & CStr(ActiveOrange)).BackColor = Color.FromArgb(147, 196, 125)
                        ' Change the background image of the active orange box to an orange
                        Me.Controls("Box" & CStr(ActiveOrange)).BackgroundImage = My.Resources.Orange
                        ' Resize the WormHistory array
                        ReDim Preserve WormHistory(WormHistory.Length)
                        ' Add the new box to the WormHistory array
                        WormHistory(WormHistory.Length() - 1) = (ActiveBox - 1)
                        ' Increment the number of points
                        Points += 1
                        ' Update the points label
                        LBLPoints.Text = ": " + CStr(Points)
                    End If
                    ' Change the back colour of the active box to brown
                    Me.Controls("Box" & CStr(ActiveBox)).BackColor = Color.FromArgb(185, 105, 0)
                    ' Remove the background image of the active box
                    Me.Controls("Box" & CStr(ActiveBox)).BackgroundImage = Nothing
                    ' Change the backround image of the new box to the Left-facing worm face
                    Me.Controls("Box" & CStr(ActiveBox - 1)).BackgroundImage = My.Resources.Face_Left
                    ' Change ActiveBox to the new box
                    ActiveBox = (ActiveBox - 1)
                Else
                    ' Disable timers
                    TMRGame.Enabled = False
                    TMRTime.Enabled = False
                    ' Sleep for half of a second
                    Application.DoEvents()
                    Threading.Thread.Sleep(500)
                    ' Iterate through every box number in the WormBoxes array
                    For Box As Integer = 1 To WormBoxes.Length()
                        ' Hide the box
                        Me.Controls("Box" & CStr(Box)).Visible = False
                        ' Remove the background image of the box
                        Me.Controls("Box" & CStr(Box)).BackgroundImage = Nothing
                    Next
                    ' Change the background image to the empty image
                    BackgroundImage = My.Resources.Empty
                    ' Iterate through every box number in the GameOverWormBoxes array
                    For Box As Integer = 0 To (GameOverWormBoxes.Length() - 1)
                        ' Check if it's less than the last box of the array
                        If Box < (GameOverWormBoxes.Length() - 1) Then
                            ' Set the colour of the box to brown
                            Me.Controls("Box" & CStr(GameOverWormBoxes(Box))).BackColor = Color.FromArgb(185, 105, 0)
                        Else
                            ' Set the colour of the box to transparent
                            Me.Controls("Box" & CStr(GameOverWormBoxes(Box))).BackColor = Color.Transparent
                            ' Set the background image of the box to the sad worm face
                            Me.Controls("Box" & CStr(GameOverWormBoxes(Box))).BackgroundImage = My.Resources.Face_Sad
                        End If
                        ' Show the box
                        Me.Controls("Box" & CStr(GameOverWormBoxes(Box))).Visible = True
                    Next
                    ' Show new controls
                    LBLGameOver.Visible = True
                    BTNRestart.Visible = True
                End If
            Else
                ' Disable timers
                TMRGame.Enabled = False
                TMRTime.Enabled = False
                ' Sleep for half of a second
                Application.DoEvents()
                Threading.Thread.Sleep(500)
                ' Iterate through every box number in the WormBoxes array
                For Box As Integer = 1 To WormBoxes.Length()
                    ' Hide the box
                    Me.Controls("Box" & CStr(Box)).Visible = False
                    ' Remove the background image from the box
                    Me.Controls("Box" & CStr(Box)).BackgroundImage = Nothing
                    ' Set the back colour ofthe box to green
                    Me.Controls("Box" & CStr(Box)).BackColor = Color.FromArgb(147, 196, 125)
                Next
                ' Change the background image to the empty image
                BackgroundImage = My.Resources.Empty
                ' Iterate through every box number in the GameOverWormBoxes array
                For Box As Integer = 0 To (GameOverWormBoxes.Length() - 1)
                    ' Check if it's less than the last box of the array
                    If Box < (GameOverWormBoxes.Length() - 1) Then
                        ' Set the colour of the box to brown
                        Me.Controls("Box" & CStr(GameOverWormBoxes(Box))).BackColor = Color.FromArgb(185, 105, 0)
                    Else
                        ' Set the colour of the box to transparent
                        Me.Controls("Box" & CStr(GameOverWormBoxes(Box))).BackColor = Color.Transparent
                        ' Set the background image of the box to the sad worm face
                        Me.Controls("Box" & CStr(GameOverWormBoxes(Box))).BackgroundImage = My.Resources.Face_Sad
                    End If
                    ' Show the box
                    Me.Controls("Box" & CStr(GameOverWormBoxes(Box))).Visible = True
                Next
                ' Show new controls
                LBLGameOver.Visible = True
                BTNRestart.Visible = True
            End If
        Else
            ' Check the Direction Variable
            Select Case Direction
                Case "Up"
                    ' Invert the direction variable
                    Direction = "Down"
                Case "Right"
                    ' Invert the direction variable
                    Direction = "Left"
                Case "Down"
                    ' Invert the direction variable
                    Direction = "Up"
                Case "Left"
                    ' Invert the direction variable
                    Direction = "Right"
            End Select

        End If
    End Sub
    Private Sub BTNRestart_Click(sender As Object, e As EventArgs) Handles BTNRestart.Click
        ' Check sound status
        If Sound = True Then
            ' Play a click sound
            My.Computer.Audio.Play(My.Resources.Click, AudioPlayMode.Background)
        End If
        ' Hide unused controls
        PBXPoints.Visible = False
        LBLPoints.Visible = False
        LBLTime.Visible = False
        LBLGameOver.Visible = False
        BTNRestart.Visible = False
        BTNStart.Location = New Point(147, 300)
        For Box As Integer = 0 To (GameOverWormBoxes.Length() - 1)
            ' Hide the box
            Me.Controls("Box" & CStr(GameOverWormBoxes(Box))).Visible = False
            ' Remove the background image of the box
            Me.Controls("Box" & CStr(GameOverWormBoxes(Box))).BackgroundImage = Nothing
            ' Set the back colour of the box to green
            Me.Controls("Box" & CStr(GameOverWormBoxes(Box))).BackColor = Color.FromArgb(147, 196, 125)
        Next
        ' Reset variables
        WelcomeWormBoxes = {23, 24, 25, 26, 36, 46}
        GameOverWormBoxes = {13, 14, 15, 16, 26, 36}
        WormBoxes = {
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
        OrangeBoxes = {
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
        WormHistory = {43, 44, 45}
        Time = 0
        Points = 0
        Direction = “Right”
        OldDirection = “Right”
        Mode = "Hard"
        ActiveBox = 45
        ActiveOrange = 47
        FirstGame = True
        LBLPoints.Text = ": 0"
        LBLTime.Text = "00 : 00"
        ' Show new controls
        BackgroundImage = My.Resources.Empty
        LBLWelcome.Visible = True
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
        BTNStart.Visible = True
        BTNInstructions.Visible = True
    End Sub
    Private Sub TMRTime_Tick(sender As Object, e As EventArgs) Handles TMRTime.Tick
        ' Increment Time variable by 1
        Time += 1
        ' Set time label to new time
        LBLTime.Text = CStr($"{Time \ 60:D2} : {Time Mod 60:D2}")
        ' Check if time had passed 30 seconds
        If Time = 30 Then
            ' Stop timers
            TMRGame.Enabled = False
            TMRTime.Enabled = False
            ' Change background image to the empty image
            BackgroundImage = My.Resources.Empty
            ' Hide boxes
            For Box As Integer = 1 To WormBoxes.Length()
                ' Hide the box
                Me.Controls("Box" & CStr(Box)).Visible = False
            Next
            LBLLevel2.Visible = True
            ' Reduce the game interval by 10 ms
            TMRGame.Interval -= 30
            ' Sleep for 2 seconds
            Application.DoEvents()
            Threading.Thread.Sleep(2000)
            ' Hide unused controls
            LBLLevel2.Visible = False
            ' Change background image to the play image
            BackgroundImage = My.Resources.Play
            ' Hide boxes
            For Box As Integer = 1 To WormBoxes.Length()
                ' Hide the box
                Me.Controls("Box" & CStr(Box)).Visible = True
            Next
            ' Start timers
            TMRGame.Enabled = True
            TMRTime.Enabled = True
        ElseIf Time = 60 Then
            ' Stop timers
            TMRGame.Enabled = False
            TMRTime.Enabled = False
            ' Change background image to the empty image
            BackgroundImage = My.Resources.Empty
            ' Hide boxes
            For Box As Integer = 1 To WormBoxes.Length()
                ' Hide the box
                Me.Controls("Box" & CStr(Box)).Visible = False
            Next
            LBLLevel3.Visible = True
            ' Reduce the game interval by 10 ms
            TMRGame.Interval -= 40
            ' Sleep for 2 seconds
            Application.DoEvents()
            Threading.Thread.Sleep(2000)
            ' Hide unused controls
            LBLLevel3.Visible = False
            ' Change background image to the play image
            BackgroundImage = My.Resources.Play
            ' Hide boxes
            For Box As Integer = 1 To WormBoxes.Length()
                ' Hide the box
                Me.Controls("Box" & CStr(Box)).Visible = True
            Next
            ' Start timers
            TMRGame.Enabled = True
            TMRTime.Enabled = True
        End If
    End Sub
    Private Sub QuitterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitterToolStripMenuItem.Click
        ' Check sound status
        If Sound = True Then
            ' Play a click sound
            My.Computer.Audio.Play(My.Resources.Click, AudioPlayMode.Background)
        End If
        End
    End Sub
    Private Sub FacileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FacileToolStripMenuItem.Click
        ' Check sound status
        If Sound = True Then
            ' Play a click sound
            My.Computer.Audio.Play(My.Resources.Click, AudioPlayMode.Background)
        End If
        ' Stop timers
        TMRGame.Enabled = False
        TMRTime.Enabled = False
        ' Reset variables
        WelcomeWormBoxes = {23, 24, 25, 26, 36, 46}
        GameOverWormBoxes = {13, 14, 15, 16, 26, 36}
        WormBoxes = {
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
        OrangeBoxes = {
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
        WormHistory = {43, 44, 45}
        Time = 0
        Points = 0
        Direction = “Right”
        OldDirection = “Right”
        Mode = "Hard"
        ActiveBox = 45
        ActiveOrange = 47
        FirstGame = True
        LBLPoints.Text = ": 0"
        LBLTime.Text = "00 : 00"
        ' Hide unused controls
        LBLWelcome.Visible = False
        BTNStart.Visible = False
        BTNInstructions.Visible = False
        LBLInstructionsIntro.Visible = False
        LBLInstructions.Visible = False
        LBLLevel2.Visible = False
        LBLLevel3.Visible = False
        LBLSelectMode.Visible = False
        BTNEasy.Visible = False
        BTNHard.Visible = False
        PBXEasy.Visible = False
        PBXHard.Visible = False
        PBXPoints.Visible = False
        LBLPoints.Visible = False
        LBLTime.Visible = False
        LBLGameOver.Visible = False
        BTNRestart.Visible = False
        For Box As Integer = 1 To WormBoxes.Length()
            ' Hide the box
            Me.Controls("Box" & CStr(Box)).Visible = False
            ' Remove the background image of the box
            Me.Controls("Box" & CStr(Box)).BackgroundImage = Nothing
            ' Set the back colour of the box to green
            Me.Controls("Box" & CStr(Box)).BackColor = Color.FromArgb(147, 196, 125)
        Next
        ' Change the Mode variable to "Easy"
        Mode = "Easy"
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
        ' Change the status of the active orange box in the OrangeBoxes array
        OrangeBoxes(ActiveOrange - 1) = True
        ' Change the colour of the box to green
        Me.Controls("Box" & CStr(ActiveOrange)).BackColor = Color.FromArgb(147, 196, 125)
        ' Change the background image of the active orange box to an orange
        Me.Controls("Box" & CStr(ActiveOrange)).BackgroundImage = My.Resources.Orange
        ' Choose another box for the next orange
        ActiveOrange = Int(Rnd() * 100) + 1
        ' Make sure the active orange box isn't on the worm or a pre-existing orange
        While OrangeBoxes(ActiveOrange - 1) = True Or WormBoxes(ActiveOrange - 1) = True
            ' Choose another box for the next orange
            ActiveOrange = Int(Rnd() * 100) + 1
        End While
        ' Change the status of the active orange box in the OrangeBoxes array
        OrangeBoxes(ActiveOrange - 1) = True
        ' Change the colour of the box to green
        Me.Controls("Box" & CStr(ActiveOrange)).BackColor = Color.FromArgb(147, 196, 125)
        ' Change the background image of the active orange box to an orange
        Me.Controls("Box" & CStr(ActiveOrange)).BackgroundImage = My.Resources.Orange
        ' Choose another box for the next orange
        ActiveOrange = Int(Rnd() * 100) + 1
        ' Make sure the active orange box isn't on the worm or a pre-existing orange
        While OrangeBoxes(ActiveOrange - 1) = True Or WormBoxes(ActiveOrange - 1) = True
            ' Choose another box for the next orange
            ActiveOrange = Int(Rnd() * 100) + 1
        End While
        ' Change the status of the active orange box in the OrangeBoxes array
        OrangeBoxes(ActiveOrange - 1) = True
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
    Private Sub DifficileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DifficileToolStripMenuItem.Click
        ' Check sound status
        If Sound = True Then
            ' Play a click sound
            My.Computer.Audio.Play(My.Resources.Click, AudioPlayMode.Background)
        End If
        ' Stop timers
        TMRGame.Enabled = False
        TMRTime.Enabled = False
        ' Reset variables
        WelcomeWormBoxes = {23, 24, 25, 26, 36, 46}
        GameOverWormBoxes = {13, 14, 15, 16, 26, 36}
        WormBoxes = {
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
        OrangeBoxes = {
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
        WormHistory = {43, 44, 45}
        Time = 0
        Points = 0
        Direction = “Right”
        OldDirection = “Right”
        Mode = "Hard"
        ActiveBox = 45
        ActiveOrange = 47
        FirstGame = True
        LBLPoints.Text = ": 0"
        LBLTime.Text = "00 : 00"
        ' Hide unused controls
        LBLWelcome.Visible = False
        BTNStart.Visible = False
        BTNInstructions.Visible = False
        LBLInstructionsIntro.Visible = False
        LBLInstructions.Visible = False
        LBLLevel2.Visible = False
        LBLLevel3.Visible = False
        LBLSelectMode.Visible = False
        BTNEasy.Visible = False
        BTNHard.Visible = False
        PBXEasy.Visible = False
        PBXHard.Visible = False
        PBXPoints.Visible = False
        LBLPoints.Visible = False
        LBLTime.Visible = False
        LBLGameOver.Visible = False
        BTNRestart.Visible = False
        For Box As Integer = 1 To WormBoxes.Length()
            ' Hide the box
            Me.Controls("Box" & CStr(Box)).Visible = False
            ' Remove the background image of the box
            Me.Controls("Box" & CStr(Box)).BackgroundImage = Nothing
            ' Set the back colour of the box to green
            Me.Controls("Box" & CStr(Box)).BackColor = Color.FromArgb(147, 196, 125)
        Next
        ' Change the Mode variable to "Hard"
        Mode = "Hard"
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
        ' Change the status of the active orange box in the OrangeBoxes array
        OrangeBoxes(ActiveOrange - 1) = True
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

    Private Sub InstructionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InstructionsToolStripMenuItem.Click
        ' Check sound status
        If Sound = True Then
            ' Play a click sound
            My.Computer.Audio.Play(My.Resources.Click, AudioPlayMode.Background)
        End If
        ' Stop timers
        TMRGame.Enabled = False
        TMRTime.Enabled = False
        ' Reset variables
        WelcomeWormBoxes = {23, 24, 25, 26, 36, 46}
        GameOverWormBoxes = {13, 14, 15, 16, 26, 36}
        WormBoxes = {
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
        OrangeBoxes = {
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
        WormHistory = {43, 44, 45}
        Time = 0
        Points = 0
        Direction = “Right”
        OldDirection = “Right”
        Mode = "Hard"
        ActiveBox = 45
        ActiveOrange = 47
        FirstGame = True
        LBLPoints.Text = ": 0"
        LBLTime.Text = "00 : 00"
        ' Hide unused controls
        LBLWelcome.Visible = False
        BTNStart.Visible = False
        BTNInstructions.Visible = False
        LBLInstructionsIntro.Visible = False
        LBLInstructions.Visible = False
        LBLLevel2.Visible = False
        LBLLevel3.Visible = False
        LBLSelectMode.Visible = False
        BTNEasy.Visible = False
        BTNHard.Visible = False
        PBXEasy.Visible = False
        PBXHard.Visible = False
        PBXPoints.Visible = False
        LBLPoints.Visible = False
        LBLTime.Visible = False
        LBLGameOver.Visible = False
        BTNRestart.Visible = False
        For Box As Integer = 1 To WormBoxes.Length()
            ' Hide the box
            Me.Controls("Box" & CStr(Box)).Visible = False
            ' Remove the background image of the box
            Me.Controls("Box" & CStr(Box)).BackgroundImage = Nothing
            ' Set the back colour of the box to green
            Me.Controls("Box" & CStr(Box)).BackColor = Color.FromArgb(147, 196, 125)
        Next
        ' Iterate through every box number in the WelcomeWormBoxes array
        For Box = 0 To WelcomeWormBoxes.Length - 1
            ' Hide the box
            Controls("Box" & WelcomeWormBoxes(Box)).Visible = False
        Next
        ' Mode the start button to the bottom of the screen
        BTNStart.Location = New Point(147, 485)
        ' Show new controls
        BTNStart.Visible = True
        LBLInstructionsIntro.Visible = True
        LBLInstructions.Visible = True
    End Sub
End Class

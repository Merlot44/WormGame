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
    Public Sound As Boolean = True
    Public Time As Integer = 0
    Public Points As Integer = 0
    Public Direction As String = “Right”
    Public Mode As String = "Normal"
    Public ActiveBox As Integer = 45
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
        ' Show new controls
        PBXPoints.Visible = True
        LBLPoints.Visible = True
        LBLTime.Visible = True
        ' Change background image to the game background
        BackgroundImage = My.Resources.Play
        ' Iterate through every box number in the WormBoxes array
        For Box As Integer = 1 To WormBoxes.Length()
            ' Check the status of the box
            If (Box - 1) = ActiveBox Then
                ' Change the colour of the box to green
                Me.Controls("Box" & CStr(Box)).BackColor = Color.FromArgb(147, 196, 125)
                Me.Controls("Box" & CStr(Box)).BackgroundImage = My.Resources.Face_Right
            ElseIf WormBoxes(Box - 1) = False Then
                ' Change the colour of the box to green
                Me.Controls("Box" & CStr(Box)).BackColor = Color.FromArgb(147, 196, 125)
                Me.Controls("Box" & CStr(Box)).BackgroundImage = Nothing
            ElseIf WormBoxes(Box - 1) = True Then
                Me.Controls("Box" & CStr(Box)).BackColor = Color.FromArgb(185, 105, 0)
                Me.Controls("Box" & CStr(Box)).BackgroundImage = Nothing
            End If
            Me.Controls("Box" & CStr(Box)).Visible = True
        Next
    End Sub
End Class

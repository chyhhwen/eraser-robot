Public Class Form1
    Dim map(10, 10), obmap(10, 10) As Integer
    Dim s, t As Point
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Randomize()
        initmap()
        showmap()
    End Sub
    Function initmap()
        s = New Point(0, 0)
        t = New Point(0, 0)
        For i = 1 To 9
            For j = 1 To 9
                map(i, j) = 0
            Next
        Next
        obmap = map.Clone()
    End Function
    Function showmap()
        Dim k As Integer
        For i = 1 To 9
            For j = 1 To 9
                k = (i - 1) * 9 + j
                Controls("TextBox" & k).Text = ""
                If map(i, j) = 0 Or map(i, j) = -2 Then
                    Controls("TextBox" & k).BackColor = Color.White
                ElseIf map(i, j) = -1 Then
                    Controls("TextBox" & k).BackColor = Color.Black
                ElseIf map(i, j) = -3 Then
                    Controls("TextBox" & k).BackColor = Color.Gray
                Else
                    Controls("TextBox" & k).Text = map(i, j)
                End If
            Next
        Next
        k = (s.X - 1) * 9 + s.Y
        If k >= 1 And k <= 81 Then
            Controls("TextBox" & k).Text = "S"
        End If
        k = (t.X - 1) * 9 + t.Y
        If k >= 1 And k <= 81 Then
            Controls("TextBox" & k).Text = "T"
        End If
    End Function
    Function randmap()
        Dim i, max As Integer
        Dim p As Point
        max = Rnd() * 30 + 20
        Label11.Text = max
        Do While (i < max)
            p = getrandpoint()
            map(p.X, p.Y) = -1
            i = i + 1
        Loop
        obmap = map.Clone()
    End Function
    Function getrandpoint()
        Dim find As Boolean = False
        Dim x, y As Integer
        Do While (Not find)
            x = Rnd() * 8 + 1
            y = Rnd() * 8 + 1
            If map(x, y) = 0 Then
                Return New Point(x, y)
            End If
        Loop
        Return New Point(0, 0)
    End Function
    Function getq()
        Dim w As Integer = 1
        Dim q As Queue = New Queue
        map(s.X, s.Y) = w
        map(t.X, t.Y) = 0
        q.Enqueue(New Point(s.X, s.Y))
        Do Until map(t.X, t.Y) > 0 Or w > 9 * 9
            Dim q2 As Queue = New Queue
            Do While q.Count > 0
                Dim p As Point = q.Dequeue()
                If p.X > 1 Then If map(p.X - 1, p.Y) = 0 Then map(p.X - 1, p.Y) = w + 1 : q2.Enqueue(New Point(p.X - 1, p.Y))
                If p.X < 9 Then If map(p.X + 1, p.Y) = 0 Then map(p.X + 1, p.Y) = w + 1 : q2.Enqueue(New Point(p.X + 1, p.Y))
                If p.Y > 1 Then If map(p.X, p.Y - 1) = 0 Then map(p.X, p.Y - 1) = w + 1 : q2.Enqueue(New Point(p.X, p.Y - 1))
                If p.Y < 9 Then If map(p.X, p.Y + 1) = 0 Then map(p.X, p.Y + 1) = w + 1 : q2.Enqueue(New Point(p.X, p.Y + 1))
            Loop
            q = q2.Clone()
            w = w + 1
        Loop
        Dim x, y As Integer
        x = t.X
        y = t.Y
        If map(t.X, t.Y) = 0 Then
            Label12.Text = "NO"
            Exit Function
        End If
        Do Until w < 1
            If x = s.X And y = s.Y Then
                map(x, y) = -3
                Label12.Text = "YES"
                Exit Function
            End If
            If map(x - 1, y) = w - 1 Then
                map(x, y) = -3
                x -= 1
                w -= 1
            End If
            If map(x + 1, y) = w - 1 Then
                map(x, y) = -3
                x += 1
                w -= 1
            End If
            If map(x, y - 1) = w - 1 Then
                map(x, y) = -3
                y -= 1
                w -= 1
            End If
            If map(x, y + 1) = w - 1 Then
                map(x, y) = -3
                y += 1
                w -= 1
            End If
        Loop
    End Function
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        initmap()
        showmap()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        initmap()
        randmap()
        showmap()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        End
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        map = obmap.Clone
        s = getrandpoint()
        t = getrandpoint()
        showmap()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        getq()
        showmap()
    End Sub
End Class

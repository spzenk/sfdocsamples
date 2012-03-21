Module Module1

  Sub Main()
    Dim host As String = "", port As Integer = 0
    Dim login As String = "", pwd As String = ""

    Console.WriteLine("Enter the e-mail server (for example: pop.gmail.com)")
    host = Console.ReadLine().Trim()

    Console.WriteLine("Enter the port number (for example: 110)")
    Integer.TryParse(Console.ReadLine(), port)
    If port <= 0 Then port = 110

    Console.WriteLine("Enter the user name")
    login = Console.ReadLine().Trim()

    Console.WriteLine("Enter the password")
    pwd = Console.ReadLine().Trim()

    Dim myPop3 As New Pop3Lib.Client(host, port, login, pwd)

    Dim m As Pop3Lib.MailItem
    Do While (myPop3.NextMail(m))
      Console.Write("New message from {0}: {1}", m.From, m.Subject)
      Console.WriteLine("Are you want remove this message (y/n)?")
      If Console.ReadLine().ToLower().StartsWith("y") Then
        myPop3.Delete()
        Console.WriteLine("Mail is marked for remove.")
      End If
    Loop

    myPop3.Close()
    Console.ReadKey()
  End Sub

End Module

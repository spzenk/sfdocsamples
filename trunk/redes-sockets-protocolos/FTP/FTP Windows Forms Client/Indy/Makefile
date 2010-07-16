run:IndyFTP.exe
	IndyFTP
IndyFTP.exe: AssemblyInfo.cs Form1.cs Form1.resx App.ico
	csc /out:IndyFTP.exe /target:winexe /r:Indy.Sockets.dll /win32icon:App.ico /resource:Form1.resx AssemblyInfo.cs Form1.cs

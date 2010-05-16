e:
svcutil ChatService.exe
pause
svcutil *.wsdl *.xsd /a /language:C# /out:MyProxy.cs /config:app.config

pause
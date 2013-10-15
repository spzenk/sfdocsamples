
ECHO ** Generador t4 fwk :. .Net 4.0**
@setlocal enableextensions
@cd /d "%~dp0"


gacutil /u JavascriptCruncher.dll, Version=1.0.0.0 , Culture=neutral, PublicKeyToken=8e88a9f51048ee4d
gacutil /u ajaxmin.dll, Version=3.30.3576.28515 , Culture=neutral, PublicKeyToken=b60b318a12299464
	   
@ECHO OFF

pause

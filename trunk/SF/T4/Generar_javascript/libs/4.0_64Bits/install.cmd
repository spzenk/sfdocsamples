ECHO ** Generador t4 fwk :. .Net 4.0**
@setlocal enableextensions
@cd /d "%~dp0"
@set OLDDIR=%CD%
@set "vs=\Microsoft Visual Studio 10.0\VC\Bin"
@SET "SPDIR= %PROGRAMFILES%%vs%"
@if not "%PROGRAMFILES(X86)%" == "" (
 @SET "SPDIR= %PROGRAMFILES(X86)%%vs%"
)
gacutil -i Fwk.T4Gen.dll
gacutil -i ajaxmin.dll
@ECHO OFF

pause

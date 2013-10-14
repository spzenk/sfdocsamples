ECHO ** Generador t4 fwk :. .Net 4.0**
@setlocal enableextensions
@cd /d "%~dp0"

gacutil -u Fwk.T4Gen.dll
gacutil -u ajaxmin.dll


pause

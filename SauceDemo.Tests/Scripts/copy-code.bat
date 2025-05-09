@echo off

:: Clean out prior run
rmdir /S /Q copy-for-review

:: Copy test project files
robocopy .. copy-for-review *.cs *.feature /S /XD obj bin Scripts /XF Usings.cs

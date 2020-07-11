Option Explicit On
Option Infer Off
Option Strict On
Imports System.Runtime.CompilerServices

Imports CodeCoverage.Microsoft.VisualBasic.CompilerServices.NativeMethods

Public Module ControlExtensions
    <Extension()>
    Public Sub Suspend(Crtl As Control)
        LockWindowUpdate(Crtl.Handle)
    End Sub

    <Extension()>
    Public Sub [Resume](_1 As Control)
        LockWindowUpdate(IntPtr.Zero)
    End Sub

End Module

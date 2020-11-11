Option Explicit On
Option Infer Off
Option Strict On
Imports System.Runtime.CompilerServices

Imports CodeCoverage.Microsoft.VisualBasic.CompilerServices.NativeMethods

Public Module ControlExtensions
    <Extension()>
    Friend Sub Suspend(Crtl As Control)
        LockWindowUpdate(Crtl.Handle)
    End Sub

    <Extension()>
    Public Sub [Resume](_0 As Control)
        LockWindowUpdate(IntPtr.Zero)
    End Sub

End Module

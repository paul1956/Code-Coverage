Option Explicit On
Option Infer Off
Option Strict On
Imports System.Runtime.CompilerServices

Imports CodeCoverage.Microsoft.VisualBasic.CompilerServices.NativeMethods

Public Module ControlExtensions
    <Extension()>
    Public Sub Suspend(_control As Control)
        LockWindowUpdate(_control.Handle)
    End Sub

    <Extension()>
    Public Sub [Resume](_1 As Control)
        LockWindowUpdate(IntPtr.Zero)
    End Sub

End Module

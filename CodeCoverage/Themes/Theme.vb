' Licensed to the .NET Foundation under one or more agreements.
' The .NET Foundation licenses this file to you under the MIT license.
' See the LICENSE file in the project root for more information.
Imports System.IO
Imports System.Xml.Serialization

'''<remarks/>
<Serializable(),
 ComponentModel.DesignerCategory("code"),
 XmlType(AnonymousType:=True),
 XmlRoot([Namespace]:="", IsNullable:=False)>
Partial Public Class Themes

    Sub New()
    End Sub

    '''<remarks/>
    Public Property Theme() As ThemesTheme

End Class

'''<remarks/>
<Serializable(),
 ComponentModel.DesignerCategory("code"),
 XmlType(AnonymousType:=True)>
Partial Public Class ThemesTheme

    '''<remarks/>
    '<XmlAttribute()>
    'Private Property GUID As String

#Disable Warning CA1819 ' Properties should not return arrays
    '''<remarks/>
    <XmlElement("Category")>
    Public Property Category As ThemesThemeCategory()
#Disable Warning CA2235 ' Mark all non-serializable fields
    '''<remarks/>
    <XmlAttribute()>
    Public Property Name As String
#Enable Warning CA2235 ' Mark all non-serializable fields
#Enable Warning CA1819 ' Properties should not return arrays

End Class

'''<remarks/>
<Serializable(),
 ComponentModel.DesignerCategory("code"),
 XmlType(AnonymousType:=True)>
Partial Public Class ThemesThemeCategory

    '''<remarks/>
    '<XmlAttribute()>
    'Private Property GUID As String

#Disable Warning CA1819 ' Properties should not return arrays
    '''<remarks/>
    <XmlElement("Color")>
    Public Property Color As ThemesThemeCategoryColor()
#Disable Warning CA2235 ' Mark all non-serializable fields
    '''<remarks/>
    <XmlAttribute()>
    Public Property Name As String
#Enable Warning CA2235 ' Mark all non-serializable fields
#Enable Warning CA1819 ' Properties should not return arrays
End Class

'''<remarks/>
<Serializable(),
 ComponentModel.DesignerCategory("code"),
 XmlType(AnonymousType:=True)>
Partial Public Class ThemesThemeCategoryColor

    '''<remarks/>
    Public Property Background As ThemesThemeCategoryColorBackground

    '''<remarks/>
    Public Property Foreground As ThemesThemeCategoryColorForeground

#Disable Warning CA2235 ' Mark all non-serializable fields
    '''<remarks/>
    <XmlAttribute()>
    Public Property Name As String
#Enable Warning CA2235 ' Mark all non-serializable fields

End Class

'''<remarks/>
<Serializable(),
 ComponentModel.DesignerCategory("code"),
 XmlType(AnonymousType:=True)>
Partial Public Class ThemesThemeCategoryColorBackground

#Disable Warning CA2235 ' Mark all non-serializable fields
    '''<remarks/>
    <XmlAttribute()>
    Public Property Source() As String

    '''<remarks/>
    <XmlAttribute()>
    Public Property Type() As String
#Enable Warning CA2235 ' Mark all non-serializable fields

End Class

'''<remarks/>
<Serializable(),
 ComponentModel.DesignerCategory("code"),
 XmlType(AnonymousType:=True)>
Partial Public Class ThemesThemeCategoryColorForeground

#Disable Warning CA2235 ' Mark all non-serializable fields
    '''<remarks/>
    <XmlAttribute()>
    Public Property Source() As String

    '''<remarks/>
    <XmlAttribute()>
    Public Property Type() As String
#Enable Warning CA2235 ' Mark all non-serializable fields

End Class

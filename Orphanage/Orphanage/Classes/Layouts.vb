Imports System.IO
Imports System.Xml
Imports Telerik.WinControls.UI
Imports Telerik.WinControls

Public Class Layouts
    Public Shared Sub SaveFormLayout(ByVal frm As Form)
        If Not File.Exists("FormsLayouts.dat") Then
            Dim xmlDoc = <?xml version="1.0"?>
                         <Forms>
                             <Form name=<%= frm.Name %>>
                                 <Size Height=<%= IIf(frm.WindowState = FormWindowState.Normal, frm.Size.Height, frm.MinimumSize.Height) %> Width=<%= IIf(frm.WindowState = FormWindowState.Normal, frm.Size.Width, frm.MinimumSize.Width) %>/>
                                 <location X=<%= frm.Location.X %> Y=<%= frm.Location.Y %>/>
                                 <WindowState><%= CInt(frm.WindowState) %></WindowState>
                                 <Font Italic=<%= frm.Font.Italic %> name=<%= frm.Font.Name %> bold=<%= frm.Font.Bold %> size=<%= frm.Font.Size %>/>
                             </Form>
                         </Forms>
            My.Computer.FileSystem.WriteAllText("FormsLayouts.dat", xmlDoc.ToString(), False)
        Else
            Dim XmlDoc = XDocument.Load("FormsLayouts.dat")
            Dim founded As Boolean = False
            For Each xmlel In XmlDoc...<Form>
                If xmlel.FirstAttribute.Value = frm.Name Then
                    If frm.WindowState = FormWindowState.Normal Then
                        xmlel...<Size>.@Height = frm.Size.Height
                        xmlel...<Size>.@Width = frm.Size.Width
                    End If
                    xmlel...<location>.@X = frm.Location.X
                    xmlel...<location>.@Y = frm.Location.Y
                    xmlel...<WindowState>.Value = CInt(frm.WindowState)
                    xmlel...<Font>.@Italic = frm.Font.Italic
                    xmlel...<Font>.@name = frm.Font.Name
                    xmlel...<Font>.@bold = frm.Font.Bold
                    xmlel...<Font>.@size = frm.Font.Size
                    XmlDoc.Save("FormsLayouts.dat")
                    founded = True
                    Exit For
                End If
            Next
            If Not founded Then
                Dim xmlE = <Form name=<%= frm.Name %>>
                               <Size Height=<%= IIf(frm.WindowState = FormWindowState.Normal, frm.Size.Height, frm.MinimumSize.Height) %> Width=<%= IIf(frm.WindowState = FormWindowState.Normal, frm.Size.Width, frm.MinimumSize.Width) %>/>
                               <location X=<%= frm.Location.X %> Y=<%= frm.Location.Y %>/>
                               <WindowState><%= CInt(frm.WindowState) %></WindowState>
                               <Font Italic=<%= frm.Font.Italic %> name=<%= frm.Font.Name %> bold=<%= frm.Font.Bold %> size=<%= frm.Font.Size %>/>
                           </Form>
                XmlDoc...<Forms>.First().Add(xmlE)
                XmlDoc.Save("FormsLayouts.dat")
            End If
        End If
    End Sub
    Public Shared Sub LoadFormLayout(ByRef frm As Form)
        If File.Exists("FormsLayouts.dat") Then
            Dim XmlDoc = XDocument.Load("FormsLayouts.dat")
            For Each xmlel In XmlDoc...<Form>
                If xmlel.FirstAttribute.Value = frm.Name Then
                    frm.WindowState = CInt(xmlel...<WindowState>.Value)
                    frm.Height = xmlel...<Size>.@Height
                    frm.Width = xmlel...<Size>.@Width
                    frm.Left = xmlel...<location>.@X
                    frm.Top = xmlel...<location>.@Y
                    If CBool(xmlel...<Font>.@Italic) And CBool(xmlel...<Font>.@bold) Then
                        Dim fnt As New Font(xmlel...<Font>.@name, Single.Parse(xmlel...<Font>.@size), FontStyle.Bold Or FontStyle.Italic)
                        frm.Font = fnt
                    ElseIf CBool(xmlel...<Font>.@Italic) And Not CBool(xmlel...<Font>.@bold) Then
                        Dim fnt As New Font(xmlel...<Font>.@name, Single.Parse(xmlel...<Font>.@size), FontStyle.Italic)
                        frm.Font = fnt
                    ElseIf Not CBool(xmlel...<Font>.@Italic) And CBool(xmlel...<Font>.@bold) Then
                        Dim fnt As New Font(xmlel...<Font>.@name, Single.Parse(xmlel...<Font>.@size), FontStyle.Bold)
                        frm.Font = fnt
                    Else
                        Dim fnt As New Font(xmlel...<Font>.@name, Single.Parse(xmlel...<Font>.@size))
                        frm.Font = fnt
                    End If
                End If
            Next
        End If
    End Sub
    Public Shared Sub SetControlsFromSetting(ByRef frm As Form)
        For Each ctrl As Control In frm.Controls
            If TypeOf ctrl Is RadSpinEditor Then
                Dim xx As RadSpinEditor = CType(ctrl, RadSpinEditor)
                xx.ThousandsSeparator = My.Settings.UseThousendSeprator
                xx.DecimalPlaces = My.Settings.DecimalPercion
            End If
        Next
    End Sub
    Public Shared Sub DrawRowColorsFamilies(ByRef e As Telerik.WinControls.UI.RowFormattingEventArgs, ByRef IDSColors As Dictionary(Of Integer, Color), ByVal Isclosing As Boolean)
        Dim row As GridViewRowInfo = e.RowElement.RowInfo
        If My.Settings.UseColors Then
            Try
                Dim Fid As Integer = CInt(row.Cells("Family_ID").Value)
                If Isclosing Then
                    Control.CheckForIllegalCrossThreadCalls = True
                    Exit Sub
                End If
                Dim ColorM As Color
                'If Fid = 53 Then Stop
                If Not IDSColors.Keys.Contains(Fid) Then
                    If Not CBool(row.Cells("IsBailed").Value) Then
                        If (Not IsNothing(row.Cells("Color_Mark").Value) AndAlso _
                         Not IsDBNull(row.Cells("Color_Mark").Value)) Then
                            ColorM = Color.FromArgb(row.Cells("Color_Mark").Value)
                        Else
                            ColorM = Color.Black
                        End If
                    Else
                        ColorM = Getter.GetFamilyColor(Fid)
                    End If
                    IDSColors.Add(Fid, ColorM)
                Else
                    ColorM = IDSColors(Fid)
                End If
                ClearRowColor(e.RowElement)
                If ColorM <> Color.Black AndAlso Not e.RowElement.IsSelected Then
                    e.RowElement.DrawFill = True
                    If My.Settings.UseBackgroundColor Then
                        e.RowElement.GradientStyle = GradientStyles.Solid
                        e.RowElement.BackColor = ColorM
                        e.RowElement.BackColor2 = ColorM
                        e.RowElement.BackColor3 = ColorM
                        e.RowElement.BackColor4 = ColorM
                        e.RowElement.ForeColor = Color.Black
                    Else
                        e.RowElement.ForeColor = ColorM
                        'e.RowElement.BackColor2 = Nothing
                        'e.RowElement.BackColor3 = Nothing
                        'e.RowElement.BackColor4 = Nothing
                        e.RowElement.BackColor = Nothing
                    End If
                Else
                    ClearRowColor(e.RowElement)
                End If
                'If Fid Mod 10 = 0 Then Application.DoEvents()
            Catch
            End Try
        End If
    End Sub

    Public Shared Sub DrawRowColors(ByRef e As Telerik.WinControls.UI.RowFormattingEventArgs, _
                                    ByRef IDSColors As Dictionary(Of Integer, Color), _
                                    ByVal ColumnIdName As String, _
                                    ByVal ColumnColorname As String, _
                                    ByVal Isclosing As Boolean)
        Dim row As GridViewRowInfo = e.RowElement.RowInfo
        If My.Settings.UseColors Then
            Try
                Dim Fid As Integer = CInt(row.Cells(ColumnIdName).Value)
                If Isclosing Then
                    Control.CheckForIllegalCrossThreadCalls = True
                    Exit Sub
                End If
                Dim ColorM As Color
                'If Fid = 53 Then Stop
                If Not IDSColors.Keys.Contains(Fid) Then
                    If (Not IsNothing(row.Cells(ColumnColorname).Value) AndAlso _
                     Not IsDBNull(row.Cells(ColumnColorname).Value)) Then
                        ColorM = Color.FromArgb(row.Cells(ColumnColorname).Value)
                    Else
                        ColorM = Color.Black
                    End If
                    IDSColors.Add(Fid, ColorM)
                Else
                    ColorM = IDSColors(Fid)
                End If
                ClearRowColor(e.RowElement)
                If ColorM <> Color.Black AndAlso Not e.RowElement.IsSelected Then
                    e.RowElement.DrawFill = True
                    If My.Settings.UseBackgroundColor Then
                        e.RowElement.GradientStyle = GradientStyles.Solid
                        e.RowElement.BackColor = ColorM
                        e.RowElement.BackColor2 = ColorM
                        e.RowElement.BackColor3 = ColorM
                        e.RowElement.BackColor4 = ColorM
                        e.RowElement.ForeColor = Color.Black
                    Else
                        e.RowElement.ForeColor = ColorM
                        'e.RowElement.BackColor2 = Nothing
                        'e.RowElement.BackColor3 = Nothing
                        'e.RowElement.BackColor4 = Nothing
                        e.RowElement.BackColor = Nothing
                    End If
                Else
                    ClearRowColor(e.RowElement)
                End If
                'If Fid Mod 10 = 0 Then Application.DoEvents()
            Catch
            End Try
        End If
    End Sub

    Public Shared Sub DrawRowColorsOrphan(ByRef e As Telerik.WinControls.UI.RowFormattingEventArgs, ByRef IDSColors As Dictionary(Of Integer, Color), ByVal Isclosing As Boolean)
        Dim row As GridViewRowInfo = e.RowElement.RowInfo
        If My.Settings.UseColors Then
            Try
                Dim Fid As Integer = CInt(row.Cells("ID").Value)
                If Isclosing Then
                    Control.CheckForIllegalCrossThreadCalls = True
                    Exit Sub
                End If
                Dim ColorM As Color
                'If Fid = 53 Then Stop
                If Not IDSColors.Keys.Contains(Fid) Then
                    If Not CBool(row.Cells("IsBailed").Value) Then
                        If (Not IsNothing(row.Cells("Color_Mark").Value) AndAlso _
                         Not IsDBNull(row.Cells("Color_Mark").Value)) Then
                            ColorM = Color.FromArgb(row.Cells("Color_Mark").Value)
                        Else
                            ColorM = Color.Black
                        End If
                    Else
                        ColorM = Getter.GetOrphanColor(Fid)
                    End If
                    IDSColors.Add(Fid, ColorM)
                Else
                    ColorM = IDSColors(Fid)
                End If
                ClearRowColor(e.RowElement)
                If ColorM <> Color.Black AndAlso Not e.RowElement.IsSelected Then
                    e.RowElement.DrawFill = True
                    If My.Settings.UseBackgroundColor Then
                        e.RowElement.GradientStyle = GradientStyles.Solid
                        e.RowElement.BackColor = ColorM
                        e.RowElement.BackColor2 = ColorM
                        e.RowElement.BackColor3 = ColorM
                        e.RowElement.BackColor4 = ColorM
                        e.RowElement.ForeColor = Color.Black
                    Else
                        e.RowElement.ForeColor = ColorM
                        'e.RowElement.BackColor2 = Nothing
                        'e.RowElement.BackColor3 = Nothing
                        'e.RowElement.BackColor4 = Nothing
                        e.RowElement.BackColor = Nothing
                    End If
                Else
                    ClearRowColor(e.RowElement)
                End If
                'If Fid Mod 10 = 0 Then Application.DoEvents()
            Catch
            End Try
        End If
    End Sub

    Private Shared Sub ClearRowColor(ByRef row As GridRowElement)
        row.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local)
        row.ResetValue(LightVisualElement.BackColor2Property, ValueResetFlags.Local)
        row.ResetValue(LightVisualElement.BackColor3Property, ValueResetFlags.Local)
        row.ResetValue(LightVisualElement.BackColor4Property, ValueResetFlags.Local)
        row.ResetValue(LightVisualElement.ForeColorProperty, ValueResetFlags.Local)
        row.ResetValue(LightVisualElement.GradientStyleProperty, ValueResetFlags.Local)
        row.ResetValue(LightVisualElement.DrawFillProperty, ValueResetFlags.Local)
    End Sub
End Class

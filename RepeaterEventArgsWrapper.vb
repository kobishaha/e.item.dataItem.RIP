Imports System
Imports System.Data
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls

Public Class RepeaterEventArgsWrapper
    ' אחסון של הפרמטר המקורי e
    Public ReadOnly Property Original As RepeaterItemEventArgs

    ' פרמטרים נפוצים
    Public ReadOnly Property Item As RepeaterItem
    Public ReadOnly Property Type As ListItemType
    Public ReadOnly Property Data As DataRowView
    Public ReadOnly Property Index As Integer

    ' פרופרטי לבדיקת סוג Item (Item או AlternatingItem)
    Public ReadOnly Property GeneralItem As Boolean
        Get
            Return Type = ListItemType.Item OrElse Type = ListItemType.AlternatingItem
        End Get
    End Property

    ' בנאי שמקבל את e
    Public Sub New(e As RepeaterItemEventArgs)
        Original = e
        Item = e.Item
        Type = e.Item.ItemType
        Data = TryCast(e.Item.DataItem, DataRowView)
        Index = e.Item.ItemIndex
    End Sub

    ' פונקציה לגישה לערכים מתוך ה-Data
    Public Function DataField(columnName As String) As String
        If Data IsNot Nothing AndAlso Data.Row.Table.Columns.Contains(columnName) Then
            Return Data(columnName).ToString()
        End If
        Throw New Exception($"Column '{columnName}' not found in the data source.")
    End Function

    ' גישה ל-Label
    Public Function Label(controlName As String) As Label
        Dim lbl = TryCast(Item.FindControl(controlName), Label)
        If lbl Is Nothing Then Throw New Exception($"Label '{controlName}' not found.")
        Return lbl
    End Function

    ' גישה ל-Literal
    Public Function Literal(controlName As String) As Literal
        Dim lit = TryCast(Item.FindControl(controlName), Literal)
        If lit Is Nothing Then Throw New Exception($"Literal '{controlName}' not found.")
        Return lit
    End Function

    ' גישה ל-HTML Generic Control
    Public Function HtmlGeneric(controlName As String) As HtmlGenericControl
        Dim ctrl = TryCast(Item.FindControl(controlName), HtmlGenericControl)
        If ctrl Is Nothing Then Throw New Exception($"HtmlGenericControl '{controlName}' not found.")
        Return ctrl
    End Function

    ' גישה ל-Panel
    Public Function Panel(controlName As String) As Panel
        Dim pnl = TryCast(Item.FindControl(controlName), Panel)
        If pnl Is Nothing Then Throw New Exception($"Panel '{controlName}' not found.")
        Return pnl
    End Function

    ' גישה ל-PlaceHolder
    Public Function PlaceHolder(controlName As String) As PlaceHolder
        Dim ph = TryCast(Item.FindControl(controlName), PlaceHolder)
        If ph Is Nothing Then Throw New Exception($"PlaceHolder '{controlName}' not found.")
        Return ph
    End Function

    ' גישה ל-Image
    Public Function [Image](controlName As String) As System.Web.UI.WebControls.Image
        Dim img = TryCast(Item.FindControl(controlName), System.Web.UI.WebControls.Image)
        If img Is Nothing Then Throw New Exception($"Image '{controlName}' not found.")
        Return img
    End Function

    ' גישה ל-HyperLink
    Public Function HyperLink(controlName As String) As System.Web.UI.WebControls.HyperLink
        Dim lnk = TryCast(Item.FindControl(controlName), System.Web.UI.WebControls.HyperLink)
        If lnk Is Nothing Then Throw New Exception($"HyperLink '{controlName}' not found.")
        Return lnk
    End Function

    ' גישה ל-TextBox
    Public Function TextBox(controlName As String) As System.Web.UI.WebControls.TextBox
        Dim txt = TryCast(Item.FindControl(controlName), System.Web.UI.WebControls.TextBox)
        If txt Is Nothing Then Throw New Exception($"TextBox '{controlName}' not found.")
        Return txt
    End Function

    ' גישה ל-HTML Table
    Public Function HtmlTable(controlName As String) As HtmlTable
        Dim tbl = TryCast(Item.FindControl(controlName), HtmlTable)
        If tbl Is Nothing Then Throw New Exception($"HtmlTable '{controlName}' not found.")
        Return tbl
    End Function

    ' גישה ל-HTML Table Row
    Public Function HtmlTableRow(controlName As String) As HtmlTableRow
        Dim tr = TryCast(Item.FindControl(controlName), HtmlTableRow)
        If tr Is Nothing Then Throw New Exception($"HtmlTableRow '{controlName}' not found.")
        Return tr
    End Function

    ' גישה ל-HTML Table Cell
    Public Function HtmlTableCell(controlName As String) As HtmlTableCell
        Dim td = TryCast(Item.FindControl(controlName), HtmlTableCell)
        If td Is Nothing Then Throw New Exception($"HtmlTableCell '{controlName}' not found.")
        Return td
    End Function
End Class

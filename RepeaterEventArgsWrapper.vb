Option Strict On
Imports System
Imports System.Data
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls

''' <summary>
''' A wrapper class for RepeaterItemEventArgs to simplify access to controls and data fields.
''' </summary>
Public Class RepeaterEventArgsWrapper
    ''' <summary>
    ''' Gets the original RepeaterItemEventArgs.
    ''' </summary>
    Public ReadOnly Property Original As RepeaterItemEventArgs

    ''' <summary>
    ''' Gets the RepeaterItem associated with the event.
    ''' </summary>
    Public ReadOnly Property Item As RepeaterItem

    ''' <summary>
    ''' Gets the type of the RepeaterItem (Header, Footer, Item, AlternatingItem, etc.).
    ''' </summary>
    Public ReadOnly Property Type As ListItemType

    ''' <summary>
    ''' Gets the data item associated with the RepeaterItem, if it exists.
    ''' </summary>
    Public ReadOnly Property Data As DataRowView

    ''' <summary>
    ''' Gets the index of the RepeaterItem in the Repeater control.
    ''' </summary>
    Public ReadOnly Property Index As Integer

    ''' <summary>
    ''' Gets a value indicating whether the item is a general data item (Item or AlternatingItem).
    ''' </summary>
    Public ReadOnly Property GeneralItem As Boolean
        Get
            Return Type = ListItemType.Item OrElse Type = ListItemType.AlternatingItem
        End Get
    End Property

    ''' <summary>
    ''' Initializes a new instance of the RepeaterEventArgsWrapper class.
    ''' </summary>
    ''' <param name="e">The RepeaterItemEventArgs to wrap.</param>
    Public Sub New(e As RepeaterItemEventArgs)
        Original = e
        Item = e.Item
        Type = e.Item.ItemType
        Data = TryCast(e.Item.DataItem, DataRowView)
        Index = e.Item.ItemIndex
    End Sub

    ''' <summary>
    ''' Retrieves the value of the specified column from the data item.
    ''' </summary>
    ''' <param name="columnName">The name of the column.</param>
    ''' <returns>The value of the column as a string.</returns>
    ''' <exception cref="Exception">Thrown when the column is not found in the data source.</exception>
    Public Function DataField(columnName As String) As String
        If Data IsNot Nothing AndAlso Data.Row.Table.Columns.Contains(columnName) Then
            Return Data(columnName).ToString()
        End If
        Throw New Exception($"Column '{columnName}' not found in the data source.")
    End Function

    ''' <summary>
    ''' Retrieves the Label control with the specified ID.
    ''' </summary>
    ''' <param name="controlName">The ID of the Label control.</param>
    ''' <returns>The Label control.</returns>
    ''' <exception cref="Exception">Thrown when the Label control is not found.</exception>
    Public Function Label(controlName As String) As Label
        Dim lbl = TryCast(Item.FindControl(controlName), Label)
        If lbl Is Nothing Then Throw New Exception($"Label '{controlName}' not found.")
        Return lbl
    End Function

    ''' <summary>
    ''' Retrieves the Literal control with the specified ID.
    ''' </summary>
    ''' <param name="controlName">The ID of the Literal control.</param>
    ''' <returns>The Literal control.</returns>
    ''' <exception cref="Exception">Thrown when the Literal control is not found.</exception>
    Public Function Literal(controlName As String) As Literal
        Dim lit = TryCast(Item.FindControl(controlName), Literal)
        If lit Is Nothing Then Throw New Exception($"Literal '{controlName}' not found.")
        Return lit
    End Function

    ''' <summary>
    ''' Retrieves the HtmlGenericControl with the specified ID.
    ''' </summary>
    ''' <param name="controlName">The ID of the HtmlGenericControl.</param>
    ''' <returns>The HtmlGenericControl.</returns>
    ''' <exception cref="Exception">Thrown when the HtmlGenericControl is not found.</exception>
    Public Function HtmlGeneric(controlName As String) As HtmlGenericControl
        Dim ctrl = TryCast(Item.FindControl(controlName), HtmlGenericControl)
        If ctrl Is Nothing Then Throw New Exception($"HtmlGenericControl '{controlName}' not found.")
        Return ctrl
    End Function

    ''' <summary>
    ''' Retrieves the Panel control with the specified ID.
    ''' </summary>
    ''' <param name="controlName">The ID of the Panel control.</param>
    ''' <returns>The Panel control.</returns>
    ''' <exception cref="Exception">Thrown when the Panel control is not found.</exception>
    Public Function Panel(controlName As String) As Panel
        Dim pnl = TryCast(Item.FindControl(controlName), Panel)
        If pnl Is Nothing Then Throw New Exception($"Panel '{controlName}' not found.")
        Return pnl
    End Function

    ''' <summary>
    ''' Retrieves the PlaceHolder control with the specified ID.
    ''' </summary>
    ''' <param name="controlName">The ID of the PlaceHolder control.</param>
    ''' <returns>The PlaceHolder control.</returns>
    ''' <exception cref="Exception">Thrown when the PlaceHolder control is not found.</exception>
    Public Function PlaceHolder(controlName As String) As PlaceHolder
        Dim ph = TryCast(Item.FindControl(controlName), PlaceHolder)
        If ph Is Nothing Then Throw New Exception($"PlaceHolder '{controlName}' not found.")
        Return ph
    End Function

    ''' <summary>
    ''' Retrieves the Image control with the specified ID.
    ''' </summary>
    ''' <param name="controlName">The ID of the Image control.</param>
    ''' <returns>The Image control.</returns>
    ''' <exception cref="Exception">Thrown when the Image control is not found.</exception>
    Public Function [Image](controlName As String) As System.Web.UI.WebControls.Image
        Dim img = TryCast(Item.FindControl(controlName), System.Web.UI.WebControls.Image)
        If img Is Nothing Then Throw New Exception($"Image '{controlName}' not found.")
        Return img
    End Function

    ''' <summary>
    ''' Retrieves the HyperLink control with the specified ID.
    ''' </summary>
    ''' <param name="controlName">The ID of the HyperLink control.</param>
    ''' <returns>The HyperLink control.</returns>
    ''' <exception cref="Exception">Thrown when the HyperLink control is not found.</exception>
    Public Function HyperLink(controlName As String) As System.Web.UI.WebControls.HyperLink
        Dim lnk = TryCast(Item.FindControl(controlName), System.Web.UI.WebControls.HyperLink)
        If lnk Is Nothing Then Throw New Exception($"HyperLink '{controlName}' not found.")
        Return lnk
    End Function

    ''' <summary>
    ''' Retrieves the TextBox control with the specified ID.
    ''' </summary>
    ''' <param name="controlName">The ID of the TextBox control.</param>
    ''' <returns>The TextBox control.</returns>
    ''' <exception cref="Exception">Thrown when the TextBox control is not found.</exception>
    Public Function TextBox(controlName As String) As System.Web.UI.WebControls.TextBox
        Dim txt = TryCast(Item.FindControl(controlName), System.Web.UI.WebControls.TextBox)
        If txt Is Nothing Then Throw New Exception($"TextBox '{controlName}' not found.")
        Return txt
    End Function

    ''' <summary>
    ''' Retrieves the HtmlTable control with the specified ID.
    ''' </summary>
    ''' <param name="controlName">The ID of the HtmlTable control.</param>
    ''' <returns>The HtmlTable control.</returns>
    ''' <exception cref="Exception">Thrown when the HtmlTable control is not found.</exception>
    Public Function HtmlTable(controlName As String) As HtmlTable
        Dim tbl = TryCast(Item.FindControl(controlName), HtmlTable)
        If tbl Is Nothing Then Throw New Exception($"HtmlTable '{controlName}' not found.")
        Return tbl
    End Function

    ''' <summary>
    ''' Retrieves the HtmlTableRow control with the specified ID.
    ''' </summary>
    ''' <param name="controlName">The ID of the HtmlTableRow control.</param>
    ''' <returns>The HtmlTableRow control.</returns>
    ''' <exception cref="Exception">Thrown when the HtmlTableRow control is not found.</exception>
    Public Function HtmlTableRow(controlName As String) As HtmlTableRow
        Dim tr = TryCast(Item.FindControl(controlName), HtmlTableRow)
        If tr Is Nothing Then Throw New Exception($"HtmlTableRow '{controlName}' not found.")
        Return tr
    End Function

    ''' <summary>
    ''' Retrieves the HtmlTableCell control with the specified ID.
    ''' </summary>
    ''' <param name="controlName">The ID of the HtmlTableCell control.</param>
    ''' <returns>The HtmlTableCell control.</returns>
    ''' <exception cref="Exception">Thrown when the HtmlTableCell control is not found.</exception>
    Public Function HtmlTableCell(controlName As String) As HtmlTableCell
        Dim td = TryCast(Item.FindControl(controlName), HtmlTableCell)
        If td Is Nothing Then Throw New Exception($"HtmlTableCell '{controlName}' not found.")
        Return td
    End Function
End Class

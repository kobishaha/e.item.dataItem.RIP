# RepeaterEventArgsWrapper

A lightweight helper class designed for ASP.NET (Web Forms) applications to simplify and centralize the common repetitive tasks involved in the `ItemDataBound` event of `Repeater` (and similar) controls. This class acts as a wrapper around the standard `RepeaterItemEventArgs`, providing clean, strongly-typed methods to access controls and data fields without constantly writing `FindControl` logic.

## Table of Contents
- [Why Use It](#why-use-it)
- [Key Features](#key-features)
- [Basic Usage](#basic-usage)
- [Handling Item Types](#handling-item-types)
- [API Overview](#api-overview)
- [Example](#example)
- [Potential Improvements](#potential-improvements)
- [Contributing](#contributing)
- [License](#license)

---

## Why Use It
1. **Cleaner Code**  
   Eliminate verbose `Dim lbl As Label = CType(e.Item.FindControl("lblName"), Label)` statements and unify your approach to working with ASP.NET server controls inside a Repeater’s (or DataList’s) `ItemDataBound` event.

2. **Centralized Error Handling**  
   If a control or a data column is missing, `RepeaterEventArgsWrapper` throws an exception by default. This fails fast and makes debugging easier, instead of returning `Nothing` quietly.

3. **Easy Maintenance**  
   Keeping the logic for control discovery and data-field extraction in one helper class keeps your code-behind smaller and easier to maintain.

---

## Key Features
- **Typed Accessors for Common Controls**  
  The class provides methods like `Label(controlName)`, `TextBox(controlName)`, `Image(controlName)`, etc., each returning the proper control type.
- **DataField Lookup**  
  A single function `DataField(columnName)` that returns the corresponding cell’s string value from the underlying `DataRowView`.
- **Event Args Wrapping**  
  Exposes `Item`, `Index`, `Type` (ListItemType), and more to reduce repeated checks.
- **GeneralItem Property**  
  Quickly checks whether the current item is a regular data item (`ListItemType.Item` or `ListItemType.AlternatingItem`), simplifying code that often checks multiple item types in a single condition.

---

## Basic Usage

1. **Add the class to your project**  
   Create a new `.vb` file named `RepeaterEventArgsWrapper.vb` and include the class source code.

2. **Instantiate in `ItemDataBound`**  
   ```vbnet
   Protected Sub rptSample_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rptSample.ItemDataBound
       Dim w As New RepeaterEventArgsWrapper(e)
       If w.GeneralItem Then
           w.Label("lblTitle").Text = w.DataField("TitleColumn")
           w.Image("imgLogo").ImageUrl = w.DataField("LogoUrl")
       End If
   End Sub

	3.	Compile and Run
Your code-behind will now be much cleaner, and you’ll quickly see any issues with missing controls or data columns.

Handling Item Types

Traditionally, you might see code like:

If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
    ' ...
End If

Using RepeaterEventArgsWrapper, you can simply write:

If w.GeneralItem Then
    ' ...
End If

to handle both ListItemType.Item and ListItemType.AlternatingItem in one condition.

If you need to check other item types (like Header or Footer), you can still use:

If w.Type = ListItemType.Header Then
    ' ...
ElseIf w.Type = ListItemType.Footer Then
    ' ...
End If

This makes it easier to maintain and read the logic around which part of the Repeater you’re working on.

API Overview

The class exposes several properties and methods for convenience:
	•	Properties
	•	Original As RepeaterItemEventArgs: The original event args.
	•	Item As RepeaterItem: The Repeater item in question.
	•	Type As ListItemType: The item’s type (Header, Footer, Item, AlternatingItem, etc.).
	•	Data As DataRowView: The underlying data row if it exists.
	•	Index As Integer: The position of the current item in the Repeater.
	•	GeneralItem As Boolean: True if Type is Item or AlternatingItem (useful for simplifying typical data-item checks).
	•	Methods
	•	DataField(columnName As String) As String: Returns the value of the specified column as a string (or throws an exception if not found).
	•	Label(controlName As String) As Label
	•	Literal(controlName As String) As Literal
	•	TextBox(controlName As String) As TextBox
	•	Panel(controlName As String) As Panel
	•	PlaceHolder(controlName As String) As PlaceHolder
	•	[Image](controlName As String) As System.Web.UI.WebControls.Image
	•	HyperLink(controlName As String) As System.Web.UI.WebControls.HyperLink
	•	HtmlGeneric(controlName As String) As HtmlGenericControl
	•	HtmlTable(controlName As String) As HtmlTable
	•	HtmlTableRow(controlName As String) As HtmlTableRow
	•	HtmlTableCell(controlName As String) As HtmlTableCell

(If you need more controls, just add new methods following the same pattern.)

Example

Protected Sub rptProducts_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rptProducts.ItemDataBound
    Dim w As New RepeaterEventArgsWrapper(e)
    
    ' Handle only 'Item' or 'AlternatingItem'
    If w.GeneralItem Then
        
        ' Set product name
        w.Label("lblProductName").Text = w.DataField("ProductName")
        
        ' Set product image
        w.Image("imgProduct").ImageUrl = w.DataField("ImageUrl")
        
        ' Show sale banner if item is on sale
        If w.DataField("IsOnSale") = "True" Then
            w.Panel("pnlSaleBanner").Visible = True
        End If
    ElseIf w.Type = ListItemType.Header Then
        ' Optional: handle header
    ElseIf w.Type = ListItemType.Footer Then
        ' Optional: handle footer
    End If
End Sub

Potential Improvements
	1.	Graceful Handling
Allow an optional “Try*” pattern for controls or data fields to return Nothing instead of throwing an exception. This could be useful in production where certain columns or controls might be optional.
	2.	Generic Conversions
Add a DataField(Of T)(columnName As String) method to handle direct conversions (e.g., integer, DateTime) without having to parse strings manually.
	3.	Extension Methods
Alternatively, you could define extension methods on RepeaterItemEventArgs to avoid needing a separate wrapper instantiation, though you might lose the easy debugging advantages of a dedicated wrapper class.
	4.	Handle Nested Repeaters
If your project has nested repeaters, you might consider an overload that wraps nested item events similarly.
	5.	Configuration for Exceptions
Provide a switch to enable/disable the exception-throwing behavior for missing controls/columns, or route it through a custom error handler.

Contributing

Contributions are welcome! Whether it’s adding support for more controls (e.g., CheckBox, DropDownList, LinkButton) or improving how data is accessed, feel free to fork and submit a pull request.

Steps to Contribute
	1.	Fork the repository.
	2.	Create a new branch for your feature (git checkout -b feature/my-improvement).
	3.	Commit your changes (git commit -am 'Add new control method').
	4.	Push to your branch (git push origin feature/my-improvement).
	5.	Create a Pull Request and describe your changes in detail.

License

This project is provided under the MIT License. Feel free to use it and modify it for both personal and commercial projects.

Happy Coding!
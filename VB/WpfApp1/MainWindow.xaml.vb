Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports DevExpress.Xpf.SpellChecker
Imports DevExpress.XtraSpellChecker.Parser

Namespace WpfApp1
	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits System.Windows.Window

		Public Sub New()
			DataContext = Me
			InitializeComponent()
		End Sub

		Public ReadOnly Property MenuItems() As ObservableCollection(Of Object)
		= New ObservableCollection(Of Object)()

		void RichTextBox_PreviewMouseRightButtonUp(Object sender, MouseButtonEventArgs e)
			MenuItems.Clear()
			Dim commands = Me.richTextBox.GetErrorOperationCommands(e.GetPosition(Me.richTextBox))
			For Each command In commands
				Dim menuItem = New MenuItem()
				menuItem.Header = command.Caption
				AddHandler menuItem.Click, Sub(s, args) command.DoCommand()
				menuItem.IsEnabled = command.Enabled
				MenuItems.Add(menuItem)
			Next command
			If MenuItems.Count = 0 Then
				MenuItems.Add(New MenuItem() With {.Header = "No Error", .IsEnabled = False})
			End If

		void TextBox_PreviewMouseRightButtonUp(Object sender, MouseButtonEventArgs e)
			MenuItems.Clear()
			Dim commands = Me.textBox.GetErrorOperationCommands(Me.textBox.SelectionStart)
			For Each command In commands
				Dim menuItem = New MenuItem()
				menuItem.Header = command.Caption
				AddHandler menuItem.Click, Sub(s, args) command.DoCommand()
				menuItem.IsEnabled = command.Enabled
				MenuItems.Add(menuItem)
			Next command
			If MenuItems.Count = 0 Then
				MenuItems.Add(New MenuItem() With {.Header = "No Error", .IsEnabled = False})
			End If
	End Class
End Namespace

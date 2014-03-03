Imports SC.BusinessLogic.Services.Dialog
Imports System.Windows.Forms
Imports SC.BusinessLogic.Service.Views

Namespace SC.BusinessLogic.Services.Dialog

    ''' <summary>
    ''' This is a very bare bones implementation of a Dialog service.
    ''' MessageBox is a bummer way to display messages in WPF.  Use TaskDialog or a TaskDialog replacment for a nicer experiece.
    ''' You should also have File Open, File Save, Folder Browswer operations.
    ''' </summary>
    Public Class ModalDialogService
        Implements IDialogService

#Region "Constructor"

        ''' <summary>
        ''' Initializes a new instance of the <see cref="ModalDialogService"/> class.
        ''' </summary>
        Public Sub New()
        End Sub

#End Region

#Region "Methods"

        Private Function GetButton(ByVal button As DialogButton) As MessageBoxButtons

            Select Case button

                Case DialogButton.OK
                    Return MessageBoxButtons.OK

                Case DialogButton.OKCancel
                    Return MessageBoxButtons.OKCancel

                Case DialogButton.YesNo
                    Return MessageBoxButtons.YesNo

                Case DialogButton.YesNoCancel
                    Return MessageBoxButtons.YesNoCancel
            End Select
            Throw New ArgumentOutOfRangeException("button", "Invalid button")
        End Function
        Private Function GetImage(ByVal image As DialogImage) As MessageBoxIcon

            Select Case image

                Case DialogImage.Asterisk
                    Return MessageBoxIcon.Asterisk

                Case DialogImage.Error
                    Return MessageBoxIcon.Error

                Case DialogImage.Exclamation
                    Return MessageBoxIcon.Exclamation

                Case DialogImage.Hand
                    Return MessageBoxIcon.Hand

                Case DialogImage.Information
                    Return MessageBoxIcon.Information

                Case DialogImage.None
                    Return MessageBoxIcon.None

                Case DialogImage.Question
                    Return MessageBoxIcon.Question

                Case DialogImage.Stop
                    Return MessageBoxIcon.Stop

                Case DialogImage.Warning
                    Return MessageBoxIcon.Warning
            End Select
            Throw New ArgumentOutOfRangeException("image", "Invalid image")
        End Function
        Private Function GetResponse(ByVal result As MsgBoxResult) As DialogResponse

            Select Case result

                Case MsgBoxResult.Cancel
                    Return DialogResponse.Cancel

                Case MsgBoxResult.No
                    Return DialogResponse.No

                    'Case MsgBoxResult.None
                    '    Return DialogResponse.None

                Case MsgBoxResult.Ok
                    Return DialogResponse.OK

                Case MsgBoxResult.Yes
                    Return DialogResponse.Yes
            End Select
            Throw New ArgumentOutOfRangeException("result", "Invalid result")
        End Function

        ''' <summary>
        ''' Shows the exception in a MessageBox.
        ''' </summary>
        ''' <param name="message">The message.</param>
        ''' <param name="image">The image.</param>
        ''' <returns><see cref="DialogResponse"/>.OK</returns>
        Public Function ShowException(ByVal message As String, Optional ByVal image As DialogImage = DialogImage.Error) As DialogResponse Implements IDialogService.ShowException
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, GetImage(image))
            Return DialogResponse.OK
        End Function

        ''' <summary>
        ''' Shows the message in a MessageBox.
        ''' </summary>
        ''' <param name="message">The message.</param>
        ''' <param name="caption">The caption.</param>
        ''' <param name="button">The button.</param>
        ''' <param name="image">The image.</param>
        ''' <returns><see cref="DialogResponse"/></returns>
        Public Function ShowMessage(ByVal message As String, ByVal caption As String, ByVal button As DialogButton, ByVal image As DialogImage) As DialogResponse Implements IDialogService.ShowMessage
            Return GetResponse(MessageBox.Show(message, caption, GetButton(button), GetImage(image)))
        End Function

        Public Function FileOpen(Optional directory As String = "", Optional filter As String = "") As String Implements IDialogService.FileOpen

            Dim fileDialogOpen As New OpenFileDialog
            ' check if the given initial directory exists
            If directory <> "" Then If FileIO.FileSystem.DirectoryExists(directory) Then fileDialogOpen.InitialDirectory = directory

            If filter <> "" Then fileDialogOpen.Filter = filter

            Dim result? As Boolean = fileDialogOpen.ShowDialog

            If result = True Then
                Return fileDialogOpen.FileName
            Else
                Return String.Empty
            End If

        End Function

        Public Function FileSave(filename As String, directory As String) As Boolean Implements IDialogService.FileSave

            'Dim filenameExtract = Split(filename, ".")
            'Dim extension = filenameExtract(1)
            Dim newFile = CStr(directory) & "\" & filename ' "\img_" & filenameExtract(0) & "." & extension
            Try
                System.IO.File.Copy(filename, newFile, True)
                Return True
            Catch ex As Exception
                Return False
            End Try

        End Function

        Public Function ShowMessageView(messageTitle As String, messageContent As String) As Boolean Implements IDialogService.ShowMessageView
            Dim showMessageDialog As New MessageView(messageTitle, messageContent)
            showMessageDialog.ShowDialog()

            Return True

        End Function

        'Public Function FolderBrowse() As String Implements IDialogService.FolderBrowse
        '    Return FileIO.FileSystem
        'End Function

        Public Function ShowBusyView(messageTitle As String, messageContent As String) As Boolean Implements IDialogService.ShowBusyView
            Dim showBusyDialog As New BusyView(messageTitle, messageContent)
            showBusyDialog.Show()

            Return True

        End Function

#End Region

    End Class

End Namespace
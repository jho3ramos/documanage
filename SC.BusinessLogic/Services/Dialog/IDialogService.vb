Namespace SC.BusinessLogic.Services.Dialog

    ''' <summary>
    ''' This is a very bare bones implementation of an IDialog service.
    ''' There should be many more overloads for showing messages to make programming easier and to provide support for TaskDialog.
    ''' You should also have File Open, File Save, Folder Browswer operations.
    ''' </summary>    
    Public Interface IDialogService
        Function ShowException(ByVal message As String, Optional ByVal image As DialogImage = DialogImage.Error) As DialogResponse
        Function ShowMessage(ByVal message As String, ByVal caption As String, ByVal button As DialogButton, ByVal image As DialogImage) As DialogResponse
        Function FileOpen(Optional directory As String = "", Optional filter As String = "") As String
        Function FileSave(ByVal filename As String, ByVal directory As String) As Boolean
        'Function FolderBrowse() As String
        Function ShowMessageView(messageTitle As String, messageContent As String) As Boolean
        Function ShowBusyView(messageTitle As String, messageContent As String) As Boolean

    End Interface

End Namespace

Imports GroupDocs.Search.Events

'ExStart:commonutilitiesclass
Public Class Utilities
    Public Const indexPath As String = "../../../../Data/Documents Indexes/"
    Public Const indexPath2 As String = "../../../../Data/Documents Indexes2/"
    Public Const documentsPath As String = "../../../../Data/Documents/"
    Public Const synonymFilePath As String = "../../../../Data/synonyms.txt"
    Public Const licensePath As String = "../../../../Data/Documents/GroupDocs.Total.lic"
 
    ''' <summary>
    ''' Apply license 
    ''' </summary>
    Public Shared Sub ApplyLicense()
        'initialize License
        Dim lic As New License()
        'Set license
        lic.SetLicense(licensePath)
    End Sub
    ''' <summary>
    ''' Index operation finished
    ''' </summary>
    ''' <param name="sender">Object</param>
    ''' <param name="e">OperationFinishedArg</param>
    Public Shared Sub index_OperationFinished(sender As Object, e As OperationFinishedArg)
        Dim time As DateTime = e.Time
        ' Time when documents added
        Dim indexId As Guid = e.IndexId
        ' Index Id
        Dim indexFolder As String = e.IndexFolder
        ' Index Folder
        Dim status As IndexStatus = e.Status
        ' Index Status
        Dim operationType As OperationType = e.OperationType
        ' Operation Type.
    End Sub
    ''' <summary>
    ''' Index operation finished
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function index_OperationFinished() As Object
        Throw New NotImplementedException
    End Function
End Class
'ExEnd:commonutilitiesclass

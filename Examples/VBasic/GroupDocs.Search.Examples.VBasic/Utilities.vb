Imports GroupDocs.Search.Events

'ExStart:commonutilitiesclass
Public Class Utilities

    Public Const indexPath As String = "../../../../Data/Documents Indexes/"
    Public Const indexPath2 As String = "../../../../Data/Documents Indexes2/"
    Public Const mergeIndexPath1 As String = "../../../../Data/Index Merging/Index1/"
    Public Const mergeIndexPath2 As String = "../../../../Data/Index Merging/Index2/"
    Public Const mainMergedIndexesPath As String = "../../../../Data/Index Merging/Main Merged Indexes/"
    Public Const documentsPath As String = "../../../../Data/Documents/"
    Public Const documentsPath2 As String = "../../../../Data/Documents2/"
    Public Const documentsPath3 As String = "../../../../Data/Documents3/"
    Public Const synonymFilePath As String = "../../../../Data/synonyms.txt"
    Public Const stopWordsFilePath As String = "../../../../Data/MyStopWords.txt"
    Public Const exportedStopWordsFilePath As String = "../../../../Data/MyExportedStopWords.txt"
    Public Const mySynonymFilePath As String = "../../../../Data/mySynonyms.txt"
    Public Const licensePath As String = "D:/Aspose Projects/License/GroupDocs.Total.lic"
    Public Const pathToPstFile As String = "D:/MyOutlookDataFile.pst"
    Public Const pathToPasswordProtectedFile As String = "../../../../Data/Documents/Password Protected Document.docx"
    Public Const pathToPasswordProtectedFile2  As String= "../../../../Data/Documents/Password Protected Document2.docx"
    Public Const pathToPasswordProtectedFile3 As String = "../../../../Data/Documents/Password Protected Document3.docx"
    Public Const exportedHomophonesFilePath As String = "../../../../Data/MyExportedHomophones.txt"
    Public Const homophonesFilePath As String = "../../../../Data/MyHomophones.txt"
    Public Const aliasFilePath As String = "../../../../Data/MyAliases.txt"
    Public Const exportedAliasFilePath As String = "../../../../Data/MyExportedAliases.txt"
    Public Const spellingDictionaryFilePath As String = "../../../../Data/MySpellingDictionary.txt"
    Public Const exportedSpellingDictionaryFilePath As String = "../../../../Data/MyExportedSpellingDictionary.txt"

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

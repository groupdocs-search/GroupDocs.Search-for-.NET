
'ExStart:Customfieldextractor
Class CustomFieldExtractor
    Implements IFieldExtractor
    Public ReadOnly Property Extensions() As String() Implements IFieldExtractor.Extensions
        'redefine internal field extractor
        Get
            Return {".doc", ".doc"}
        End Get

        'extractor for supporting new document format
        'Get
        '    Return {".doc", ".doc"}
        'End Get
    End Property
    Public Function GetFields(fileName As String) As FieldInfo() Implements IFieldExtractor.GetFields
        Dim result As FieldInfo() = New FieldInfo(3) {}
        result(0) = New FieldInfo("Content", "Hardcoded document content")
        result(1) = New FieldInfo("DocumentType", "MyDocumentType")
        result(2) = New FieldInfo("Author", "Hardcoded author")
        result(3) = New FieldInfo("CreationDate", "21.05.2004")
        Return result
    End Function
End Class
'ExEnd:Customfieldextractor


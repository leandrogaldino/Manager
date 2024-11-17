Imports ControlLibrary
''' <summary>
''' Representa uma atividade do CRM.
''' </summary>
Public Class CrmTreatment
    Inherits ChildModel
    Private _Responsible As New Person
    Private _Contact As Date = Today
    Private _NextContact As Date = Today
    Private _ContactType As CrmTreatmentContactType = CrmTreatmentContactType.Phone
    Private _Summary As String
    Public Property Responsible As Person
        Get
            Return _Responsible
        End Get
        Set
            _Responsible = Value
        End Set
    End Property
    Public Property Contact As Date
        Get
            Return _Contact
        End Get
        Set
            _Contact = Value
        End Set
    End Property
    Public Property NextContact As Date
        Get
            Return _NextContact
        End Get
        Set
            _NextContact = Value
        End Set
    End Property
    Public Property ContactType As CrmTreatmentContactType
        Get
            Return _ContactType
        End Get
        Set
            _ContactType = Value
            _ContactTypeImage = GetContactTypeImage(_ContactType)
        End Set
    End Property
    Private _ContactTypeImage As Image
    Public ReadOnly Property ContactTypeImage As Image
        Get
            Return _ContactTypeImage
        End Get
    End Property
    Public Property Summary As String
        Get
            Return _Summary
        End Get
        Set
            _Summary = Value

        End Set
    End Property
    Private Function GetContactTypeImage(ContactType As CrmTreatmentContactType) As Image
        Select Case ContactType
            Case = CrmTreatmentContactType.Phone
                Return My.Resources.ContactPhone
            Case = CrmTreatmentContactType.Email
                Return My.Resources.ContactEmail
            Case = CrmTreatmentContactType.Whatsapp
                Return My.Resources.ContactWhatsapp
            Case Else
                Return Nothing
        End Select
    End Function
    Public Sub New()
        SetRoutine(Routine.CrmTreatment)
    End Sub
End Class

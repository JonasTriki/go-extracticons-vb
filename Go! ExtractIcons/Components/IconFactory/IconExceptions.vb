Public Class IconExeptions
    Inherits Exception

    Public Enum ThrowingFor

        GetLastErrorResult = 1

        ResultError = 2

    End Enum

    Public Enum Errors

        IndexShoudBeInRange = 1

        NoIconsInTheList = 2

        TheFileDoesNotExistOrIsEmpty = 3

        TheFileDoesNotExist = 4

        TheFileIsNotAnValidWin32ExecutableOrDLL = 5

        AnUnexpectedErrorHasArrived = 6

        TheIconsToTheFileIsNotAvailableYouCantExtractIconsFromThisFile = 7

        TheIconsListShoudContainAtLeastOneIcon = 8

        TheIconIsEmpty = 9

    End Enum

#Region " GetLastErrorResult "

    Dim m_GetLastErrorResult As GetLastErrorResult

    Public Sub New(ByVal GetLastErrorResult As GetLastErrorResult)
        m_CurrentlyThrowingFor = ThrowingFor.GetLastErrorResult
        m_GetLastErrorResult = GetLastErrorResult
    End Sub

    Public ReadOnly Property GetLastErrorResult As GetLastErrorResult
        Get
            Return m_GetLastErrorResult
        End Get
    End Property

#End Region

#Region " ResultError "

    Dim m_ResultError As Errors

    Public Sub New(ByVal ErrorResult As Errors)
        m_CurrentlyThrowingFor = ThrowingFor.ResultError
        m_ResultError = m_ResultError
    End Sub

    Public ReadOnly Property ResultError As Errors
        Get
            Return m_ResultError
        End Get
    End Property

#End Region

    Dim m_CurrentlyThrowingFor As ThrowingFor

    Public ReadOnly Property CurrentlyThrowingFor As ThrowingFor
        Get
            Return m_CurrentlyThrowingFor
        End Get
    End Property

End Class
Module GlobalModule
    Public SharedTeamList As New List(Of String)
    Public GlobalFullTeams As New List(Of TeamData)

    Public Class TeamData
        Public Property Name As String
        Public Property Info As String
        Public Property Logo As Image
    End Class
End Module
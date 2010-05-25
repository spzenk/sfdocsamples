Imports System.Data.SqlClient
Public Class dbCustDragDrop

    Public Function FetchCustomers(ByVal sConnString As String) As DataTable
        Dim conn As SqlConnection
        Dim da As SqlDataAdapter
        Dim dtCust As DataTable
        Try

            conn = New SqlConnection()
            dtCust = New DataTable()
            conn.ConnectionString = sConnString
            conn.Open()
            da = New SqlDataAdapter("SELECT * FROM tipoproducto ORDER BY idtipoproducto", conn)
            da.Fill(dtCust)
            conn.Close()
            Return dtCust
        Catch ex As Exception
            Throw ex
        End Try

    End Function

End Class

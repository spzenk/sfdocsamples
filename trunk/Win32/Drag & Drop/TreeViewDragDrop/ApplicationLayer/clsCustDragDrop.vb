Public Class clsCustDragDrop
    Dim objdbCustDragDrop As dbCustDragDrop

    Public Function FetchCustomers(ByVal sConnString As String) As DataTable
        Try

            objdbCustDragDrop = New dbCustDragDrop()
            Return objdbCustDragDrop.FetchCustomers(sConnString)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class

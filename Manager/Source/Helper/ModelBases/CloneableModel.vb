Imports System.Reflection

Public MustInherit Class CloneableModel
    Public Function Clone() As CloneableModel
        Dim Cloned As CloneableModel = CType(MemberwiseClone(), CloneableModel)
        ClonePropertiesAndFields(Me, Cloned)
        Return Cloned
    End Function

    Private Sub ClonePropertiesAndFields(Original As Object, Clone As Object)
        Dim Properties As PropertyInfo() = Original.GetType().GetProperties(BindingFlags.Public Or BindingFlags.NonPublic Or BindingFlags.Instance)
        For Each [Property] As PropertyInfo In Properties
            If [Property].CanWrite Then
                Try
                    [Property].SetValue(Clone, [Property].GetValue(Original))
                Catch ex As Exception
                    Debug.Print("Erro ao copiar a propriedade: " & [Property].Name)
                End Try
            End If
        Next
        Dim Fields As FieldInfo() = Original.GetType().GetFields(BindingFlags.Public Or BindingFlags.NonPublic Or BindingFlags.Instance)
        For Each Field As FieldInfo In Fields
            Try
                Field.SetValue(Clone, Field.GetValue(Original))
            Catch ex As Exception
                Debug.Print("Erro ao copiar o campo: " & Field.Name)
            End Try
        Next
    End Sub
End Class

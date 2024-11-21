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
                    Dim Value = [Property].GetValue(Original)
                    If Value IsNot Nothing Then
                        If TypeOf Value Is ICloneable Then
                            [Property].SetValue(Clone, CType(Value, ICloneable).Clone())
                        ElseIf TypeOf Value Is IEnumerable Then
                            Dim NewList = CloneEnumerable(CType(Value, IEnumerable))
                            [Property].SetValue(Clone, NewList)
                        Else
                            [Property].SetValue(Clone, Value)
                        End If
                    End If
                Catch ex As Exception
                    Debug.Print("Erro ao copiar a propriedade: " & [Property].Name)
                End Try
            End If
        Next

        Dim Fields As FieldInfo() = Original.GetType().GetFields(BindingFlags.Public Or BindingFlags.NonPublic Or BindingFlags.Instance)
        For Each Field As FieldInfo In Fields
            Try
                Dim Value = Field.GetValue(Original)
                If Value IsNot Nothing Then
                    If TypeOf Value Is ICloneable Then
                        Field.SetValue(Clone, CType(Value, ICloneable).Clone())
                    ElseIf TypeOf Value Is IEnumerable Then
                        Dim NewList = CloneEnumerable(CType(Value, IEnumerable))
                        Field.SetValue(Clone, NewList)
                    Else
                        Field.SetValue(Clone, Value)
                    End If
                End If
            Catch ex As Exception
                Debug.Print("Erro ao copiar o campo: " & Field.Name)
            End Try
        Next
    End Sub

    Private Function CloneEnumerable(Source As IEnumerable) As Object
        Dim ListType = Source.GetType()
        Dim GenericType = ListType.GetGenericArguments().FirstOrDefault()
        If GenericType IsNot Nothing Then
            Dim NewList = Activator.CreateInstance(ListType)
            For Each Item In Source
                If TypeOf Item Is ICloneable Then
                    NewList.GetType().GetMethod("Add").Invoke(NewList, {CType(Item, ICloneable).Clone()})
                Else
                    NewList.GetType().GetMethod("Add").Invoke(NewList, {Item})
                End If
            Next
            Return NewList
        Else
            Return Nothing
        End If
    End Function
End Class

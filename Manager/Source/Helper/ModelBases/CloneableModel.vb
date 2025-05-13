Imports System.Reflection

Public MustInherit Class CloneableModel
    Public Function Clone() As CloneableModel
        Dim Cloned As CloneableModel = CType(MemberwiseClone(), CloneableModel)
        ClonePropertiesAndFields(Me, Cloned)
        Return Cloned
    End Function

    Private Sub ClonePropertiesAndFields(Original As Object, Clone As Object)
            ' Clona as propriedades
            Dim Properties As PropertyInfo() = Original.GetType().GetProperties(BindingFlags.Public Or BindingFlags.NonPublic Or BindingFlags.Instance)
            For Each [Property] As PropertyInfo In Properties
                If [Property].CanWrite Then
                    Try
                        Dim Value = [Property].GetValue(Original)
                        If Value IsNot Nothing Then
                            If TypeOf Value Is ICloneable Then
                                [Property].SetValue(Clone, CType(Value, ICloneable).Clone())
                            ElseIf TypeOf Value Is IEnumerable Then
                                Dim NewCollection = CloneEnumerable(CType(Value, IEnumerable))
                                [Property].SetValue(Clone, NewCollection)
                            Else
                                [Property].SetValue(Clone, Value)
                            End If
                        End If
                    Catch ex As Exception
                        Debug.Print("Erro ao copiar a propriedade: " & [Property].Name)
                    End Try
                End If
            Next

            ' Clona os campos
            Dim Fields As FieldInfo() = Original.GetType().GetFields(BindingFlags.Public Or BindingFlags.NonPublic Or BindingFlags.Instance)
            For Each Field As FieldInfo In Fields
                Try
                    Dim Value = Field.GetValue(Original)
                    If Value IsNot Nothing Then
                        If TypeOf Value Is ICloneable Then
                            Field.SetValue(Clone, CType(Value, ICloneable).Clone())
                        ElseIf TypeOf Value Is IEnumerable Then
                            Dim NewCollection = CloneEnumerable(CType(Value, IEnumerable))
                            Field.SetValue(Clone, NewCollection)
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
            If Source Is Nothing Then Return Nothing

            Dim ListType = Source.GetType()

            ' Trata coleções genéricas (exemplo: List(Of T))
            If ListType.IsGenericType Then
                Dim NewList = Activator.CreateInstance(ListType)
                For Each Item In Source
                    Dim ClonedItem = If(TypeOf Item Is ICloneable, CType(Item, ICloneable).Clone(), DeepCloneObject(Item))
                    NewList.GetType().GetMethod("Add").Invoke(NewList, {ClonedItem})
                Next
                Return NewList
            End If

            ' Trata arrays
            If ListType.IsArray Then
                Dim OriginalArray = CType(Source, Array)
                Dim ElementType = OriginalArray.GetType().GetElementType()
                Dim ClonedArray = Array.CreateInstance(ElementType, OriginalArray.Length)
                For i As Integer = 0 To OriginalArray.Length - 1
                    Dim ClonedItem = If(TypeOf OriginalArray.GetValue(i) Is ICloneable, CType(OriginalArray.GetValue(i), ICloneable).Clone(), DeepCloneObject(OriginalArray.GetValue(i)))
                    ClonedArray.SetValue(ClonedItem, i)
                Next
                Return ClonedArray
            End If

            ' Coleções não genéricas
            Dim NewCollection = Activator.CreateInstance(ListType)
            For Each Item In Source
                Dim ClonedItem = If(TypeOf Item Is ICloneable, CType(Item, ICloneable).Clone(), DeepCloneObject(Item))
                NewCollection.GetType().GetMethod("Add").Invoke(NewCollection, {ClonedItem})
            Next

            Return NewCollection
        End Function

        Private Function DeepCloneObject(Value As Object) As Object
            If Value Is Nothing Then Return Nothing

            Dim Type = Value.GetType()
            If Type.IsValueType OrElse Type = GetType(String) Then
                Return Value
            End If

            Dim CloneMethod = Type.GetMethod("MemberwiseClone", BindingFlags.Instance Or BindingFlags.NonPublic)
            If CloneMethod IsNot Nothing Then
                Dim ClonedObject = CloneMethod.Invoke(Value, Nothing)
                ClonePropertiesAndFields(Value, ClonedObject)
                Return ClonedObject
            End If

            Return Value

    End Function
    End Class


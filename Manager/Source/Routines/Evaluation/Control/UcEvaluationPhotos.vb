Imports System.Collections.ObjectModel
Imports System.Collections.Specialized
Imports System.ComponentModel
Imports System.IO

Public Class UcEvaluationPhotos
    Private _SelectedPhoto As Image = Nothing
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
    Public Property SelectedPhoto As Image
        Get
            Return _SelectedPhoto
        End Get
        Set(value As Image)
            _SelectedPhoto = value
            If _SelectedPhoto IsNot Nothing Then
                PbxPhoto.Image = ResizePhoto(_SelectedPhoto)
            Else
                PbxPhoto.Image = Nothing
            End If
        End Set
    End Property

    Public Property Photos As ObservableCollection(Of Image)

    Public Sub New()
        InitializeComponent()
        Photos = New ObservableCollection(Of Image)()
    End Sub
    Private Sub UcEvaluationPhotos_Load(sender As Object, e As EventArgs) Handles Me.Load
        AddHandler Photos.CollectionChanged, AddressOf OnCollectionChanged
    End Sub

    Private Sub OnCollectionChanged(sender As Object, e As NotifyCollectionChangedEventArgs)
        If e.Action = NotifyCollectionChangedAction.Add Then
            ' Se um item foi adicionado, atribui o SelectedPhoto a esse item
            If e.NewItems.Count > 0 Then
                SelectedPhoto = CType(e.NewItems(0), Image)
            End If
        ElseIf e.Action = NotifyCollectionChangedAction.Remove Then
            ' Se um item foi removido, verifica se é o SelectedPhoto
            If e.OldItems.Count > 0 Then
                Dim removedPhoto As Image = CType(e.OldItems(0), Image)

                If removedPhoto Is SelectedPhoto Then
                    ' Se o item removido é o SelectedPhoto, tenta pegar o próximo ou anterior
                    Dim currentIndex As Integer = Photos.IndexOf(removedPhoto)

                    If currentIndex < Photos.Count Then
                        ' Se há um próximo item, atribui
                        SelectedPhoto = Photos(currentIndex)
                    ElseIf currentIndex > 0 Then
                        ' Se não há próximo, mas há um anterior, atribui
                        SelectedPhoto = Photos(currentIndex - 1)
                    Else
                        ' Se não há próximo nem anterior, define como Nothing
                        SelectedPhoto = Nothing
                    End If
                Else
                    ' Se não for o SelectedPhoto, apenas remove
                    ' Neste caso, não é necessário fazer nada, pois a coleção já foi atualizada
                End If
            End If
        End If
    End Sub

    Private Sub BtnInclude_Click(sender As Object, e As EventArgs) Handles BtnInclude.Click
        Using openFileDialog As New OpenFileDialog()
            openFileDialog.Filter = "Imagens|*.jpg;*.jpeg;*.png;*.bmp|Todos os arquivos|*.*"
            openFileDialog.Title = "Selecionar Imagem"
            If openFileDialog.ShowDialog() = DialogResult.OK Then
                Dim selectedImagePath As String = openFileDialog.FileName
                Dim newPhoto As String = selectedImagePath
                Photos.Add(Image.FromStream(New MemoryStream(File.ReadAllBytes(newPhoto))))
            End If
        End Using
    End Sub



    Private Function ResizePhoto(Photo As Image) As Image
        ' Verificar se a imagem excede 1920x1280
        If Photo.Width > 960 OrElse Photo.Height > 540 Then
            ' Calcular o fator de escala para manter a proporção
            Dim escalaLargura As Single = 960 / Photo.Width
            Dim escalaAltura As Single = 540 / Photo.Height
            Dim escala As Single = Math.Min(escalaLargura, escalaAltura)

            ' Calcular novas dimensões
            Dim novaLargura As Integer = CInt(Photo.Width * escala)
            Dim novaAltura As Integer = CInt(Photo.Height * escala)

            ' Criar nova imagem redimensionada
            Dim novaImagem As New Bitmap(Photo, novaLargura, novaAltura)
            Photo.Dispose() ' Liberar recursos da imagem original
            Return novaImagem
        Else
            ' Retorna a imagem original se não precisar redimensionar
            Return Photo
        End If
    End Function

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click

    End Sub
End Class

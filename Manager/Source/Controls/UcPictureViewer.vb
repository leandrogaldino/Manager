Imports System.Collections.ObjectModel
Imports System.Collections.Specialized
Imports System.ComponentModel
Imports System.IO

Public Class UcPictureViewer
    Private _SelectedPicture As Image = Nothing
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
    Public Property SelectedPicture As Image
        Get
            Return _SelectedPicture
        End Get
        Set(value As Image)
            _SelectedPicture = value
            If _SelectedPicture IsNot Nothing Then
                PbxPicture.Image = ResizePicture(_SelectedPicture)
            Else
                PbxPicture.Image = Nothing
            End If
        End Set
    End Property
    Public Property Pictures As ObservableCollection(Of Image)
    Public Sub New()
        InitializeComponent()
        Pictures = New ObservableCollection(Of Image)()
    End Sub
    Private Sub UcPictureViewer_Load(sender As Object, e As EventArgs) Handles Me.Load
        AddHandler Pictures.CollectionChanged, AddressOf OnCollectionChanged
    End Sub
    Private Sub OnCollectionChanged(sender As Object, e As NotifyCollectionChangedEventArgs)
        If e.Action = NotifyCollectionChangedAction.Add Then
            ' Se um item foi adicionado, atribui o SelectedPicture a esse item
            If e.NewItems.Count > 0 Then
                SelectedPicture = CType(e.NewItems(0), Image)
            End If
        ElseIf e.Action = NotifyCollectionChangedAction.Remove Then
            ' Se um item foi removido, verifica se é o SelectedPicture
            If e.OldItems.Count > 0 Then
                Dim RemovedPicture As Image = CType(e.OldItems(0), Image)

                If RemovedPicture Is SelectedPicture Then
                    ' Se o item removido é o SelectedPicture, tenta pegar o próximo ou anterior
                    Dim currentIndex As Integer = Pictures.IndexOf(RemovedPicture)

                    If currentIndex < Pictures.Count Then
                        ' Se há um próximo item, atribui
                        SelectedPicture = Pictures(currentIndex)
                    ElseIf currentIndex > 0 Then
                        ' Se não há próximo, mas há um anterior, atribui
                        SelectedPicture = Pictures(currentIndex - 1)
                    Else
                        ' Se não há próximo nem anterior, define como Nothing
                        SelectedPicture = Nothing
                    End If
                Else
                    ' Se não for o SelectedPicture, apenas remove
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
                Dim NewPicture As String = selectedImagePath
                Pictures.Add(Image.FromStream(New MemoryStream(File.ReadAllBytes(NewPicture))))
            End If
        End Using
    End Sub
    Private Function ResizePicture(Picture As Image) As Image
        ' Verificar se a imagem excede 1920x1280
        If Picture.Width > 960 OrElse Picture.Height > 540 Then
            ' Calcular o fator de escala para manter a proporção
            Dim escalaLargura As Single = 960 / Picture.Width
            Dim escalaAltura As Single = 540 / Picture.Height
            Dim escala As Single = Math.Min(escalaLargura, escalaAltura)

            ' Calcular novas dimensões
            Dim novaLargura As Integer = CInt(Picture.Width * escala)
            Dim novaAltura As Integer = CInt(Picture.Height * escala)

            ' Criar nova imagem redimensionada
            Dim novaImagem As New Bitmap(Picture, novaLargura, novaAltura)
            Picture.Dispose() ' Liberar recursos da imagem original
            Return novaImagem
        Else
            ' Retorna a imagem original se não precisar redimensionar
            Return Picture
        End If
    End Function
End Class

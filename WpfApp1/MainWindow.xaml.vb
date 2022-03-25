Imports System.Net.Http
Imports Newtonsoft.Json

Class MainWindow
    Private Sub RadioButton_Checked(sender As Object, e As RoutedEventArgs)

    End Sub

    Private Sub TextBox_TextChanged(sender As Object, e As TextChangedEventArgs)

    End Sub

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        Dim data
        Dim dogBreedDetails() As String
        Dim dogBreed As String

        lblDogBreed.Content = "Bringing a dog..."

        Using client = New HttpClient()
            client.BaseAddress = New Uri("https://dog.ceo")
            Dim response = client.GetAsync("/api/breeds/image/random").Result

            If response.StatusCode = 200 Then
                Dim json = JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result)
                data = json.First().Value
                'response.Content.ReadAsStringAsync().Result
                dogBreedDetails = data.Value.Split("/".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                dogBreed = dogBreedDetails(3)

                lblDogBreed.Content = dogBreed
                dogImage.Source = New BitmapImage(New Uri(data.Value, UriKind.RelativeOrAbsolute))

            End If

        End Using
    End Sub
End Class

Public Class Login
    Private usuarios As New Dictionary(Of String, String) From {{"admin", "admin123"}, {"usuario1", "contraseña1"}}
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        ' Obtener el nombre de usuario y la contraseña ingresados
        Dim usuario As String = txtAdmin.Text
        Dim contraseña As String = txtPassword.Text

        ' Verificar si el usuario existe y la contraseña es correcta
        If usuarios.ContainsKey(usuario) AndAlso usuarios(usuario) = contraseña Then
            ' Si las credenciales son válidas, mostrar un mensaje y permitir el acceso al sistema
            MessageBox.Show("Inicio de sesión exitoso", "Bienvenido", MessageBoxButtons.OK, MessageBoxIcon.Information)


            MenuAdmin.Show()
            Me.Hide()
        Else
            ' Si las credenciales no son válidas, mostrar un mensaje de error
            MessageBox.Show("Nombre de usuario o contraseña incorrectos", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error)

            ' Limpiar los campos de texto
            txtAdmin.Clear()
            txtPassword.Clear()

            ' Establecer el foco en el cuadro de texto del nombre de usuario
            txtAdmin.Focus()


        End If
    End Sub
End Class

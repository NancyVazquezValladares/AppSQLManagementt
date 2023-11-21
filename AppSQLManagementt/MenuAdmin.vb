Imports System.Data.SqlClient
Imports System.Runtime.Remoting.Messaging
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class MenuAdmin
    Dim connectionString As String = "Data Source=LAPTOP-9KA9VTM6\SQLEXPRESS01;Initial Catalog=Fragancias;Integrated Security=True"

    Private Sub EmpleadoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmpleadoToolStripMenuItem.Click
        PanelEmpleados.BringToFront()
    End Sub
    Private Sub txtContrasena_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtContrasena.KeyPress
        If Not Char.IsControl(e.KeyChar) Then
            e.KeyChar = "*"
        End If

    End Sub
    Private Sub BtnAgregarE_Click(sender As Object, e As EventArgs) Handles BtnAgregarE.Click
        Dim nombre As String = TextBox1.Text
        Dim rol As String = TextBox2.Text
        Dim contrasena As String = txtContrasena.Text

        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Using command As New SqlCommand("AgregarEmpleado", connection)
                    command.CommandType = CommandType.StoredProcedure
                    ' Agrega los parámetros
                    command.Parameters.AddWithValue("@Nombre", nombre)
                    command.Parameters.AddWithValue("@Rol", rol)
                    command.Parameters.AddWithValue("@Contrasena", contrasena)
                    ' Ejecuta el procedimiento almacenado
                    command.ExecuteNonQuery()
                    MessageBox.Show("Empleado agregado correctamente.")
                End Using
            End Using
            mostrar_datosE()
        Catch ex As Exception
            MessageBox.Show("Error al agregar empleado: " & ex.Message)
        End Try

        EliminarTextos()
    End Sub

    Private Sub BtbModificarE_Click(sender As Object, e As EventArgs) Handles BtbModificarE.Click
        Dim nuevoNombre As String = TextBox1.Text
        Dim nuevoRol As String = TextBox2.Text
        Dim nuevaContrasena As String = txtContrasena.Text

        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Using command As New SqlCommand("ActualizarEmpleado", connection)
                    command.CommandType = CommandType.StoredProcedure
                    ' Agrega los parámetros
                    command.Parameters.AddWithValue("@Nombre", nuevoNombre)
                    command.Parameters.AddWithValue("@Rol", nuevoRol)
                    command.Parameters.AddWithValue("@Contrasena", nuevaContrasena)

                    ' Ejecuta el procedimiento almacenado
                    command.ExecuteNonQuery()

                    MessageBox.Show("Empleado actualizado correctamente.")
                    command.ExecuteNonQuery()
                End Using

            End Using
            mostrar_datosE()
        Catch ex As Exception
            MessageBox.Show("Error al actualizar empleado: ")
        End Try


        EliminarTextos()
    End Sub

    Private Sub BtnLeerE_Click(sender As Object, e As EventArgs) Handles BtnLeerE.Click
        mostrar_datosE()
    End Sub

    Private Sub BtnEliminarE_Click(sender As Object, e As EventArgs) Handles BtnEliminarE.Click
        Dim nombreEmpleado As String = TextBox4.Text
        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()
                Using command As New SqlCommand("EliminarEmpleado", connection)
                    command.CommandType = CommandType.StoredProcedure
                    ' Agrega el parámetro
                    command.Parameters.AddWithValue("@NombreEmpleado", nombreEmpleado)

                    ' Ejecuta el procedimiento almacenado
                    command.ExecuteNonQuery()

                    MessageBox.Show("Empleado eliminado correctamente.")
                    command.ExecuteNonQuery()

                End Using
            End Using
            mostrar_datosE()
        Catch ex As Exception
            MessageBox.Show("Error al eliminar empleado: " & ex.Message)
        End Try


        EliminarTextos()
    End Sub
    Private Sub mostrar_datosE()
        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Using command As New SqlCommand("ObtenerEmpleados", connection)
                    command.CommandType = CommandType.StoredProcedure

                    Using adapter As New SqlDataAdapter(command)
                        Dim dataTable As New DataTable()
                        adapter.Fill(dataTable)
                        ' Muestra los resultados en un DataGridView (asumiendo que tienes un control DataGridView llamado dgvEmpleados en tu formulario)
                        DataGridView1.DataSource = dataTable
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al leer empleados: " & ex.Message)


        End Try

        EliminarTextos()
    End Sub

    Private Sub MenuAdmin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mostrar_datosE()
        mostrar_datosC()
    End Sub

    Private Sub BtnAgregarC_Click(sender As Object, e As EventArgs) Handles BtnAgregarC.Click
        Dim nombre As String = TextBox1.Text
        Dim telefono As String = TextBox2.Text
        Dim correo_cliente As String = TextBox3.Text
        Dim direccion As String = TextBox3.Text
        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Using command As New SqlCommand("AgregarCliente", connection)
                    command.CommandType = CommandType.StoredProcedure
                    ' Agrega los parámetros
                    command.Parameters.AddWithValue("@Nombre_Cliente", nombre)
                    command.Parameters.AddWithValue("@Telefono", telefono)
                    command.Parameters.AddWithValue("@Correo_Cliente", correo_cliente)
                    command.Parameters.AddWithValue("@Direccion", direccion)
                    ' Ejecuta el procedimiento almacenado
                    command.ExecuteNonQuery()
                    MessageBox.Show("Cliente agregado correctamente.")
                End Using
            End Using
            mostrar_datosC()
        Catch ex As Exception
            MessageBox.Show("Error al agregar empleado: " & ex.Message)
        End Try

        EliminarTextos()
    End Sub

    Private Sub BtbModificarC_Click(sender As Object, e As EventArgs) Handles BtbModificarC.Click
        Dim nombre As String = TextBox1.Text
        Dim telefono As String = TextBox2.Text
        Dim correo_cliente As String = TextBox3.Text
        Dim direccion As String = TextBox5.Text

        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Using command As New SqlCommand("ActualizarCliente", connection)
                    command.CommandType = CommandType.StoredProcedure
                    ' Agrega los parámetros
                    command.Parameters.AddWithValue("@Nombre_Cliente", nombre)
                    command.Parameters.AddWithValue("@Telefono", telefono)
                    command.Parameters.AddWithValue("@Correo_Cliente", correo_cliente)
                    command.Parameters.AddWithValue("@Direccion", direccion)
                    ' Ejecuta el procedimiento almacenado
                    command.ExecuteNonQuery()

                    MessageBox.Show("Cliente actualizado correctamente.")
                    command.ExecuteNonQuery()
                End Using

            End Using
            mostrar_datosC()
        Catch ex As Exception
            MessageBox.Show("Error al actualizar Cliente: ")
        End Try


        EliminarTextos()
    End Sub

    Private Sub BtnLeerC_Click(sender As Object, e As EventArgs) Handles BtnLeerC.Click
        mostrar_datosC()
    End Sub

    Private Sub BtnEliminarC_Click(sender As Object, e As EventArgs) Handles BtnEliminarC.Click
        Dim nombreEmpleado As String = TextBox1.Text
        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()
                Using command As New SqlCommand("EliminarCliente", connection)
                    command.CommandType = CommandType.StoredProcedure
                    ' Agrega el parámetro
                    command.Parameters.AddWithValue("@Nombre_Cliente", nombreEmpleado)

                    ' Ejecuta el procedimiento almacenado
                    command.ExecuteNonQuery()

                    MessageBox.Show("Cliente eliminado correctamente.")
                    command.ExecuteNonQuery()

                End Using
            End Using
            mostrar_datosC()
        Catch ex As Exception
            MessageBox.Show("Error al eliminar Cliente: " & ex.Message)
        End Try


        EliminarTextos()
    End Sub
    Private Sub mostrar_datosC()
        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Using command As New SqlCommand("ObtenerCliente", connection)
                    command.CommandType = CommandType.StoredProcedure

                    Using adapter As New SqlDataAdapter(command)
                        Dim dataTable As New DataTable()
                        adapter.Fill(dataTable)
                        ' Muestra los resultados en un DataGridView (asumiendo que tienes un control DataGridView llamado dgvEmpleados en tu formulario)
                        DataGridView1.DataSource = dataTable
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al leer empleados: " & ex.Message)


        End Try

        EliminarTextos()
    End Sub

    Private Sub ClientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClientesToolStripMenuItem.Click
        PanelClientes.BringToFront()

    End Sub

    Private Sub agregarV_Click(sender As Object, e As EventArgs) Handles agregarV.Click
        Dim Fecha = DateTimePicker1
        Dim Cantidad As String = TextBox2.Text
        Dim id_Empleado As String = TextBox3.Text
        Dim id_Producto As String = TextBox4.Text

        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()
                Using command As New SqlCommand("AgregarVenta", connection)
                    command.CommandType = CommandType.StoredProcedure
                    ' Agrega el parámetro
                    command.Parameters.AddWithValue("@Fecha", Fecha)
                    command.Parameters.AddWithValue("@Cantidad", Cantidad)
                    command.Parameters.AddWithValue("@id_Empleado", id_Empleado)
                    command.Parameters.AddWithValue(" @id_Producto", id_Producto)

                    ' Ejecuta el procedimiento almacenado
                    command.ExecuteNonQuery()

                    MessageBox.Show("Agregado correctamente.")
                    command.ExecuteNonQuery()

                End Using
            End Using
            mostrar_datosV()
        Catch ex As Exception
            MessageBox.Show("Error al Agregar: " & ex.Message)
        End Try

        EliminarTextos()
    End Sub

    Private Sub VentasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VentasToolStripMenuItem.Click
        PanelVentas.BringToFront()
    End Sub

    Private Sub ModificarV_Click(sender As Object, e As EventArgs) Handles ModificarV.Click
        Dim Fecha = DateTimePicker1
        Dim Cantidad As String = TextBox2.Text
        Dim id_Empleado As String = TextBox3.Text
        Dim id_Producto As String = TextBox4.Text
        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Using command As New SqlCommand("ModificarVenta", connection)
                    command.CommandType = CommandType.StoredProcedure
                    ' Agrega los parámetros
                    command.Parameters.AddWithValue("@Fecha", Fecha)
                    command.Parameters.AddWithValue("@Cantidad", Cantidad)
                    command.Parameters.AddWithValue("@id_Empleado", id_Empleado)
                    command.Parameters.AddWithValue(" @id_Producto", id_Producto)

                    command.ExecuteNonQuery()

                    MessageBox.Show("Actualizado correctamente.")
                    command.ExecuteNonQuery()
                End Using

            End Using
            mostrar_datosV()
        Catch ex As Exception
            MessageBox.Show("Error al actualizar: ")
        End Try

        EliminarTextos()
    End Sub

    Private Sub LeerV_Click(sender As Object, e As EventArgs) Handles LeerV.Click
        mostrar_datosV()

        EliminarTextos()
    End Sub

    Private Sub EliminarV_Click(sender As Object, e As EventArgs) Handles EliminarV.Click
        Dim id_Venta As String = TextBox2.Text
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()
                Using command As New SqlCommand("EliminarVenta", connection)
                    command.CommandType = CommandType.StoredProcedure
                    ' Agrega el parámetro
                    command.Parameters.AddWithValue("@id_Venta", id_Venta)


                    ' Ejecuta el procedimiento almacenado
                    command.ExecuteNonQuery()

                    MessageBox.Show("eliminado correctamente.")
                    command.ExecuteNonQuery()

                End Using
            End Using
            mostrar_datosV()
        Catch ex As Exception
            MessageBox.Show("Error al eliminado: " & ex.Message)
        End Try

        EliminarTextos()
    End Sub
    Private Sub mostrar_datosV()
        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Using command As New SqlCommand("ObtenerVentas", connection)
                    command.CommandType = CommandType.StoredProcedure

                    Using adapter As New SqlDataAdapter(command)
                        Dim dataTable As New DataTable()
                        adapter.Fill(dataTable)
                        ' Muestra los resultados en un DataGridView (asumiendo que tienes un control DataGridView llamado dgvEmpleados en tu formulario)
                        DataGridView1.DataSource = dataTable
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al leer: " & ex.Message)


        End Try
        EliminarTextos()
    End Sub
    Private Sub EliminarTextos()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
        TextBox9.Clear()
        TextBox10.Clear()
        TextBox11.Clear()
        TextBox12.Clear()
        TextBox13.Clear()
        TextBox14.Clear()
        TextBox15.Clear()
        TextBox16.Clear()
        TextBox17.Clear()
        TextBox18.Clear()
        TextBox19.Clear()
        TextBox20.Clear()
        TextBox21.Clear()
        TextBox22.Clear()
        TextBox23.Clear()
        TextBox24.Clear()
        TextBox25.Clear()
        TextBox26.Clear()
        TextBox27.Clear()
        TextBox28.Clear()
        TextBox29.Clear()
        TextBox30.Clear()
        TextBox31.Clear()

    End Sub



    Private Sub AgregarDV_Click(sender As Object, e As EventArgs) Handles AgregarDV.Click
        Dim Producto As String = TextBox14.Text
        Dim Precio As String = TextBox13.Text
        Dim Total As String = TextBox12.Text
        Dim monto As String = TextBox11.Text
        Dim Resto As String = TextBox15.Text
        Dim Venta As String = TextBox16.Text
        Dim Cliente As String = TextBox17.Text
        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()
                Using command As New SqlCommand("AgregarVenta", connection)
                    command.CommandType = CommandType.StoredProcedure
                    ' Agrega el parámetro
                    command.Parameters.AddWithValue("@Producto", Producto)
                    command.Parameters.AddWithValue(" @Precio", Precio)
                    command.Parameters.AddWithValue("@Total", Total)
                    command.Parameters.AddWithValue(" @Monto", monto)
                    command.Parameters.AddWithValue(" @Resto", Resto)
                    command.Parameters.AddWithValue(" @id_Venta", Venta)
                    command.Parameters.AddWithValue(" @id_Cliente ", Cliente)

                    ' Ejecuta el procedimiento almacenado
                    command.ExecuteNonQuery()

                    MessageBox.Show("Agregado correctamente.")
                    command.ExecuteNonQuery()

                End Using
            End Using
            mostrar_datosDV()
        Catch ex As Exception
            MessageBox.Show("Error al Agregar: " & ex.Message)
        End Try
        EliminarTextos()
    End Sub

    Private Sub ModDv_Click(sender As Object, e As EventArgs) Handles ModDv.Click
        Dim Producto As String = TextBox14.Text
        Dim Precio As String = TextBox13.Text
        Dim Total As String = TextBox12.Text
        Dim monto As String = TextBox11.Text
        Dim Resto As String = TextBox15.Text
        Dim Venta As String = TextBox16.Text
        Dim Cliente As String = TextBox17.Text
        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Using command As New SqlCommand("ModificarVenta", connection)
                    command.CommandType = CommandType.StoredProcedure
                    ' Agrega los parámetros
                    command.Parameters.AddWithValue("@Producto", Producto)
                    command.Parameters.AddWithValue(" @Precio", Precio)
                    command.Parameters.AddWithValue("@Total", Total)
                    command.Parameters.AddWithValue(" @Monto", monto)
                    command.Parameters.AddWithValue(" @Resto", Resto)
                    command.Parameters.AddWithValue(" @id_Venta", Venta)
                    command.Parameters.AddWithValue(" @id_Cliente ", Cliente)
                    command.ExecuteNonQuery()

                    MessageBox.Show("Actualizado correctamente.")
                    command.ExecuteNonQuery()
                End Using

            End Using
            mostrar_datosDV()
        Catch ex As Exception
            MessageBox.Show("Error al actualizar: ")
        End Try

    End Sub

    Private Sub LeerDV_Click(sender As Object, e As EventArgs) Handles LeerDV.Click
        mostrar_datosDV()
    End Sub

    Private Sub EliminarDV_Click(sender As Object, e As EventArgs) Handles EliminarDV.Click
        Dim producto As String = TextBox14.Text

        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()
                Using command As New SqlCommand("EliminarDetalleVenta", connection)
                    command.CommandType = CommandType.StoredProcedure
                    ' Agrega el parámetro
                    command.Parameters.AddWithValue("@Producto", producto)


                    ' Ejecuta el procedimiento almacenado
                    command.ExecuteNonQuery()

                    MessageBox.Show("eliminado correctamente.")
                    command.ExecuteNonQuery()

                End Using
            End Using
            mostrar_datosDV()
        Catch ex As Exception
            MessageBox.Show("Error al eliminado: " & ex.Message)
        End Try
    End Sub
    Private Sub mostrar_datosDV()
        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Using command As New SqlCommand("ObtenerDetalleVentas", connection)
                    command.CommandType = CommandType.StoredProcedure

                    Using adapter As New SqlDataAdapter(command)
                        Dim dataTable As New DataTable()
                        adapter.Fill(dataTable)
                        ' Muestra los resultados en un DataGridView (asumiendo que tienes un control DataGridView llamado dgvEmpleados en tu formulario)
                        DataGridView4.DataSource = dataTable
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al leer: " & ex.Message)


        End Try
        EliminarTextos()
    End Sub

    Private Sub ProductosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductosToolStripMenuItem.Click
        PanelProductos.BringToFront()
    End Sub

    Private Sub AgregarP_Click(sender As Object, e As EventArgs) Handles AgregarP.Click
        Dim descripcion As String = TextBox20.Text
        Dim Precio As String = TextBox19.Text
        Dim Stock As String = TextBox18.Text

        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Using command As New SqlCommand("AgregarProducto", connection)
                    command.CommandType = CommandType.StoredProcedure
                    ' Agrega los parámetros
                    command.Parameters.AddWithValue("@Descripcion", descripcion)
                    command.Parameters.AddWithValue("@Precio", Precio)
                    command.Parameters.AddWithValue("@Stock", Stock)
                    ' Ejecuta el procedimiento almacenado
                    command.ExecuteNonQuery()
                    MessageBox.Show("Producto agregado correctamente.")
                End Using
            End Using
            mostrar_datosP()
        Catch ex As Exception
            MessageBox.Show("Error al agregar Producto : " & ex.Message)
        End Try
        EliminarTextos()
    End Sub

    Private Sub ModP_Click(sender As Object, e As EventArgs) Handles ModP.Click
        Dim descripcion As String = TextBox20.Text
        Dim Precio As String = TextBox19.Text
        Dim Stock As String = TextBox18.Text
        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Using command As New SqlCommand("ActualizarProducto", connection)
                    command.CommandType = CommandType.StoredProcedure
                    ' Agrega los parámetros
                    command.Parameters.AddWithValue("@Descipcion", descripcion)
                    command.Parameters.AddWithValue("@Precio", Precio)
                    command.Parameters.AddWithValue("@Stock", Stock)

                    ' Ejecuta el procedimiento almacenado
                    command.ExecuteNonQuery()

                    MessageBox.Show("Producto actualizado correctamente.")
                    command.ExecuteNonQuery()
                End Using

            End Using
            mostrar_datosP()
        Catch ex As Exception
            MessageBox.Show("Error al actualizar Producto: ")
        End Try
        EliminarTextos()
    End Sub

    Private Sub leerP_Click(sender As Object, e As EventArgs) Handles leerP.Click
        mostrar_datosP()
    End Sub

    Private Sub EliminarP_Click(sender As Object, e As EventArgs) Handles EliminarP.Click
        Dim descripcion As String = TextBox20.Text
        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()
                Using command As New SqlCommand("EliminarProducto", connection)
                    command.CommandType = CommandType.StoredProcedure
                    ' Agrega el parámetro
                    command.Parameters.AddWithValue("@Descripcion", descripcion)

                    ' Ejecuta el procedimiento almacenado
                    command.ExecuteNonQuery()

                    MessageBox.Show("Producto eliminado correctamente.")
                    command.ExecuteNonQuery()

                End Using
            End Using
            mostrar_datosP()
        Catch ex As Exception
            MessageBox.Show("Error al eliminar Producto: " & ex.Message)
        End Try
        EliminarTextos()
    End Sub
    Private Sub mostrar_datosP()
        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Using command As New SqlCommand("ObtenerProductos", connection)
                    command.CommandType = CommandType.StoredProcedure

                    Using adapter As New SqlDataAdapter(command)
                        Dim dataTable As New DataTable()
                        adapter.Fill(dataTable)
                        ' Muestra los resultados en un DataGridView (asumiendo que tienes un control DataGridView llamado dgvEmpleados en tu formulario)
                        DataGridView1.DataSource = dataTable
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al leer empleados: " & ex.Message)


        End Try
        EliminarTextos()
    End Sub



    Private Sub agregarDesc_Click(sender As Object, e As EventArgs) Handles agregarDesc.Click
        Dim Porcentaje As Integer = TextBox23.Text
        Dim id_Producto As String = TextBox22.Text

        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Using command As New SqlCommand("AgregarDescuento", connection)
                    command.CommandType = CommandType.StoredProcedure
                    ' Agrega los parámetros
                    command.Parameters.AddWithValue("@Porcentaje", Porcentaje)
                    command.Parameters.AddWithValue("  @id_Producto", id_Producto)

                    ' Ejecuta el procedimiento almacenado
                    command.ExecuteNonQuery()
                    MessageBox.Show("Producto agregado correctamente.")
                End Using
            End Using
            mostrar_datosDesc()
        Catch ex As Exception
            MessageBox.Show("Error al agregar Producto : " & ex.Message)
        End Try
        EliminarTextos()
    End Sub

    Private Sub ModDesc_Click(sender As Object, e As EventArgs) Handles ModDesc.Click
        Dim Porcentaje As Integer = TextBox23.Text
        Dim id_Producto As String = TextBox22.Text
        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Using command As New SqlCommand("ActualizarProducto", connection)
                    command.CommandType = CommandType.StoredProcedure
                    ' Agrega los parámetros
                    command.Parameters.AddWithValue("@Porcentaje", Porcentaje)
                    command.Parameters.AddWithValue("  @id_Producto", id_Producto)

                    ' Ejecuta el procedimiento almacenado
                    command.ExecuteNonQuery()

                    MessageBox.Show(" actualizado correctamente.")
                    command.ExecuteNonQuery()
                End Using

            End Using
            mostrar_datosDesc()
        Catch ex As Exception
            MessageBox.Show("Error al actualizar : ")
        End Try
        EliminarTextos()

    End Sub

    Private Sub LeerDesc_Click(sender As Object, e As EventArgs) Handles LeerDesc.Click
        mostrar_datosDesc()
    End Sub

    Private Sub EliminarDesc_Click(sender As Object, e As EventArgs) Handles EliminarDesc.Click
        Dim Porcentaje As String = TextBox23.Text
        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()
                Using command As New SqlCommand("EliminarDescuento", connection)
                    command.CommandType = CommandType.StoredProcedure
                    ' Agrega el parámetro
                    command.Parameters.AddWithValue("@Porcentaje", Porcentaje)

                    ' Ejecuta el procedimiento almacenado
                    command.ExecuteNonQuery()

                    MessageBox.Show(" eliminado correctamente.")
                    command.ExecuteNonQuery()

                End Using
            End Using
            mostrar_datosDesc()
        Catch ex As Exception
            MessageBox.Show("Error al eliminar: " & ex.Message)
        End Try
        EliminarTextos()
    End Sub
    Private Sub mostrar_datosDesc()
        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Using command As New SqlCommand("ObtenerDescuentos", connection)
                    command.CommandType = CommandType.StoredProcedure

                    Using adapter As New SqlDataAdapter(command)
                        Dim dataTable As New DataTable()
                        adapter.Fill(dataTable)
                        ' Muestra los resultados en un DataGridView (asumiendo que tienes un control DataGridView llamado dgvEmpleados en tu formulario)
                        DataGridView6.DataSource = dataTable
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al leer : " & ex.Message)


        End Try
        EliminarTextos()
    End Sub



    Private Sub AgregarM_Click(sender As Object, e As EventArgs) Handles AgregarM.Click
        Dim Marca As String = TextBox24.Text
        Dim id_Producto As String = TextBox21.Text

        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Using command As New SqlCommand("AgregarMarca", connection)
                    command.CommandType = CommandType.StoredProcedure
                    ' Agrega los parámetros
                    command.Parameters.AddWithValue("@Nombre_Marca", Marca)
                    command.Parameters.AddWithValue("@id_Producto", id_Producto)

                    ' Ejecuta el procedimiento almacenado
                    command.ExecuteNonQuery()
                    MessageBox.Show("Agregado correctamente.")
                End Using
            End Using
            mostrar_datosMarca()
        Catch ex As Exception
            MessageBox.Show("Error al agregar: " & ex.Message)
        End Try
        EliminarTextos()
    End Sub

    Private Sub ModM_Click(sender As Object, e As EventArgs) Handles ModM.Click
        Dim Marca As String = TextBox24.Text
        Dim id_Producto As String = TextBox21.Text
        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Using command As New SqlCommand("AgregarMarca", connection)
                    command.CommandType = CommandType.StoredProcedure
                    ' Agrega los parámetros
                    command.Parameters.AddWithValue("@Nombre_Marca", Marca)
                    command.Parameters.AddWithValue("@id_Producto", id_Producto)
                    ' Ejecuta el procedimiento almacenado
                    command.ExecuteNonQuery()

                    MessageBox.Show("Actualizado correctamente.")
                    command.ExecuteNonQuery()
                End Using

            End Using
            mostrar_datosMarca()
        Catch ex As Exception
            MessageBox.Show("Error al actualizar: ")
        End Try
        EliminarTextos()
    End Sub

    Private Sub LeerM_Click(sender As Object, e As EventArgs) Handles LeerM.Click
        mostrar_datosMarca()
    End Sub

    Private Sub EliminarM_Click(sender As Object, e As EventArgs) Handles EliminarM.Click
        Dim marca As String = TextBox24.Text
        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()
                Using command As New SqlCommand("EliminarMarca", connection)
                    command.CommandType = CommandType.StoredProcedure
                    ' Agrega el parámetro
                    command.Parameters.AddWithValue("@Nombre_Marca", marca)

                    ' Ejecuta el procedimiento almacenado
                    command.ExecuteNonQuery()

                    MessageBox.Show("eliminado correctamente.")
                    command.ExecuteNonQuery()

                End Using
            End Using
            mostrar_datosMarca()
        Catch ex As Exception
            MessageBox.Show("Error al eliminado: " & ex.Message)
        End Try
        EliminarTextos()
    End Sub
    Private Sub mostrar_datosMarca()
        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Using command As New SqlCommand("ObtenerMarcas", connection)
                    command.CommandType = CommandType.StoredProcedure

                    Using adapter As New SqlDataAdapter(command)
                        Dim dataTable As New DataTable()
                        adapter.Fill(dataTable)
                        ' Muestra los resultados en un DataGridView (asumiendo que tienes un control DataGridView llamado dgvEmpleados en tu formulario)
                        DataGridView7.DataSource = dataTable
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al leer: " & ex.Message)


        End Try
        EliminarTextos()

    End Sub

    Private Sub ProveedoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProveedoresToolStripMenuItem.Click
        PanelProveedor.BringToFront()
    End Sub

    Private Sub AgregarPro_Click(sender As Object, e As EventArgs) Handles AgregarPro.Click
        Dim Nombre As String = TextBox27.Text
        Dim Contacto As String = TextBox26.Text
        Dim id_Marca As String = TextBox25.Text

        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Using command As New SqlCommand("AgregarProveedor", connection)
                    command.CommandType = CommandType.StoredProcedure
                    ' Agrega los parámetros
                    command.Parameters.AddWithValue("@Nombre_Proveedor", Nombre)
                    command.Parameters.AddWithValue("@Contacto", Contacto)
                    command.Parameters.AddWithValue("@id_Marca", id_Marca)
                    ' Ejecuta el procedimiento almacenado
                    command.ExecuteNonQuery()
                    MessageBox.Show("Proveedor agregado correctamente.")
                End Using
            End Using
            MostrarDatosPro()
        Catch ex As Exception
            MessageBox.Show("Error al agregar Proveedor : " & ex.Message)
        End Try
        EliminarTextos()
    End Sub

    Private Sub MoPro_Click(sender As Object, e As EventArgs) Handles MoPro.Click
        Dim Nombre As String = TextBox27.Text
        Dim Contacto As String = TextBox26.Text
        Dim id_Marca As String = TextBox25.Text

        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Using command As New SqlCommand("ModificarProveedor", connection)
                    command.CommandType = CommandType.StoredProcedure
                    ' Agrega los parámetros
                    command.Parameters.AddWithValue("@Nombre_Proveedor", Nombre)
                    command.Parameters.AddWithValue("@Contacto", Contacto)
                    command.Parameters.AddWithValue("@id_Marca", id_Marca)

                    ' Ejecuta el procedimiento almacenado
                    command.ExecuteNonQuery()

                    MessageBox.Show("Actualizado correctamente.")
                    command.ExecuteNonQuery()
                End Using

            End Using
            MostrarDatosPro()
        Catch ex As Exception
            MessageBox.Show("Error al actualizar: ")
        End Try

        EliminarTextos()
    End Sub

    Private Sub LeerPro_Click(sender As Object, e As EventArgs) Handles LeerPro.Click
        MostrarDatosPro()
    End Sub

    Private Sub EliminarPro_Click(sender As Object, e As EventArgs) Handles EliminarPro.Click
        Dim Nombre As String = TextBox27.Text
        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()
                Using command As New SqlCommand("EliminarProveedor", connection)
                    command.CommandType = CommandType.StoredProcedure
                    ' Agrega el parámetro
                    command.Parameters.AddWithValue("@Nombre_Proveedor", Nombre)

                    ' Ejecuta el procedimiento almacenado
                    command.ExecuteNonQuery()

                    MessageBox.Show("Eliminado correctamente.")
                    command.ExecuteNonQuery()

                End Using
            End Using
            MostrarDatosPro()
        Catch ex As Exception
            MessageBox.Show("Error al eliminar: " & ex.Message)
        End Try

        EliminarTextos()
    End Sub
    Private Sub MostrarDatosPro()
        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Using command As New SqlCommand("ObtenerProveedores", connection)
                    command.CommandType = CommandType.StoredProcedure

                    Using adapter As New SqlDataAdapter(command)
                        Dim dataTable As New DataTable()
                        adapter.Fill(dataTable)
                        ' Muestra los resultados en un DataGridView (asumiendo que tienes un control DataGridView llamado dgvEmpleados en tu formulario)
                        DataGridView8.DataSource = dataTable
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al leer : " & ex.Message)


        End Try
        EliminarTextos()
    End Sub

    Private Sub PedidoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PedidoToolStripMenuItem.Click
        Panelpedidos.BringToFront()
    End Sub

    Private Sub AgregaPedido_Click(sender As Object, e As EventArgs) Handles AgregaPedido.Click
        Dim Pedido As Date = DateTimePicker2.MinDate
        Dim Entrega As Date = DateTimePicker3.MaxDate
        Dim id_Proveedor As Integer = TextBox28.Text

        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Using command As New SqlCommand("AgregarPedido", connection)
                    command.CommandType = CommandType.StoredProcedure
                    ' Agrega los parámetros
                    command.Parameters.AddWithValue("@Fecha_Pedido", Pedido)
                    command.Parameters.AddWithValue("@Fecha_Entrega", Entrega)
                    command.Parameters.AddWithValue("@id_Proveedor", id_Proveedor)
                    ' Ejecuta el procedimiento almacenado
                    command.ExecuteNonQuery()
                    MessageBox.Show("agregado correctamente.")
                End Using
            End Using
            mostrar_datosPedido()
        Catch ex As Exception
            MessageBox.Show("Error al agregar  : " & ex.Message)
        End Try
        EliminarTextos()
    End Sub
    Private Sub Mostrar_DatosPedido()
        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Using command As New SqlCommand("ObtenerPedidos", connection)
                    command.CommandType = CommandType.StoredProcedure

                    Using adapter As New SqlDataAdapter(command)
                        Dim dataTable As New DataTable()
                        adapter.Fill(dataTable)
                        ' Muestra los resultados en un DataGridView (asumiendo que tienes un control DataGridView llamado dgvEmpleados en tu formulario)
                        DataGridView9.DataSource = dataTable
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al leer : " & ex.Message)


        End Try
        EliminarTextos()
    End Sub

    Private Sub ModPedido_Click(sender As Object, e As EventArgs) Handles ModPedido.Click
        Dim Pedido As Date = DateTimePicker2.MinDate
        Dim Entrega As Date = DateTimePicker3.MaxDate
        Dim id_Proveedor As Integer = TextBox28.Text
        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Using command As New SqlCommand("ActualizarProducto", connection)
                    command.CommandType = CommandType.StoredProcedure
                    ' Agrega los parámetros
                    command.Parameters.AddWithValue("@Fecha_Pedido", Pedido)
                    command.Parameters.AddWithValue("@Fecha_Entrega", Entrega)
                    command.Parameters.AddWithValue("@id_Proveedor", id_Proveedor)

                    ' Ejecuta el procedimiento almacenado
                    command.ExecuteNonQuery()

                    MessageBox.Show("actualizado correctamente.")
                    command.ExecuteNonQuery()
                End Using

            End Using
            Mostrar_DatosPedido()
        Catch ex As Exception
            MessageBox.Show("Error al actualizar: ")
        End Try
        EliminarTextos()
    End Sub

    Private Sub LeerPedido_Click(sender As Object, e As EventArgs) Handles LeerPedido.Click
        Mostrar_DatosPedido()
    End Sub

    Private Sub EliminarPedido_Click(sender As Object, e As EventArgs) Handles EliminarPedido.Click
        Dim Pedido As Date = DateTimePicker2.MinDate
        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()
                Using command As New SqlCommand("EliminarPedido", connection)
                    command.CommandType = CommandType.StoredProcedure
                    ' Agrega el parámetro
                    command.Parameters.AddWithValue("@Descripcion", Pedido)

                    ' Ejecuta el procedimiento almacenado
                    command.ExecuteNonQuery()

                    MessageBox.Show("Producto eliminado correctamente.")
                    command.ExecuteNonQuery()

                End Using
            End Using
            Mostrar_DatosPedido()
        Catch ex As Exception
            MessageBox.Show("Error al eliminar Producto: " & ex.Message)
        End Try

        EliminarTextos()
    End Sub

    Private Sub CajasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CajasToolStripMenuItem.Click
        PanelCaja.BringToFront()
    End Sub

    Private Sub AgregarCaja_Click(sender As Object, e As EventArgs) Handles AgregarCaja.Click
        Dim SaldoI As String = TextBox31.Text
        Dim SaldoF As String = TextBox30.Text
        Dim empleado As String = TextBox29.Text
        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Using command As New SqlCommand("AgregarCaja", connection)
                    command.CommandType = CommandType.StoredProcedure
                    ' Agrega los parámetros
                    command.Parameters.AddWithValue("@Saldo_Inicial", SaldoI)
                    command.Parameters.AddWithValue("@Saldo_Final", SaldoF)
                    command.Parameters.AddWithValue("@id_Empleado", empleado)
                    ' Ejecuta el procedimiento almacenado
                    command.ExecuteNonQuery()
                    MessageBox.Show("Agregado correctamente.")
                End Using
            End Using
            mostrar_datosCaja()
        Catch ex As Exception
            MessageBox.Show("Error al agregar: " & ex.Message)
        End Try
        EliminarTextos()
    End Sub
    Private Sub mostrar_datosCaja()
        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Using command As New SqlCommand("ObtenerCaja", connection)
                    command.CommandType = CommandType.StoredProcedure

                    Using adapter As New SqlDataAdapter(command)
                        Dim dataTable As New DataTable()
                        adapter.Fill(dataTable)
                        ' Muestra los resultados en un DataGridView (asumiendo que tienes un control DataGridView llamado dgvEmpleados en tu formulario)
                        DataGridView10.DataSource = dataTable
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al leer: " & ex.Message)


        End Try
        EliminarTextos()
    End Sub
    Private Sub ModCaja_Click(sender As Object, e As EventArgs) Handles ModCaja.Click
        Dim SaldoI As String = TextBox31.Text
        Dim SaldoF As String = TextBox30.Text
        Dim empleado As String = TextBox29.Text
        Try

            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Using command As New SqlCommand("AgregarMarca", connection)
                    command.CommandType = CommandType.StoredProcedure
                    ' Agrega los parámetros
                    command.Parameters.AddWithValue("@NuevoSaldoI", SaldoI)
                    command.Parameters.AddWithValue("@NuevoSaldoF", SaldoF)
                    command.Parameters.AddWithValue("@id_Empleado", empleado)
                    ' Ejecuta el procedimiento almacenado
                    command.ExecuteNonQuery()

                    MessageBox.Show("Actualizado correctamente.")
                    command.ExecuteNonQuery()
                End Using
                Enabled = True
            End Using
            mostrar_datosCaja()
        Catch ex As Exception
            MessageBox.Show("Saldo Inicial Habilitado por el Admin: ")
        End Try
        EliminarTextos()
    End Sub

    Private Sub LeerCaja_Click(sender As Object, e As EventArgs) Handles LeerCaja.Click
        mostrar_datosCaja()
    End Sub

    Private Sub EliminarCaja_Click(sender As Object, e As EventArgs) Handles EliminarCaja.Click
        Dim SaldoI As String = TextBox31.Text
        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()
                Using command As New SqlCommand("EliminarCaja", connection)
                    command.CommandType = CommandType.StoredProcedure
                    ' Agrega el parámetro
                    command.Parameters.AddWithValue("@id_caja", SaldoI)

                    ' Ejecuta el procedimiento almacenado
                    command.ExecuteNonQuery()

                    MessageBox.Show("eliminado correctamente.")
                    command.ExecuteNonQuery()

                End Using
            End Using
            mostrar_datosCaja()
        Catch ex As Exception
            MessageBox.Show("Error al eliminado: " & ex.Message)
        End Try

        EliminarTextos()
    End Sub

    Private Sub DetalleVentaToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DetalleVentaToolStripMenuItem1.Click
        PanelDetalleVentas.BringToFront()
    End Sub

    Private Sub DescuentosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DescuentosToolStripMenuItem1.Click
        PanelDescuentos.BringToFront()
    End Sub

    Private Sub MarcasToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles MarcasToolStripMenuItem1.Click
        PanelMarcas.BringToFront()
    End Sub
End Class
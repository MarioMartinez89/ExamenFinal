Imports System.Data.SqlClient
Public Class Form3
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Limpiar()
        ActualizarTabla()
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        TxtbDescripcion.Enabled = False
        TxtbPrecio.Enabled = False
        TxtbCantidad.Enabled = False
        BotGuardar.Enabled = False
        BotEditar.Enabled = False

    End Sub

    Private Sub ActualizarTabla()
        Dim productos As ConexionSQLS
        productos = New ConexionSQLS
        DataGridView1.DataSource = productos.ObtenerProductos()
    End Sub


    Private Sub Limpiar()

        Txtbcodigop.Text = ""
        TxtbDescripcion.Text = ""
        TxtbPrecio.Text = ""
        TxtbCantidad.Text = ""


    End Sub

    Private Sub BotGuardar_Click(sender As Object, e As EventArgs) Handles BotGuardar.Click


        Dim Codigop As String = Txtbcodigop.Text
        Dim Existencia As Integer = Integer.Parse(TxtbCantidad.Text)
        Dim descripcion As String
        Dim preciou As Decimal
        Dim Productos As ConexionSQLS
        Productos = New ConexionSQLS

        If Productos.ProductoExists(Codigop) Then

            Dim productoExiste As ConexionSQLS
            productoExiste = New ConexionSQLS
            productoExiste.ActualizarExistencia(Codigop, Existencia)


        Else
            If Txtbcodigop.TextLength <> 12 Then
                ' Si la longitud es diferente de 12, mostrar un mensaje de error
                MessageBox.Show("Debe ingresar y codigo de exactamente 12 dígitos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ' Limpiar el TextBox o tomar otras acciones según tus necesidades
                Txtbcodigop.Clear()
                ' Devolver el foco al TextBox para que el usuario pueda corregir la entrada
                Txtbcodigop.Focus()
            Else
                Codigop = Txtbcodigop.Text
                descripcion = TxtbDescripcion.Text
                preciou = Convert.ToDecimal(TxtbPrecio.Text)
                Existencia = Integer.Parse(TxtbCantidad.Text)


                Dim productoNuevo As ConexionSQLS
                productoNuevo = New ConexionSQLS
                productoNuevo.InsertarProducto(Codigop, descripcion, preciou, Existencia)


            End If
        End If


        Limpiar()
        ActualizarTabla()
        TxtbDescripcion.Enabled = False
        TxtbPrecio.Enabled = False
        TxtbCantidad.Enabled = False
        BotGuardar.Enabled = False
        BotEditar.Enabled = False



    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

        Dim NumeroDeFilaSeleccionada As Integer

        If Not DataGridView1.CurrentRow Is Nothing Then

            NumeroDeFilaSeleccionada = DataGridView1.CurrentRow.Index()
            Txtbcodigop.Text = DataGridView1(1, NumeroDeFilaSeleccionada).Value.ToString()
            TxtbDescripcion.Text = DataGridView1(2, NumeroDeFilaSeleccionada).Value.ToString()
            TxtbCantidad.Text = DataGridView1(4, NumeroDeFilaSeleccionada).Value.ToString()
            TxtbPrecio.Text = DataGridView1(3, NumeroDeFilaSeleccionada).Value.ToString()
        Else
            MessageBox.Show("Selecciona una fila")
        End If
        TxtbDescripcion.Enabled = False
        TxtbPrecio.Enabled = False
        TxtbCantidad.Enabled = False
        BotGuardar.Enabled = False
        BotEditar.Enabled = False


    End Sub

    Private Sub BotBuscar_Click(sender As Object, e As EventArgs) Handles BotBuscar.Click
        Dim Codigop As String = Txtbcodigop.Text
        Dim Productos As ConexionSQLS
        Productos = New ConexionSQLS
        Try


            If Productos.ProductoExists(Codigop) Then

                Dim result As DialogResult = MessageBox.Show("El codigo buscado ya existe. ¿Desea agregar mas existencias?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If result = DialogResult.Yes Then
                    TxtbCantidad.Enabled = True
                    BotGuardar.Enabled = True
                    TxtbCantidad.Text = ""

                Else
                    Txtbcodigop.Enabled = False
                    TxtbCantidad.Enabled = True
                    TxtbDescripcion.Enabled = True
                    TxtbPrecio.Enabled = True
                    BotEditar.Enabled = True
                End If


            Else
                Dim result As DialogResult = MessageBox.Show("El codigo buscado no Existe ¿Desea crear un codigo nuevo?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If result = DialogResult.Yes Then
                    TxtbDescripcion.Enabled = True
                    TxtbPrecio.Enabled = True
                    TxtbCantidad.Enabled = True
                    BotGuardar.Enabled = True
                    BotEditar.Enabled = False
                    TxtbDescripcion.Text = ""
                    TxtbPrecio.Text = ""
                    TxtbCantidad.Text = ""

                Else

                    Limpiar()
                    TxtbDescripcion.Enabled = False
                    TxtbPrecio.Enabled = False
                    TxtbCantidad.Enabled = False
                    BotGuardar.Enabled = False
                    BotEditar.Enabled = False


                End If

            End If

        Catch ex As Exception
            MsgBox("Ingrese un codigo valido: " & ex.Message)
        Finally

        End Try

    End Sub

    Private Sub Txtbcodigop_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txtbcodigop.KeyPress

        ' Permitir solo dígitos, la tecla de retroceso y los paréntesis
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If


        ' Limitar la longitud total a 8 caracteres (incluyendo paréntesis y guión)
        If Txtbcodigop.TextLength >= 12 AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True

        End If


    End Sub

    Private Sub TxtbCantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtbCantidad.KeyPress

        ' Verificar si el carácter ingresado no es un dígito
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            ' Si no es un dígito, marcar el evento como manejado para evitar que se agregue al TextBox
            e.Handled = True
        End If
    End Sub
    Private Sub TxtbPrecio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtbPrecio.KeyPress

        ' Verificar si el carácter ingresado no es un dígito
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            ' Si no es un dígito, marcar el evento como manejado para evitar que se agregue al TextBox
            e.Handled = True
        End If
    End Sub

    Private Sub BotBorrar_Click(sender As Object, e As EventArgs) Handles BotBorrar.Click

        Dim result As DialogResult = MessageBox.Show("¿Esta seguro que desea eliminar este registro?. Perdera toda la existencia.", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then

            Dim NumeroDeFilaSeleccionada As Integer
            Dim Codigop As String
            Dim productosDel As ConexionSQLS

            NumeroDeFilaSeleccionada = DataGridView1.CurrentRow.Index
            Codigop = DataGridView1(1, NumeroDeFilaSeleccionada).Value.ToString()
            productosDel = New ConexionSQLS
            productosDel.EliminarProducto(Codigop)

            MessageBox.Show("Producto Eliminado correctamente")
            ActualizarTabla()
            Limpiar()
        Else
            Limpiar()
            TxtbDescripcion.Enabled = False
            TxtbPrecio.Enabled = False
            TxtbCantidad.Enabled = False
            BotGuardar.Enabled = False
            BotEditar.Enabled = False

        End If

    End Sub

    Private Sub BotEditar_Click(sender As Object, e As EventArgs) Handles BotEditar.Click


        Dim Codigop As String = Txtbcodigop.Text
        Dim productos As ConexionSQLS
        productos = New ConexionSQLS
        productos.EditarProducto(Codigop, TxtbDescripcion.Text, Convert.ToDecimal(TxtbPrecio.Text), TxtbCantidad.Text)

        MessageBox.Show("Producto actualizado correctamente")
        ActualizarTabla()
        Limpiar()
        TxtbDescripcion.Enabled = False
        TxtbPrecio.Enabled = False
        TxtbCantidad.Enabled = False
        BotGuardar.Enabled = False
        BotEditar.Enabled = False

    End Sub
End Class
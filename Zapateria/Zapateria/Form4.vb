Public Class Form4
    Dim conexion As New ConexionSQLS()

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label5.Text = Date.Now.ToString("dd/MM/yyyy")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Verificar si se ha ingresado un código de producto válido
        If String.IsNullOrWhiteSpace(TextBoxCodigoProducto.Text) OrElse Not IsNumeric(TextBoxCodigoProducto.Text) Then
            MessageBox.Show("Ingrese un código de producto válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Verificar si el producto existe en la base de datos
        Dim codigoProducto As Decimal = Decimal.Parse(TextBoxCodigoProducto.Text)
        If Not conexion.ProductoExists(codigoProducto.ToString()) Then
            MessageBox.Show("El producto con el código ingresado no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Verificar si se ha ingresado una cantidad válida
        Dim cantidad As Integer
        If Not Integer.TryParse(TextBoxCantidad.Text, cantidad) OrElse cantidad <= 0 Then
            MessageBox.Show("Ingrese una cantidad válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Obtener los detalles del producto seleccionado
        Dim descripcionProducto As String = conexion.ObtenerDescripcionProducto(codigoProducto)
        Dim precioUnitario As Decimal = conexion.ObtenerPrecioProducto(codigoProducto)
        Dim existenciaProducto As Integer = conexion.ObtenerExistenciaProducto(codigoProducto)

        ' Verificar existencia suficiente
        If cantidad > existenciaProducto Then
            MessageBox.Show("No hay suficientes existencias del producto seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Calcular el total
        Dim total As Decimal = precioUnitario * cantidad

        ' Agregar los detalles de la venta al DataGridView
        DataGridViewVentas.Rows.Add(codigoProducto, descripcionProducto, precioUnitario, cantidad, total)

        TextBoxCodigoProducto.Clear()
        TextBoxCantidad.Clear()

        ' Calcular el total de la venta
        CalcularTotalVenta()
    End Sub

    Private Sub CalcularTotalVenta()
        Dim subtotalVenta As Decimal = 0
        Dim totalVentaConIVA As Decimal = 0
        Dim iva As Decimal = 0

        For Each fila As DataGridViewRow In DataGridViewVentas.Rows
            totalVentaConIVA += CDec(fila.Cells("Total").Value)
        Next

        ' Calcular el total con el 12% de IVA
        subtotalVenta = totalVentaConIVA / 1.12
        iva = subtotalVenta * 0.12

        ' Mostrar el subtotal y el total con formato de moneda
        LabelIva.Text = iva.ToString("C")
        LabelSubTotal.Text = subtotalVenta.ToString("C")
        LabelTotal.Text = totalVentaConIVA.ToString("C")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If DataGridViewVentas.SelectedRows.Count > 0 Then
            Dim index As Integer = DataGridViewVentas.SelectedRows(0).Index
            DataGridViewVentas.Rows.RemoveAt(index)

            ' Calcular el total de la venta
            CalcularTotalVenta()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ' Verificar si hay elementos en el DataGridView
        If DataGridViewVentas.Rows.Count = 0 Then
            MessageBox.Show("No hay elementos en la factura.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Verificar si se han ingresado los datos del cliente
        If String.IsNullOrWhiteSpace(TextBoxNombreCliente.Text) Or String.IsNullOrWhiteSpace(TextBoxNIT.Text) Then
            MessageBox.Show("Ingrese los datos del cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Construir mensaje de factura
        Dim mensajeFactura As String = ""
        mensajeFactura &= "Factura" & vbCrLf
        mensajeFactura &= "---------------------------------" & vbCrLf
        mensajeFactura &= "Fecha: " & DateTime.Now.ToString("dd/MM/yyyy") & vbCrLf
        mensajeFactura &= "Nombre del cliente: " & TextBoxNombreCliente.Text & vbCrLf
        mensajeFactura &= "NIT: " & TextBoxNIT.Text & vbCrLf
        mensajeFactura &= "---------------------------------" & vbCrLf
        mensajeFactura &= "Detalles de la factura:" & vbCrLf

        ' Agregar detalles de la factura al mensaje
        For Each fila As DataGridViewRow In DataGridViewVentas.Rows

            mensajeFactura &= $"{fila.Cells("Cantidad").Value} {fila.Cells("Descripcion").Value} {fila.Cells("Precio").Value} {fila.Cells("Total").Value}" & vbCrLf
        Next

        ' Agregar total a pagar al mensaje de la factura
        mensajeFactura &= "---------------------------------" & vbCrLf
        mensajeFactura &= "Total a pagar: " & LabelTotal.Text & vbCrLf

        ' Actualizar existencias en la base de datos
        For Each fila As DataGridViewRow In DataGridViewVentas.Rows
            Dim codigoProducto As Decimal = CDec(fila.Cells("ID").Value)
            Dim cantidad As Integer = CInt(fila.Cells("Cantidad").Value)
            conexion.ActualizarExistenciaFacturacion(codigoProducto, cantidad)
        Next

        ' Limpiar el DataGridView y el total de la venta
        DataGridViewVentas.Rows.Clear()
        LabelTotal.Text = ""
        LabelSubTotal.Text = ""
        LabelIva.Text = ""
        TextBoxNIT.Text = ""
        TextBoxNombreCliente.Text = ""
        ' Mostrar el mensaje de factura en un MessageBox
        MessageBox.Show(mensajeFactura, "Factura Generada", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly Or MessageBoxOptions.DefaultDesktopOnly)



    End Sub

    Private Sub TextBoxNIT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxNIT.KeyPress

        ' Verificar si el carácter ingresado no es un dígito
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            ' Si no es un dígito, marcar el evento como manejado para evitar que se agregue al TextBox
            e.Handled = True
        End If

    End Sub
End Class
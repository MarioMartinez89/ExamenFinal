
Imports System.Data.SqlClient
Public Class ConexionSQLS
    Private connectionString As String
    Private connection As SqlConnection

    Public Sub New()
        ' Configurar la cadena de conexión para Windows Authentication en localhost
        connectionString = "Data Source=DESKTOP-P3R1P5S\SQLEXPRESS;Initial Catalog=db_zapateria;Integrated Security=True"
        connection = New SqlConnection(connectionString)
    End Sub

    Public Sub InsertarProducto(Codigo As String, descripcion As String, preciou As Decimal, Existencia As Integer)
        Try
            connection.Open()
            Dim query As String = "INSERT INTO Inventario (Codigo_Producto, Descripcion, Precio_Unit, Existencia) VALUES (@Codigop, @Descripcion, @Precio, @Existencia)"
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@Codigop", Codigo)
            command.Parameters.AddWithValue("@Descripcion", descripcion)
            command.Parameters.AddWithValue("@Precio", preciou)
            command.Parameters.AddWithValue("@Existencia", Existencia)
            command.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Error al insertar el producto: " & ex.Message)
        Finally
            connection.Close()
        End Try
    End Sub

    Public Sub EditarProducto(Codigop As String, descripcion As String, preciou As Decimal, Existencia As Integer)
        Try
            connection.Open()
            Dim query As String = "UPDATE Inventario SET Codigo_producto = @codigop, Descripcion = @Descripcion, Precio_Unit = @Preciou, Existencia = @Existencia WHERE Codigo_Producto = @Codigop"
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@Codigop", Codigop)
            command.Parameters.AddWithValue("@Descripcion", descripcion)
            command.Parameters.AddWithValue("@Preciou", preciou)
            command.Parameters.AddWithValue("@Existencia", Existencia)
            command.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Error al actualizar el producto: " & ex.Message)
        Finally
            connection.Close()
        End Try
    End Sub

    Public Sub EliminarProducto(Codigop As String)
        Try
            connection.Open()
            Dim query As String = "DELETE FROM Inventario WHERE Codigo_Producto = @Codigop"
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@Codigop", Codigop)
            command.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Error al eliminar el producto: " & ex.Message)
        Finally
            connection.Close()
        End Try
    End Sub

    Public Function ObtenerProductos() As DataTable
        Dim dataTable As New DataTable()
        Try
            connection.Open()
            Dim query As String = "SELECT ID_Inv, Codigo_Producto, Descripcion, Precio_Unit, Existencia FROM Inventario"
            Dim adapter As New SqlDataAdapter(query, connection)
            adapter.Fill(dataTable)
        Catch ex As Exception
            MsgBox("Error al obtener los productos: " & ex.Message)
        Finally
            connection.Close()
        End Try
        Return dataTable
    End Function

    Public Function ProductoExists(codigop As String) As Boolean
        Dim query As String = "SELECT COUNT(*) FROM Inventario WHERE Codigo_Producto = @Codigo_Producto"
        Dim command As New SqlCommand(query, connection)
        command.Parameters.AddWithValue("@Codigo_Producto", codigop)
        connection.Open()
        Dim count As Integer = Convert.ToInt32(command.ExecuteScalar())
        connection.Close()

        Return count > 0
    End Function

    Public Sub ActualizarExistencia(Codigop As String, cantidad As Integer)
        Try
            connection.Open()
            Dim query As String = "UPDATE Inventario SET Existencia = Existencia + @Cantidad WHERE Codigo_Producto = @Codigop"
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@Cantidad", cantidad)
            command.Parameters.AddWithValue("@Codigop", Codigop)
            command.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Error al actualizar Existencia: " & ex.Message)
        Finally
            connection.Close()
        End Try
    End Sub

    'Para Facturacion
    Public Sub ActualizarExistenciaFacturacion(Codigop As Decimal, CantidadVendida As Integer)
        Try
            ' Obtener la cantidad existente en la base de datos
            Dim cantidadExistente As Integer
            Using connection As New SqlConnection(connectionString)
                connection.Open()
                Dim queryExistente As String = "SELECT Existencia FROM Inventario WHERE Codigo_Producto = @Codigop"
                Dim commandExistente As New SqlCommand(queryExistente, connection)
                commandExistente.Parameters.AddWithValue("@Codigop", Codigop)
                cantidadExistente = Convert.ToInt32(commandExistente.ExecuteScalar())
            End Using

            ' Calcular la nueva cantidad de existencia
            Dim nuevaExistencia As Integer = cantidadExistente - CantidadVendida

            ' Actualizar la existencia en la base de datos
            Using connection As New SqlConnection(connectionString)
                connection.Open()
                Dim queryActualizar As String = "UPDATE Inventario SET Existencia = @NuevaExistencia WHERE Codigo_Producto = @Codigop"
                Dim commandActualizar As New SqlCommand(queryActualizar, connection)
                commandActualizar.Parameters.AddWithValue("@NuevaExistencia", nuevaExistencia)
                commandActualizar.Parameters.AddWithValue("@Codigop", Codigop)
                commandActualizar.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            MsgBox("Error al actualizar Existencia: " & ex.Message)
        End Try
    End Sub

    Public Function ObtenerDescripcionProducto(codigoProducto As Decimal) As String
        Dim descripcion As String = String.Empty
        Try
            Dim dataTable As DataTable = Me.ObtenerProductos()
            For Each row As DataRow In dataTable.Rows
                If Decimal.Parse(row("Codigo_Producto").ToString()) = codigoProducto Then
                    descripcion = row("Descripcion").ToString()
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("Error al obtener la descripción del producto: " & ex.Message)
        End Try

        Return descripcion
    End Function

    Public Function ObtenerPrecioProducto(codigoProducto As Decimal) As Decimal
        Dim precio As Decimal = 0

        Try
            Dim dataTable As DataTable = Me.ObtenerProductos()
            For Each row As DataRow In dataTable.Rows
                If Decimal.Parse(row("Codigo_Producto").ToString()) = codigoProducto Then
                    precio = Decimal.Parse(row("Precio_Unit").ToString())
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("Error al obtener el precio del producto: " & ex.Message)
        End Try

        Return precio
    End Function

    Public Function ObtenerExistenciaProducto(codigoProducto As Decimal) As Integer
        Dim existencia As Integer = 0

        Try
            Dim dataTable As DataTable = Me.ObtenerProductos()
            For Each row As DataRow In dataTable.Rows
                If Decimal.Parse(row("Codigo_Producto").ToString()) = codigoProducto Then
                    existencia = Integer.Parse(row("Existencia").ToString())
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("Error al obtener la existencia del producto: " & ex.Message)
        End Try

        Return existencia
    End Function

End Class


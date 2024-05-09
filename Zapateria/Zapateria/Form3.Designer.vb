<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Txtbcodigop = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtbDescripcion = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtbCantidad = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtbPrecio = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.BotGuardar = New System.Windows.Forms.Button()
        Me.BotEditar = New System.Windows.Forms.Button()
        Me.BotBorrar = New System.Windows.Forms.Button()
        Me.BotBuscar = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(59, 88)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Codigo Producto:"
        '
        'Txtbcodigop
        '
        Me.Txtbcodigop.Location = New System.Drawing.Point(185, 79)
        Me.Txtbcodigop.Margin = New System.Windows.Forms.Padding(4)
        Me.Txtbcodigop.Multiline = True
        Me.Txtbcodigop.Name = "Txtbcodigop"
        Me.Txtbcodigop.Size = New System.Drawing.Size(251, 34)
        Me.Txtbcodigop.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(61, 129)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Descripcion:"
        '
        'TxtbDescripcion
        '
        Me.TxtbDescripcion.Location = New System.Drawing.Point(185, 120)
        Me.TxtbDescripcion.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtbDescripcion.Multiline = True
        Me.TxtbDescripcion.Name = "TxtbDescripcion"
        Me.TxtbDescripcion.Size = New System.Drawing.Size(445, 34)
        Me.TxtbDescripcion.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(61, 168)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 17)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Cantidad:"
        '
        'TxtbCantidad
        '
        Me.TxtbCantidad.Location = New System.Drawing.Point(185, 159)
        Me.TxtbCantidad.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtbCantidad.Multiline = True
        Me.TxtbCantidad.Name = "TxtbCantidad"
        Me.TxtbCantidad.Size = New System.Drawing.Size(125, 34)
        Me.TxtbCantidad.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(61, 208)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(105, 17)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Precio Unitario:"
        '
        'TxtbPrecio
        '
        Me.TxtbPrecio.Location = New System.Drawing.Point(185, 201)
        Me.TxtbPrecio.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtbPrecio.Multiline = True
        Me.TxtbPrecio.Name = "TxtbPrecio"
        Me.TxtbPrecio.Size = New System.Drawing.Size(125, 34)
        Me.TxtbPrecio.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(376, 28)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(148, 25)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "INVENTARIO"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(52, 272)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(727, 329)
        Me.DataGridView1.TabIndex = 9
        '
        'BotGuardar
        '
        Me.BotGuardar.Location = New System.Drawing.Point(716, 79)
        Me.BotGuardar.Name = "BotGuardar"
        Me.BotGuardar.Size = New System.Drawing.Size(75, 23)
        Me.BotGuardar.TabIndex = 10
        Me.BotGuardar.Text = "Guardar"
        Me.BotGuardar.UseVisualStyleBackColor = True
        '
        'BotEditar
        '
        Me.BotEditar.Location = New System.Drawing.Point(716, 117)
        Me.BotEditar.Name = "BotEditar"
        Me.BotEditar.Size = New System.Drawing.Size(75, 23)
        Me.BotEditar.TabIndex = 11
        Me.BotEditar.Text = "Editar"
        Me.BotEditar.UseVisualStyleBackColor = True
        '
        'BotBorrar
        '
        Me.BotBorrar.Location = New System.Drawing.Point(716, 156)
        Me.BotBorrar.Name = "BotBorrar"
        Me.BotBorrar.Size = New System.Drawing.Size(75, 23)
        Me.BotBorrar.TabIndex = 12
        Me.BotBorrar.Text = "Borrar"
        Me.BotBorrar.UseVisualStyleBackColor = True
        '
        'BotBuscar
        '
        Me.BotBuscar.Location = New System.Drawing.Point(716, 193)
        Me.BotBuscar.Name = "BotBuscar"
        Me.BotBuscar.Size = New System.Drawing.Size(75, 23)
        Me.BotBuscar.TabIndex = 13
        Me.BotBuscar.Text = "Buscar"
        Me.BotBuscar.UseVisualStyleBackColor = True
        '
        'Form3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(829, 613)
        Me.Controls.Add(Me.BotBuscar)
        Me.Controls.Add(Me.BotBorrar)
        Me.Controls.Add(Me.BotEditar)
        Me.Controls.Add(Me.BotGuardar)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtbPrecio)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtbCantidad)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtbDescripcion)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Txtbcodigop)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Form3"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "INVENTARIO"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Txtbcodigop As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtbDescripcion As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtbCantidad As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtbPrecio As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents BotGuardar As Button
    Friend WithEvents BotEditar As Button
    Friend WithEvents BotBorrar As Button
    Friend WithEvents BotBuscar As Button
End Class

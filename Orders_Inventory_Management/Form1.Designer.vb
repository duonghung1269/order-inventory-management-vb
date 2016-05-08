<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMicroland
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.btnStock = New System.Windows.Forms.Button()
        Me.btnBills = New System.Windows.Forms.Button()
        Me.lstOutput = New System.Windows.Forms.ListBox()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.MicrolandDataSet1 = New Orders_Inventory_Management.MicrolandDataSet1()
        Me.CustomersTableAdapter = New Orders_Inventory_Management.MicrolandDataSet1TableAdapters.CustomersTableAdapter()
        Me.InventoryTableAdapter = New Orders_Inventory_Management.MicrolandDataSet1TableAdapters.InventoryTableAdapter()
        Me.OrdersTableAdapter = New Orders_Inventory_Management.MicrolandDataSet1TableAdapters.OrdersTableAdapter()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MicrolandDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnStock
        '
        Me.btnStock.Location = New System.Drawing.Point(12, 23)
        Me.btnStock.Name = "btnStock"
        Me.btnStock.Size = New System.Drawing.Size(86, 53)
        Me.btnStock.TabIndex = 0
        Me.btnStock.Text = "Out Of Stock Items"
        Me.btnStock.UseVisualStyleBackColor = True
        '
        'btnBills
        '
        Me.btnBills.Location = New System.Drawing.Point(185, 23)
        Me.btnBills.Name = "btnBills"
        Me.btnBills.Size = New System.Drawing.Size(85, 53)
        Me.btnBills.TabIndex = 1
        Me.btnBills.Text = "Bills for today's orders"
        Me.btnBills.UseVisualStyleBackColor = True
        '
        'lstOutput
        '
        Me.lstOutput.FormattingEnabled = True
        Me.lstOutput.Location = New System.Drawing.Point(13, 101)
        Me.lstOutput.Name = "lstOutput"
        Me.lstOutput.Size = New System.Drawing.Size(443, 173)
        Me.lstOutput.TabIndex = 2
        '
        'BindingSource1
        '
        Me.BindingSource1.DataMember = "Orders"
        Me.BindingSource1.DataSource = Me.MicrolandDataSet1
        '
        'MicrolandDataSet1
        '
        Me.MicrolandDataSet1.DataSetName = "MicrolandDataSet1"
        Me.MicrolandDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'CustomersTableAdapter
        '
        Me.CustomersTableAdapter.ClearBeforeFill = True
        '
        'InventoryTableAdapter
        '
        Me.InventoryTableAdapter.ClearBeforeFill = True
        '
        'OrdersTableAdapter
        '
        Me.OrdersTableAdapter.ClearBeforeFill = True
        '
        'frmMicroland
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(485, 278)
        Me.Controls.Add(Me.lstOutput)
        Me.Controls.Add(Me.btnBills)
        Me.Controls.Add(Me.btnStock)
        Me.Name = "frmMicroland"
        Me.Text = "Microland"
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MicrolandDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnStock As System.Windows.Forms.Button
    Friend WithEvents btnBills As System.Windows.Forms.Button
    Friend WithEvents lstOutput As System.Windows.Forms.ListBox
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents MicrolandDataSet1 As Orders_Inventory_Management.MicrolandDataSet1
    Friend WithEvents CustomersTableAdapter As Orders_Inventory_Management.MicrolandDataSet1TableAdapters.CustomersTableAdapter
    Friend WithEvents InventoryTableAdapter As Orders_Inventory_Management.MicrolandDataSet1TableAdapters.InventoryTableAdapter
    Friend WithEvents OrdersTableAdapter As Orders_Inventory_Management.MicrolandDataSet1TableAdapters.OrdersTableAdapter

End Class

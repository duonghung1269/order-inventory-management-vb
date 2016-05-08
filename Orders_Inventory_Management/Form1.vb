' Project: Orders and Inventory Management
' Description:  Program uses three databases to track orders, customers and inventory for items.
'     User clicks on "Out of Stock" button to determine which items need to be ordered
'     User clicks on "Bills for Today's Orders" to see a summary of each customer and their order details
'     for the current day

Public Class frmMicroland
    ' Declare global variables
    Structure OutOfStock
        Dim itemNumber As String
        Dim description As String
        Dim startQty As Integer
        Dim numOrdered As Integer
        Dim endQty As Integer
    End Structure
    Dim outOfStockArray() As OutOfStock
    Structure Customer
        Dim customerID As Integer
        Dim name As String
        Dim street As String
        Dim city As String
    End Structure
    Dim customerArray() As Customer
    Structure Order
        Dim customerID As Integer
        Dim qtyOrdered As Integer
        Dim description As String
        Dim pricePerItem As Double
        Dim totalPrice As Double
    End Structure
    Dim orderArray() As Order

    Private Sub frmMicroland_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.OrdersTableAdapter.Fill(Me.MicrolandDataSet1.Orders)
        Me.InventoryTableAdapter.Fill(Me.MicrolandDataSet1.Inventory)
        Me.CustomersTableAdapter.Fill(Me.MicrolandDataSet1.Customers)
    End Sub

    Private Sub btnStock_Click(sender As Object, e As EventArgs) Handles btnStock.Click
        DisplayIntroComments()
        CreateStockArray()
        CombineDuplicateItems()
        DisplayOutOfStock()
    End Sub

    Private Sub btnBills_Click(sender As Object, e As EventArgs) Handles btnBills.Click
        lstOutput.Items.Clear()
        CreateCustomerArray()
        CreateOrderArray()
        DisplayOutput()
    End Sub

    Sub DisplayIntroComments()
        ' Display the first few lines of comments when the "Out of Stock" button is pressed
        lstOutput.Items.Clear()
        lstOutput.Items.Add("Here are the items that are out of")
        lstOutput.Items.Add("inventory or must be reordered.")
        lstOutput.Items.Add("")
        lstOutput.Items.Add("The numbers shown give the")
        lstOutput.Items.Add("minimum reorder quantity required.")
        lstOutput.Items.Add("")
    End Sub

    Sub CreateStockArray()
        ' Create a query from items in Orders and Inventory tables
        Dim query = From order In MicrolandDataSet1.Orders
                    Join item In MicrolandDataSet1.Inventory
                    On order.itemID Equals item.itemID
                    Let itemNumber = order.itemID
                    Let description = item.description
                    Let startQuantity = item.quantity
                    Let numberOrdered = order.quantity
                    Select itemNumber, description, startQuantity, numberOrdered
        ' Populate query into array for manipulation
        ReDim outOfStockArray(query.Count - 1)
        For i = 0 To (query.Count - 1)
            outOfStockArray(i).itemNumber = query(i).itemNumber
            outOfStockArray(i).description = query(i).description
            outOfStockArray(i).startQty = CInt(query(i).startQuantity)
            outOfStockArray(i).numOrdered = CInt(query(i).numberOrdered)
            outOfStockArray(i).endQty = 0
        Next
    End Sub

    Sub CombineDuplicateItems()
        ' Consolidates duplicates for items sold to calculate stock
        For i = 0 To (outOfStockArray.Count - 1)
            For j = 0 To (outOfStockArray.Count - 1)
                If i <> j Then
                    If (outOfStockArray(i).itemNumber = outOfStockArray(j).itemNumber) Then
                        ' combine the qty sold and set the duplicate to 0
                        outOfStockArray(i).numOrdered += outOfStockArray(j).numOrdered
                        outOfStockArray(j).numOrdered = 0
                    End If
                End If
            Next
        Next
    End Sub

    Sub DisplayOutOfStock()
        ' calculate the end quantity of each item and display items which need to be ordered
        Dim numberToOrder As Integer = 0
        For i = 0 To (outOfStockArray.Count - 1)
            outOfStockArray(i).endQty = outOfStockArray(i).startQty - outOfStockArray(i).numOrdered
            If outOfStockArray(i).endQty <= 0 Then
                numberToOrder = -(outOfStockArray(i).endQty)
                lstOutput.Items.Add(outOfStockArray(i).itemNumber & " " & numberToOrder & " " & outOfStockArray(i).description)
            End If
        Next
    End Sub

    Sub CreateCustomerArray()
        ' Create a query of only those customers which placed an order
        Dim query = From customer In MicrolandDataSet1.Customers
                    Join order In MicrolandDataSet1.Orders
                    On customer.custID Equals order.custID
                    Let customerID = customer.custID
                    Let name = customer.name
                    Let street = customer.street
                    Let city = customer.city
                    Select customerID, name, street, city
                    Distinct
        ' Populate query results into array for manipulation
        ReDim customerArray(query.Count - 1)
        For i = 0 To (query.Count - 1)
            customerArray(i).customerID = CInt(query(i).customerID)
            customerArray(i).name = query(i).name
            customerArray(i).street = query(i).street
            customerArray(i).city = query(i).city
        Next
    End Sub

    Sub CreateOrderArray()
        ' Create a query from orders and inventory
        Dim query = From order In MicrolandDataSet1.Orders
                    Join item In MicrolandDataSet1.Inventory
                    On order.itemID Equals item.itemID
                    Let itemNumber = order.itemID
                    Let customerNumber = order.custID
                    Let quantity = order.quantity
                    Let description = item.description
                    Let pricePerItem = item.price
                    Select itemNumber, customerNumber, quantity, description, pricePerItem
        ' Populate query into array for manipulation
        ReDim orderArray(query.Count - 1)
        For i = 0 To (query.Count - 1)
            orderArray(i).customerID = query(i).customerNumber
            orderArray(i).qtyOrdered = CInt(query(i).quantity)
            orderArray(i).description = query(i).description
            orderArray(i).pricePerItem = CDbl(query(i).pricePerItem)
            orderArray(i).totalPrice = orderArray(i).qtyOrdered * orderArray(i).pricePerItem
        Next
    End Sub

    Sub DisplayOutput()
        Dim totalPrice As Double = 0
        For i = 0 To (customerArray.Count - 1)
            totalPrice = 0
            ' Display customer information
            lstOutput.Items.Add(customerArray(i).name)
            lstOutput.Items.Add(customerArray(i).street)
            lstOutput.Items.Add(customerArray(i).city)
            lstOutput.Items.Add("")
            ' Display order details
            For j = 0 To (orderArray.Count - 1)
                If customerArray(i).customerID = orderArray(j).customerID Then
                    lstOutput.Items.Add(CInt(orderArray(j).qtyOrdered) & " " & orderArray(j).description & " " & ((orderArray(j).totalPrice).ToString("C")))
                    totalPrice += CDbl(orderArray(j).totalPrice)
                End If
            Next
            ' Display total cost for current customer
            lstOutput.Items.Add("Total Cost: " & (totalPrice).ToString("C"))
            lstOutput.Items.Add("")
        Next
    End Sub
End Class
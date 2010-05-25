Public Class frmCntryTree
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents lstCust As System.Windows.Forms.ListBox
    Friend WithEvents trvCntry As System.Windows.Forms.TreeView
    Friend WithEvents grbCustom As System.Windows.Forms.GroupBox
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnNewFolder As System.Windows.Forms.Button
    Friend WithEvents btnDelFolder As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Country")
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCntryTree))
        Me.lstCust = New System.Windows.Forms.ListBox
        Me.trvCntry = New System.Windows.Forms.TreeView
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.grbCustom = New System.Windows.Forms.GroupBox
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnNewFolder = New System.Windows.Forms.Button
        Me.btnDelFolder = New System.Windows.Forms.Button
        Me.grbCustom.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstCust
        '
        Me.lstCust.AllowDrop = True
        Me.lstCust.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.lstCust.Location = New System.Drawing.Point(16, 32)
        Me.lstCust.Name = "lstCust"
        Me.lstCust.Size = New System.Drawing.Size(304, 433)
        Me.lstCust.Sorted = True
        Me.lstCust.TabIndex = 0
        '
        'trvCntry
        '
        Me.trvCntry.AllowDrop = True
        Me.trvCntry.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.trvCntry.ImageIndex = 0
        Me.trvCntry.ImageList = Me.ImageList1
        Me.trvCntry.LabelEdit = True
        Me.trvCntry.Location = New System.Drawing.Point(336, 16)
        Me.trvCntry.Name = "trvCntry"
        TreeNode1.Name = ""
        TreeNode1.Text = "Country"
        Me.trvCntry.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1})
        Me.trvCntry.SelectedImageIndex = 0
        Me.trvCntry.Size = New System.Drawing.Size(312, 432)
        Me.trvCntry.Sorted = True
        Me.trvCntry.TabIndex = 1
        Me.trvCntry.Tag = "Y"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "")
        Me.ImageList1.Images.SetKeyName(1, "")
        '
        'grbCustom
        '
        Me.grbCustom.Controls.Add(Me.trvCntry)
        Me.grbCustom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbCustom.Location = New System.Drawing.Point(8, 16)
        Me.grbCustom.Name = "grbCustom"
        Me.grbCustom.Size = New System.Drawing.Size(656, 456)
        Me.grbCustom.TabIndex = 2
        Me.grbCustom.TabStop = False
        Me.grbCustom.Text = "Customers"
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(680, 464)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(88, 32)
        Me.btnExit.TabIndex = 3
        Me.btnExit.Text = "&Exit"
        '
        'btnNewFolder
        '
        Me.btnNewFolder.Location = New System.Drawing.Point(680, 56)
        Me.btnNewFolder.Name = "btnNewFolder"
        Me.btnNewFolder.Size = New System.Drawing.Size(88, 32)
        Me.btnNewFolder.TabIndex = 4
        Me.btnNewFolder.Text = "&NewFolder"
        '
        'btnDelFolder
        '
        Me.btnDelFolder.Location = New System.Drawing.Point(680, 104)
        Me.btnDelFolder.Name = "btnDelFolder"
        Me.btnDelFolder.Size = New System.Drawing.Size(88, 32)
        Me.btnDelFolder.TabIndex = 5
        Me.btnDelFolder.Text = "&DeleteFolder"
        '
        'frmCntryTree
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(792, 501)
        Me.Controls.Add(Me.btnDelFolder)
        Me.Controls.Add(Me.btnNewFolder)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.lstCust)
        Me.Controls.Add(Me.grbCustom)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCntryTree"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Customer Hierarchy"
        Me.grbCustom.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim sConnString As String
    Dim objReadApp As ReadApp
    Dim sThree As Integer = 3
    Dim strLstItem, sLstItem, strTrvItem As String
    Dim sZero As Int16 = 0
    Private Sub frmCntryTree_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim objclsCustDragDrop As clsCustDragDrop
        Dim dtCust As DataTable
        Try
            objReadApp = New ReadApp()
            sConnString = objReadApp.GetAppValue("SQLConnectionString")
            objclsCustDragDrop = New clsCustDragDrop()
            dtCust = New DataTable()
            dtCust = objclsCustDragDrop.FetchCustomers(sConnString)
            If dtCust.Rows.Count > 0 Then
                PopulateCust(dtCust)
            End If
            trvCntry.TopNode.Tag = "Y"
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub PopulateCust(ByVal dtCust As DataTable)
        Dim iCount As Integer
        Try

            For iCount = 0 To dtCust.Rows.Count - 1
                lstCust.Items.Insert(iCount, (dtCust.Rows(iCount)("nombre").ToString))
            Next
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub lstcust_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstCust.MouseDown
        Dim iFound As Integer
        Dim iLength As Integer
        Dim strItem As String
        Try
            If lstCust.Items.Count > sZero Then

                strItem = lstCust.Items(lstCust.IndexFromPoint(e.X, e.Y)).ToString()
                strLstItem = lstCust.Items(lstCust.IndexFromPoint(e.X, e.Y)).ToString()

                iFound = strItem.IndexOf("(")
                If iFound > sZero Then
                    iLength = strItem.Length
                    ' remove the  substring starting with "(" ...    
                    strItem = strItem.Remove(iFound, (iLength - iFound))
                End If
                If strItem.Trim.Length > sZero Then
                    DoDragDrop(strItem, DragDropEffects.All)
                End If ''Avisos Web Portales Club
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub trvCntry_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles trvCntry.DragDrop
        Dim strDummy As String = ""
        Dim strNodeDragged As String
        Dim DragNode As TreeNode
        Dim DropNode As TreeNode
        Dim mTrNode As TreeNode
        Dim position As Point
        position = New Point(0, 0)

        Try

            strNodeDragged = CType(e.Data.GetData(strDummy.GetType), String)
            DragNode = New TreeNode(strNodeDragged)
            position.X = e.X
            position.Y = e.Y
            position = trvCntry.PointToClient(position)
            DropNode = Me.trvCntry.GetNodeAt(position)
            If IsNothing(DropNode) Or DropNode.Text = "Country" Or DropNode.Text = DragNode.Text Then
                Exit Sub
            End If

            If IsNothing(DragNode.Tag) Then
                DragNode.Tag = "N"
            End If
            '
            'CHECK FOR EXISTING ENTRY IN TREEVIEW
            '
            mTrNode = New TreeNode()
            For Each mTrNode In trvCntry.Nodes
                ExistInTreeView(mTrNode, DragNode)
            Next

            'If IsNothing(DropNode.LastNode) Then
            If DropNode.Tag = "Y" Then
                DropNode.Nodes.Insert(DropNode.Index + 1, DragNode)
                DragNode.Tag = "N"
                DragNode.ImageIndex = 5
                DragNode.SelectedImageIndex = 5
                DropNode.Expand()
            Else
                DropNode.Parent.Nodes.Insert(DropNode.Index + 1, DragNode)
                DragNode.Tag = "N"
                DragNode.ImageIndex = 5
                DragNode.SelectedImageIndex = 5
                DropNode.Expand()
            End If
            'Else
            'If DropNode.Tag = "Y" Then
            '    DropNode.Nodes.Insert(DropNode.LastNode.Index + 1, DragNode)
            '    DragNode.Tag = "N"
            '    DragNode.ImageIndex = 5
            '    DragNode.SelectedImageIndex = 5
            '    DropNode.Expand()

            'Else
            '    DropNode.Parent.Nodes.Insert(DropNode.Index + 1, DragNode)
            '    DragNode.Tag = "N"
            '    DragNode.ImageIndex = 5
            '    DragNode.SelectedImageIndex = 5
            '    DropNode.Expand()
            'End If
            'End If
            'Avisos Red Nacional con Rev. Club
            ' CHANGE FOLDER NAME OF DRAGGED ITEM IN LISTBOX
            '
            UpdateListItem(strLstItem, DropNode)
            UpdateListBox(strLstItem, DragNode)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub trvCntry_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles trvCntry.DragEnter
        Try
            If e.Data.GetDataPresent(DataFormats.Text) Then
                e.Effect = DragDropEffects.Move
            Else
                e.Effect = DragDropEffects.None
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub trvLayout_ItemDrag(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemDragEventArgs) Handles trvCntry.ItemDrag
        'Set the drag node and initiate the DragDrop 
        Dim node As TreeNode
        Dim iFound As Integer
        Try
            node = New TreeNode()
            If e.Item.Tag.ToString = "Y" Then
                Exit Sub
            End If
            strTrvItem = e.Item.ToString
            node.Text = e.Item.ToString
            iFound = strTrvItem.IndexOf(":")
            If iFound > sZero Then
                ' remove the  substring starting with ":" ...    Aviso Desplegado Rev Club
                strTrvItem = strTrvItem.Remove(0, iFound + 2)
            End If
            strLstItem = strTrvItem
            DoDragDrop(strTrvItem, DragDropEffects.Move)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub trvLayout_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles trvCntry.DragOver
        'Check that there is a TreeNode being dragged 
        Dim selectedTreeview As TreeView
        Dim targetNode As TreeNode
        Dim DropNode As TreeNode
        Dim mPoint As Point
        Try
            If e.Data.GetDataPresent(DataFormats.Text) = True Then
                Exit Sub
            Else
                selectedTreeview = CType(sender, TreeView)
                mPoint = CType(sender, TreeView).PointToClient(New Point(e.X, e.Y))
                targetNode = selectedTreeview.GetNodeAt(mPoint)
                'See if the targetNode is currently selected, 
                If Not (selectedTreeview.SelectedNode Is targetNode) Then
                    'Select the    node currently under the cursor
                    selectedTreeview.SelectedNode = targetNode
                    'Check that the selected node is not the DropNode and
                    'also that it is not a child of the DropNode and 
                    'therefore an invalid target
                    DropNode = CType(e.Data.GetData(DataFormats.Text), TreeNode)
                    Do Until IsNothing(targetNode)
                        If targetNode Is DropNode Then
                            e.Effect = DragDropEffects.None
                            Exit Sub
                        End If
                        targetNode = targetNode.Parent
                    Loop
                End If
                'Currently selected node is a suitable target
                e.Effect = DragDropEffects.Move
                strLstItem = strTrvItem
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    '*******************************************************************************************
    ' Function Name :   ExistInTreeView
    ' Purpose       :   This Function Removes The DragNode from the tree from its Previous Place
    ' Input         :   DragNode,Node
    ' Output        :   Integer
    ' Author        :   Ujwal Watgule
    ' Date          :   6th May  2006
    ' Modification History
    ' ------------------------------------------------------------------------------------------
    ' Modified Date        Modified By            CIF/UCF#            Purpose Of  Modification
    ' ------------------------------------------------------------------------------------------
    '      
    ' ------------------------------------------------------------------------------------------
    '*******************************************************************************************
    Private Function ExistInTreeView(ByVal node As TreeNode, ByVal nddrag As TreeNode) As Integer
        Dim anode As TreeNode
        Try
            anode = New TreeNode()
            For Each anode In node.Nodes
                If Trim(anode.Text) = Trim(nddrag.Text) Then
                    trvCntry.Nodes.Remove(anode)
                    Return sThree

                End If
                If anode.Nodes.Count > 0 Then
                    ExistInTreeView(anode, nddrag)
                End If
                If Trim(anode.Text) = Trim(nddrag.Text) Then
                    trvCntry.Nodes.Remove(anode)
                    Return sThree

                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '*******************************************************************************************
    ' Sub Name      :   UpdateListItem
    ' Purpose       :   This SubRoutine Updates The Listbox if The item is dragged from Listbox and dropped in  Treeview
    ' Input         :   ItemName,DropNode
    ' Output        :   Nothing
    ' Author        :   Ujwal Watgule
    ' Date          :   3rd May 2006
    ' Modification History
    ' ------------------------------------------------------------------------------------------
    ' Modified Date        Modified By            CIF/UCF#            Purpose Of  Modification
    ' ------------------------------------------------------------------------------------------
    '      
    ' ------------------------------------------------------------------------------------------
    '*******************************************************************************************
    Private Sub UpdateListItem(ByVal ItemName As String, ByVal DropNode As TreeNode)
        Dim iFindString, intCntr As Integer
        Dim iLength As Integer
        Dim strItemNewName As String
        Try

            If DropNode.Tag = "N" Then
                For intCntr = 0 To lstCust.Items.Count - 1
                    If ItemName = lstCust.Items(intCntr) Then
                        iFindString = ItemName.IndexOf("(")
                        If iFindString > 0 Then
                            iLength = ItemName.Length
                            ' remove the  substring starting with "(" ...    
                            ItemName = ItemName.Remove(iFindString, (iLength - iFindString))
                            strItemNewName = ItemName & "(" & DropNode.Parent.FullPath & ")"
                            lstCust.Items.RemoveAt(intCntr)
                            lstCust.Items.Insert(intCntr, (strItemNewName))
                            lstCust.Refresh()

                            Exit For
                        Else
                            strItemNewName = ItemName & "(" & DropNode.Parent.FullPath & ")"
                            lstCust.Items.RemoveAt(intCntr)
                            lstCust.Items.Insert(intCntr, (strItemNewName))
                            lstCust.Refresh()

                            Exit For
                        End If
                    End If
                Next

            Else
                For intCntr = 0 To lstCust.Items.Count - 1
                    If ItemName = lstCust.Items(intCntr) Then
                        iFindString = ItemName.IndexOf("(")
                        If iFindString > 0 Then
                            iLength = ItemName.Length
                            ' remove the  substring starting with "(" ...    
                            ItemName = ItemName.Remove(iFindString, (iLength - iFindString))
                            strItemNewName = ItemName & "(" & DropNode.FullPath & ")"
                            lstCust.Items.RemoveAt(intCntr)
                            lstCust.Items.Insert(intCntr, (strItemNewName))
                            lstCust.Refresh()
                            Exit For
                        Else
                            strItemNewName = ItemName & "(" & DropNode.FullPath & ")"
                            lstCust.Items.RemoveAt(intCntr)
                            lstCust.Items.Insert(intCntr, (strItemNewName))
                            lstCust.Refresh()
                            Exit For
                        End If
                    End If
                Next
            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '*******************************************************************************************
    ' Sub Name      :   UpdateListBox
    ' Purpose       :   This SubRoutine Updates The Listbox if The item is dragged within the Treeview
    ' Input         :   DragNode,Node
    ' Output        :   Nothing
    ' Author        :   Ujwal Watgule
    ' Date          :   3rd May 2006
    ' Modification History
    ' ------------------------------------------------------------------------------------------
    ' Modified Date        Modified By            CIF/UCF#            Purpose Of  Modification
    ' ------------------------------------------------------------------------------------------
    '      
    ' ------------------------------------------------------------------------------------------
    '*******************************************************************************************
    Private Sub UpdateListBox(ByVal ItemName As String, ByVal DragNode As TreeNode)
        Dim mSt As String
        Dim oCntr, icntr As Integer
        Try

            For oCntr = 0 To lstCust.Items.Count - 1
                sLstItem = lstCust.Items(oCntr)
                For icntr = 0 To sLstItem.Length - 1
                    If ItemName = sLstItem.Substring(0, icntr) Then
                        mSt = ItemName & "(" & DragNode.Parent.FullPath & ")"
                        lstCust.Items.RemoveAt(oCntr)
                        lstCust.Items.Insert(oCntr, (mSt))
                        lstCust.Refresh()
                        'Exit For
                        Exit Sub
                    End If
                Next
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub lstCust_MeasureItem(ByVal sender As Object, ByVal e As System.Windows.Forms.MeasureItemEventArgs) Handles lstCust.MeasureItem
        Dim mItemSize As SizeF
        Dim mSize As SizeF
        Dim mFnt As Font
        mFnt = New Font("Verdana", 8, FontStyle.Regular)
        mSize = New SizeF(lstCust.Width, 200)
        Try
            mItemSize = e.Graphics.MeasureString(lstCust.Items(e.Index).ToString, mFnt, mSize)
            e.ItemHeight = mItemSize.Height
            e.ItemWidth = mItemSize.Width

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub lstCust_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles lstCust.DrawItem
        Dim mItemBrush As SolidBrush
        Dim mFont As Font
        Dim mFontSize As Font
        Dim mRecStr As RectangleF
        Dim intCntr As Integer
        Try

            mFont = New Font("Verdana", 8, FontStyle.Regular)
            mItemBrush = New SolidBrush(Color.Blue)
            mFontSize = New Font(mFont.Name, mFont.Size, FontStyle.Regular)
            'initializing a rectangle for drawing string in the listbox item 
            mRecStr = New RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height)
            'drawing listbox items 
            For intCntr = 0 To lstCust.Items(e.Index).ToString.Length - 1
                If lstCust.Items(e.Index).ToString.Substring(intCntr, 1) = "(" Then
                    mFont = New Font("Verdana", 8, FontStyle.Italic)
                    mItemBrush = New SolidBrush(Color.Black)
                    Exit For
                End If
            Next
            e.Graphics.DrawString(lstCust.Items(e.Index).ToString, mFontSize, mItemBrush, mRecStr) ', mRecStr)
            e.DrawFocusRectangle()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnNewFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewFolder.Click
        Dim SubFolder As TreeNode
        Dim mFnt As Font
        mFnt = New Font("Verdana", 7, FontStyle.Bold)
        Try


            If trvCntry.SelectedNode.Tag = "Y" Then
                SubFolder = New TreeNode()
                If IsNothing(trvCntry.SelectedNode.LastNode) Then
                    trvCntry.SelectedNode.Nodes.Insert(trvCntry.SelectedNode.Index + 1, SubFolder)
                    trvCntry.SelectedNode.Expand()
                Else
                    trvCntry.SelectedNode.Nodes.Insert(trvCntry.SelectedNode.LastNode.Index + 1, SubFolder)
                    trvCntry.SelectedNode.Expand()
                End If
                SubFolder.Tag = "Y"
                SubFolder.ImageIndex = 0
                SubFolder.Text = "NewFolder"
                trvCntry.SelectedNode = SubFolder
                trvCntry.LabelEdit = True
                trvCntry.SelectedNode.BeginEdit()

                SubFolder.NodeFont = mFnt
            End If

        Catch ex As Exception
            Throw ex
        End Try


    End Sub

    Private Sub btnDelFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelFolder.Click
        Try
            If trvCntry.SelectedNode.Text = "Country" Then
                Exit Sub
            End If
            If trvCntry.SelectedNode.Tag = "Y" Then
                DeleteItems(trvCntry.SelectedNode)
                trvCntry.SelectedNode.Remove()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    '*******************************************************************************************
    ' Function Name :   DeleteItems
    ' Purpose       :   This Subroutine Deletes The item From the Treeview
    ' Input         :   Treenode
    ' Output        :   Nothing
    ' Author        :   Ujwal Watgule
    ' Date          :   11th May  2006
    ' Modification History
    ' ------------------------------------------------------------------------------------------
    ' Modified Date        Modified By            CIF/UCF#            Purpose Of  Modification
    ' ------------------------------------------------------------------------------------------
    '      
    ' ------------------------------------------------------------------------------------------
    '*******************************************************************************************
    Private Sub DeleteItems(ByVal mNode As TreeNode)
        Dim aNode As TreeNode
        Try
            For Each aNode In mNode.Nodes
                DeleteItems(aNode)
                RefreshList(aNode.Text)
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    '*******************************************************************************************
    ' Function Name :   RefreshList
    ' Purpose       :   This Subroutine Refreshes The Listbox 
    ' Input         :   Items Name
    ' Output        :   Nothing
    ' Author        :   Ujwal Watgule
    ' Date          :   11th May 2006
    ' Modification History
    ' ------------------------------------------------------------------------------------------
    ' Modified Date        Modified By            CIF/UCF#            Purpose Of  Modification
    ' ------------------------------------------------------------------------------------------
    '      
    ' ------------------------------------------------------------------------------------------
    '*******************************************************************************************
    Private Sub RefreshList(ByVal mItem As String)
        Dim strRefreshListItem As String
        Dim strChkItem As String
        Dim intCntr, icntr As Integer
        Try
            For intCntr = 0 To lstCust.Items.Count - 1
                strRefreshListItem = lstCust.Items(intCntr)
                For icntr = 0 To strRefreshListItem.Length - 1
                    If mItem = strRefreshListItem.Substring(0, icntr) Then
                        strChkItem = mItem
                        lstCust.Items.RemoveAt(intCntr)
                        lstCust.Items.Insert(intCntr, (strChkItem))
                        lstCust.Refresh()
                        Exit For
                    End If
                Next
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub trvCntry_AfterLabelEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.NodeLabelEditEventArgs) Handles trvCntry.AfterLabelEdit
        Dim mTrNode As TreeNode
        Dim iItemExists As Int16

        Try
            If e.Label Is Nothing = False Then
                e.Node.Text = e.Label

                If Trim(e.Node.Text) = "" Then
                    MessageBox.Show("Plaes Specify a Valid Name.", "Folder Creation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    e.Node.Remove()
                    Exit Sub
                End If
            End If

            mTrNode = New TreeNode()
            For Each mTrNode In trvCntry.Nodes
                iItemExists = ExistItemInTreeView(mTrNode, e.Node)
                If iItemExists = 3 Then
                    MsgBox("This folder already exists", MsgBoxStyle.Critical, "Customers Hierarchy")
                    e.Node.Remove()
                End If
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    '*******************************************************************************************
    ' Function Name :   ExistItemInTreeView
    ' Purpose       :   This Function Checks Whether Item ALready Existed In treeView Or Not
    ' Input         :   Treenode,Treenode
    ' Output        :   Integer
    ' Author        :   Ujwal Watgule
    ' Date          :   11th August  2006
    ' Modification History
    ' ------------------------------------------------------------------------------------------
    ' Modified Date        Modified By            CIF/UCF#            Purpose Of  Modification
    ' ------------------------------------------------------------------------------------------
    '      
    ' ------------------------------------------------------------------------------------------
    '*******************************************************************************************
    Private Function ExistItemInTreeView(ByVal LayoutNode As TreeNode, ByVal NewNode As TreeNode) As Integer
        Dim ChkNode As TreeNode
        Dim mExists As Int16 = 0
        Try
            ChkNode = New TreeNode()
            For Each ChkNode In LayoutNode.Nodes
                If ChkNode Is NewNode = False Then
                    If Trim(ChkNode.Text).ToUpper = Trim(NewNode.Text).ToUpper Then
                        Return sThree
                    Else
                        If (ChkNode.Nodes.Count > sZero) Then
                            mExists = ExistItemInTreeView(ChkNode, NewNode)
                            If Not mExists = Nothing Then
                                Return sThree
                            End If
                        End If
                    End If
                End If

            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub lstCust_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstCust.SelectedIndexChanged

    End Sub
End Class

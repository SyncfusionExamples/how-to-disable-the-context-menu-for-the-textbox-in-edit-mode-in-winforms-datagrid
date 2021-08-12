# How to disable the context menu for the textbox in edit mode in WinForms DataGrid (SfDatGrid)?

## About the sample
This example illustrates how to disable the context menu for the textbox in edit mode in [WinForms DataGrid](https://www.syncfusion.com/winforms-ui-controls/datagrid) (SfDatGrid)?

The ContextMenu can be disabled for a TextBox in edit mode by deriving a new class from [GridTextBoxCellRenderer](https://help.syncfusion.com/cr/windowsforms/Syncfusion.WinForms.DataGrid.Renderers.GridTextBoxCellRenderer.html) and overriding the **OnWireEditUIElement** while assigning an empty context menu into the ContextMenu property of TextBox.

```C#

public partial class Form1 : Form
{
        public Form1()
        {
            InitializeComponent();
            //Remove existing TextBox Renderer
            sfDataGrid.CellRenderers.Remove("TextBox");
            //Add customized TextBox Renderer
            sfDataGrid.CellRenderers.Add("TextBox", new GridTextBoxCellRendererExt());
        }
}

public class GridTextBoxCellRendererExt : GridTextBoxCellRenderer
{
        protected override void OnWireEditUIElement(TextBox uiElement)
        {
            base.OnWireEditUIElement(uiElement);
            //To prevent the default context menu of a TextBox from showing up, assign a empty context menu as shown below
            uiElement.ContextMenu = new ContextMenu();
        }
}

```
**Note:** This can also be done for [GridNumericColumn](https://help.syncfusion.com/cr/windowsforms/Syncfusion.WinForms.DataGrid.GridNumericColumn.html) by deriving a new class from [GridNumericCellRenderer](https://help.syncfusion.com/cr/windowsforms/Syncfusion.WinForms.DataGrid.Renderers.GridNumericCellRenderer.html).


Take a moment to peruse the [WinForms DataGrid – Customize Column Renderer](https://help.syncfusion.com/windowsforms/datagrid/columntypes#customize-column-renderer) documentation, where you can find about customize column renderer with code examples.

## Requirements to run the demo
Visual Studio 2015 and above versions

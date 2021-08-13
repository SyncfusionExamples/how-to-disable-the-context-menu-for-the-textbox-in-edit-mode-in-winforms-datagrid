using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Renderers;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Forms;

namespace SfDataGridDemo
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            sfDataGrid.AutoGenerateColumns = false;
            sfDataGrid.DataSource = new ViewModel().Orders;            
            sfDataGrid.AllowEditing = true;

            GridTextColumn gridTextColumn1 = new GridTextColumn() { MappingName = "OrderID", HeaderText = "Order ID" };
            GridTextColumn gridTextColumn2 = new GridTextColumn() { MappingName = "CustomerID", HeaderText = "Customer ID" };
            GridTextColumn gridTextColumn3 = new GridTextColumn() { MappingName = "CustomerName", HeaderText = "Customer Name" };
            GridTextColumn gridTextColumn4 = new GridTextColumn() { MappingName = "Country", HeaderText = "Country" };
            GridTextColumn gridTextColumn5 = new GridTextColumn() { MappingName = "ShipCity", HeaderText = "Ship City" };            

            sfDataGrid.Columns.Add(gridTextColumn1);
            sfDataGrid.Columns.Add(gridTextColumn2);
            sfDataGrid.Columns.Add(gridTextColumn3);
            sfDataGrid.Columns.Add(gridTextColumn4);
            sfDataGrid.Columns.Add(gridTextColumn5);
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

    public class OrderInfo : INotifyPropertyChanged
    {
        decimal? orderID;
        string customerId;
        string country;
        string customerName;
        string shippingCity;       

        public OrderInfo()
        {

        }

        public decimal? OrderID
        {
            get { return orderID; }
            set { orderID = value; this.OnPropertyChanged("OrderID"); }
        }

        public string CustomerID
        {
            get { return customerId; }
            set { customerId = value; this.OnPropertyChanged("CustomerID"); }
        }

        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; this.OnPropertyChanged("CustomerName"); }
        }

        public string Country
        {
            get { return country; }
            set { country = value; this.OnPropertyChanged("Country"); }
        }

        public string ShipCity
        {
            get { return shippingCity; }
            set { shippingCity = value; this.OnPropertyChanged("ShipCity"); }
        }

        public OrderInfo(decimal? orderId, string customerName, string country, string customerId, string shipCity)
        {
            this.OrderID = orderId;
            this.CustomerName = customerName;
            this.Country = country;
            this.CustomerID = customerId;
            this.ShipCity = shipCity;            
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class ViewModel
    {
        private ObservableCollection<OrderInfo> orders;
        public ObservableCollection<OrderInfo> Orders
        {
            get { return orders; }
            set { orders = value; }
        }

        public ViewModel()
        {
            orders = new ObservableCollection<OrderInfo>();
            orders.Add(new OrderInfo(1001, "Thomas Hardy", "Germany", "ALFKI", "Berlin"));
            orders.Add(new OrderInfo(1002, "Laurence Lebihan", "Mexico", "ANATR", "Mexico"));
            orders.Add(new OrderInfo(1003, "Antonio Moreno", "Mexico", "ANTON", "Mexico"));
            orders.Add(new OrderInfo(1004, "Thomas Hardy", "UK", "AROUT", "London"));
            orders.Add(new OrderInfo(1005, "Christina Berglund", "Sweden", "BERGS", "Lula"));
        }
    }
}

using Data.ApplicationDbContext;
using Data.Repository;
using Resturant.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Orders
{
    class OrderViewModel:BindableBase
    {
		CatagoryRepository catagoryRepository;
		KindRepository kindRepository;
		OrdersRepository OrdersRepository;
		private ComboBoxItem selectCatagory;
		private RelayCommand addToCurrentOrderCommand;
		private Order order;

		public Order Order
		{
			get { return order; }
			set {SetProperty(ref order , value); }
		}

		public RelayCommand AddToCurrentOrderCommand
		{
			get { return addToCurrentOrderCommand; }
			set {SetProperty(ref addToCurrentOrderCommand , value); }
		}
	

		public ComboBoxItem SelectCatagory
		{
			get { return selectCatagory; }
			set {SetProperty(ref selectCatagory, value); SelectCatagoryChangeAction(); }
		}
		private RelayCommand removeOrder;

		public RelayCommand RemoveOrder
		{
			get { return removeOrder; }
			set {SetProperty(ref removeOrder, value);  }
		}

		private List<ComboBoxItem> catagorys;
		public OrderViewModel()
		{
			catagoryRepository = new CatagoryRepository();
			kindRepository = new KindRepository();
			OrdersRepository = new OrdersRepository();
			Catagorys = catagoryRepository.Get().Select(a => new ComboBoxItem { Text = a.Name, Value = a.Id }).ToList();
			RemoveOrder = new RelayCommand(RemoveOrderAciton);
			AddToCurrentOrderCommand = new RelayCommand(AddToCurrentOrders);
			SaveOrders = new RelayCommand(SaveorderAciton);
			EmptyFieldsCommand = new RelayCommand(EmptyFieldsAction);
		}

		private void EmptyFieldsAction()
		{
			Orders.Clear();
			Totalprice = 0;
			

		}

		private void SaveorderAciton()
		{
			foreach (var item in Orders)
			{
				item.OrderDate = DateTime.Now;
				OrdersRepository.Insert(item);
				
			}
			EmptyFieldsAction();

		}
		private RelayCommand emptyFieldsCommand;

		public RelayCommand EmptyFieldsCommand
		{
			get { return emptyFieldsCommand; }
			set {SetProperty(ref emptyFieldsCommand , value); }
		}

		private decimal totalprice;

		public decimal Totalprice
		{
			get { return totalprice; }
			set {SetProperty(ref totalprice , value); }
		}

		private void RemoveOrderAciton()
		{
			if (Order!=null)
			{
             Totalprice -= Order.Price;
			Orders.Remove(Order); 
			}
			
			
		}

		private async void AddToCurrentOrders()
		{
		    var kind=await	kindRepository.GetByIDAsync((int)SelectKind.Value);
			
			Orders.Add(new Order { Quantity=Quantity,KindsId=kind.Id,Price=(decimal)(Quantity)* kind.Price});
			Totalprice += (decimal)(Quantity) * kind.Price;
		}
		private ComboBoxItem selectKind;

		public ComboBoxItem SelectKind
		{
			get { return selectKind; }
			set {SetProperty(ref selectKind ,value); }
		}

		private async void SelectCatagoryChangeAction()
		{
			if (SelectCatagory!=null)
			{
             var catagory = await catagoryRepository.GetByIDAsync(SelectCatagory.Value);
				Kinds = catagory.Kinds.Select(a => new ComboBoxItem { Text = a.Name, Value = a.Id }).ToList();
			}
			 
		}

		public List<ComboBoxItem> Catagorys
		{
			get { return catagorys; }
			set {SetProperty(ref catagorys , value); }
		}	
		private List<ComboBoxItem> kinds;

		public List<ComboBoxItem> Kinds
		{
			get { return kinds; }
			set {SetProperty(ref kinds , value); }
		}
		private double quantity;

		public double Quantity
		{
			get { return quantity; }
			set {SetProperty(ref quantity ,value); }
		}

		private ObservableCollection<Order> orders=new ObservableCollection<Order>();

		public ObservableCollection<Order> Orders
		{
			get
			{
			
				return orders;
				
			}
			set {
			
				SetProperty(ref orders , value);
			}
		}
		private RelayCommand saveOrders;

		public RelayCommand SaveOrders
		{
			get { return saveOrders; }
			set {SetProperty(ref saveOrders ,value); }
		}


	}
}

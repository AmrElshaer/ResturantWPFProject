using Data.ApplicationDbContext;
using Data.Repository;
using Resturant.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Home
{
    class HomeViewModel:BindableBase
    {
		CatagoryRepository catagoryRepository;
		OrdersRepository ordersRepository;
		public HomeViewModel()
		{
			catagoryRepository = new CatagoryRepository();
			ordersRepository = new OrdersRepository(); 
			Catagorys =new ObservableCollection<Catagory>(catagoryRepository.Get(includeProperties: "Kinds.Orders"));
			Refresh = new RelayCommand(RefreshAction);
		
			DateTimeChange += ResetOrdersandTotalprice;
			DateTimeChange(DateTime.Now);
		}

		private void RefreshAction()
		{
			DateTimeChange(DateTimeOfOrder);
		}

		private ObservableCollection<Catagory>catagorys;

		public ObservableCollection<Catagory> Catagorys
		{
			get { return catagorys; }
			set {SetProperty(ref catagorys , value); }
		}
		private ObservableCollection<Order> orders;

		public ObservableCollection<Order> Orders
		{
			get { return orders; }
			set {SetProperty(ref orders , value); }
		}

		private DateTime dateTimeOfOrder=DateTime.Now.Date;

		public DateTime DateTimeOfOrder
		{
			get { return dateTimeOfOrder; }
			set {SetProperty(ref dateTimeOfOrder , value); DateTimeChange(value); }
		}
		private decimal totalprice;

		public decimal Totalprice
		{
			get { return totalprice; }
			set {SetProperty(ref totalprice ,value); }
		}

		event Action<DateTime> DateTimeChange=delegate { };
		private void ResetOrdersandTotalprice(DateTime dateTime)
		{
		    Orders=new ObservableCollection<Order>(ordersRepository.Get(includeProperties:"Kind").ToList().Where(a => a.OrderDate.Value.Date == dateTime.Date));
			Totalprice=Orders.Sum(a => a.Price);

		}
		private RelayCommand refresh;

		public RelayCommand Refresh
		{
			get { return refresh; }
			set {SetProperty(ref refresh , value); }
		}

	}
}

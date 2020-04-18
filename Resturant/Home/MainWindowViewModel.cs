
using Data.ApplicationDbContext;
using Resturant.Catagorys;
using Resturant.Kinds;
using Resturant.Orders;
using Resturant.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Home
{
    class MainWindowViewModel:BindableBase
    {
		
		CatagoryViewModel catagoryViewModel ;
		OrderViewModel ordersListViewModel ;
		KindViewModel kindViewModel;
		HomeViewModel homeViewModel;
		private BindableBase currentViewModel;

		public BindableBase CurrentViewModel
		{
			get { return currentViewModel; }
			set { SetProperty(ref currentViewModel, value); }
			
		}
		private RelayCommand<string> navCommand;
		public RelayCommand<string> NavCommand
		{
			get { return navCommand; }
			set { SetProperty(ref navCommand, value); }
		}
		public MainWindowViewModel()
		{
			homeViewModel = new HomeViewModel();
			kindViewModel = new KindViewModel();
			catagoryViewModel = new CatagoryViewModel();
			ordersListViewModel = new OrderViewModel();
			navCommand = new RelayCommand<string>(NavToNext);
		}

		private void NavToNext(string obj)
		{
			switch (obj)
			{
				case "Home":
					CurrentViewModel = homeViewModel;
					break;
				case "Catagory":
					CurrentViewModel = catagoryViewModel;
					break;
				case "Orders":
					CurrentViewModel = ordersListViewModel;
					break;
				case "Kind":
					CurrentViewModel = kindViewModel;
					break;



			}
		}
	}
}

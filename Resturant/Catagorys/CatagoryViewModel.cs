using Data.ApplicationDbContext;
using Resturant.Catagorys;
using Resturant.Shared;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Catagorys
{
    class CatagoryViewModel:BindableBase
    {
		CreateCatagoryViewModel CreateCatagoryViewModel;
		ListCatagoryViewModel ListCatagoryViewModel;
		DeleteCatagoryViewModel DeleteCatagoryViewModel;
		EditCatagoryViewModel EditCatagoryViewModel;
		public CatagoryViewModel()
		{
			ListCatagoryViewModel = new ListCatagoryViewModel();
			CreateCatagoryViewModel = new CreateCatagoryViewModel();
			EditCatagoryViewModel = new EditCatagoryViewModel();
			DeleteCatagoryViewModel = new DeleteCatagoryViewModel();
			NavCommand = new RelayCommand<string>(Nav);
			ChangeNav += CurrentViewModelChange;
			currentViewModel = ListCatagoryViewModel;


		}
		private BindableBase currentViewModel;
		private Catagory selectCatagory;

		public Catagory SelectCatagory
		{
			get { return selectCatagory; }
			set { SetProperty(ref selectCatagory, value); }
		}

		

		private static event Action<Type,Catagory> ChangeNav;
		public static void raise(Type ViewModel,Catagory selectcatagory)
		{
			ChangeNav(ViewModel,selectcatagory);
		}
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

		

		private void CurrentViewModelChange(Type obj,Catagory selectcatagory)
		{
			if (obj==typeof(DeleteCatagoryViewModel))
			{
		            	DeleteCatagoryViewModel.SelectCatagory = selectcatagory;
			
						CurrentViewModel =DeleteCatagoryViewModel;
			}
			else if (obj==typeof(EditCatagoryViewModel))
			{
				EditCatagoryViewModel.SelectCatagory = selectcatagory;

				CurrentViewModel = EditCatagoryViewModel;
			}
			else 
			{
				CurrentViewModel = ListCatagoryViewModel;
			}
		}



		

		private void Nav(string obj)
		{
			switch (obj)
			{
				case"Create":
					CurrentViewModel = CreateCatagoryViewModel;
					break;
				case "Catagorys":
					CurrentViewModel = ListCatagoryViewModel;
					break;
				   
			}
		}

		
	}
}

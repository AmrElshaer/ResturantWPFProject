using Data.ApplicationDbContext;
using Resturant.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Kinds
{
	//KindViewModel
    class KindViewModel:BindableBase
    {
        
		CreateKindViewModel CreateKindViewModel;
		ListKindsViewModel ListKindViewModel;
		DeleteKindViewModel DeleteKindViewModel;
		
		public KindViewModel()
		{
			ListKindViewModel = new ListKindsViewModel();
			CreateKindViewModel = new CreateKindViewModel();
		
			DeleteKindViewModel = new DeleteKindViewModel();
			NavCommand = new RelayCommand<string>(Nav);
			ChangeNav += CurrentViewModelChange;
			currentViewModel = ListKindViewModel;

		}
		private BindableBase currentViewModel;
		private Kind selectCatagory;

		public Kind SelectCatagory
		{
			get { return selectCatagory; }
			set { SetProperty(ref selectCatagory, value); }
		}
		


		private static event Action<Type, Kind> ChangeNav;
		public static void raise(Type ViewModel, Kind selectcatagory)
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

		

		private void CurrentViewModelChange(Type obj, Kind selectcatagory)
		{
			if (obj==typeof(DeleteKindViewModel))
			{
		            	DeleteKindViewModel.SelectKind = selectcatagory;
			
						CurrentViewModel =DeleteKindViewModel;
			}
			else if (obj==typeof(EditKindViewModel))
			{
				EditKindViewModel EditKindViewModel = new EditKindViewModel(selectcatagory);
			
				

				CurrentViewModel = EditKindViewModel;
			}
			else 
			{
				CurrentViewModel = ListKindViewModel;
			}
		}



		

		private void Nav(string obj)
		{
			switch (obj)
			{
				case"Create":
					CurrentViewModel = CreateKindViewModel;
					break;
				case "Kinds":
					CurrentViewModel = ListKindViewModel;
					break;
				   
			}
		}

    }
}

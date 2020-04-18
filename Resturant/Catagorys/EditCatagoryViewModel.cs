using Data.ApplicationDbContext;
using Data.Repository;
using Resturant.Shared;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Resturant.Catagorys
{
    class EditCatagoryViewModel : BindableBase
    {
		private Catagory selectCatagory;

		public Catagory SelectCatagory
		{
			get { return selectCatagory; }
			set { SetProperty(ref selectCatagory, value); }
		}
		private RelayCommand saveCommand;

		public RelayCommand SaveCommand
		{
			get { return saveCommand; }
			set {SetProperty(ref saveCommand ,value); }
		}
		CatagoryRepository repository;
		
		public EditCatagoryViewModel()
		{

			repository = new CatagoryRepository();
			SaveCommand = new RelayCommand(UpdateCatagory);
		}

		private void UpdateCatagory()
		{
			repository.Update(selectCatagory);
			CatagoryViewModel.raise(typeof(ListCatagoryViewModel), null);

		}
	}
}

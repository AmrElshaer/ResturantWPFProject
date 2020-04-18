using Data.ApplicationDbContext;
using Data.Repository;
using Resturant.Shared;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace Resturant.Catagorys
{
    public class DeleteCatagoryViewModel:BindableBase
    {
		CatagoryRepository catagoryRepository;
	
		public DeleteCatagoryViewModel()
		{

			catagoryRepository = new CatagoryRepository(); 
			DeleteCommand = new RelayCommand<int>(DeleteCatagory);
		


		}

		private async void DeleteCatagory(int obj)
		{
		    await	catagoryRepository.Delete(obj);
			CatagoryViewModel.raise(typeof(ListCatagoryViewModel), null);

		}
		private Catagory selectCatagory;

		public Catagory SelectCatagory
		{
			get { return selectCatagory; }
			set {SetProperty(ref selectCatagory ,value); }
		}


		private RelayCommand<int> deleteCommand;

		public RelayCommand<int> DeleteCommand
		{
			get { return deleteCommand; }
			set {SetProperty(ref deleteCommand, value); }
		}


	}
}

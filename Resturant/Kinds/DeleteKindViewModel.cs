using Data.ApplicationDbContext;
using Data.Repository;
using Resturant.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Kinds
{
    class DeleteKindViewModel:BindableBase
    {
		KindRepository KindRepository;

		public DeleteKindViewModel()
		{

			KindRepository = new KindRepository();
			DeleteCommand = new RelayCommand<int>(DeleteKind);
			
	
		}

		private async void DeleteKind(int obj)
		{
			await KindRepository.Delete(obj);
			KindViewModel.raise(typeof(ListKindsViewModel), null);

		}
		private Kind selectKind;

		public Kind SelectKind
		{
			get { return selectKind; }
			set { SetProperty(ref selectKind, value); }
		}


		private RelayCommand<int> deleteCommand;

		public RelayCommand<int> DeleteCommand
		{
			get { return deleteCommand; }
			set { SetProperty(ref deleteCommand, value); }
		}
	}
}

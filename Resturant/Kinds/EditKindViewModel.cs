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
    class EditKindViewModel:BindableBase
    {
		private Kind selectKind;
	    private CatagoryRepository catagoryRepository;
		private ComboBoxItem comboBoxItem;
		private List<ComboBoxItem> catagorys;
		public List<ComboBoxItem> Catagorys
		{
			get { return catagorys; }
			set { SetProperty(ref catagorys, value); }
		}
		public ComboBoxItem ComboBoxItem
		{
			get { return comboBoxItem; }
			set {SetProperty(ref comboBoxItem ,value); }
		}

		public Kind SelectKind
		{
			get { return selectKind; }
			set { SetProperty(ref selectKind, value); }
		}
		private RelayCommand saveCommand;

		public RelayCommand SaveCommand
		{
			get { return saveCommand; }
			set { SetProperty(ref saveCommand, value); }
		}
		KindRepository repository;

		public EditKindViewModel(Kind selectKind)
		{
			SelectKind = selectKind;
			catagoryRepository = new CatagoryRepository();
			repository = new KindRepository();
			SaveCommand = new RelayCommand(UpdateKind);
			ComboBoxItem = new ComboBoxItem { Text = SelectKind.Name, Value = SelectKind.CatagoryId };
			catagorys = catagoryRepository.Get().Select(a => new ComboBoxItem { Text = a.Name, Value = a.Id }).ToList();
		}

		private void UpdateKind()
		{
			
			selectKind.CatagoryId = (int)ComboBoxItem.Value;
			repository.Update(selectKind);
			KindViewModel.raise(typeof(ListKindsViewModel), null);

		}
	}
}

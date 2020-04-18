using Data.Repository;
using Resturant.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Resturant.Kinds
{
 
	partial class CreateKindViewModel : BindableBase
	{
		private List<ComboBoxItem> catagorys;
		private ComboBoxItem catagoryId;

		public ComboBoxItem CatagoryId
		{
			get { return catagoryId; }
			set {SetProperty(ref catagoryId , value); }
		}


		CatagoryRepository catagoryRepository;
		public List<ComboBoxItem> Catagorys
		{
			get { return catagorys; }
			set {SetProperty(ref catagorys , value);}
		}


		private ImageSource imagesource;
		
		public ImageSource Imagesource
		{
			get { return imagesource; }
			set { SetProperty(ref imagesource, value); }
		}

		KindRepository KindRepository;
		private RelayCommand addCommand;
		public CreateKindViewModel()
		{
			catagoryRepository = new CatagoryRepository();
			KindRepository = new KindRepository();
			addCommand = new RelayCommand(Add);
			catagorys = catagoryRepository.Get().Select(a=>new ComboBoxItem { Text=a.Name,Value=a.Id}).ToList();
			
		}

		private void Add()
		{

			var ImagePath = Imagesource?.ToString().Remove(0, 8);

			KindRepository.Insert(new Data.ApplicationDbContext.Kind { Price=price,Name = name, ImagePath = ImagePath,CatagoryId=(int)CatagoryId.Value  });
			KindViewModel.raise(typeof(ListKindsViewModel), null);


		}

		public RelayCommand AddCommand
		{
			get { return addCommand; }
			set { SetProperty(ref addCommand, value); }
		}



	}
	partial class CreateKindViewModel
	{
		private string name;
		
		public string Name
		{
			get { return name; }
			set { SetProperty(ref name, value); }
		}

		private int price;

		public int Price
		{
			get { return price; }
			set {SetProperty(ref price , value); }
		}

	}
}

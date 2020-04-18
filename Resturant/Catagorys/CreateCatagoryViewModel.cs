using Data.ApplicationDbContext;
using Data.Repository;
using Resturant.Shared;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Resturant.Catagorys
{
    partial  class CreateCatagoryViewModel: ValidatableBindableBase
	{
		
		private ImageSource imagesource;

		public ImageSource Imagesource
		{
			get { return imagesource; }
			set {SetProperty(ref imagesource, value); }
		}

		CatagoryRepository catagoryRepository;
		private RelayCommand addCommand;
		public CreateCatagoryViewModel()
		{

			catagoryRepository = new CatagoryRepository();
			addCommand = new RelayCommand(Add);
			
		}

		private void Add()
		{

			var ImagePath = Imagesource?.ToString().Remove(0,8);

			catagoryRepository.Insert(new Data.ApplicationDbContext.Catagory { Name = name, ImagePath = ImagePath });
			CatagoryViewModel.raise(typeof(ListCatagoryViewModel),null);


		}

		public RelayCommand AddCommand
		{
			get { return addCommand; }
			set { SetProperty(ref addCommand, value);}
		}
	


	}
    partial class CreateCatagoryViewModel
	{
		private string name;
		[Required]
		public string Name
		{
			get { return name; }
			set { SetProperty(ref name, value); }
		}
	

	}
}

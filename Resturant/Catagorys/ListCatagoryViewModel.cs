using Data.ApplicationDbContext;
using Resturant.Catagorys;
using Resturant.Shared;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using Data.Repository;

namespace Resturant.Catagorys
{
    public class ListCatagoryViewModel:BindableBase
    {
        CatagoryRepository catagoryRepository;
        
       
        public ListCatagoryViewModel()
        {

            catagoryRepository = new CatagoryRepository();
            DeleteCommand = new RelayCommand<Catagory>(DeleteCatagory);
            EditCommand = new RelayCommand<Catagory>(EditCatagory);
           
        }

        private void EditCatagory(Catagory obj)
        {
            CatagoryViewModel.raise(typeof(EditCatagoryViewModel),obj);
        }

        private void DeleteCatagory(Catagory obj)
        {
            
            CatagoryViewModel.raise(typeof(DeleteCatagoryViewModel),obj);
        }

        private RelayCommand<Catagory> deleteCommand;

        public RelayCommand<Catagory> DeleteCommand
        {
            get { return deleteCommand; }
            set {SetProperty(ref deleteCommand , value); }
        }
        private RelayCommand<Catagory> editCommand;

        public RelayCommand<Catagory> EditCommand
        {
            get { return editCommand; }
            set {SetProperty(ref editCommand , value); }
        }


        public ObservableCollection<Catagory> Catagorys
        {
            get => new System.Collections.ObjectModel.ObservableCollection<Catagory>(LoadData());

        }
        private  IEnumerable<Catagory> LoadData()
        {
           
               
              return  catagoryRepository.Get();


        }   
   
    }
}

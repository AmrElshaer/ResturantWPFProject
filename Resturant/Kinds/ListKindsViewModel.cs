using Data.ApplicationDbContext;
using Data.Repository;
using Resturant.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Kinds
{
    class ListKindsViewModel:BindableBase
    {
        KindRepository KindRepository;


        public ListKindsViewModel()
        {

            KindRepository = new KindRepository();
            DeleteCommand = new RelayCommand<Kind>(DeleteKind);
            EditCommand = new RelayCommand<Kind>(EditKind);
            

        }

        private void EditKind(Kind obj)
        {
            KindViewModel.raise(typeof(EditKindViewModel), obj);
        }

        private void DeleteKind(Kind obj)
        {

            KindViewModel.raise(typeof(DeleteKindViewModel), obj);
        }

        private RelayCommand<Kind> deleteCommand;

        public RelayCommand<Kind> DeleteCommand
        {
            get { return deleteCommand; }
            set { SetProperty(ref deleteCommand, value); }
        }
        private RelayCommand<Kind> editCommand;

        public RelayCommand<Kind> EditCommand
        {
            get { return editCommand; }
            set { SetProperty(ref editCommand, value); }
        }


        public ObservableCollection<Kind> Kinds
        {
            get => new System.Collections.ObjectModel.ObservableCollection<Kind>(LoadData());

        }
        private IEnumerable<Kind> LoadData()
        {


            return KindRepository.Get(includeProperties:"Catagory") ;


        }
    }
}

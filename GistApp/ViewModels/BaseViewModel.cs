using GistApp.DBModels;
using GistApp.Models;
using GistApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GistApp.ViewModels
{
    public abstract class BaseViewModel<T> : BaseModel where T : class
    {        
        #region Fields       
        private Queue<T> ItensQueueAdd { get; set; }        
        private T _Item;
        public T Item
        {
            get
            {
                return _Item;
            }
            set
            {
                Set(ref _Item, value);
            }
        }
        public ObservableCollection<T> Items { get; private set; }
        #endregion
        #region Constructors
        public BaseViewModel()
        {
            Items = new ObservableCollection<T>();
            Item = (T)Activator.CreateInstance(typeof(T), Array.Empty<object>());            
            ItensQueueAdd = (Queue<T>)Activator.CreateInstance(typeof(Queue<T>), Array.Empty<object>());
        }
        #endregion
        #region Crud Operations
        public bool LoadItens(List<T> value)
        {            
            if (value!=null)
            {
                foreach(T item in value)
                {
                    ItensQueueAdd.Enqueue(item);
                }
                ClearQueue();
                return true;
            }
            else
            {
                return false;
            }          
        }
        public bool Add(T value)
        {
            if(value!=null)
            {
                ItensQueueAdd.Enqueue(value);
                ClearQueue();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Update(T value)
        {
            bool ischanged = false;
            if (value != null)
            {
                T item;
                item = Items.Where(x => ((IBaseDBModel)x).Id == ((IBaseDBModel)value).Id).FirstOrDefault();

                if (item != null)
                {
                    int position;
                    position = Items.IndexOf(item);
                    foreach (PropertyInfo property in typeof(T).GetProperties())
                    {                        
                        if (!property.Name.Equals("Id", StringComparison.CurrentCulture))
                        {
                            if (property.GetValue(value, null) != property.GetValue(Items[position], null))
                            {
                                property.SetValue(Items[position], property.GetValue(value, null));
                                Changed<T>(property.Name); 
                                ischanged = true;
                            }
                        }
                    }
                    return ischanged;
                }
                return ischanged;
            }
            else
            {
                return false;
            }
        }        
        public IEnumerable<T> Get(Func<T, bool> func)
        {
            return Items.Where(func);
        }
        public IEnumerable<T> GetAll()
        {
            return Items;            
        }
        public bool Remove(T value)
        {
            bool ischanged = false;
            if(value!=null)
            {
                T item;                
                item = Items.Where(x => ((IBaseDBModel)x).Id == ((IBaseDBModel)value).Id).FirstOrDefault();
                if(item!=null)
                {
                    Items.Remove(item);
                    ischanged = true;
                }
                else
                {
                    ischanged = false;
                }
            }
            return ischanged;
        }
        #endregion
        #region Commands
        public Command<T> DeleteCommand => new Command<T>((value)=>Update(value));
        public Command<T> SaveCommand => new Command<T>((value)=>Add(value));
        public Command<T> UpdateCommand => new Command<T>((value)=>Update(value));
        public Command GetAllCommand => new Command(()=> GetAll());
        #endregion
        #region Ações Diversas        
        private void ClearQueue()
        {
            while (ItensQueueAdd.Count > 0)
            {
                Items.Add(ItensQueueAdd.Dequeue());
            }
        }
        #endregion
    }
}

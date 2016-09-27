using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace Orion.Client.Core
{
    public abstract class SimpleViewModel : INotifyPropertyChanged
    {
        protected void NotifyChanged<T>(Expression<Func<T>> expression)
        {
            var property = (MemberExpression)expression.Body;
            this.OnPropertyChanged(property.Member.Name);
        }
        protected void NotifyChanged(string propertyName)
        {
            this.OnPropertyChanged(propertyName);
        }
        //protected void NotityCodigoChanged(string codigo)
        //{
        //    this.OnCodigoChanged(codigo);
        //}

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        //protected void OnCodigoChanged(string codigo)
        //{
        //    EventHandler handler = CodigoChanged;
        //    if (handler != null)
        //    {
        //        handler(this, new CodigoChangedEventArgs() { Codigo = codigo });
        //    }
        //}

        public event PropertyChangedEventHandler PropertyChanged;
        //public event EventHandler CodigoChanged;

    }
}

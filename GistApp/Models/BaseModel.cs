using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Json;
using System.Text;

namespace GistApp.Models
{
    public class BaseModel : INotifyPropertyChanged
    {
        #region PropertyChangedEventHandler

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region - PropertyChanged

        protected void Changed<T>(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        protected void Changed<T>(Expression<Func<T>> property)
        {
            if (property != null)
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(GetMemberInfo(property).Name));
        }

        protected void Set<T>(ref T valorPrivado, T valorNovo, [CallerMemberName] string propertyName = null)
        {
            try
            {
                if (EqualityComparer<T>.Default.Equals(valorPrivado, valorNovo))
                    return;

                valorPrivado = valorNovo;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            catch
            {

            }
        }

        private static MemberInfo GetMemberInfo(Expression expression)
        {
            MemberExpression operand;
            LambdaExpression lambdaExpression = (LambdaExpression)expression;
            if (lambdaExpression.Body as UnaryExpression != null)
            {
                UnaryExpression body = (UnaryExpression)lambdaExpression.Body;
                operand = (MemberExpression)body.Operand;
            }
            else
            {
                operand = (MemberExpression)lambdaExpression.Body;
            }
            return operand.Member;
        }
        #endregion
        
    }
}

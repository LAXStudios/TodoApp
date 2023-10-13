using Microsoft.Maui.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Handler
{
    public class BorderlessEntry : Entry 
    {
        public static readonly BindableProperty HasUnderlineProperty = BindableProperty.Create(
        propertyName: nameof(HasUnderline),
        returnType: typeof(bool),
        declaringType: typeof(BorderlessEntry),
        defaultValue: false,
        defaultBindingMode: BindingMode.TwoWay
        );

        public bool HasUnderline
        {
            get => (bool)GetValue(HasUnderlineProperty);
            set { SetValue(HasUnderlineProperty, value); }
        }
    }
}

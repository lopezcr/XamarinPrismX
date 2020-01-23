using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamarinPrismX.ViewModels;

namespace XamarinPrismX.Control
{
    class ColorSelectTemplate : DataTemplateSelector
    {
        public DataTemplate Template1 { get; set; } //En mi ejemplo de encuenta, este era preguntaAbierta
        public DataTemplate Template2 { get; set; }//En mi ejemplo de encuenta, este era preguntaCerrada
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return ((PantoneColorViewModel)item).itemParSelectorTemplate == true ? Template1 : Template2;
        }
    }
}

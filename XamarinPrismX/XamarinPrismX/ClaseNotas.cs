using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinPrismX
{
    class ClaseNotas
    {
        public ClaseNotas()
        {
                
        }
    }
}


/*

Esta clase la usare para agregar notas cuando vaya avanzando en los ejercicios
y espero ir agregando notas durante cada commit

//------------------------------------------------------------------------
https://www.youtube.com/watch?v=81Q2fxFWIqA
Prism for Xamarin.Forms - Create your first application


-----
*** Para agregar *** Xamarin prism en visual studio
Menu-Extension-Manage Extensions
Prism Template Pack
-----

Creamos el proyecto
Prism Blank App


//------------------------------------------------------------------------
//------------------------------------------------------------------------
//------------------------------------------------------------------------
002.-Nueva vista y cambiar de main


https://www.youtube.com/watch?v=81Q2fxFWIqA
Prism for Xamarin.Forms - Create your first application

nuevo item 9:08
-----
En views - nuevo item - "Prism ContentPage(xamarin.forms)"
Crear archivo en: Views, viewmodel y actualiza el app.xaml
Para el ejemplo se creo el "ContetPage" con el nombre ViewB
La clase se cambio su herencia a ViewModelBase, la variable title es del ViewModelBase

-----
*** Actualizando el viewBviewModel.cs


public class ViewBViewModel : ViewModelBase
    {
        public ViewAViewModel(INavigationService navigationService):base(navigationService)
        {
            Title = "Mi vista A :)";
        }
    }

-----

*** En la vista Viewb.xaml ***

Se actualiza los valores del content page, agregando una variable para el titulo
(Ejemplo cortado)

<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
...	
Title="{Binding Title}"
>


//Dentro de la etiqueta content, creo que StackLayout seria como el body en html
Se agregar esta linea

<ContentPage.Content>
    <ScrollView>
        <StackLayout>
            <Label Text="Aqui va un texto"/>           
        </StackLayout>
    </ScrollView>
</ContentPage.Content>

-----
**** En el archivo app.xaml- app.xaml.cs
se Actualiza para que la pagina principalsea el viewB

protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/ViewB");
        }
//noTA: Anteriormente se tuvo que haber agregado automaticamente el registro
// en este mismo archivo  containerRegistry.RegisterForNavigation<ViewB, ViewBViewModel>();



//------------------------------------------------------------------------
//------------------------------------------------------------------------
//------------------------------------------------------------------------
 
     
*/




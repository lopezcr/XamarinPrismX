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
003.-NAVEGACION

//EN EL VIEWMODEL

using ComedorIndustrial.Prism.Helper;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services.Dialogs;

 
//Este variable es para todos los botones
private readonly INavigationService _navigationService;

//y este es uno por uno por cada boton
private DelegateCommand _navigateCommand;

//EN ESPECIFICO CUANDO LE DE CLICK EN EL BOTON EJECUTO, igual por cada boton
public DelegateCommand NavigateCommand => _navigateCommand ?? (_navigateCommand = new DelegateCommand(ExecuteNavigateCommand));


public Vista1xViewModel(INavigationService navigationService ):base(navigationService)
{
   ...
	_navigationService = navigationService; //hay que agregar este
}


//EL METODO QUE SE EJECUTA LLAMA CON EL CLICK
async void ExecuteNavigateCommand()
{
            await _navigationService.NavigateAsync("MainPage");
			
			//Puede seri asi tambien
            //Nota importante este es un ejemplo simple, en el comentario de abajo hay otro ejemploe
			// await _navigationService.NavigateAsync("MainPage"); //creo que es para cuando en app.xaml esta asi var result = await NavigationService.NavigateAsync("NavigationPage/Vista1x");
}
-----

EN LA VISTA AGREGAMOS EL BOTON

<Button Text="Navigate to main" Command="{Binding NavigateCommand}"/>



//------------------------------------------------------------------------
//------------------------------------------------------------------------
//------------------------------------------------------------------------
*/


#region Otro boton a la vista navegacion
/*
     Es casi lo mismo que el otro pero solo para dejar claro el tema
     //en este ejemplo con tal no he creado otro content (vista y su modelo), por lo que los dos botones llaman a main
     //pero se entiende que solo se modificaria _navigationService hacia otra vista.

        public class Vista1xViewModel : ViewModelBase
    {
 

        private DelegateCommand _navigateCommand;      
        private DelegateCommand _navigateCommand2;

        private readonly INavigationService _navigationService;


        public DelegateCommand NavigateCommand => _navigateCommand ?? (_navigateCommand = new DelegateCommand(ExecuteNavigateCommand));
        public DelegateCommand NavigateCommand2 => _navigateCommand2 ?? (_navigateCommand2 = new DelegateCommand(ExecuteNavigateCommand2));



        public Vista1xViewModel(INavigationService navigationService ):base(navigationService)
        {
            Title = "Mi vista 1";
            Titulo = "Titulo en español";
            _navigationService = navigationService;
        }

        async void ExecuteNavigateCommand()
        {
           //En
            await _navigationService.NavigateAsync("Vista2x"); 
        }
        async void ExecuteNavigateCommand2()
        {
            await _navigationService.NavigateAsync("MainPage");
        }
    }

    /////en la vista el otro boton
    <Button Text="Vista 2" Command="{Binding NavigateCommand2}"/>

*/
#endregion

#region Boton Regresar
/*     
 
    //para este ejemplo puse el boton regresar en main
    await _navigationService.GoBackAsync();

 */
#endregion


#region Plantilla-region-MiTitulo-comentario
/*     
 */
#endregion


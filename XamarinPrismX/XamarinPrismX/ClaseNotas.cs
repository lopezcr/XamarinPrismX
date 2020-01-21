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

#region Navegacion relativa y absoluta
/*     
      
 //no hice ejemplo de este por que con lo demas se entiendo facil este pedo     
  EN EL APP.XAML

PUEDE ESTAR ASI
var result = await NavigationService.NavigateAsync("NavigationPage/Vista1x");

O  ASI

var result = await NavigationService.NavigateAsync("Vista1x");


--------------------------------------------------------------------------------

EN EL MODEL PARA REDIRECCIONAR


PUEDE ESTAR ASI

await _navigationService.NavigateAsync("/MainPage");

O  ASI

await _navigationService.NavigateAsync("MainPage");

o asi

//con este mantenemos la vista contenedora y hacemos reset en el boton atras que aparece en el titulo
await _navigationService.NavigateAsync("/NavigationPage/MainPage"); 

Este desmadre es para indicar si una vista esta dentro de otra :)   
 */
#endregion

#region Navegacion prism
/*     
  //Supongo que con este no se puede validar, va directo a la vista sin pasar por  un metodo.
 <Button Text="View B" Command="{prism:NavigateTo Vista1x}" />
 
 
 
 //Creo que este va al tab y sale de su pagina contenedora. En el de arriba sigue en su pagina contenedora.
 <Button Text="Select Tab C" Command="{prism:SelectTab ViewC}" />
 
 
 //Se entiende.
 <Button Text="Go Back" Command="{prism:GoBack}" />
 
 //**************************************************
 //El content page debe tener:
  xmlns:prism="http://prismlibrary.com"   

 */
#endregion


#region Parametros Preparacion 
/*     
 En este commit voy a prepara el siguiente ejemplo de parametros, osea lo voy a hacer en dos commits
 al crear un content crea varios archivos y es mas dificil revisar despues, asi que aqui creo el content y hago un ejemplo de navegacion

    para entender este si no me acuerdo, ver el commit , "nueva vista y buton" y "navegacion boton 1"

    Voy a crear una vista principal y vistaC , vista principal la dejare como vista inicial
    Crear un boton de principal a vistaC



 */
#endregion

#region Parametros
/*     
 //en el metodo de la funcion donde redireccionamos , ver archivo 003.-NAVEGACION.txt

async void ExecuteNavigateCommand2()
        {
            var p = new NavigationParameters();
            p.Add("title", "Este es un titulo por parametro");
            await _navigationService.NavigateAsync("Vista2x",p);
        }



----------------------------------------------------------------------------
//importante agregar la interface INavigationAware a la clase del viewmodel que recibe
//En el modelo de la vista agregue el siguiente metodo override

public override void OnNavigatedTo(INavigationParameters parameters)
        {
            Title = parameters.GetValue<string>("title");
        }

//----------------------------------------------------------

en la vista 
<Label Text="{Binding Title}"/>



//----------------------------------------------------------
Algo de explicacion en el video, el vato agrego a la clase (en el modelo que recibe)la interface INavigationAware
al agregar esta interface se agregan diferentes metodos que implementa la interface,
osea el OnNavigatedTo y otros mas. Yo no implemente esta interface por que anteriormente
yo habia cambiado de cual clase hereda mi clase de la vista de modelo Vista2xViewModel, 
originalmente tenia BindableBase y yo la cambie a ViewModelBase
ViewModelBase ya implementa INavigationAware, por eso yo solamente hice override al metodo OnNavigatedTo
    
 */
#endregion

#region Verificacion de parametros
/*     
 //PARA VERIFICAR SI EXISTEN UN PARAMETRO
if(parameters.ContainsKey("title"))
            {

            }
			

//otra verificacion			

var result = parameters["title"] as string;
            if(result==null)
            {

            }
			
			
//a este le falta algo
parameters.TryGetValue<string>("title");			

 */
#endregion

#region Imagen de fondo xamarin prepraracion
/*     
 //En este commit voy a crear otro content y guardare una imagen en xamarinPrismX.android/Resources/drawable  //si no existe la carpeta la creamos.
 //El nuevo Content lo llamare login :) y lo pondre como pagina principal
 //la imagen que guarde se llama Lemillion.jpg     :)

 */
#endregion

#region Imagen de fondo xamarin Preparacion importante! correccion 
/*     
  Me equivoque al agregar la imagen, la imagen la guarde en el proyecto de ios
 */
#endregion

#region Imagen de fondo en pantalla
/*     
  Este no tiene tanto rollo la magia lo hace el AbsoluteLayout
  Lo que sigue dentro del  content page
  La imagen no tiene mas direccion que su propio nombre

        <AbsoluteLayout VerticalOptions="FillAndExpand" HorizontalOptions="FillAndExpand">
        <Image  AbsoluteLayout.LayoutBounds="1,1,1,1" AbsoluteLayout.LayoutFlags="All" Aspect="AspectFill" Source="miImage.png" AnchorX="800" AnchorY="1000"></Image>
        <ScrollView AbsoluteLayout.LayoutFlags="All" AbsoluteLayout.LayoutBounds="0, 0, 1, 1">
            <StackLayout Orientation="Vertical">
             ...
            </StackLayout>
        </ScrollView>

    </AbsoluteLayout>


 */
#endregion


#region Formulario login simple
/*     
   Agregare un pequeño formulario con usuario y contraseña con un frame nomas para que no se vea tan feo :P   

         <ScrollView AbsoluteLayout.LayoutFlags="All" AbsoluteLayout.LayoutBounds="0, 0, 1, 1">
            <StackLayout Orientation="Vertical"  VerticalOptions="Center">
                <Frame Padding="10" >
                    <StackLayout>
                        <Label Text="Usuario"></Label>
                        <Editor Text="I am an Editor" />

                        <Label Text="Contraseña"></Label>
                        <Editor Text="" Placeholder="Introduce una contraseña" />
                    </StackLayout>                    
                </Frame>
            </StackLayout>
        </ScrollView>

 */
#endregion

#region Login mejorado (sin binding y validacion)
/*
 Formulario synfusion, ademas de usar el inputLayout:SfTextInputLayout , hare el binding y utilizare unos estilos
 el formulario sigue siendo en el mismo login y los estilos estan en el app.xaml
 instale el synfusion license y Syncfusion Xamarin core para poder utillizar el inputLayout:SfTextInputLayout

 En este commint solo mejore el estilo de login con algunas herramientas extras.
 Creo que principalmente de usar las herramientas de inputLayout:SfTextInputLayout que es como un input text
 es que sobre todo tiene ciertas caracteriticas por ejemplo el manejo de errores entre otros
 Para este ejemplo y para no complicarlos a la hora de volver a este codigo, solo utilizare el inputLayout:SfTextInputLayout en el usuario.

Ver documentacion en synfusion SfTextInputLayout
 
     ***************************
     Para este ejemplo instale fonts, en android/assets...IntroRegular.otf , IntroBlack.otf entre otros
     *************************



    /------------------------------------------------------------------------------------------------------------------/
    en el login
    Este es para input de synfusion, explicare las cosas necesarias. Mas abajo esta el codigo de los estilos, primero hay que agregar los estilo o no funciona el xaml
    /------------------------------------------/
    /------------------------------------------/
    /------------------------------------------/

    <inputLayout:SfTextInputLayout
        FocusedColor="#ee3837"|
            ContainerType="Outlined"
            OutlineCornerRadius="5"
            ContainerBackgroundColor="White"
        LeadingViewPosition="Inside"
        HasError="{Binding HasErrorEmail}"
        ErrorText="{Binding ErrorTextEmail}"
        Hint="Correo Electrónico"
            Margin="0"
            Padding="0"                               
        >
        <inputLayout:SfTextInputLayout.LeadingView>
            <Label Text="&#xf007;" Style="{StaticResource IconStyleSolid}" />
        </inputLayout:SfTextInputLayout.LeadingView>
        <inputLayout:SfTextInputLayout.HintLabelStyle>
            <inputLayout:LabelStyle>
                <inputLayout:LabelStyle.FontFamily>
                    <OnPlatform x:TypeArguments="x:String" iOS="IntroRegular" Android="IntroRegular.otf#IntroRegular" />
                </inputLayout:LabelStyle.FontFamily>
            </inputLayout:LabelStyle>
        </inputLayout:SfTextInputLayout.HintLabelStyle>
        <Entry Keyboard="Email" x:Name="TxtEmail" Text="{Binding Email}" BackgroundColor="#f6f6f6" Style="{StaticResource EntryNormal}" />
    </inputLayout:SfTextInputLayout>

    --------------------------------------------------------------
    Explicacion del codigo anterior.

            ContainerType...contorno alrededor del input
        OutlineCornerRadius .... Es el borde
        LeadingViewPosition...El icono adentro o afuera del input
        HasError...para la validacion del error
        ErrorText...para el error.
        Hint... es como el placeholder

        //Esto es para el icono
        <inputLayout:SfTextInputLayout.LeadingView>
	        <Label Text="&#xf007;" Style="{StaticResource IconStyleSolid}" />
        </inputLayout:SfTextInputLayout.LeadingView>

        //este desmadrito solo es para el estilo del placeholder
        <inputLayout:SfTextInputLayout.HintLabelStyle>
	        <inputLayout:LabelStyle>
		        <inputLayout:LabelStyle.FontFamily>
			        <OnPlatform x:TypeArguments="x:String" iOS="IntroRegular" Android="IntroRegular.otf#IntroRegular" />
		        </inputLayout:LabelStyle.FontFamily>
	        </inputLayout:LabelStyle>
        </inputLayout:SfTextInputLayout.HintLabelStyle>

        //Aqui es realmente donde el usuario escribe
        <Entry Keyboard="Email" x:Name="TxtEmail" Text="{Binding Email}" BackgroundColor="#f6f6f6" Style="{StaticResource EntryNormal}" />






    /-------------------------------------------------------------------------------------------------------------------------/
    el App.xaml para los estilos
    Estos estilos y fuentes son usados en el formulario login, creo que agregue demas en los assets, pero en este xaml es lo requerido
    Aqui tambien esta para el icono de usuario :)
    /------------------------------------------/
    /------------------------------------------/
    /------------------------------------------/
    <?xml version="1.0" encoding="utf-8" ?>
<prism:PrismApplication xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:prism="clr-namespace:Prism.DryIoc;assembly=Prism.DryIoc.Forms"
             x:Class="XamarinPrismX.App">
    <prism:PrismApplication.Resources>
        <ResourceDictionary>

            <OnPlatform x:TypeArguments="x:String" x:Key="FontRegular">
                <On Platform="iOS" Value="Intro-Regular" />
                <On Platform="Android" Value="IntroRegular.otf#IntroRegular" />
            </OnPlatform>
            
            <OnPlatform x:TypeArguments="x:String" x:Key="IconFontFamily" iOS="FontAwesome5FreeSolid" Android="Font Awesome 5 Free-Solid-900.otf#Font Awesome 5 Free-Solid-900" />
            <OnPlatform x:TypeArguments="x:String" x:Key="IconFontFamilyRegular" iOS="FontAwesome5FreeRegular" Android="Font Awesome 5 Free-Solid-900.otf#Font Awesome 5 Free-Solid-900" />
            

            <Style x:Key="EntryNormal" TargetType="Entry">
                <Setter Property="FontFamily" Value="{DynamicResource FontRegular}"></Setter>
            </Style>
            <Style x:Key="IconStyleSolid" TargetType="Label">
                <Setter Property="FontFamily" Value="{DynamicResource IconFontFamily}"></Setter>
                <Setter Property="FontSize" Value="18"></Setter>
                <Setter Property="VerticalOptions" Value="CenterAndExpand"></Setter>
            </Style>
        </ResourceDictionary>
    </prism:PrismApplication.Resources>
</prism:PrismApplication>
 
 */
#endregion

#region Validacion formulario, login validacion (is null) y binding
/*     
   Para empezar se convirtio el viewmodel del login dle tipo viewmodel, ver punto 003 que es navegacion 
   Se creo un boton para navegar y para este boton se creo un estilo nuevo.

    Tambien se crearon campos privados y propiedades publicas, esto es necesario para hacer el binding
    El xaml ya tenia el binding con las propiedades, pero no existian, asi que aqui solo se creo las propiedades
    y se valido a la hora de navegar

    No hize la validacion si existe el usuario, esto se vera en WebServices.
    
    -----------------------------------------------------------------------------------------------------------
    public class LoginViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private string _errorTextEmail;
        private bool _hasErrorEmail;
        private string _email;
        private DelegateCommand _MainCommand;

        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        public string ErrorTextEmail
        {
            get => _errorTextEmail;
            set => SetProperty(ref _errorTextEmail, value);
        }

        public bool HasErrorEmail
        {
            get => _hasErrorEmail;
            set => SetProperty(ref _hasErrorEmail, value);
        }



        public DelegateCommand LoginCommand => _MainCommand ?? (_MainCommand = new DelegateCommand(ExecuteLoginCommand));
        public LoginViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
        }

        async void ExecuteLoginCommand()
        {
            if (string.IsNullOrEmpty(Email))
            {
                ErrorTextEmail = "Es requerido";
                HasErrorEmail = true;
                return;
            }
            else
            {
                HasErrorEmail = false;
            }

            var result = await NavigationService.NavigateAsync("/NavigationPage/MainPage");
        }

    }
}




 */
#endregion

#region WebServices Busqueda de usaurio.
/*     
  Para este ejemplo voy a usar el ejemplo de https://reqres.in/
  Para este ejemplo si esta medio canijo poner todo aqui, asi que agregue el archivo que habia creado esta en Archivo/Webservice
  
  El ejemplo me parece bueno bueno, quizas solo hay que adaptarlo a las necesidades. y como sea tambien hago el ejemplo del login en este proyecto.
  Existe diferencias entre una solicitud Get Post, especialmente de la informacion  que se envia.

  En esa misma carpeta hay otros ejemplo, especialmente interesante de como se envia un token de verificacion de la informacion.

   No pondre todo pero pondre todos los archivos que cree y modifique

    Cree:
    Model/Response
    Model/LoginRequest
    Model/LoginResponse
    Services/IApiService
    Services/ApiService


    Modifique:
    LoginViewModel
    App.Xaml
    App.Xaml.cs
    login.xaml (solo el entry del password)



 */
#endregion


#region ActivityIndicator
/*     
     No es nada del otro mundo, solo es como un gif cuando se hace un ajax.
     Es para indicar al usuario que esta buscando informacion.
      
    //en el xaml donde mejor se acomode
    <ActivityIndicator VerticalOptions="CenterAndExpand"  IsRunning="{Binding IsRunning}"></ActivityIndicator>

    //en el boton se le hace el binding en isEnable
    <Button Text="INICIAR SESIÓN" HorizontalOptions="FillAndExpand" Opacity="1" FontSize="12" Margin="0" IsEnabled="{Binding IsEnable}" Command="{Binding LoginCommand}" Style="{StaticResource ButtonDefault}"  />


    En la vista de modelo solo se actualizo los valores de IsEnable y IsRunning antes y despues de la consulta del  WS

            IsRunning = true;
            IsEnable = false;            
            //
            ...
            Aqui iria mi consulta al Ws
            ...
            //

            IsRunning = false;
            IsEnable = true;


 */
#endregion



#region Plantilla-region-MiTitulo-comentario
/*     
 */
#endregion


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

#region Guardar sesion del usuario logueado y cerrar sesion
/*     
 Para este hay que instalar el Xam.Plugins.Settings

    Creo la carpeta  Helpers y el archivo Settings.cs , para este archivo no agregare notas, solo revisar.

    //-----------------------------------------------------------------------------------------------------------
    //Anteriormente ya se habia realizado la verificcion del usuario con WS, ahora guardaremos la informacion en loginViewModel, justo despues de verificar que el resultado IsSucess is true

    LoginResponse user = response.Result;
    Settings.User = JsonConvert.SerializeObject(user.Token);//en realidad en el ejemplo original era user.Cliente con varias propieades, como nombre, edad, etc, etc. Info del cliente, mi ejemplo es sencillo
    Settings.IsLogin = true;
    Application.Current.Properties["IsLoggedIn"] = Boolean.TrueString; //using Xamarin.Forms;

    var result = await NavigationService.NavigateAsync("/NavigationPage/MainPage");
    
    

    //-----------------------------------------------------------------------------------------------------------
    //en el app.xaml.cs se actualiza la primera navegacion validadndo si el usuario esta logueado
    protected override async void OnInitialized()
        {
            InitializeComponent();

            if (Settings.IsLogin == true)
            {
                var result = await NavigationService.NavigateAsync("/NavigationPage/MainPage");
            }
            else
            {
                await NavigationService.NavigateAsync("/Login");
            }

            //await NavigationService.NavigateAsync("NavigationPage/Login");
        }

    //-------------------------------------------------------------------------------------------------------------
    Para cerrar sesion se agregar un link o boton donde se requiera

    <Label Text="Cerrar sesion" HorizontalOptions="Center"  TextDecorations="Underline" TextColor="Black" >
            <Label.GestureRecognizers>
                <TapGestureRecognizer Command="{Binding CerrarSesionCommand}" />
            </Label.GestureRecognizers>
        </Label>

    en el viewModel se crea las propiedades y commando (ver navegacion) necesario para navegar, en el EXECUTE se agrega el siguiente codigo.

        async void ExecuteCerrarSesion()
        {
            Settings.IsLogin = false;
            Settings.User = string.Empty;
            await _navigationService.NavigateAsync("/Login");
        }

    
      
 */
#endregion


#region Mostrar lista de recuperada con WebService (Preparacion)
/*     
      Voy a crear dos vista, una donde muestre el listado que se obtenga del viewmodel y otra donde se navegue si se le da click a un item del listado.
      En esta prepracion hare cosas que estan mejor explicados en puntos anteriores asi que no hay mucho que revisar aqui, solo es para que no haya tantos
      archivos en el commit que me interesa.
      Tambien hare el WS del listado a obtener.
      Tambien realizare el Ws del listado de la pagina https://reqres.in/

      En el siguiente commit usare el shimmer, pero ya viene dentro del synfusion core, asi que no hace falta instalar
      
 */
#endregion

#region Mostrar lista de recuperada con WebService (Shimmer)
/*     
      para el shimmer se utilizan dos propiedades IsRunning y IsVisible, isRunning es para cuando el shimmer esta activo e isVisble para cuando ya termino de cargar el WS y ver la informacion.
      Osea es lo mismo que cuando el ajax y un gif de load, solo que el shimmer es mas nice, osea hace como un load pero con la forma que se supone que se mostrara la informacion cuando cargue
      (de IsVisible creo que no se  usa en el shimmer, pero lo dejo por si acaso)

        private bool _isRunning;

        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }
               
       
    Estas propiedades se cambian valor antes y despues del WS, o en su caso en el catch al buscar la informacion con el WS


    --------------------------------------------------------------------
    Realmente el shimmer es bien sencillo , tan simple como esto, un shimmer con su contentView (que es como un previo) y el content donde va lo que queremos mostrar.

            <shimmer:SfShimmer x:Name="shimmerRecientes"  VerticalOptions="FillAndExpand" HorizontalOptions="FillAndExpand"  
                                   IsActive="{Binding IsRunning}" Type="Video">
                    <shimmer:SfShimmer.CustomView>
                        <Label Text="Cargando..."></Label>                        
                    </shimmer:SfShimmer.CustomView>
                        <shimmer:SfShimmer.Content>
                           <StackLayout>
                                    <Label Text="(Aqui meto lo q quiera) Content is loaded! " HorizontalOptions="CenterAndExpand" VerticalOptions="CenterAndExpand"/>
                                </StackLayout>
                        </shimmer:SfShimmer.Content>
                </shimmer:SfShimmer>

    --------------------------------------------------------------------
    El chiste entonces del shimmer es simular una previa parecido a lo que se va a mostrar entonces la etiqueta importante es el border:SfBorder que el que hace el efecto de cargando
    Abajo un ejemplo mas completo, en realidad sobre shimmer y border:SfBorder es poco, lo que le da la forma es el grid 
    el shimmer tambien ya tiene previos por default, pero no lo puse por que es mejor el personalizado, para los de default ver documentacion shimmer en la pagina de synfusion

    Hay que agregar esto en el contentPage del xaml:
    xmlns:shimmer="clr-namespace:Syncfusion.XForms.Shimmer;assembly=Syncfusion.Core.XForms"
    xmlns:border="clr-namespace:Syncfusion.XForms.Border;assembly=Syncfusion.Core.XForms"
       

        <StackLayout BackgroundColor="White">
        <Grid ColumnSpacing="0" RowSpacing="0" HorizontalOptions="FillAndExpand" VerticalOptions="FillAndExpand" >
            <Grid.RowDefinitions>
                <RowDefinition Height="*" />
            </Grid.RowDefinitions>
            <StackLayout Margin="15,15,0,15" Padding="0" Grid.Row="0">
                <shimmer:SfShimmer x:Name="shimmerRecientes"  VerticalOptions="FillAndExpand" HorizontalOptions="FillAndExpand"  
                                   IsActive="{Binding IsRunning}" Type="Video">
                    <shimmer:SfShimmer.CustomView>
                        <Grid>
                            <Grid.RowDefinitions>
                                <RowDefinition Height="110"/>
                            </Grid.RowDefinitions>
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition Width="110"></ColumnDefinition>
                                <ColumnDefinition Width="*"></ColumnDefinition>
                            </Grid.ColumnDefinitions>

                            <border:SfBorder Grid.Row="0" Grid.Column="0"
                         BackgroundColor="{Binding Color,Source={x:Reference shimmerRecientes}}"
                         BorderColor="Transparent"
                         HeightRequest="110" WidthRequest="110"
                         VerticalOptions="Center" />

                            <StackLayout Grid.Row="0" Grid.Column="1" Padding="0,0,15,0">
                                <border:SfBorder 
                                     BackgroundColor="{Binding Color,Source={x:Reference shimmerRecientes}}"
                                     BorderColor="Transparent"
                                     HeightRequest="30" />
                                <border:SfBorder 
                                     BackgroundColor="{Binding Color,Source={x:Reference shimmerRecientes}}"
                                     BorderColor="Transparent"
                                     HeightRequest="30" />
                            </StackLayout>
                        </Grid>
                    </shimmer:SfShimmer.CustomView>
                        <shimmer:SfShimmer.Content>
                           <StackLayout>
                                    <Label Text="(Aqui meto lo q quiera) Content is loaded! " HorizontalOptions="CenterAndExpand" VerticalOptions="CenterAndExpand"/>
                                </StackLayout>
                        </shimmer:SfShimmer.Content>
                </shimmer:SfShimmer>
            </StackLayout>
        </Grid>
    </StackLayout>

      
 */
#endregion

#region Mostrar lista de recuperada con WebService (CollectionView)
/*     
 
    Vamos a trabajar sobre el content del shimmer con un contentView
    Como mi Ws no trae ninguna imagen yo agregue harcodeado la misma imagen para cada item de mi WS

    ----------------------------------------------------------------------------------------------------
    ConllectionView tampoco es tanto rollo, solo es esto, para mostrar la informacion. super simple solo mostrando un label
    El chiste es cuando se quiere agregar un formato del listado
    En este ejemplo InfoPantoneWS.data, data es el list , osea que puedo haber sido de otra forma ejemplo : ItemsSource="{Binding Milista}"

     <CollectionView ItemsSource="{Binding InfoPantoneWS.data}">
            <CollectionView.ItemsLayout>
                <LinearItemsLayout Orientation="Vertical" 
            ItemSpacing="10" />
            </CollectionView.ItemsLayout>

            <CollectionView.ItemTemplate>
                <DataTemplate>
                    <StackLayout>
                        <Label Text="{Binding name}"></Label>

                    </StackLayout>
                </DataTemplate>
            </CollectionView.ItemTemplate>
        </CollectionView>

    ----------------------------------------------------------------------------------------------------
    Este es un ejemplo con mas informacion pero sin tanto formato, no le quise meter tanto formato para hacer mas facil la lectura del ejemplo.
    Obviamente se le puede meter mas formato, pero hay la deje

        <CollectionView ItemsSource="{Binding InfoPantoneWS.data}">
        <CollectionView.ItemsLayout>
            <LinearItemsLayout Orientation="Vertical" 
        ItemSpacing="10" />
        </CollectionView.ItemsLayout>

        <CollectionView.ItemTemplate>
            <DataTemplate>
                <StackLayout>                                        
                    <Grid>
                        <Grid.RowDefinitions>
                            <RowDefinition Height="90" />
                            <RowDefinition Height="*"/>
                        </Grid.RowDefinitions>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width="200"></ColumnDefinition>
                            <ColumnDefinition Width="*"></ColumnDefinition>
                        </Grid.ColumnDefinitions>

                        <Image Source="{Binding Image}" Grid.Row="0" Grid.Column="0" Grid.RowSpan="2" ></Image>                                           
                        <Label Text="{Binding name}" Grid.Row="0" Grid.Column="1" ></Label>
                        <Label Text="{Binding color}" Grid.Row="1" Grid.Column="1"></Label>
                    </Grid>
                </StackLayout>
            </DataTemplate>
        </CollectionView.ItemTemplate>
    </CollectionView>

 */
#endregion

#region Mostrar lista de recuperada con WebService (Ver detalle navegacion)
/*     
      Primer cambio, en lugar de usar para el InfoPantoneWS.data en el  ItemsSource del collectionview, usare una variable del tipo list<miVariable> (del tipo PantoneColor (hare un viewModel)) , osea lo mismo, pero no necesiate una clase base
      osea lo dejare asi:
      <CollectionView ItemsSource="{Binding MiVariable}">


      -------------------
       Creo la nueva clase viewmodel  del tipo PantoneColor
       public class PantoneColorViewModel : PantoneColor
        {
          //primero lo voy a crear y luego lo actualizare para hacer la navegacion, ahorita solo hare el cambio para usar mas facil el collectionview
        }
      -------------------
      En viewmodel de la vista creo su campo privado y su propiedad
      
      private List<PantoneColorViewModel> _listaColores;

      public List<PantoneColorViewModel> ListaColores
        {
            get => _listaColores;
            set => SetProperty(ref _listaColores, value);
        }

     -------------------
     cuando obtengo el  WS asigno los valores a mi nueva variable

        ListaColores = new List<PantoneColorViewModel>(
                        response.Result.data.Select(x=> new PantoneColorViewModel() {
                            color = x.color,
                            id = x.id,
                            Image = x.Image,
                            name = x.name
                        })
                        ).ToList();

      -------------------
      Ahora si puedo actualizar mi collectionView en mi vista

      <CollectionView ItemsSource="{Binding ListaColores}">






     ------------------------------------------------
     ------------------------------------------------
     ------------------------------------------------
     ************************************************
     ACTUALIZO PARA NAVEGAR
      ************************************************


     Para poder navegar ahora tengo que actualizar mi PantoneColorViewModel

        public class PantoneColorViewModel : PantoneColor
        {
            private readonly INavigationService _navigationService;
            private DelegateCommand _selectColorCommand;

            public DelegateCommand SelectColorCommand => _selectColorCommand ?? (_selectColorCommand = new DelegateCommand(ShowColor));
            public PantoneColorViewModel(INavigationService navigationService)
            {
                _navigationService = navigationService;
            }

            private async void ShowColor()
            {
                var parameters = new NavigationParameters();
                parameters.Add("color", this);

                //await _navigationService.NavigateAsync("PantoneColorDetalle");            
                await _navigationService.NavigateAsync("PantoneColorDetalle", parameters);            
            }
        }

        ------------------------------------------------
        Actualizo la vista del listado para pasar el _navigationService, solo le agrego esta linea en el constructor de PantoneColorViewModel


        ListaColores = new List<PantoneColorViewModel>(
                    response.Result.data.Select(x=> new PantoneColorViewModel(_navigationService) {
                        color = x.color,
                        id = x.id,
                        Image = x.Image,
                        name = x.name
                    })
                    ).ToList();
    
        ------------------------------------------------
        En la vista agrego el GestureRecognizers al grid donde muestro mi informacion

        <Grid.GestureRecognizers>
            <TapGestureRecognizer Command="{Binding SelectColorCommand}" NumberOfTapsRequired="1" />
        </Grid.GestureRecognizers>

        queda asi:

        <CollectionView.ItemTemplate>
                <DataTemplate>
                    <StackLayout>                                        
                        <Grid>
                            <Grid.GestureRecognizers>
                                <TapGestureRecognizer Command="{Binding SelectColorCommand}" NumberOfTapsRequired="1" />
                            </Grid.GestureRecognizers>
                            <Grid.RowDefinitions>
                                <RowDefinition Height="90" />
                                <RowDefinition Height="*"/>
                            </Grid.RowDefinitions>
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition Width="200"></ColumnDefinition>
                                <ColumnDefinition Width="*"></ColumnDefinition>
                            </Grid.ColumnDefinitions>

                            <Image Source="{Binding Image}" Grid.Row="0" Grid.Column="0" Grid.RowSpan="2" ></Image>
                            <Label Text="{Binding name}" Grid.Row="0" Grid.Column="1" ></Label>
                            <Label Text="{Binding color}" Grid.Row="1" Grid.Column="1"></Label>
                        </Grid>
                    </StackLayout>
                </DataTemplate>
            </CollectionView.ItemTemplate>
        </CollectionView>


        ------------------------------------------------
        en el viewmodel que recibe lo tengo que actualizar para recibir parametros, en este caso la variable donde guardo la informacion es en ColorPantone, y en la vista uso esa variable



        public class PantoneColorDetalleViewModel : ViewModelBase
        {
            private PantoneColor _colorPantone;

            public PantoneColor ColorPantone
            {
                get => _colorPantone;
                set => SetProperty(ref _colorPantone, value);
            }

            public PantoneColorDetalleViewModel(INavigationService navigationService):base(navigationService)
            {

            }

            public override void OnNavigatedTo(INavigationParameters parameters)
            {
                base.OnNavigatedTo(parameters);

                if (parameters.ContainsKey("color"))
                {
                    ColorPantone = parameters.GetValue<PantoneColor>("color");
                }
            }

        }








 */
#endregion



#region Carousel (Preparacion)
/*  
 Creo el contentPage/vista y la navegacion   
 y utilizo el mismo Ws del ejemplo anterior
   
   
 */
#endregion

#region Carousel (Vista)
/*   
 Para estos ejemplo en produccion deberia haber validacion y mensajes de errores y el shimmer
 Pero como es para ejemplifiar el carousel solo hare el carousel sin mas.
 En el punto anterior ya se creo el contentPage y se traje el Ws del ejemplo de "Mostrar lista de recuperada con WebService"
 No le metere diseño por que no es caso.

    En este ejemplo no hay tanto rollo, solo es ItemSource

       <ScrollView>
        <StackLayout>
            <CarouselView x:Name="Carousel" ItemsSource="{Binding ListaColores}" VerticalOptions="StartAndExpand">
                <CarouselView.ItemTemplate>
                    <DataTemplate>
                        <StackLayout>
                            <Label Text="{Binding name}"  FontSize="30"></Label>
                            <Image Source="{Binding Image}"></Image>
                        </StackLayout>
                    </DataTemplate>
                </CarouselView.ItemTemplate>
            </CarouselView>
        </StackLayout>
    </ScrollView>
 */
#endregion

#region Carousel con diferentes ItemTemplate (Preparacion)
/*     
  Hare otra vista para este ejemplo     
  El chiste de este ejemplo es que a veces una lista de de una clase puede tener 
  mas de un diseño. Ejemplo encuesta. En una misma lista habia una pregunta/encuesta y con cierto parametro uno 
  utilizaba un diseño u otro.
  Osea en una vista de carousel tenia un diseño y cambiaba al otro item y podia tener otro diseño

  -Creare otro vista  (ContentPage) y utilizare el mismo Ws realizado anteriormente

      
 */
#endregion

#region Carousel con diferentes ItemTemplate
/*     
 Como explique anteriormente lo que se busca es tener diferentes template para una misma lista, y escoger el template de acuerdo a algun valor del item actual de la lista.

-------------------------------------------
 para este ejemplo se modifico el PantoneColorViewModel (es del tipo que se itera en mi Carousel) agregando una propiedad mas:
 
    //simplemente me dice si el id del mi elemento (PantoneColorViewModel) es par o no, esta logica puede variar de acuerdo a la necesidad que se quiera escoger el template.

    public class PantoneColorViewModel : PantoneColor
    { 
        ... /logica anterior

        public bool itemParSelectorTemplate {
            get {
                return (id % 2)==0 ? true : false;
            } 
     }


-------------------------------------------
Agregamos una nueva clase que nos va a ayudar a escoger el template
En mi caso lo cree en la carpeta Control
Como se puede observar mas abajo utilizamos la propiedad que creamos anteriormente (itemParSelectorTemplate)
Esta propiedad la creamos para ayudarnos a seleccionar el template, pero la logica de esta propiedadad tambien la pudimos haber evitado  y hacer la operacion en esta misma clase
pero la deje aqui para dejar ver como se hace con una propiedad del viewmodel

!!importante, aqui se devuelve Template1 o Template2, por eso se utlizo un operador ternario, pero en caso de que haya mas opciones se puede usar un select-case o varios if


using Xamarin.Forms;
using XamarinPrismX.ViewModels;

namespace XamarinPrismX.Control
{
    class ColorSelectTemplate : DataTemplateSelector
    {
        public DataTemplate Template1 { get; set; } //En mi ejemplo de encuesta, este era preguntaAbierta
        public DataTemplate Template2 { get; set; }//En mi ejemplo de encuenta, este era preguntaCerrada
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return ((PantoneColorViewModel)item).itemParSelectorTemplate == true ? Template1 : Template2;
        }
    }
}




--------------------------------------------
En la vista los template tiene un nombre
   
    //--------------

    <?xml version="1.0" encoding="utf-8" ?>
    xmlns:controls="clr-namespace:XamarinPrismX.Control"
    >

    <ContentPage.Resources>
        <ResourceDictionary>
            <DataTemplate x:Key="TemplateOpcion1">
                <StackLayout>
                    <Label Text="Nombre:"></Label>
                    <Label Text="{Binding name}"></Label>
                </StackLayout>                
            </DataTemplate>
            <DataTemplate x:Key="TemplateOpcion2">
                <StackLayout>                    
                    <Label Text="{Binding name}"></Label>
                    <Image Source="{Binding Image}"></Image>
                </StackLayout>                
            </DataTemplate>

            <controls:ColorSelectTemplate x:Key="colorSelectTemplate"
                Template1="{StaticResource TemplateOpcion1}"
                Template2="{StaticResource TemplateOpcion2}" />
        </ResourceDictionary>
    </ContentPage.Resources>



    <ScrollView>
        <StackLayout>
            <CarouselView x:Name="CarouselEncuesta" ItemsSource="{Binding ListaColores}" EmptyView="No hay encuestas disponibles"  ItemTemplate="{StaticResource colorSelectTemplate}"  IsSwipeEnabled="True">
            </CarouselView>
        </StackLayout>
    </ScrollView>
</ContentPage>

    -----------------------------
     xmlns:controls="clr-namespace:XamarinPrismX.Control"  // Referencia a la clase que utilizo para escoger el template

    <DataTemplate x:Key="TemplateOpcion1"> //nombre del template y dentro va el diseño que queramos

    <controls:ColorSelectTemplate x:Key="colorSelectTemplate"
                Template1="{StaticResource TemplateOpcion1}"
                Template2="{StaticResource TemplateOpcion2}" />
    //key nombre que va el carousel/ItemTemplate
    Template1 //es la propiedad que se creo en ColorSelectTemplate ...public DataTemplate Template1
    {StaticResource TemplateOpcion1}  //es el template que se utilizara en caso de que template1 es igual a true segun ColorSelectTemplate

    //en el carousel solo agrego el key del control
    ItemTemplate="{StaticResource colorSelectTemplate}"
 
    
 */
#endregion


#region MasteDetail menu (simple)
/*     
    para crear el menu hamburguesa, simplemente hay que crear un MasterDetailPage y navegar hacia la otra pagina

    osea para este ejemplo cree MyMasterDetailPage1 y un contentPage de siempre

    Desde la pagina a navegar Cree un boton para navegar hacia el contentPAge atravez de mi masterDetail

    Ejemplo al navegar del metodo a navegar:

     async void MasterDetailExecute()
        {
            await NavigationService.NavigateAsync($"MyMasterDetailPage1/NavigationPage/ContentPageVMD");
        }

    Y eso es todo para tener el menu hamburugesa :)
      
 */
#endregion


#region Menu en MasterDetail (ListView)
/*     
    En el ejemplo anterior se creo la masterDetailPage para el menu hamburguesa pero el menu solo quedon la informacion que trae al crear la masterDetailPage
    Ahora crear un menu con un listView
    Para este ejemplo solo me sirve del menu el item de ViewB

    En la carpeta model Creo la clase Menu


    public class Menu
    {
        public string Icon { get; set; }
        public string Title { get; set; }
        public string PageName { get; set; }        
        public int Index { get; set; }
    }
    ----------------------------------------------------
    Creo un viewmodel

        public class MenuItemViewModel : Menu
    {

        private readonly INavigationService _navigationService;
        private DelegateCommand _selectMenuCommand;

        public MenuItemViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public DelegateCommand SelectMenuCommand => _selectMenuCommand ?? (_selectMenuCommand = new DelegateCommand(SelectMenu));

        private async void SelectMenu()
        {
            //Aqui hay que corregir algo para navegar mejor y regresar, pero hay va :)
            await _navigationService.NavigateAsync($"NavigationPage/{PageName}");
        }
    }

    ----------------------------------------------------
    //en el viewmodel del masterDetailPage actualizo

        public class MyMasterDetailPage1ViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        public ObservableCollection<MenuItemViewModel> Menus { get; set; }
        public MyMasterDetailPage1ViewModel(INavigationService navigationService):base(navigationService)
        {
            _navigationService = navigationService;
            LoadMenus();

        }


        private void LoadMenus()
        {
            var menus = new List<Menu>
            {
                new Menu
                {
                    Icon = "menu.png",
                    PageName = "MainPage",
                    Title = "Menú",
                    Index = 0
                },
                new Menu
                {
                    Icon = "encuesta.png",
                    PageName = "MainPage",
                    Title = "Encuesta",
                    Index = 1
                },
                new Menu
                {
                    Icon = "eventos.png",
                    PageName = "MainPage",
                    Title = "Eventos",
                    Index = 2
                },
                new Menu
                {
                    Icon = "noticias.png",
                    PageName = "NoticiasPage",
                    Title = "Noticias",
                    Index = 3
                },
                new Menu
                {
                    Icon = "noticias.png",
                    PageName = "ViewB",
                    Title = "View B",
                    Index = 3
                }
            };

            Menus = new ObservableCollection<MenuItemViewModel>(
                menus.Select(m => new MenuItemViewModel(_navigationService)
                {
                    Icon = m.Icon,
                    PageName = m.PageName,
                    Title = m.Title,
                    Index = m.Index
                }).ToList());
        }


    }

    ----------------------------------------------------
    Y en la vista donde esta el masterdetailpage , agrego el listview

    <ListView BackgroundColor="White" ItemsSource="{Binding Menus}" SeparatorVisibility="Default" RowHeight="50" VerticalOptions="StartAndExpand" >
                        <ListView.ItemTemplate >
                            <DataTemplate>
                                <ViewCell >
                                    <Grid VerticalOptions="Center">
                                        <Grid.GestureRecognizers>
                                            <TapGestureRecognizer Command="{Binding SelectMenuCommand}"   />
                                        </Grid.GestureRecognizers>
                                        <Grid.ColumnDefinitions>
                                            <ColumnDefinition Width="Auto"></ColumnDefinition>
                                            <ColumnDefinition Width="*"></ColumnDefinition>
                                            <ColumnDefinition Width="Auto"></ColumnDefinition>
                                        </Grid.ColumnDefinitions>
                                        <Grid.RowDefinitions>
                                            <RowDefinition Height="50"></RowDefinition>
                                        </Grid.RowDefinitions>

                                        <Image Source="{Binding Icon}" VerticalOptions="Center" HorizontalOptions="Center" Grid.Column="0" />
                                        <Label Grid.Column="1"   TextColor="Black" FontSize="14" VerticalOptions="Center" Text="{Binding Title}" Padding="15,0,0,0" />
                                        <Image Source="arrowmenu.png" VerticalOptions="Center" HorizontalOptions="Center" Grid.Column="2" />
                                    </Grid>
                                </ViewCell>
                            </DataTemplate>
                        </ListView.ItemTemplate>
                    </ListView>





 */
#endregion

#region Singleton de un ViewModel
/*     
    Es un poco diferente de Singleton Normal, ya que estas clases las crea en automatico el xamarin  
    Para este ejemplo no realice un ejemplo real ya que no se me ocurrio nada simple para poder usar el singleton :P 
    Ahi esta el ejemplo :P


    public class MasterDetailShellPageViewModel : ViewModelBase
    {
        private static MasterDetailShellPageViewModel _instance;
 
        public MasterDetailShellPageViewModel(INavigationService navigationService, IEventAggregator eventAggregator, IDialogService dialogService) : base(navigationService, eventAggregator)
        {
            _instance = this;
            
        }

        public static MasterDetailShellPageViewModel GetInstance()
        {
            return _instance;
        }
    }
    -------------------------------------------------------------------------

    //En otro viewmodel podemos usar la instancia de la clase con el singleton
    var mainpage = MainPageViewModel.GetInstance();
    mainpage.UnMetodoCualquiera();


 */
#endregion



#region Plantilla-region-MiTitulo-comentario
/*     
      
 */
#endregion


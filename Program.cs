using System.Drawing;
using System.Security.Policy;
using csvfiles;

namespace tp_final;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    //[STAThread]
    public enum barrios
    {
       Lineres, Comuna01, Comuna02, Comuna03, Comuna04, Comuna05, Comuna06, Comuna07, Comuna08, Comuna09, Comuna10, Comuna11, Comuna12, Comuna13, Comuna14,Avellaneda,SanMartin,LaMatanza,Lanus,Lomas,Moron,SanIsidro,TresFebrero,Vilo,OroVerde
    }
    static void Main()

    {
       
        var csv_ = new csvfiles._csv();
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.Run(new Form1());

        cVehiculo Furgoneta = new cVehiculo(5,5.5,0,0);
        cVehiculo Camioneta = new cVehiculo(5, 5.5, 0, 0);
        cVehiculo Camion = new cVehiculo(5, 5.5, 0, 0);

        List<cPedido> Almacen = csv_.read_csv();

        cCocimundo Cocimundo = new cCocimundo(Almacen,Camioneta,Furgoneta,Camion);

        Cocimundo.cargarvehiculos();
 

       




    // Furgoneta.recorrido(Almacen, cPedido.barrios.Avellaneda, cPedido.barrios.Moron);
    }

   
}



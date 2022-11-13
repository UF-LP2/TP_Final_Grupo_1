using System.Drawing;
using System.Security.Policy;

namespace tp_final;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.Run(new Form1());

        cVehiculo Furgoneta = new cVehiculo(5,5.5,0,0);

        cPaquete Cocina = new cPaquete("Cocina", 0.5,40,true,true);
        cPaquete Calefon = new cPaquete ("Calefon", 0.5, 45, true, true);
        cPaquete Termotanque = new cPaquete("Termotanque", 0.75, 45, true, true);
        cPaquete Lavarropa = new cPaquete("Lavarropa", 1, 45, true, true);
        cPaquete Secarropa = new cPaquete("Secarropa", 1, 50, true, true);
        cPaquete Freezer = new cPaquete("Freezer", 1.5, 60, true, true);
        cPaquete Heladera = new cPaquete("Heladera", 2, 70, true, true);

        cPedido Pedido1 = new cPedido(1,"Pepe",Cocina);
        cPedido Pedido2 = new cPedido(2, "Pepe", Calefon);
        cPedido Pedido3 = new cPedido(2, "Pepe", Termotanque);
        cPedido Pedido4 = new cPedido(3, "Pepe", Lavarropa);
        cPedido Pedido5 = new cPedido(1, "Pepe", Secarropa);
        cPedido Pedido6 = new cPedido(2, "Pepe", Freezer);
        cPedido Pedido7 = new cPedido(3, "Pepe", Heladera);

        List<cPedido> Almacen = new List<cPedido>();

        Almacen.Add(Pedido1);
        Almacen.Add(Pedido2);
        Almacen.Add(Pedido3);
        Almacen.Add(Pedido4);
        Almacen.Add(Pedido5);
        Almacen.Add(Pedido6);
        Almacen.Add(Pedido7);

        Furgoneta.CargarVehiculo(Almacen,7);

        cPedido Pedido8 = new cPedido(3, "Pepe", Heladera);

    }

   
}



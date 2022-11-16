using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Collections.Generic;
using tp_final.Properties;
using System.Reflection.Metadata;
using csvfiles;
using tp_final;

namespace csvfiles {
   
    public class _csv {
        public List<cPedido> read_csv() {
            using (var reader = new StreamReader(Resources.archivo))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture)) {

                List<cPedido> records = new List<cPedido>();

                csv.Read();
                csv.ReadHeader();
                while(csv.Read()) {

                    cPedido record = new cPedido {
                        tipo = csv.GetField<string>("producto"),
                        precio = csv.GetField<float>("precio"),
                        ancho = csv.GetField<float>("ancho"),
                        largo = csv.GetField<float>("largo"),
                        alto = csv.GetField<float>("alto"),
                        prioridad = csv.GetField<string>("prioridad"),
                        barrio = csv.GetField<string>("barrio"),
                       // fecha = new DateTime(csv.GetField<int>("fecha")),
                        peso = csv.GetField<float>("peso"),
                        ID = csv.GetField<string>("ID"),
                        

                    };
                    record.volumen = record.alto * record.ancho * record.largo;
                    record.beneficio = (record.volumen * record.peso);
                    if(record.volumen >2) record.necesita_elevador = false;
                    if (record.volumen <= 2) record.necesita_elevador = true;
                    records.Add(record);
                    cbarrios Comuna01 = new cbarrios("comuna 1", 10, 4);
                    cbarrios Comuna02 = new cbarrios("comuna 2", 9, 5);
                    cbarrios Comuna03 = new cbarrios("comuna 3", 9, 4);
                    cbarrios Comuna04 = new cbarrios("comuna 4", 10, 0);
                    cbarrios Comuna05 = new cbarrios("comuna 5", 8, 1);
                    cbarrios Comuna06 = new cbarrios("comuna 6", 7, 1);
                    cbarrios Comuna07 = new cbarrios("comuna 7", 7, 0);
                    cbarrios Comuna08 = new cbarrios("comuna 8", 4, -3);
                    cbarrios Comuna09 = new cbarrios("comuna 9 ", 1, -1);
                    cbarrios Comuna10 = new cbarrios("comuna 10", 1, 1);
                    cbarrios Comuna11 = new cbarrios("comuna 11", 1, 3);
                    cbarrios Comuna12 = new cbarrios("comuna 12", 2, 8);

                    cbarrios Comuna13 = new cbarrios("comuna 13", 4, 8);
                    cbarrios Comuna14 = new cbarrios("comuna 14", 5, 7);
                    cbarrios Comuna15 = new cbarrios("comuna 15", 3, 3);
                    cbarrios tresfebrero = new cbarrios("tres de febrero", -1, 1);
                    cbarrios moron = new cbarrios("moron", -2, 0);
                    cbarrios VicenteLopez = new cbarrios("vicente lopez", 0, 10);
                    cbarrios SanIsidro = new cbarrios("san isidro", -3, 11);
                    cbarrios Liniers = new cbarrios("linieros", 0, 0);
                    cbarrios Lanus = new cbarrios("lanus", 9, -5);
                    cbarrios LaMatanza = new cbarrios("la matanza", 0, -2);
                    cbarrios Avellaneda = new cbarrios("avellaneda", 11, 0);
                    cbarrios Lomas = new cbarrios("lomas de zamora", 4, -4);
                    cbarrios sanma = new cbarrios("san martin", -3, 4);
                    if (record.barrio == "comuna 1")
                    {
                        record.barriecito = Comuna01;

                    }

                    if (record.barrio == "comuna 2")
                    {
                        record.barriecito = Comuna02;
                    }
                    if (record.barrio == "comuna 3")
                    {
                        record.barriecito = Comuna03;
                    }
                    if (record.barrio == "comuna 4")
                    {
                        record.barriecito = Comuna04;
                    }
                    if (record.barrio == "comuna 5")
                    {
                        record.barriecito = Comuna05;
                    }
                    if (record.barrio == "comuna 6")
                    {
                        record.barriecito = Comuna06;
                    }
                    if (record.barrio == "comuna 7")
                    {
                        record.barriecito = Comuna07;
                    }
                    if (record.barrio == "comuna 8")
                    {
                        record.barriecito = Comuna08;
                    }
                    if (record.barrio == "comuna 9")
                    {
                        record.barriecito = Comuna09;
                    }
                    if (record.barrio == "comuna 10")
                    {
                        record.barriecito = Comuna10;
                    }
                    if (record.barrio == "comuna 11")
                    {
                        record.barriecito = Comuna11;
                    }
                    if (record.barrio == "comuna 12")
                    {
                        record.barriecito = Comuna12;
                    }
                    if (record.barrio == "comuna 13")
                    {
                        record.barriecito = Comuna13;
                    }
                    if (record.barrio == "comuna 14")
                    {
                        record.barriecito = Comuna14;
                    }
                    if (record.barrio == "comuna 15")
                    {
                        record.barriecito = Comuna15;
                    }
                    if (record.barrio == "lomas de zamora")
                    {
                        record.barriecito = Lomas;
                    }
                    if (record.barrio == "moron")
                    {
                        record.barriecito = moron;
                    }
                    if (record.barrio == "san isidro")
                    {
                        record.barriecito = SanIsidro;
                    }
                    if (record.barrio == "tres de febrero")
                    {
                        record.barriecito = tresfebrero;
                    }
                    if (record.barrio == "san martin")
                    {
                        record.barriecito =sanma ;
                    }
                    if (record.barrio == "lanus")
                    {
                        record.barriecito = Lanus;
                    }
                    if (record.barrio == "la matanza")
                    {
                        record.barriecito = LaMatanza;
                    }
                    if (record.barrio == "avellaneda")
                    {
                        record.barriecito =Avellaneda;
                    }
                    if (record.barrio == "vicente lopez")
                    {
                        record.barriecito = VicenteLopez;
                    }

                }

                return records;
            }
        }
    }
};

// Esta clase es base para la lectura del archivo
// Puede ser editada en base a su TP
public class cPedido {
    public string ID;
    public string prioridad;
    public double beneficio;
    public string barrio;
    public double volumen;
    public string tipo;
    public float peso;
    public bool apilable;
    public bool necesita_elevador;
    public cbarrios barriecito;
   
    public float precio { get; set; }
    public float largo { get; set; }
    public float ancho { get; set; }
    public float alto { get; set; }
    public DateTime fecha { get; set; }
    public double getBeneficio()
    {
        return beneficio;

    }
    
   /* public enum barrios
    {
        Comuna01, Comuna02, Comuna03, Comuna04, Comuna05, Comuna06, Comuna07, Comuna08, Comuna09, Comuna10, Comuna11, Comuna12, Comuna13, Comuna14, Comuna15, Avellaneda, SanMartin, LaMatanza, Lanus, Lomas, Moron, SanIsidro, TresFebrero, Vilo,
    }*/
    public string getID()
    {
        return ID;
    }
    public float getPeso()
    {
        return peso;
    }
    public double getVolumen()
    {
        return volumen;
    }
    public string getNombre()
    {
        return tipo;

    }
    
        

}

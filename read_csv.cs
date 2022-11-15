using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Collections.Generic;
using tp_final.Properties;

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
                    records.Add(record);
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
    public float precio { get; set; }
    public float largo { get; set; }
    public float ancho { get; set; }
    public float alto { get; set; }
    public DateTime fecha { get; set; }
    public double getBeneficio()
    {
        return beneficio;

    }
    
    public enum barrios
    {
        Comuna01, Comuna02, Comuna03, Comuna04, Comuna05, Comuna06, Comuna07, Comuna08, Comuna09, Comuna10, Comuna11, Comuna12, Comuna13, Comuna14, Comuna15, Avellaneda, SanMartin, LaMatanza, Lanus, Lomas, Moron, SanIsidro, TresFebrero, Vilo,
    }
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

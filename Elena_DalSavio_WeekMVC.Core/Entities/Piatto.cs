using System;

namespace Elena_DalSavio_WeekMVC.Core
{
    public class Piatto
    {
        public string PiattoId {get;set;}
        public string Nome { get; set; }
        public string Descrizione { get; set; }
        public EnumTipologia Tipologia { get; set; }
        public decimal Prezzo { get; set; }

        public string MenuPiattiId { get; set; }
        public MenuPiatti menuPiatti { get; set; }
    }
    public enum EnumTipologia
    {
        Primo=1,
        Secondo=2,
        Contorno=3,
        Dolce=4
    }
}

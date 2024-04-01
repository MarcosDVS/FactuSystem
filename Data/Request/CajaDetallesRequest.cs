namespace FactuSystem.Data.Request;

public class CajaDetallesRequest
{
    public int Id { get; set; }
    public int One { get; set; }
    public int Uno => One * 1;
    public int Five { get; set; }
    public int Cinco => Five * 5;
    public int Ten { get; set; }
    public int Diez => Ten * 10;
    public int TwentyFive { get; set; }
    public int VenteCinco => TwentyFive * 25;
    public int Fifty { get; set; }
    public int Cincuenta => Fifty * 50;
    public int OneHundred { get; set; }
    public int Cien => OneHundred * 100;
    public int TwoHundred { get; set; }
    public int DosCiento => TwoHundred * 200;
    public int FiveHundred { get; set; }
    public int Quiniento => One * 500;
    public int OneThousand { get; set; }
    public int Mil => OneThousand * 1000;
    public int TwoThousand { get; set; }
    public int DosMil => TwoThousand * 2000;
    public decimal Total => Uno + Cinco + Diez + VenteCinco 
    + Cincuenta + Cien + DosCiento + Quiniento + Mil + DosMil;
}
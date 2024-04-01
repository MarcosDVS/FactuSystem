using FactuSystem.Data.Response;
using FactuSystem.Data.Request;
using System.ComponentModel.DataAnnotations;

namespace FactuSystem.Data.Model;

public class CuadrarCaja
{
    [Key]
    public int Id { get; set; }
    public DateTime Fecha { get; set; }
    public string Cajero { get; set; }
    public decimal Monto { get; set; }
    public decimal MontoCuadrado { get; set; }
    
    public int One { get; set; }
    public int Five { get; set; }
    public int Ten { get; set; }
    public int TwentyFive { get; set; }
    public int Fifty { get; set; }
    public int OneHundred { get; set; }
    public int TwoHundred { get; set; }
    public int FiveHundred { get; set; }
    public int OneThousand { get; set; }
    public int TwoThousand { get; set; }
    public decimal Total => (One * 1) + (Five * 5) + (Ten * 10) + (TwentyFive * 25) + (Fifty * 50)
    + (OneHundred * 100) + (TwoHundred * 200) + (FiveHundred * 500) 
    + (OneThousand * 1000) + (TwoThousand * 2000);

    public static CuadrarCaja Crear(CuadrarCajaRequest request)
    {
        return new CuadrarCaja()
        {
            Fecha = request.Fecha,
            Cajero = request.Cajero,
            Monto = request.Monto,
            MontoCuadrado = request.MontoCuadrado,

            One = request.One, // Asegúrate de que esto sea correcto
            Five = request.Five, // Asegúrate de que esto sea correcto
            Ten = request.Ten,
            TwentyFive = request.TwentyFive,
            Fifty = request.Fifty,
            OneHundred = request.OneHundred,
            TwoHundred = request.TwoHundred,
            FiveHundred = request.FiveHundred,
            OneThousand = request.OneThousand,
            TwoThousand = request.TwoThousand
        };
    }


    public CuadrarCajaResponse? ToResponse()
    {
        return new CuadrarCajaResponse()
        {
            Id = Id,
            Fecha = Fecha,
            Cajero = Cajero,
            Monto = Monto,
            MontoCuadrado = MontoCuadrado,

            One = One, // Asegúrate de que esto sea correcto
            Five = Five, // Asegúrate de que esto sea correcto
            Ten = Ten,
            TwentyFive = TwentyFive,
            Fifty = Fifty,
            OneHundred = OneHundred,
            TwoHundred = TwoHundred,
            FiveHundred = FiveHundred,
            OneThousand = OneThousand,
            TwoThousand = TwoThousand
        };
    }
}
﻿using System.ComponentModel.DataAnnotations;
using FactuSystem.Data.Request;
using FactuSystem.Data.Response;
using Microsoft.Win32;

namespace FactuSystem.Data.Model;

public class Cliente
{
    [Key]
    public int Id { get; set; }

    public string Cedula { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Apellidos { get; set; } = null!;
    
    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public decimal Limitecredito { get; set; }
    public static Cliente Crear(ClienteRequest cliente)
   
    {
        return new Cliente()
        {
            Nombre = cliente.Nombre,
            Apellidos = cliente.Apellidos,
            Direccion = cliente.Direccion,
            Telefono = cliente.Telefono,
            Cedula = cliente.Cedula,
            Limitecredito = cliente.Limitecredito,
        };
    }

    public bool Modificar(ClienteRequest cliente)
    {
        var cambio = false;

        if (Nombre != cliente.Nombre)
        {
            Nombre = cliente.Nombre;
            cambio = true;
        }
        if (Apellidos != cliente.Apellidos)
        {
            Apellidos = cliente.Apellidos;
            cambio = true;
        }
        if (Direccion != cliente.Direccion)
        {
            Direccion = cliente.Direccion;
            cambio = true;
        }
        if (Telefono != cliente.Telefono)
        {
            Telefono = cliente.Telefono;
            cambio = true;
        }
        if (Cedula != cliente.Cedula)
        {
            Cedula = cliente.Cedula;
            cambio = true;
        }
        if (Limitecredito != cliente.Limitecredito)
        {
            Limitecredito = cliente.Limitecredito;
            cambio = true;
        }

        return cambio;
    }



    public ClienteResponse? ToResponse()
    {
        return new ClienteResponse()
        {
            Id = Id,
            Cedula = Cedula,
            Nombre = Nombre,
            Apellidos = Apellidos,
            Telefono = Telefono,
            Direccion = Direccion,
            Limitecredito = Limitecredito,
        };
    }
}

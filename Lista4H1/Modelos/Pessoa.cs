﻿namespace Lista4H1.Modelos;
public class Pessoa
{
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public double Peso { get; set; }
    public double Altura { get; set; }

    public double CalcularIMC()
    {
        return Peso / (Altura * Altura);
    }
}
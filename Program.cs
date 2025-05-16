const decimal PrecoPriHora = 20;
const decimal PrecoHoraGrande = 20;
const decimal PrecoHoraPequeno = 10;
const decimal PrecoDiaGrande = 80;
const decimal PrecoDiaPequeno = 50;
const double AdicionalValet = 0.2;
const decimal PrecoLavagGrande = 100;
const decimal PrecoLavagPequeno = 50;
const int TempoDiaria = 5 * 60;
const int TempoTolerancia = 5;
const int TempoMaxPermanencia = 12 * 60;
int tempoPermanencia;
string tamanho;
bool valet, lavagem;
decimal ParcialEstacionamento = 0;
decimal parcialValet = 0;
decimal ParcialLavagem = 0;
decimal total = 0;


Console.Clear();


Console.WriteLine("Estacionamento\n");

Console.Write("Tamanho do veículo (P/G)_: ");
tamanho = Console.ReadLine()!.Trim().Substring(0, 1).ToUpper();

if (tamanho != "P" && tamanho != "G")

{ Console.WriteLine("Tamanho inválido."); return; }


Console.Write("Tempo de permanência (min)_: ");
tempoPermanencia = Convert.ToInt32(Console.ReadLine());


if (tempoPermanencia <= 0 || tempoPermanencia > TempoMaxPermanencia)

{ Console.WriteLine("Tempo de permanência inválido."); return; }


Console.Write("Serviço de valet (S/N)_: ");
valet = Console.ReadLine()!.Trim().Substring(0, 1).ToUpper() == "S";


Console.Write("Serviço de lavagem (S/N)_: ");
lavagem = Console.ReadLine()!.Trim().Substring(0, 1).ToUpper() == "S";


if (tempoPermanencia >= TempoDiaria)
{
    if (tamanho == "P")
    { ParcialEstacionamento = PrecoDiaPequeno; }


    else
    { ParcialEstacionamento = PrecoDiaGrande; }
}


else
{
    int horasPermanencia = (int)(tempoPermanencia / 60);
    int minutosRestantes = tempoPermanencia % 60;


    if (minutosRestantes > TempoTolerancia)
    { horasPermanencia++; }


    ParcialEstacionamento = PrecoPriHora;
    int horasAdicionais = horasPermanencia - 1;

    if (horasAdicionais > 0)

{
     if (tamanho == "P")

        { ParcialEstacionamento += horasAdicionais * PrecoHoraPequeno; }


     else
    { ParcialEstacionamento += horasAdicionais * PrecoHoraGrande; } 

}

}

if (valet)
{
parcialValet = ParcialEstacionamento * Convert.ToDecimal(AdicionalValet);
}



if (lavagem)
{
    if (tamanho == "P")
    { ParcialLavagem += PrecoLavagPequeno; }


    else
    { ParcialLavagem += PrecoLavagGrande; }

}

total = ParcialEstacionamento + parcialValet + ParcialLavagem;



Console.WriteLine($"\nEstacionamento: {ParcialEstacionamento,14:C}");
Console.WriteLine($"Valet_: {parcialValet,14:C}");
Console.WriteLine($"Lavagem_: {ParcialLavagem,14:C}");
Console.WriteLine("-----------------------------------");

Console.WriteLine("");

Console.WriteLine($"Total_: {total,14:C}");
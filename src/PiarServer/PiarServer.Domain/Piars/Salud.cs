namespace PiarServer.Domain.Piars
{
    public record Salud(
        bool AfiliSalud,
        string Eps,
        string ContrSubsi,
        string LugEmer,
        bool AtenSalud,
        string FrecAtenSalud,
        bool DiagMed,
        string CualDiagMed,
        bool TerMed,
        string CualTerMed,
        bool TratMed,
        string CualTratMed,
        bool ConsMeds,
        string MedsFrecuencia,
        bool ProdsMov,
        string CualProdsMov
    );
}
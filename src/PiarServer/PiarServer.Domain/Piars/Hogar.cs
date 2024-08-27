namespace PiarServer.Domain.Piars
{
    public record Hogar(
        string NomMam,
        string OcuMam,
        string NivEdMam,
        string NomPap,
        string OcuPap,
        string NivEdPap,
        string NomCui,
        string ParCui,
        string NivEdCui,
        string TelCui,
        string EmaCui,
        int NumHer,
        int LugOcuEst,
        string PerVivE,
        string ApoCriE,
        bool BajProt,
        bool SubInstEnt,
        string TipSub
    );
}
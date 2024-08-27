namespace PiarServer.Domain.Piars
{
    public record Educativo(
        bool VincOtrInst,
        string CualInst,
        string NoInst,
        string UltGrado,
        bool AprovUltGrad,
        string ObsUltGrd,
        bool InfmPed,
        string InstInfm,
        bool ProgComp,
        string TipoProgComp,
        string NomInst,
        string SedInst,
        string TransInst,
        string DistInt
    );
}
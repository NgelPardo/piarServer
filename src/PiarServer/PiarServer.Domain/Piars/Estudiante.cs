namespace PiarServer.Domain.Piars
{
    public record Estudiante(
        string NomEst,
        string ApeEst,
        string LugNacEst,
        int EdadEst,
        DateTime FecNacEst,
        string TipDocEst,
        string OtroDocEst,
        string DocEst,
        string DepaEst,
        string MunEst,
        string DirEst,
        string BarrioEst,
        string TelEst,
        string EmaEst,
        bool CenPro,
        string LugarCenPro,
        string GrdAspEst,
        string GrpEtn,
        bool VicConf,
        bool RegVicConf
    );
}
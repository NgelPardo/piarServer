using PiarServer.Application.Abstractions.Messaging;
using PiarServer.Domain.Abstractions;
using PiarServer.Domain.Piars;

namespace PiarServer.Application.Piars.UpdatePiar;

internal class UpdatePiarPt1CommandHandler : ICommandHandler<UpdatePiarPt1Command, Guid>
{
    private readonly IPiarRepository _piarRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePiarPt1CommandHandler(IPiarRepository piarRepository, IUnitOfWork unitOfWork)
    {
        _piarRepository = piarRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(UpdatePiarPt1Command request, CancellationToken cancellationToken)
    {
        var piar = await _piarRepository.GetByIdAsync(request.Id);

        if(piar is null)
        {
            return Result.Failure<Guid>(PiarErrors.NotFound);
        }

        var diligenciamientoUno = new DiligenciamientoUno(request.FecDil, request.NomDil, request.RolSeIe);
        var estudiante = new Estudiante(
            request.NomEst,
            request.ApeEst,
            request.LugNacEst,
            request.EdadEst,
            request.FecNacEst,
            request.TipDocEst,
            request.OtroDocEst,
            request.DocEst,
            request.DepaEst,
            request.MunEst,
            request.DirEst,
            request.BarrioEst,
            request.TelEst,
            request.EmaEst,
            request.CenPro,
            request.LugarCenPro,
            request.GrdAspEst,
            request.GrpEtn,
            request.VicConf,
            request.RegVicConf
        );

        var salud = new Salud(
            request.AfiliSalud,
            request.Eps,
            request.ContrSubsi,
            request.LugEmer,
            request.AtenSalud,
            request.FrecAtenSalud,
            request.DiagMed,
            request.CualDiagMed,
            request.TerMed,
            request.CualTerMed,
            request.TratMed,
            request.CualTratMed,
            request.ConsMeds,
            request.MedsFrecuencia,
            request.ProdsMov,
            request.CualProdsMov
        );

        var hogar = new Hogar(
            request.NomMam,
            request.OcuMam,
            request.NivEdMam,
            request.NomPap,
            request.OcuPap,
            request.NivEdPap,
            request.NomCui,
            request.ParCui,
            request.NivEdCui,
            request.TelCui,
            request.EmaCui,
            request.NumHer,
            request.LugOcuEst,
            request.PerVivEst,
            request.ApoCriEst,
            request.BajProt,
            request.SubInstEnt,
            request.TipSub
        );

        var educativo = new Educativo(
            request.VincOtrInst,
            request.CualInst,
            request.NoInst,
            request.UltGrad,
            request.AprovUltGrad,
            request.ObsUltGrd,
            request.InfmPed,
            request.InstInfm,
            request.ProgComp,
            request.TipoProgComp,
            request.NomInst,
            request.SedInst,
            request.TransInst,
            request.DistInst
        );

        piar.UpdatePt1(
            request.IdUss,
            request.IdEst,
            request.IdProf,
            diligenciamientoUno,
            estudiante,
            salud,
            hogar,
            educativo
        );

        await _piarRepository.UpdatePt1( piar, cancellationToken );

        await _unitOfWork.SaveChangesAsync( cancellationToken );

        return piar.Id!;
    }
}

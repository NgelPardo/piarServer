using PiarServer.Application.Abstractions.Messaging;
using PiarServer.Application.Exceptions;
using PiarServer.Domain.Abstractions;
using PiarServer.Domain.Piars;
using PiarServer.Domain.Users;

namespace PiarServer.Application.Piars.CrearPiar;

internal sealed class CrearPiarCommandHandler :
    ICommandHandler<CrearPiarCommand, Guid>
{
    private readonly IPiarRepository _piarRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    public CrearPiarCommandHandler(
        IPiarRepository piarRepository, 
        IUserRepository userRepository,
        IUnitOfWork unitOfWork
    )
    {
        _piarRepository = piarRepository;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(
            CrearPiarCommand request,
            CancellationToken cancellationToken
        )
    {
        var user = await _userRepository.GetByIdAsync(request.IdUss, cancellationToken);
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
            request.PerVivE,
            request.ApoCriE,
            request.BajProt,
            request.SubInstEnt,
            request.TipSub
        );
        var educativo = new Educativo(
            request.VincOtrInst,
            request.CualInst,
            request.NoInst,
            request.UltGrado,
            request.AprovUltGrad,
            request.ObsUltGrd,
            request.InfmPed,
            request.InstInfm,
            request.ProgComp,
            request.TipoProgComp,
            request.NomInst,
            request.SedInst,
            request.TransInst,
            request.DistInt
        );
        var diligenciamientoDos = new DiligenciamientoDos(
            request.FecDilA2,
            request.InstEduA2,
            request.SedA2,
            request.JorA2,
            request.DocsEla,
            request.GrdEst
        );
        var caracteristicasEstudiante = new CaracteristicasEstudiante(
            request.Desc1Est,
            request.Desc2Est
        );
        var recomendaciones = new Recomendaciones(
            request.AccFam,
            request.EstrFam,
            request.AccDoc,
            request.EstrDoc,
            request.AccDir,
            request.EstrDir,
            request.AccAdm,
            request.EstrAdm,
            request.AccPar,
            request.EstrPar
        );
        var diligenciamientoTres = new DiligenciamientoTres(
            request.FecDilA3,
            request.InstEduA30,
            request.DocDir,
            request.NomFam,
            request.ActsApo,
            request.Compromisos 
        );

        if(user is null)
        {
            return Result.Failure<Guid>(UserErrors.NotFound);
        }

        //TODO: Manejar los diferentes posibles errores

        try
        {
            var piar = Piar.Crear(
                request.IdUss,
                request.IdEst,
                request.IdProf,
                diligenciamientoUno,
                estudiante,
                salud,
                hogar,
                educativo,
                diligenciamientoDos,
                caracteristicasEstudiante,
                recomendaciones,
                diligenciamientoTres
            );

            _piarRepository.Add(piar);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return piar.Id!;
            
        }
        catch (ConcurrencyException)
        {
            return Result.Failure<Guid>(PiarErrors.Overlap);
        }

    }
}
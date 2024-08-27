using PiarServer.Application.Abstractions.Messaging;
using PiarServer.Application.Exceptions;
using PiarServer.Domain.Abstractions;
using PiarServer.Domain.Piars;
using PiarServer.Domain.Users;

namespace PiarServer.Application.Piars.CrearPiar;

internal sealed class CrearPiarPt1CommandHandler :
    ICommandHandler<CrearPiarPt1Command, Guid>
{
    private readonly IPiarRepository _piarRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    public CrearPiarPt1CommandHandler(
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
            CrearPiarPt1Command request,
            CancellationToken cancellationToken
        )
    {
        var user = await _userRepository.GetByIdAsync(request.idUss, cancellationToken);
        var diligenciamientoUno = new DiligenciamientoUno(request.fec_dil, request.nom_dil, request.rol_se_ie);
        var estudiante = new Estudiante(
            request.nom_est,
            request.ape_est,
            request.lug_nac_est,
            request.edad_est,
            request.fec_nac_est,
            request.tip_doc_est,
            request.otro_doc_est,
            request.doc_est,
            request.depa_est,
            request.mun_est,
            request.dir_est,
            request.barrio_est,
            request.tel_est,
            request.ema_est,
            request.cen_pro,
            request.lugar_cen_pro,
            request.grd_asp_est,
            request.grp_etn,
            request.vic_conf,
            request.reg_vic_conf
        );
        var salud = new Salud(
            request.afili_salud,
            request.EPS,
            request.contr_subsi,
            request.lug_emer,
            request.aten_salud,
            request.frec_aten_salud,
            request.diag_med,
            request.cual_diag_med,
            request.ter_med,
            request.cual_ter_med,
            request.trat_med,
            request.cual_trat_med,
            request.cons_meds,
            request.meds_frecuencia,
            request.prods_mov,
            request.cual_prods_mov
        );
        var hogar = new Hogar(
            request.nom_mam,
            request.ocu_mam,
            request.niv_ed_mam,
            request.nom_pap,
            request.ocu_pap,
            request.niv_ed_pap,
            request.nom_cui,
            request.par_cui,
            request.niv_ed_cui,
            request.tel_cui,
            request.ema_cui,
            request.num_her,
            request.lug_ocu_est,
            request.per_viv_e,
            request.apo_cri_e,
            request.baj_prot,
            request.sub_inst_ent,
            request.tip_sub
        );
        var educativo = new Educativo(
            request.vinc_otr_inst,
            request.cual_inst,
            request.no_inst,
            request.ult_grad,
            request.aprov_ult_grad,
            request.obs_ult_grd,
            request.infm_ped,
            request.inst_infm,
            request.prog_comp,
            request.tipo_prog_comp,
            request.nom_inst,
            request.sed_inst,
            request.trans_inst,
            request.dist_inst
        );

        if (user is null)
        {
            return Result.Failure<Guid>(UserErrors.NotFound);
        }

        //TODO: Manejar los diferentes posibles errores

        try
        {
            var piar = Piar.CrearPrimeraParte(
                request.idUss,
                request.idEst,
                request.idProf,
                diligenciamientoUno,
                estudiante,
                salud,
                hogar,
                educativo
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

using MediatR;
using Microsoft.AspNetCore.Mvc;
using PiarServer.Application.Piars.CrearPiar;
using PiarServer.Application.Piars.GetPiar;
using PiarServer.Application.Piars.GetPiars;
using PiarServer.Application.Piars.UpdatePiar;
using PiarServer.Domain.Permissions;
using PiarServer.Infrastructure.Authentication;

namespace PiarServer.Api.Controllers.Piars;

[ApiController]
[Route("api/piars")]
public class PiarsController : ControllerBase
{
    private readonly ISender _sender;

    public PiarsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> GetPiars( CancellationToken cancellationToken )
    {
        var query = new GetPiarsQuery();
        var resultados = await _sender.Send(query, cancellationToken);
        return Ok(resultados.Value);
    }

    [HttpGet("profesor/{id}")]
    public async Task<IActionResult> GetPiarsProfesor(
        Guid id,
        CancellationToken cancellationToken 
    )
    {
        var query = new GetPiarsProfesorQuery( id );
        var resultados = await _sender.Send(query, cancellationToken);
        return Ok(resultados.Value);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPiar(
        Guid id,
        CancellationToken cancellationToken
    )
    {
        var query = new GetPiarQuery(id);
        var resultado = await _sender.Send(query, cancellationToken);

        return resultado.IsSuccess ? Ok(resultado.Value) : NotFound();
    }

    [HttpGet("pt1/{id}")]
    public async Task<IActionResult> GetPiarPt1(
        Guid id,
        CancellationToken cancellationToken
    )
    {
        var query = new GetPiarPt1Query(id);
        var resultado = await _sender.Send(query, cancellationToken);

        return resultado.IsSuccess ? Ok(resultado.Value) : NotFound();
    }

    [HttpGet("pt2/{id}")]
    public async Task<IActionResult> GetPiarPt2(
        Guid id,
        CancellationToken cancellationToken
    )
    {
        var query = new GetPiarPt2Query(id);
        var resultado = await _sender.Send(query, cancellationToken);

        return resultado.IsSuccess ? Ok(resultado.Value) : NotFound();
    }

    [HttpGet("pt3/{id}")]
    public async Task<IActionResult> GetPiarPt3(
        Guid id,
        CancellationToken cancellationToken
    )
    {
        var query = new GetPiarPt3Query(id);
        var resultado = await _sender.Send(query, cancellationToken);

        return resultado.IsSuccess ? Ok(resultado.Value) : NotFound();
    }

    [HttpGet("pt4/{id}")]
    public async Task<IActionResult> GetPiarPt4(
        Guid id,
        CancellationToken cancellationToken
    )
    {
        var query = new GetPiarPt4Query(id);
        var resultado = await _sender.Send(query, cancellationToken);

        return resultado.IsSuccess ? Ok(resultado.Value) : NotFound();
    }

    //[HasPermission(PermissionEnum.UpdateUser)]
    [HttpPost("crear")]
    public async Task<IActionResult> CrearPiarPt1(
        PiarCrearPt1Request request,
        CancellationToken cancellationToken
    )
    {
        var command = new CrearPiarPt1Command
        (
            request.idUss,
            request.estPiar,
            request.idEst,
            request.idProf,
            request.fec_dil,
            request.nom_dil,
            request.rol_se_ie,
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
            request.reg_vic_conf,
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
            request.cual_prods_mov,
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
            request.tip_sub,
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

        var resultado = await _sender.Send(command, cancellationToken);

        if(resultado.IsFailure)
        {
            return BadRequest(resultado.Error);
        }

        return CreatedAtAction(nameof(GetPiar), new { id = resultado.Value }, resultado.Value);

    }

    [HttpPut("pt1/{id}")]
    public async Task<IActionResult> UpdatePiarPt1(
        Guid id,
        [FromBody] PiarUpdatePt1Request request,
        CancellationToken cancellationToken
    )
    {
        var command = new UpdatePiarPt1Command(
            id,
            request.id_uss,
            request.est_piar,
            request.id_est,
            request.id_prof,
            request.fec_dil,
            request.nom_dil,
            request.rol_se_ie,
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
            request.reg_vic_conf,
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
            request.cual_prods_mov,
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
            request.tip_sub,
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

        var result = await _sender.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return Unauthorized(result.Error);
        }

        return Ok(result.Value);
    }

    [HttpPut("pt2/{id}")]
    public async Task<IActionResult> UpdatePiarPt2(
        Guid id,
        [FromBody] PiarUpdatePt2Request request,
        CancellationToken cancellationToken
    )
    {
        var command = new UpdatePiarPt2Command(
            id,
            request.fec_dig_a2,
            request.inst_edu_a2,
            request.sed_a2,
            request.jor_a2,
            request.docs_ela,
            request.grd_est,
            request.desc_1_est,
            request.desc_2_est
        );

        var result = await _sender.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return Unauthorized(result.Error);
        }

        return Ok(result.Value);
    }

    [HttpPut("pt3/{id}")]
    public async Task<IActionResult> UpdatePiarPt3(
        Guid id,
        [FromBody] PiarUpdatePt3Request request,
        CancellationToken cancellationToken
    )
    {
        var command = new UpdatePiarPt3Command(
            id,
            request.acc_fam,
            request.estr_fam,
            request.acc_doc,
            request.estr_doc,
            request.acc_dir,
            request.estr_dir,
            request.acc_adm,
            request.estr_adm,
            request.acc_par,
            request.estr_par
        );

        var result = await _sender.Send(command, cancellationToken);

        if(result.IsFailure)
        {
            return Unauthorized(result.Error);
        }

        return Ok(result.Value);
    }

    [HttpPut("pt4/{id}")]
    public async Task<IActionResult> UpdatePiarPt4(
        Guid id,
        [FromBody] PiarUpdatePt4Request request,
        CancellationToken cancellationToken
    )
    {
        var command = new UpdatePiarPt4Command(
            id,
            request.fec_dil_a3,
            request.acts_apo,
            request.doc_dir,
            request.inst_edu_a3,
            request.nom_fam,
            request.compromisos
        );

        var result = await _sender.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return Unauthorized(result.Error);
        }

        return Ok(result.Value);
    }
}
using Dapper;
using PiarServer.Application.Abstractions.Data;
using PiarServer.Application.Abstractions.Messaging;
using PiarServer.Domain.Abstractions;

namespace PiarServer.Application.Piars.GetPiar;

internal sealed class GetPiarPt1QueryHandler
    : IQueryHandler<GetPiarPt1Query, PiarPt1Response>
{
    private readonly ISqlConnectionFactory _sqConnectionFactory;

    public GetPiarPt1QueryHandler(ISqlConnectionFactory sqConnectionFactory)
    {
        _sqConnectionFactory = sqConnectionFactory;
    }

    public async Task<Result<PiarPt1Response>> Handle(GetPiarPt1Query request, CancellationToken cancellationToken)
    {
        using var connection = _sqConnectionFactory.CreateConnection();

        var sql = """
            SELECT
                id,
                id_uss,
                est_piar,
                id_est,
                id_prof,
                diligenciamiento_uno_fec_dil AS fec_dil,
                diligenciamiento_uno_nom_dil AS nom_dil,
                diligenciamiento_uno_rol_se_ie AS rol_se_ie,
                estudiante_nom_est AS nom_est,
                estudiante_ape_est AS ape_est,
                estudiante_lug_nac_est AS lug_nac_est,
                estudiante_edad_est AS edad_est,
                estudiante_fec_nac_est AS fec_nac_est,
                estudiante_tip_doc_est AS tip_doc_est,
                estudiante_otro_doc_est AS otro_doc_est,
                estudiante_doc_est AS doc_est,
                estudiante_depa_est AS depa_est,
                estudiante_mun_est AS mun_est,
                estudiante_dir_est AS dir_est,
                estudiante_barrio_est AS barrio_est,
                estudiante_tel_est AS tel_est,
                estudiante_ema_est AS ema_est,
                estudiante_cen_pro AS cen_pro,
                estudiante_lugar_cen_pro AS lugar_cen_pro,
                estudiante_grd_asp_est AS grd_asp_est,
                estudiante_grp_etn AS grp_etn,
                estudiante_vic_conf AS vic_conf,
                estudiante_reg_vic_conf AS reg_vic_conf,
                salud_afili_salud AS afili_salud,
                salud_eps AS eps,
                salud_contr_subsi AS contr_subsi,
                salud_lug_emer AS lug_emer,
                salud_aten_salud AS aten_salud,
                salud_frec_aten_salud AS frec_aten_salud,
                salud_diag_med AS diag_med,
                salud_cual_diag_med AS cual_diag_med,
                salud_ter_med AS ter_med,
                salud_cual_ter_med AS cual_ter_med,
                salud_trat_med AS trat_med,
                salud_cual_trat_med AS cual_trat_med,
                salud_cons_meds AS cons_meds,
                salud_meds_frecuencia AS meds_frecuencia,
                salud_prods_mov AS prods_mov,
                salud_cual_prods_mov AS cual_prods_mov,
                hogar_nom_mam AS nom_mam,
                hogar_ocu_mam AS ocu_mam,
                hogar_niv_ed_mam AS niv_ed_mam,
                hogar_nom_pap AS nom_pap,
                hogar_ocu_pap AS ocu_pap,
                hogar_niv_ed_pap AS niv_ed_pap,
                hogar_nom_cui AS nom_cui,
                hogar_par_cui AS par_cui,
                hogar_niv_ed_cui AS niv_ed_cui,
                hogar_tel_cui AS tel_cui,
                hogar_ema_cui AS ema_cui,
                hogar_num_her AS num_her,
                hogar_lug_ocu_est AS lug_ocu_est,
                hogar_per_viv_e AS per_viv_e,
                hogar_apo_cri_e AS apo_cri_e,
                hogar_baj_prot AS baj_prot,
                hogar_sub_inst_ent AS sub_inst_ent,
                hogar_tip_sub AS tip_sub,
                educativo_vinc_otr_inst AS vinc_otr_inst,
                educativo_cual_inst AS cual_inst,
                educativo_no_inst AS no_inst,
                educativo_ult_grado AS ult_grad,
                educativo_aprov_ult_grad AS aprov_ult_grad,
                educativo_obs_ult_grd AS obs_ult_grd,
                educativo_infm_ped AS infm_ped,
                educativo_inst_infm AS inst_infm,
                educativo_prog_comp AS prog_comp,
                educativo_tipo_prog_comp AS tipo_prog_comp,
                educativo_nom_inst AS nom_inst,
                educativo_sed_inst AS sed_inst,
                educativo_trans_inst AS trans_inst,
                educativo_dist_int AS dist_inst
            FROM piars WHERE id = @PiarId
        """;

        var piar = await connection.QueryFirstOrDefaultAsync<PiarPt1Response>(
            sql,
            new
            {
                request.PiarId
            }
        );

        return piar!;
    }
}

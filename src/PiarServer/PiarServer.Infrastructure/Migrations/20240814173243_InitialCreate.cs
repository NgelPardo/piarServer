using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PiarServer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "outbox_messages",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    ocurred_on_utc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    type = table.Column<string>(type: "text", nullable: true),
                    content = table.Column<string>(type: "jsonb", nullable: true),
                    processed_on_utc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    error = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_outbox_messages", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "permissions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_permissions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    nombre_nombres = table.Column<string>(type: "text", nullable: true),
                    apellido_apellidos = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    password_hash = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    fec_dil = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roles_permissions",
                columns: table => new
                {
                    role_id = table.Column<int>(type: "integer", nullable: false),
                    permission_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_roles_permissions", x => new { x.role_id, x.permission_id });
                    table.ForeignKey(
                        name: "fk_roles_permissions_permissions_permission_id",
                        column: x => x.permission_id,
                        principalTable: "permissions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_roles_permissions_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "materias",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    id_uss = table.Column<Guid>(type: "uuid", nullable: false),
                    id_prof = table.Column<Guid>(type: "uuid", nullable: false),
                    nom_mat = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    fec_dil = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_materias", x => x.id);
                    table.ForeignKey(
                        name: "fk_materias_user_user_id",
                        column: x => x.id_uss,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "piars",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    id_uss = table.Column<Guid>(type: "uuid", nullable: false),
                    est_piar = table.Column<int>(type: "integer", nullable: false),
                    id_est = table.Column<Guid>(type: "uuid", nullable: false),
                    id_prof = table.Column<Guid>(type: "uuid", nullable: false),
                    diligenciamiento_uno_fec_dil = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    diligenciamiento_uno_nom_dil = table.Column<string>(type: "text", nullable: true),
                    diligenciamiento_uno_rol_se_ie = table.Column<string>(type: "text", nullable: true),
                    estudiante_nom_est = table.Column<string>(type: "text", nullable: true),
                    estudiante_ape_est = table.Column<string>(type: "text", nullable: true),
                    estudiante_lug_nac_est = table.Column<string>(type: "text", nullable: true),
                    estudiante_edad_est = table.Column<int>(type: "integer", nullable: true),
                    estudiante_fec_nac_est = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    estudiante_tip_doc_est = table.Column<string>(type: "text", nullable: true),
                    estudiante_otro_doc_est = table.Column<string>(type: "text", nullable: true),
                    estudiante_doc_est = table.Column<string>(type: "text", nullable: true),
                    estudiante_depa_est = table.Column<string>(type: "text", nullable: true),
                    estudiante_mun_est = table.Column<string>(type: "text", nullable: true),
                    estudiante_dir_est = table.Column<string>(type: "text", nullable: true),
                    estudiante_barrio_est = table.Column<string>(type: "text", nullable: true),
                    estudiante_tel_est = table.Column<string>(type: "text", nullable: true),
                    estudiante_ema_est = table.Column<string>(type: "text", nullable: true),
                    estudiante_cen_pro = table.Column<bool>(type: "boolean", nullable: true),
                    estudiante_lugar_cen_pro = table.Column<string>(type: "text", nullable: true),
                    estudiante_grd_asp_est = table.Column<string>(type: "text", nullable: true),
                    estudiante_grp_etn = table.Column<string>(type: "text", nullable: true),
                    estudiante_vic_conf = table.Column<bool>(type: "boolean", nullable: true),
                    estudiante_reg_vic_conf = table.Column<bool>(type: "boolean", nullable: true),
                    salud_afili_salud = table.Column<bool>(type: "boolean", nullable: true),
                    salud_eps = table.Column<string>(type: "text", nullable: true),
                    salud_contr_subsi = table.Column<string>(type: "text", nullable: true),
                    salud_lug_emer = table.Column<string>(type: "text", nullable: true),
                    salud_aten_salud = table.Column<bool>(type: "boolean", nullable: true),
                    salud_frec_aten_salud = table.Column<string>(type: "text", nullable: true),
                    salud_diag_med = table.Column<bool>(type: "boolean", nullable: true),
                    salud_cual_diag_med = table.Column<string>(type: "text", nullable: true),
                    salud_ter_med = table.Column<bool>(type: "boolean", nullable: true),
                    salud_cual_ter_med = table.Column<string>(type: "text", nullable: true),
                    salud_trat_med = table.Column<bool>(type: "boolean", nullable: true),
                    salud_cual_trat_med = table.Column<string>(type: "text", nullable: true),
                    salud_cons_meds = table.Column<bool>(type: "boolean", nullable: true),
                    salud_meds_frecuencia = table.Column<string>(type: "text", nullable: true),
                    salud_prods_mov = table.Column<bool>(type: "boolean", nullable: true),
                    salud_cual_prods_mov = table.Column<string>(type: "text", nullable: true),
                    hogar_nom_mam = table.Column<string>(type: "text", nullable: true),
                    hogar_ocu_mam = table.Column<string>(type: "text", nullable: true),
                    hogar_niv_ed_mam = table.Column<string>(type: "text", nullable: true),
                    hogar_nom_pap = table.Column<string>(type: "text", nullable: true),
                    hogar_ocu_pap = table.Column<string>(type: "text", nullable: true),
                    hogar_niv_ed_pap = table.Column<string>(type: "text", nullable: true),
                    hogar_nom_cui = table.Column<string>(type: "text", nullable: true),
                    hogar_par_cui = table.Column<string>(type: "text", nullable: true),
                    hogar_niv_ed_cui = table.Column<string>(type: "text", nullable: true),
                    hogar_tel_cui = table.Column<string>(type: "text", nullable: true),
                    hogar_ema_cui = table.Column<string>(type: "text", nullable: true),
                    hogar_num_her = table.Column<int>(type: "integer", nullable: true),
                    hogar_lug_ocu_est = table.Column<int>(type: "integer", nullable: true),
                    hogar_per_viv_e = table.Column<string>(type: "text", nullable: true),
                    hogar_apo_cri_e = table.Column<string>(type: "text", nullable: true),
                    hogar_baj_prot = table.Column<bool>(type: "boolean", nullable: true),
                    hogar_sub_inst_ent = table.Column<bool>(type: "boolean", nullable: true),
                    hogar_tip_sub = table.Column<string>(type: "text", nullable: true),
                    educativo_vinc_otr_inst = table.Column<bool>(type: "boolean", nullable: true),
                    educativo_cual_inst = table.Column<string>(type: "text", nullable: true),
                    educativo_no_inst = table.Column<string>(type: "text", nullable: true),
                    educativo_ult_grado = table.Column<string>(type: "text", nullable: true),
                    educativo_aprov_ult_grad = table.Column<bool>(type: "boolean", nullable: true),
                    educativo_obs_ult_grd = table.Column<string>(type: "text", nullable: true),
                    educativo_infm_ped = table.Column<bool>(type: "boolean", nullable: true),
                    educativo_inst_infm = table.Column<string>(type: "text", nullable: true),
                    educativo_prog_comp = table.Column<bool>(type: "boolean", nullable: true),
                    educativo_tipo_prog_comp = table.Column<string>(type: "text", nullable: true),
                    educativo_nom_inst = table.Column<string>(type: "text", nullable: true),
                    educativo_sed_inst = table.Column<string>(type: "text", nullable: true),
                    educativo_trans_inst = table.Column<string>(type: "text", nullable: true),
                    educativo_dist_int = table.Column<string>(type: "text", nullable: true),
                    diligenciamiento_dos_fec_dig_a2 = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    diligenciamiento_dos_inst_edu_a2 = table.Column<string>(type: "text", nullable: true),
                    diligenciamiento_dos_sed_a2 = table.Column<string>(type: "text", nullable: true),
                    diligenciamiento_dos_jor_a2 = table.Column<string>(type: "text", nullable: true),
                    diligenciamiento_dos_docs_ela = table.Column<string>(type: "text", nullable: true),
                    diligenciamiento_dos_grd_est = table.Column<string>(type: "text", nullable: true),
                    caracteristicas_estudiante_desc1est = table.Column<string>(type: "text", nullable: true),
                    caracteristicas_estudiante_desc2est = table.Column<string>(type: "text", nullable: true),
                    recomendaciones_acc_fam = table.Column<string>(type: "text", nullable: true),
                    recomendaciones_estr_fam = table.Column<string>(type: "text", nullable: true),
                    recomendaciones_acc_doc = table.Column<string>(type: "text", nullable: true),
                    recomendaciones_estr_doc = table.Column<string>(type: "text", nullable: true),
                    recomendaciones_acc_dir = table.Column<string>(type: "text", nullable: true),
                    recomendaciones_estr_dir = table.Column<string>(type: "text", nullable: true),
                    recomendaciones_acc_adm = table.Column<string>(type: "text", nullable: true),
                    recomendaciones_estr_adm = table.Column<string>(type: "text", nullable: true),
                    recomendaciones_acc_par = table.Column<string>(type: "text", nullable: true),
                    recomendaciones_estr_par = table.Column<string>(type: "text", nullable: true),
                    diligenciamiento_tres_fec_dil_a3 = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    diligenciamiento_tres_inst_edu_a30 = table.Column<string>(type: "text", nullable: true),
                    diligenciamiento_tres_doc_dir = table.Column<string>(type: "text", nullable: true),
                    diligenciamiento_tres_nom_fam = table.Column<string>(type: "text", nullable: true),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_piars", x => x.id);
                    table.ForeignKey(
                        name: "fk_piars_user_user_id",
                        column: x => x.id_uss,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_roles",
                columns: table => new
                {
                    role_id = table.Column<int>(type: "integer", nullable: false),
                    id_uss = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_roles", x => new { x.role_id, x.id_uss });
                    table.ForeignKey(
                        name: "fk_user_roles_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_user_roles_users_id_uss",
                        column: x => x.id_uss,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ajustes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    id_mat = table.Column<Guid>(type: "uuid", nullable: true),
                    desc_obj = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    fec_dil = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ajustes", x => x.id);
                    table.ForeignKey(
                        name: "fk_ajustes_materia_materia_id",
                        column: x => x.id_mat,
                        principalTable: "materias",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "barreras",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    id_mat = table.Column<Guid>(type: "uuid", nullable: true),
                    desc_barr = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    fec_dil = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_barreras", x => x.id);
                    table.ForeignKey(
                        name: "fk_barreras_materia_materia_id",
                        column: x => x.id_mat,
                        principalTable: "materias",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "evaluaciones",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    id_mat = table.Column<Guid>(type: "uuid", nullable: true),
                    desc_eva = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    fec_dil = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_evaluaciones", x => x.id);
                    table.ForeignKey(
                        name: "fk_evaluaciones_materia_materia_id",
                        column: x => x.id_mat,
                        principalTable: "materias",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "objetivos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    id_mat = table.Column<Guid>(type: "uuid", nullable: true),
                    desc_obj = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    fec_dil = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_objetivos", x => x.id);
                    table.ForeignKey(
                        name: "fk_objetivos_materias_materia_id",
                        column: x => x.id_mat,
                        principalTable: "materias",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "firmas_piar",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    id_piar = table.Column<Guid>(type: "uuid", nullable: true),
                    firma_sec_piar = table.Column<int>(type: "integer", nullable: true),
                    firma_file_piar = table.Column<byte[]>(type: "bytea", nullable: true),
                    firma_nom_fir = table.Column<string>(type: "text", nullable: true),
                    firma_are_fir = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_firmas_piar", x => x.id);
                    table.ForeignKey(
                        name: "fk_firmas_piar_piar_piar_id",
                        column: x => x.id_piar,
                        principalTable: "piars",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "materias_piar",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    id_piar = table.Column<Guid>(type: "uuid", nullable: true),
                    materia = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_materias_piar", x => x.id);
                    table.ForeignKey(
                        name: "fk_materias_piar_piar_piar_id",
                        column: x => x.id_piar,
                        principalTable: "piars",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ajustes_piar",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    id_mat = table.Column<Guid>(type: "uuid", nullable: true),
                    id_piar = table.Column<Guid>(type: "uuid", nullable: true),
                    sem_ajt = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ajustes_piar", x => x.id);
                    table.ForeignKey(
                        name: "fk_ajustes_piar_materia_piar_materia_piar_id",
                        column: x => x.id_mat,
                        principalTable: "materias_piar",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "barreras_piar",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    id_mat = table.Column<Guid>(type: "uuid", nullable: true),
                    id_piar = table.Column<Guid>(type: "uuid", nullable: true),
                    sem_barr = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_barreras_piar", x => x.id);
                    table.ForeignKey(
                        name: "fk_barreras_piar_materia_piar_materia_piar_id",
                        column: x => x.id_mat,
                        principalTable: "materias_piar",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "evaluaciones_piar",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    id_mat = table.Column<Guid>(type: "uuid", nullable: true),
                    id_piar = table.Column<Guid>(type: "uuid", nullable: true),
                    sem_eva = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_evaluaciones_piar", x => x.id);
                    table.ForeignKey(
                        name: "fk_evaluaciones_piar_materia_piar_materia_piar_id",
                        column: x => x.id_mat,
                        principalTable: "materias_piar",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "objetivos_piar",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    id_mat = table.Column<Guid>(type: "uuid", nullable: true),
                    id_obj = table.Column<Guid>(type: "uuid", nullable: true),
                    id_piar = table.Column<Guid>(type: "uuid", nullable: true),
                    sem_obj = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_objetivos_piar", x => x.id);
                    table.ForeignKey(
                        name: "fk_objetivos_piar_materias_piar_materia_piar_id",
                        column: x => x.id_mat,
                        principalTable: "materias_piar",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                table: "permissions",
                columns: new[] { "id", "nombre" },
                values: new object[,]
                {
                    { 1, "ReadUser" },
                    { 2, "WriteUser" },
                    { 3, "UpdateUser" }
                });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "SuperAdmin" },
                    { 2, "Admin" },
                    { 3, "Profesor" },
                    { 4, "Auxiliar" }
                });

            migrationBuilder.InsertData(
                table: "roles_permissions",
                columns: new[] { "permission_id", "role_id" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 3, 2 },
                    { 1, 3 },
                    { 2, 3 },
                    { 1, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "ix_ajustes_id_mat",
                table: "ajustes",
                column: "id_mat");

            migrationBuilder.CreateIndex(
                name: "ix_ajustes_piar_id_mat",
                table: "ajustes_piar",
                column: "id_mat");

            migrationBuilder.CreateIndex(
                name: "ix_barreras_id_mat",
                table: "barreras",
                column: "id_mat");

            migrationBuilder.CreateIndex(
                name: "ix_barreras_piar_id_mat",
                table: "barreras_piar",
                column: "id_mat");

            migrationBuilder.CreateIndex(
                name: "ix_evaluaciones_id_mat",
                table: "evaluaciones",
                column: "id_mat");

            migrationBuilder.CreateIndex(
                name: "ix_evaluaciones_piar_id_mat",
                table: "evaluaciones_piar",
                column: "id_mat");

            migrationBuilder.CreateIndex(
                name: "ix_firmas_piar_id_piar",
                table: "firmas_piar",
                column: "id_piar");

            migrationBuilder.CreateIndex(
                name: "ix_materias_id_uss",
                table: "materias",
                column: "id_uss");

            migrationBuilder.CreateIndex(
                name: "ix_materias_piar_id_piar",
                table: "materias_piar",
                column: "id_piar");

            migrationBuilder.CreateIndex(
                name: "ix_objetivos_id_mat",
                table: "objetivos",
                column: "id_mat");

            migrationBuilder.CreateIndex(
                name: "ix_objetivos_piar_id_mat",
                table: "objetivos_piar",
                column: "id_mat");

            migrationBuilder.CreateIndex(
                name: "ix_piars_id_uss",
                table: "piars",
                column: "id_uss");

            migrationBuilder.CreateIndex(
                name: "ix_roles_permissions_permission_id",
                table: "roles_permissions",
                column: "permission_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_roles_id_uss",
                table: "user_roles",
                column: "id_uss");

            migrationBuilder.CreateIndex(
                name: "ix_users_email",
                table: "users",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ajustes");

            migrationBuilder.DropTable(
                name: "ajustes_piar");

            migrationBuilder.DropTable(
                name: "barreras");

            migrationBuilder.DropTable(
                name: "barreras_piar");

            migrationBuilder.DropTable(
                name: "evaluaciones");

            migrationBuilder.DropTable(
                name: "evaluaciones_piar");

            migrationBuilder.DropTable(
                name: "firmas_piar");

            migrationBuilder.DropTable(
                name: "objetivos");

            migrationBuilder.DropTable(
                name: "objetivos_piar");

            migrationBuilder.DropTable(
                name: "outbox_messages");

            migrationBuilder.DropTable(
                name: "roles_permissions");

            migrationBuilder.DropTable(
                name: "user_roles");

            migrationBuilder.DropTable(
                name: "materias");

            migrationBuilder.DropTable(
                name: "materias_piar");

            migrationBuilder.DropTable(
                name: "permissions");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "piars");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}

namespace PiarServer.Api.Controllers.Piars;
public sealed record PiarUpdatePt3Request(
    string acc_fam,
    string estr_fam,
    string acc_doc,
    string estr_doc,
    string acc_dir,
    string estr_dir,
    string acc_adm,
    string estr_adm,
    string acc_par,
    string estr_par
);
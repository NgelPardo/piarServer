namespace PiarServer.Api.Controllers.Piars;

public sealed record PiarUpdatePt4Request(
    DateTime fec_dil_a3,
    string acts_apo,
    string doc_dir,
    string inst_edu_a3,
    string nom_fam,
    string compromisos
);
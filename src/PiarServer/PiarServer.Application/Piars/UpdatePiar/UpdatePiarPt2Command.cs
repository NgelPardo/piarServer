using PiarServer.Application.Abstractions.Messaging;

namespace PiarServer.Application.Piars.UpdatePiar;

public record UpdatePiarPt2Command(
    Guid id,
    DateTime fec_dig_a2,
    string inst_edu_a2,
    string sed_a2,
    string jor_a2,
    string docs_ela,
    string grd_est,
    string desc_1_est,
    string desc_2_est
) : ICommand<Guid>;
using Escola.Domain.Entities;
using Escola.Domain.Repositories.Disciplina;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Escola.Infrastructure.DataAccess.Repositories;
public class DisciplineRepository : IDisciplineReadOnlyRepository
{
    private readonly string _connectionString;
    private readonly EscolaDbContext _dbContext;

    public DisciplineRepository(EscolaDbContext context, IConfiguration configuration)
    {
        _dbContext = context;
        _connectionString = configuration.GetConnectionString("DefaultConnection")!;
    }
    public async Task<IList<Disciplina>> GetAll()
    {
        var disciplinas = new List<Disciplina>();

        using (var connection = new NpgsqlConnection(_connectionString))
        {
            var sql = "SELECT cod_disc, qtd_cred, nom_disc, cod_disc_equiv FROM disciplinas";
            await connection.OpenAsync();
            using (var command = new NpgsqlCommand(sql, connection)) 
            { 
                using(var reader = await command.ExecuteReaderAsync())
                {
                    while(await reader.ReadAsync())
                    {
                        disciplinas.Add(new Disciplina
                        {
                            CodDisc = reader.GetInt64(0),
                            QtdCred = reader.GetInt32(1),
                            NomDisc = reader.GetString(2),
                            CodDiscEquiv = reader.IsDBNull(3) ? 0 : reader.GetInt64(3)

                        });
                    }
                }
            }
        }

        return disciplinas;
    }

    public async Task<Disciplina> GetByCodDisciplina(long codDisc)
    {
        Disciplina? disciplina = null;

        using (var connection = new NpgsqlConnection(_connectionString))
        {
            var sql = "SELECT cod_disc, qtd_cred, nom_disc, cod_disc_equiv FROM disciplinas WHERE cod_disc = @cod_disc";
            await connection.OpenAsync();
            using (var command = new NpgsqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@cod_disc", codDisc);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        disciplina = new Disciplina
                        {
                            CodDisc = reader.GetInt64(0),
                            QtdCred = reader.GetInt32(1),
                            NomDisc = reader.GetString(2),
                            CodDiscEquiv = reader.IsDBNull(3) ? 0 : reader.GetInt64(3)
                        };
                    }
                }
            }
        }

        return disciplina!;
    }
}

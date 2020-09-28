using System;
using System.Collections.Generic;
using System.Linq;

namespace entra21_tests
{
    public class Election
    {
        // Propriedade abaixo:
        // Sempre em PascalCase
        public List<(Guid id, string name, string cpf, int votes)> Candidates { get; private set; }
        public bool CreateCandidates (List<(string name, string cpf)> candidate, string password)
        {
            if (password == "Pa$$w0rd")
            {
                Candidates = candidate.Select(candidate => {
                    return (Guid.NewGuid(), candidate.name, candidate.cpf, 0);
                }).ToList();

                return true;
            }
            else return false;
        }

        // ToDo: Este método deve retornar a lista de candidatos que tem o mesmo nome informado
        public List<Guid> GetCandidateIdByName(string name)
        {
            var candidateFound = Candidates.Where(x => x.name == name);
            return candidateFound.Select(x => x.id).ToList();
        }
        // ToDo: Criar método que retorne um Guid que represente o candidato pesquisado por CPF
        public Guid GetCandidateIdByCPF(string cpf)
        {
            return Candidates.Find(x => x.cpf == cpf).id;
        }
        public void Vote(Guid id)
        {
            Candidates = Candidates.Select(candidate => {
                return candidate.id == id
                    ? (candidate.id, candidate.name, candidate.cpf, candidate.votes + 1)
                    : candidate;
            }).ToList();
        }
        public List<(Guid id, string name, string cpf, int votes)> GetWinners()
        {
            var winners = new List<(Guid id, string name, string cpf, int votes)>{Candidates[0]};

            for (int i = 1; i < Candidates.Count; i++)
            {
                if (Candidates[i].votes > winners[0].votes)
                {
                    winners.Clear();
                    winners.Add(Candidates[i]);
                }
                else if (Candidates[i].votes == winners[0].votes)
                {
                    winners.Add(Candidates[i]);
                }
            }
            return winners;
        }
    }
}
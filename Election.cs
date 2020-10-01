using System;
using System.Collections.Generic;
using System.Linq;

namespace entra21_tests
{
    public class Election
    {
        // Esta propriedade tem a sua escrita privada, ou seja, ninguém de fora da classe pode alterar seu valor
        // Propriedade privada SEMPRE em camelcase
        private List<Candidate> candidates { get; set; }

        // Propriedade pública SEMPRE em PascalCase
        // Propriedade apenas com GET pode ser usada com arrow
        public IReadOnlyCollection<Candidate> Candidates => candidates;
        public bool CreateCandidates (List<Candidate> candidate, string password)
        {
            if (password == "Pa$$w0rd")
            {
                candidates = candidate;

                return true;
            }
            else return false;
        }

        // ToDo: Este método deve retornar a lista de candidatos que tem o mesmo nome informado
        public List<Guid> GetCandidateIdByName(string name)
        {
            return candidates.Where(x => x.name == name).id;
        }
        public List<(Guid id, string name, string cpf, int votes)> GetCandidatesByName(string name)
        {
            var candidatesFound = candidates.Where(x => x.name == name);
            return candidatesFound.ToList();
        }
        // ToDo: Criar método que retorne um Guid que represente o candidato pesquisado por CPF
        public Guid GetCandidateIdByCPF(string cpf)
        {
            return candidates.Find(x => x.cpf == cpf).id;
        }
        public void Vote(Guid id)
        {
            candidates = candidates.Select(candidate => {
                return candidate.id == id
                    ? (candidate.id, candidate.name, candidate.cpf, candidate.votes + 1)
                    : candidate;
            }).ToList();
        }
        public List<(Guid id, string name, string cpf, int votes)> GetWinners()
        {
            var winners = new List<(Guid id, string name, string cpf, int votes)>{candidates[0]};

            for (int i = 1; i < candidates.Count; i++)
            {
                if (candidates[i].votes > winners[0].votes)
                {
                    winners.Clear();
                    winners.Add(candidates[i]);
                }
                else if (candidates[i].votes == winners[0].votes)
                {
                    winners.Add(candidates[i]);
                }
            }
            return winners;
        }
    }
}
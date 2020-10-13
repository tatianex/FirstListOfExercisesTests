using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class Election
    {
        public Election()
        {
            _candidates = new List<Candidate>();
        }
        // Esta propriedade tem a sua escrita privada, ou seja, ninguém de fora da classe pode alterar seu valor
        // Propriedade privada SEMPRE em camelcase
        private List<Candidate> _candidates { get; set; }

        // Propriedade pública SEMPRE em PascalCase
        // Propriedade apenas com GET pode ser usada com arrow
        public IReadOnlyCollection<Candidate> Candidates => _candidates;
        public bool CreateCandidates (List<Candidate> candidates, string password)
        {
            if (password == "Pa$$w0rd")
            {
                if (candidates == null) return true;
                _candidates = candidates;
                return true;
            }
            return false;
        }

        public Guid GetCandidateIdByName(string name)
        {
            return _candidates.First(x => x.Name == name).Id;
        }

        // ToDo: Este método deve retornar a lista de candidatos que tem o mesmo nome informado
        public List<Candidate> GetCandidatesByName(string name)
        {
           return _candidates.Where(candidate => candidate.Name == name).ToList();
        }

        // ToDo: Criar método que retorne um Guid que represente o candidato pesquisado por CPF
        public Guid GetCandidateIdByCPF(string cpf)
        {
            return _candidates.Find(x => x.CPF == cpf).Id;
        }
        
        public List<Candidate> GetWinners()
        {
            var winners = new List<Candidate>{_candidates[0]};

            for (int i = 1; i < _candidates.Count; i++)
            {
                if (_candidates[i].Votes > winners[0].Votes)
                {
                    winners.Clear();
                    winners.Add(_candidates[i]);
                }
                else if (_candidates[i].Votes == winners[0].Votes)
                {
                    winners.Add(_candidates[i]);
                }
            }
            return winners;
        }
    }
}
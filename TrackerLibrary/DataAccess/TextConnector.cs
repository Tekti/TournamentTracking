﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;
using TrackerLibrary.DataAccess.TextHelpers;
using System.Runtime.InteropServices;

namespace TrackerLibrary.DataAccess
{
    public class TextConnector : IDataConnection
    {
        private const string PrizesFile = "PrizesModels.csv";
        private const string PeopleFile = "PersonModels.csv";
        private const string TeamFile = "TeamModels.csv";

        /// <summary>
        /// Saves a new prize to the textFile
        /// </summary>
        /// <param name="model">The prize infromation</param>
        /// <returns>The prize information, including the unique identifier.</returns>
        public PrizeModel CreatePrize(PrizeModel model)
        {
            List<PrizeModel> prizes = PrizesFile.FullFilePath().LoadFile().ConvertToPrizeModels();

            int currentId = 1;

            if (prizes.Count() > 0)
            {
                currentId = prizes.OrderByDescending(x => x.Id).First().Id + 1;
            }

            model.Id = currentId;

            prizes.Add(model);

            prizes.SaveToPrizeFile(PrizesFile);

            return model;
        }

        public PersonModel CreatePerson(PersonModel person)
        {
            List<PersonModel> people = PeopleFile.FullFilePath().LoadFile().ConvertToPersonModels();

            int currentId = 1;

            if (people.Count() > 0)
            {
                currentId = people.OrderByDescending(x => x.Id).First().Id + 1;
            }

            person.Id = currentId;

            people.Add(person);

            people.SaveToPersonFile(PeopleFile);

            return person;
        }

        public List<PersonModel> GetPerson_All()
        {
            return PeopleFile.FullFilePath().LoadFile().ConvertToPersonModels();
        }

        public TeamModel CreateTeam(TeamModel model)
        {
            List<TeamModel> teams = TeamFile.FullFilePath().LoadFile().ConvertToTeamModels(PeopleFile);

            int currentId = 1;

            if (teams.Count() > 0)
            {
                currentId = teams.OrderByDescending(x => x.Id).First().Id + 1;
            }

            model.Id = currentId;

            teams.Add(model);

            teams.SaveToTeamFile(TeamFile);

            return model;
        }

        public List<TeamModel> GetTeam_All()
        {
            return TeamFile.FullFilePath().LoadFile().ConvertToTeamModels(PeopleFile);
        }
    }
}

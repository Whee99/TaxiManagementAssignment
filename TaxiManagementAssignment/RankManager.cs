using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiManagementAssignment
{ // start of namespace
	public class RankManager
	{ // start of class RankManager
		public Dictionary<int, Rank> ranks = new Dictionary<int, Rank>();

		public RankManager()
		{ // start of RankManager
			Rank first = new Rank(1, 5);
			ranks.Add(1, first);
			Rank second = new Rank(1, 2);
			ranks.Add(2, second);
			Rank third = new Rank(1, 4);
			ranks.Add(3, third);
		} // end of RankManager

		public bool AddTaxiToRank(Taxi t, int rankId)
        {
			return true;
        }

		public Rank FindRank(int rankId)
		{ // start of FindRank
			if (ranks.GetValueOrDefault(rankId) == default) {
				return null;
			}
            else {
				return ranks.GetValueOrDefault(rankId);
			}
		} // end of FindRank


	} // end of class RankManager
} // end of namespace


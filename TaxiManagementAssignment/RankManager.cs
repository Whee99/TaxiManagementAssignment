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
			Rank second = new Rank(2, 2);
			ranks.Add(2, second);
			Rank third = new Rank(3, 4);
			ranks.Add(3, third);
		} // end of RankManager

		public bool AddTaxiToRank(Taxi t, int rankId)
		{ // start of AddTaxiToRank
			// Check if rank exists or not
			if (ranks.ContainsKey(rankId) == false) {
				return false;
			}
			else if (t.Rank == ranks[rankId]) {
				return false;
			}
			else if (ranks.ContainsValue(t.Rank)) {
				return false;
            }
            else if (t.Destination.Length > 0) {
				return false;
			}
            else {
				return ranks[rankId].AddTaxi(t);
			}
		} // end of AddTaxiToRank

		public Taxi FrontTaxiInRankTakesFare(int rankId, string destination, double agreedPrice)
		{ // start of FrontTaxiInRankTakesFare
			if (ranks.ContainsKey(rankId) == false) {
				return null;
			}
			else if (ranks[rankId].TaxiSpace.Count == 0) {
				return null;
			}
            else {
				return ranks[rankId].FrontTaxiTakesFare(destination, agreedPrice);
			}
		} // end of FrontTaxiInRankTakesFare

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


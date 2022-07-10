namespace BlackjackTrainer;

public class OptimalMoveProvider : IOptimalMoveProvider
{
    public PlayerMove GetOptimalMove(CardValue dealerUpcard, List<CardValue> hand)
    {
        if (hand.Count == 2 && hand.Distinct().Count() == 1)
        {
            return GetOptimalPairMove(dealerUpcard, hand);
        }

        if (hand.Contains(CardValue.Ace))
        {
            return GetOptimalSoftMove(dealerUpcard, hand);
        }

        return GetOptimalHardMove(dealerUpcard, hand);
    }

    private static PlayerMove GetOptimalHardMove(CardValue dealerUpcard, List<CardValue> hand)
    {
        throw new NotImplementedException();
    }

    private static PlayerMove GetOptimalSoftMove(CardValue dealerUpcard, List<CardValue> hand)
    {
        throw new NotImplementedException();
    }

    private static PlayerMove GetOptimalPairMove(CardValue dealerUpcard, List<CardValue> hand)
    {
        var card = hand.FirstOrDefault();
        return card switch
        {
            CardValue.Ace or CardValue.Eight => PlayerMove.Split,
            CardValue.Five or CardValue.Ten => GetOptimalHardMove(dealerUpcard, hand),
            CardValue.Nine when dealerUpcard 
                is not CardValue.Seven or CardValue.Ten or CardValue.Ace => PlayerMove.Split,
            CardValue.Nine => GetOptimalHardMove(dealerUpcard, hand),
            CardValue.Seven when dealerUpcard <= CardValue.Seven => PlayerMove.Split,
            CardValue.Seven => GetOptimalHardMove(dealerUpcard, hand),
            CardValue.Six when dealerUpcard is CardValue.Two => PlayerMove.SplitIfCanDouble,
            CardValue.Six when dealerUpcard <= CardValue.Six => PlayerMove.Split,
            CardValue.Six => GetOptimalHardMove(dealerUpcard, hand),
            CardValue.Four when dealerUpcard is CardValue.Five or CardValue.Six => PlayerMove.SplitIfCanDouble,
            CardValue.Four => GetOptimalHardMove(dealerUpcard, hand),
            CardValue.Three when dealerUpcard is CardValue.Two or CardValue.Three => PlayerMove.SplitIfCanDouble,
            CardValue.Three when dealerUpcard >= CardValue.Seven => PlayerMove.Split,
            CardValue.Three => GetOptimalHardMove(dealerUpcard, hand),
            CardValue.Two when dealerUpcard is CardValue.Two or CardValue.Three => PlayerMove.SplitIfCanDouble,
            CardValue.Two when dealerUpcard <= CardValue.Seven => PlayerMove.Split,
            _ => GetOptimalHardMove(dealerUpcard, hand)
        };
    }
}
namespace BlackjackTrainer;

public interface IOptimalMoveProvider
{
    PlayerMove GetOptimalMove(CardValue dealerUpcard, List<CardValue> hand);
}
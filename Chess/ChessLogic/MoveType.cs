namespace ChessLogic
{
    public enum MoveType
    {
        Normal, //Normalne ruchy pionków
        CastleKS, //roszada ze strony króla
        CastleQS, //roszada ze strony hetmana
        DoublePawn, //ruch pionka gdzie może sie ruchyć o dwa do przodu zamiast jeden na początku
        EnPassant, //En Passant
        PawnPromotion //awans
    }
}

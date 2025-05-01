namespace ChessLogic
{
    public enum Player
    {
        None, //zwycięzca musi być wybrany, ale kiedy jest remis zwycięzcą jest null
        White,
        Black
    }

    public static class PlayerExtentions
    {
        public static Player Opponent(this Player player)
        {
            return player switch
            {
                Player.White => Player.Black,
                Player.Black => Player.White,
                _ => Player.None, //oryginalnie switch case ale skompilowane na prostsze
            };
        }
    }
}

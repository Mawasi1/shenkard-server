using System.Collections.Generic;
using Card_package;
using Game_package;
using Location_package;
using Player_package;

class GameController
{
    private GameService gameService = GameService.getInstance();

    public Game putCardToLocation(Player player, int locationId, int cardId, Game game)
    {

        ILocation location = getLocationById(game, locationId);
        ICard card = getCardById(cardId, player);
        if (card == null || location == null)
        {
            return null;
        }

        return gameService.putCardToLocation(player, location, card, game);

    }

    private ILocation getLocationById(Game game, int id)
    {
        foreach (ILocation location in game.locations)
        {
            if (location.id == id)
            {
                return location;
            }
        }
        return null;
    }
    private ICard getCardById(int id, Player player)
    {
        foreach (ICard card in player.displayedCards)
        {
            if (card.id == id)
            {
                return card;
            }
        }
        return null;
    }

    public bool endTurn(Game game)
    {
        return game.endTurn();
    }
    public Game askForGame(int id1, int id2)
    {
        return gameService.askForGame(id1, id2);

    }
    public List<int> startBattle(Game game)
    {
        return gameService.startBattle(game);
    }

}